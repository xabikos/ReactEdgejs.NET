using System;

namespace ReactEdge
{
    public class ReactConfiguration : IReactConfiguration
    {
        static ReactConfiguration()
        {
            Configuration = new ReactConfiguration();
        }

        public static IReactConfiguration Configuration { get; set; }

        public string GeneratedScriptContent { get; set; }

        public bool UseInternalReactScript { get; set; }

        public bool UseServerSideRouting { get; set; }

        public IReactConfiguration SetGeneratedScriptContent(string generatedScriptPath)
        {
            GeneratedScriptContent = generatedScriptPath;
            return this;
        }

        public IReactConfiguration SetUseInternalReactScript(bool useInternalReactScript)
        {
            UseInternalReactScript = useInternalReactScript;
            return this;
        }

        public IReactConfiguration SetUseServerSideRouting(bool useServerSideRendering, string routesJson = null)
        {
            UseServerSideRouting = useServerSideRendering;
            return this;
        }
    }
}
