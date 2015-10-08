using System;
using System.IO;

namespace ReactEdge.Sample.Mvc5
{
    public class ReactConfig
    {
        public static void Configure(string generatedScriptPath)
        {
            ReactConfiguration.Configuration
                .SetUseServerSideRouting(false)
                .SetUseInternalReactScript(false)
                .SetGeneratedScriptContent(File.ReadAllText(generatedScriptPath));
        }
    }
}