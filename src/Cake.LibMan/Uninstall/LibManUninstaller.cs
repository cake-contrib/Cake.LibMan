using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;

namespace Cake.LibMan.Uninstall
{
    /// <summary>
    /// Tool for uninstalling libman client side libraries
    /// </summary>
    public class LibManUninstaller : LibManTool<LibManUninstallSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibManUninstaller"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public LibManUninstaller(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICakeLog log)
            : base(fileSystem, environment, processRunner, tools, log)
        { }

        /// <summary>
        /// Deletes all files associated with the specified library from the destination in libman.json. Also removes the associated library configuration from libman.json.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Uninstall(LibManUninstallSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            RunCore(settings);
        }
    }
}
