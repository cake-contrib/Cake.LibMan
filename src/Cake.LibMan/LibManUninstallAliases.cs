using Cake.Core;
using Cake.Core.Annotations;
using Cake.LibMan.Uninstall;
using System;

namespace Cake.LibMan
{
    /// <summary>
    /// LibMan Uninstall aliases
    /// </summary>
    [CakeAliasCategory("LibMan")]
    [CakeNamespaceImport("Cake.LibMan.Install")]
    public static class LibManUninstallAliases
    {
        /// <summary>
        /// Uninstalls client side libraries using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <para> Uninstalls client side libraries using the settings ('libman uninstall')</para>
        /// <code>
        /// <![CDATA[
        ///    LibManUninstall(settings =>
        ///    {
        ///        settings
        ///            .SetLibrary("jquery")
        ///            .WithVerbosity(LibManVerbosity.Detailed)
        ///            .FromPath(@"c:\myproject");
        ///    });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Uninstall")]
        public static void LibManUninstall(this ICakeContext context, Action<LibManUninstallSettings> configurator)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (configurator == null)
                throw new ArgumentNullException(nameof(configurator));

            var settings = new LibManUninstallSettings();
            configurator(settings);
            context.LibManUninstall(settings);
        }

        /// <summary>
        /// Uninstalls client side libraries using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para> Uninstalls client side libraries in a specific working directory ('libman uninstall')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = new LibManUninstallSettings
        ///        {
        ///            WorkingDirectory = @"c:\myproject",
        ///            Verbosity = LibManVerbosity.Detailed,
        ///            Library = "jquery"
        ///        };
        ///     LibManUninstall(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Uninstall")]
        public static void LibManUninstall(this ICakeContext context, LibManUninstallSettings settings)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            LibManAddinInformation.LogVersionInformation(context.Log);
            var uninstaller = new LibManUninstaller(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            uninstaller.Uninstall(settings);
        }
    }
}
