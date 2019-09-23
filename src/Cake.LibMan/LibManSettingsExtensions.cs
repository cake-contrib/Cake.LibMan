using Cake.Core.IO;
using System;

namespace Cake.LibMan
{
    /// <summary>
    /// Extensions for <see cref="LibManSettings"/>.
    /// </summary>
    public static class LibManSettingsExtensions
    {
        /// <summary>
        /// Sets the verbosity level which should be used to run the libman command.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="verbosity">Log level which should be used to run the libman command.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="LibManSettings.Verbosity"/> set to <paramref name="verbosity"/>.</returns>
        public static LibManSettings WithVerbosity(this LibManSettings settings, LibManVerbosity verbosity)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            settings.Verbosity = verbosity;

            return settings;
        }

        /// <summary>
        /// Sets the working directory which should be used to run the libman command.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="path">Working directory which should be used to run the libman command.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="Core.Tooling.ToolSettings.WorkingDirectory"/> set to <paramref name="path"/>.</returns>
        public static LibManSettings FromPath(this LibManSettings settings, DirectoryPath path)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            settings.WorkingDirectory = path ?? throw new ArgumentNullException(nameof(path));

            return settings;
        }
    }
}
