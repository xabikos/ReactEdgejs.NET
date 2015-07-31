using System;

namespace ReactEdge
{
    public interface IReactConfiguration
    {
        bool UseInternalReactScript { get; }
        IReactConfiguration SetUseInternalReactScript(bool useInternalReactScript);

        bool UseServerSideRouting { get; }
        IReactConfiguration SetUseServerSideRouting(bool useServerSideRendering, string routesJson = null);

        string GeneratedScriptContent { get; }
        IReactConfiguration SetGeneratedScriptContent(string generatedScriptPath);
    }
}
