using System;

namespace ReactEdge
{
    public interface IReactConfiguration
    {
        bool UseInternalReactScript { get; }
        IReactConfiguration SetUseInternalReactScript(bool useInternalReactScript);

        bool UseServerSideRendering { get; }
        IReactConfiguration SetUseServerSideRendering(bool useServerSideRendering);

        string GeneratedScriptContent { get; }
        IReactConfiguration SetGeneratedScriptContent(string generatedScriptPath);
    }
}
