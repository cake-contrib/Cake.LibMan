using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;

namespace Cake.LibMan.Cache
{
    /// <summary>
    /// Tool for clearing the cache for a cdn provider or all cdn providers.
    /// </summary>
    public class LibManCacheCleanTool : LibManTool<LibManCacheCleanSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibManCacheCleanTool"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public LibManCacheCleanTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICakeLog log)
            : base(fileSystem, environment, processRunner, tools, log)
        { }

        /// <summary>
        /// Clears library cache using the specified <see cref="LibManCacheCleanSettings"/> settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void CacheClean(LibManCacheCleanSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            RunCore(settings);
        }
    }
}
