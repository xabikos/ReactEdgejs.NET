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
              var path = data.route.path ? data.route.path : '/';
              var queryString = data.route.queryString ? data.route.queryString : '';
              var location = new Location(path, queryString);

              Router.run(Routes, location, function(error, initialState, transition) {
                result = React.renderToString(React.createElement(Router, React.__spread({},  initialState)));
              });

              callback(null, result);
            }";

        public ReactContext(IReactConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<string> GetHtml(string componentName, object props, Route route = null)
        {
            EnsureReactIsInitialized();
            if (_config.UseServerSideRouting)
            {
                EnsureServerSideRoutingIsInitialized();
                if(route == null)
                {
                    throw new RouteNullReferenceException("When using server side rendering the route parameter should not be null.");
                }
                var env = Edge.Func(GetScript());
                var res = await env(new {
                    componentName = componentName,
                    dataProps = props,
                    route = new { path = route.Path, queryString = route.QueryString }
                });
                return res.ToString();
            }
            var environment = Edge.Func(GetScript());
            var result = await environment(new { componentName = componentName, dataProps = props });
            return result.ToString();
        }

        public async Task<string> GetHtmlForRoute(object props, Route route)
        {
            EnsureReactIsInitialized();
            if (!_config.UseServerSideRouting)
            {
                throw new ServerSideRoutingNotEnabledException("You must enable server side routing when using GetHtmlForRoute method");
            }
            EnsureServerSideRoutingIsInitialized();
            if (route == null)
            {
                throw new RouteNullReferenceException("When using server side rendering the route parameter should not be null.");
            }
            var env = Edge.Func(GetScript());
            var res = await env(new
            {
                dataProps = props,
                route = new { path = route.Path, queryString = route.QueryString }
            });
            return res.ToString();
        }

        private void EnsureReactIsInitialized()
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


        private void EnsureServerSideRoutingIsInitialized()
        {
            const string reactRouterIsInstalledScript = @"
                require('react-router');
                var routes = Routes;
                return function (data, callback) {
                    callback(null, {});
                }";
            try
            {
                var env = Edge.Func(_config.GeneratedScriptContent + reactRouterIsInstalledScript);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException != null &&
                    ex.InnerException.Message.IndexOf("Cannot find module 'react-router'", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new ReactRouterNotInstalledException("React Router node package is not installed. Please execute 'npm install react-router' in the execution folder.");
                }
                if(ex.InnerException != null &&
                    ex.InnerException.Message.IndexOf("Routes is not defined", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new RoutesNotExposedException("Routes is not exposed in the global scope. Try to use expose loader.");
                }
                throw ex;
            }
        }

        private string GetScript()
        {
            var result = string.Empty;
            result += _config.UseInternalReactScript ?
                "var React = require('react');"
                : string.Empty;

            result += _config.UseServerSideRouting ?
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
                    throw new ReactNotInstalledException("React node package is not installed. Please execute 'npm install react' in the execution folder.");
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
