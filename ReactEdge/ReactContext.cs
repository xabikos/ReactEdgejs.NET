using System.Threading.Tasks;
using EdgeJs;

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
            var environment = Edge.Func(GetScript());
            var result = await environment(new { componentName = componentName, dataProps = props });
            return result.ToString();
        }

        protected string GetScript()
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

    }
}
