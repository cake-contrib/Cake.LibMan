using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;

namespace Cake.LibMan.Clean
{
    /// <summary>
    /// Tool for running npm scripts.
    /// </summary>
    public class LibManCleanTool : LibManTool<LibManCleanSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibManCleanTool"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public LibManCleanTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICakeLog log)
            : base(fileSystem, environment, processRunner, tools, log)
        { }

        /// <summary>
        ///  Deletes library files previously restored via LibMan. Folders that become empty after this operation are deleted.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Clean(LibManCleanSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            RunCore(settings);
        }
    }
}
