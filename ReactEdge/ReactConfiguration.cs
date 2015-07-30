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

        public bool UseServerSideRendering { get; set; }

        public IReactConfiguration SetGeneratedScriptContent(string generatedScriptPath)
        {
            GeneratedScriptContent = generatedScriptPath;
            return this;
        }

        public IReactConfiguration SetUseServerSideRendering(bool useServerSideRendering)
        {
            UseServerSideRendering = useServerSideRendering;
            return this;
        }
    }
}
