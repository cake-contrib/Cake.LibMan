using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;

namespace Cake.LibMan.Install
{
    /// <summary>
    /// Tool for installing libman client side libraries
    /// </summary>
    public class LibManInstaller : LibManTool<LibManInstallSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibManInstaller"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public LibManInstaller(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICakeLog log)
            : base(fileSystem, environment, processRunner, tools, log)
        { }

        /// <summary>
        /// Installs library files into the project using the specified <see cref="LibManInstallSettings"/> settings. A libman.json file is added if one doesn't exist. The libman.json file is modified to store configuration details for the library files.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Install(LibManInstallSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            RunCore(settings);
        }
    }
}
