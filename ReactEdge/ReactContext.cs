using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgeJs;

namespace ReactEdge
{
    public class ReactContext : IReactContext
    {
        private readonly IReactConfiguration _config;
        private Func<object, Task<object>> environment;

        private readonly string reactServer = @"
                        return function (data, callback) {
                            var result;
                            result = React.renderToString(React.createElement(eval(data.componentName), data.dataProps));
                            callback(null, result);
                        }";

        public ReactContext(IReactConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<string> GetHtml(string componentName, object props)
        {
            var finalScript = _config.GeneratedScriptContent + reactServer;
            environment = Edge.Func(finalScript);
            var result = await environment(new { componentName = componentName, dataProps = props });
            return result.ToString();
        }
    }
}
