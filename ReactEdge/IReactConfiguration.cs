using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactEdge
{
    public interface IReactConfiguration
    {

        bool UseServerSideRendering { get; }
        IReactConfiguration SetUseServerSideRendering(bool useServerSideRendering);

        string GeneratedScriptContent { get; }
        IReactConfiguration SetGeneratedScriptContent(string generatedScriptPath);
    }
}
