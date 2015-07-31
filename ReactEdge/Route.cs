using System;

namespace ReactEdge
{
    /// <summary>
    /// Used to hold the data for server side routing
    /// </summary>
    public class Route
    {
        public Route(string path, string queryString)
        {
            Path = path;
            QueryString = queryString;
        }

        /// <summary>
        /// The path of the requested route
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// The query string of the requested route
        /// </summary>
        public string QueryString { get; private set; }
    }
}
