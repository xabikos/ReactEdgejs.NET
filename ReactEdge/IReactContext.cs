using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactEdge
{
    interface IReactContext
    {
        Task<string> GetHtml(string componentName, object props, Route route = null);
    }
}
