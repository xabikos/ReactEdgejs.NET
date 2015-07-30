using ReactEdge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactTest
{
    class Program
    {

        static string GeneratedScript = @"
                var HelloMessage = React.createClass({displayName: ""HelloMessage"",
                  render: function()
                        {
                            return React.createElement(""div"", null, ""Hello "", this.props.name);
                        }
                    });";

        static void Main(string[] args)
        {
            ReactConfiguration.Configuration
                .SetGeneratedScriptContent(GeneratedScript)
                .SetUseInternalReactScript(true);

            var reactContext = new ReactContext(ReactConfiguration.Configuration);
            var result = reactContext.GetHtml("HelloMessage", new { name = "Babis" }).Result;
        }
    }
}
