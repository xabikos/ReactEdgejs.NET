using System;
using System.Threading.Tasks;
using EdgeJs;
using ReactEdge.Exceptions;

namespace ReactEdge
{
    public class ReactContext : IReactContext
    {
        private readonly IReactConfiguration _config;

        private const string edgeCallback = @"
                        return function (data, callback) {
                            var result;
                            result = React.renderToString(React.createElement(eval(data.componentName), data.dataProps));
                            callback(null, result);
                        }";

        private const string edgeCallbackServerSideRendering = @"
                        var Location = require('react-router/lib/Location');
                        var Router = ReactRouter.Router;

                        return function (data, callback) {
                          var result;
                          var location = new Location(data.route.path, data.route.query);

                          Router.run(Routes, location, function(error, initialState, transition) {
                            result = React.renderToString(React.createElement(Router, React.__spread({},  initialState)));
                          });

                          callback(null, result);
                        }";

        public ReactContext(IReactConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<string> GetHtml(string componentName, object props)
        {
            EnsureReactIsInitialized();
            var environment = Edge.Func(GetScript());
            var result = await environment(new { componentName = componentName, dataProps = props });
            return result.ToString();
        }

        protected void EnsureReactIsInitialized()
        {
            if (_config.UseInternalReactScript)
            {
                EnsureReactIsInstalled();
            }
            else
            {
                EnsureReactIsExposed();
            }
        }

        private string GetScript()
        {
            var result = string.Empty;
            result += _config.UseInternalReactScript ?
                "var React = require('react');"
                : string.Empty;

            result += _config.UseServerSideRendering ?
                _config.GeneratedScriptContent + edgeCallbackServerSideRendering :
                _config.GeneratedScriptContent + edgeCallback;

            return result;
        }

        private static void EnsureReactIsInstalled()
        {
            const string reactIsInstalledScript = @"
                    require('react');
                    return function (data, callback) {
                      callback(null, {});
                    }";
            try
            {
                var env = Edge.Func(reactIsInstalledScript);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException != null &&
                    ex.InnerException.Message.IndexOf("Cannot find module 'react'", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new ReactNotInstalledException("React node package is not properly installed. Please execute 'npm install react' in the execution folder.");
                }
                throw ex;
            }
        }

        private void EnsureReactIsExposed()
        {
            const string reactIsExposedScript = @"
                        React.createElement('div', null);
                        return function (data, callback) {
                            callback(null, {});
                        }";
            try
            {
                var env = Edge.Func(_config.GeneratedScriptContent + reactIsExposedScript);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException != null &&
                    ex.InnerException.Message.IndexOf("React is not defined", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new ReactNotExposedException("React is not exposed in the global scope. Try to use expose loader.");
                }
                throw ex;
            }
        }

    }
}
