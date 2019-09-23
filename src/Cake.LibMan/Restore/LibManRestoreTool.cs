using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;

namespace Cake.LibMan.Restore
{
    /// <summary>
    /// Tool for restoring libman client side libraries
    /// </summary>
    public class LibManRestoreTool : LibManTool<LibManRestoreSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibManRestoreTool"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public LibManRestoreTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICakeLog log)
            : base(fileSystem, environment, processRunner, tools, log)
        { }

        /// <summary>
        ///  Installs client side library files defined in libman.json. 
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Restore(LibManRestoreSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            RunCore(settings);
        }
    }
}
