using ReactEdge;
using System;
using System.IO;

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
            var generatedScript = File.ReadAllText("app.bundle.js");
            ReactConfiguration.Configuration
                .SetGeneratedScriptContent(generatedScript)
                .SetUseInternalReactScript(true)
                .SetUseServerSideRouting(true);

            var reactContext = new ReactContext(ReactConfiguration.Configuration);
            try {
                var result = reactContext.GetHtml("HelloMessage", new { name = "Babis" }, new Route("/", "")).Result;
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            Console.ReadLine();
        }
    }
}
