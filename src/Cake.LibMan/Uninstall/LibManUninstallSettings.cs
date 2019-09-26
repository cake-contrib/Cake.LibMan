using Cake.Core;
using Cake.Core.IO;
using System;

namespace Cake.LibMan.Uninstall
{
    /// <summary>
    /// Contains settings used by <see cref="LibManUninstaller"/>.
    /// </summary>
    public class LibManUninstallSettings : LibManSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibManUninstallSettings"/> class.
        /// </summary>
        public LibManUninstallSettings()
            : base("uninstall")
        { }

        /// <summary>
        /// The name of the library to uninstall. This name may include version number notation (for example, @1.2.0).
        /// </summary>
        public string Library { get; set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            if (string.IsNullOrWhiteSpace(Library))
                throw new ArgumentNullException(nameof(Library), "Must provide library name.");

            args.Append(Library);
        }
    }
}
