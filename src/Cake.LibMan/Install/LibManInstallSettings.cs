using Cake.Core;
using Cake.Core.IO;
using System;
using System.Collections.Generic;

namespace Cake.LibMan.Install
{
    /// <summary>
    /// Contains settings used by <see cref="LibManInstaller"/>.
    /// </summary>
    public class LibManInstallSettings : LibManSettings
    {
        private readonly List<FilePath> _files = new List<FilePath>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LibManInstallSettings"/> class.
        /// </summary>
        public LibManInstallSettings()
            : base("install")
        { }

        /// <summary>
        /// The name of the library to install. This name may include version number notation (for example, @1.2.0).
        /// This is required.
        /// </summary>
        public string Library { get; set; }

        /// <summary>
        /// The location to install the library. If not specified, the default location is used. If no defaultDestination property is specified in libman.json, this option is required.
        /// </summary>
        public DirectoryPath Destination { get; set; }

        /// <summary>
        /// Specify the name of the file to install from the library. If not specified, all files from the library are installed. Provide one --files option per file to be installed. Relative paths are supported too. For example: --files dist/browser/signalr.js.
        /// </summary>
        public IList<FilePath> Files => _files;

        /// <summary>
        /// The name of the provider to use for the library acquisition.  If not specified, the defaultProvider property in libman.json is used. If no defaultProvider property is specified in libman.json, this option is required.
        /// </summary>
        public CdnProvider Provider { get; set; } = CdnProvider.Default;

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            const string separator = " ";

            base.EvaluateCore(args);

            if (string.IsNullOrWhiteSpace(Library))
                throw new ArgumentNullException(nameof(Library), $"Missing required {nameof(Library)} property.");

            args.Append(Library);

            if (Destination != null)
                args.AppendSwitchQuoted("--destination", separator, Destination.FullPath);

            if (Provider != CdnProvider.Default)
                args.AppendSwitch("--provider", separator, Provider.ToString());

            foreach (var file in Files)
                args.AppendSwitchQuoted("--files", separator, file.FullPath);
        }
    }
}
