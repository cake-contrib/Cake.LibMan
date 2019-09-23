using Cake.Core;
using Cake.Core.Annotations;
using Cake.LibMan.Install;
using System;

namespace Cake.LibMan
{
    /// <summary>
    /// LibMan Install aliases
    /// </summary>
    [CakeAliasCategory("LibMan")]
    [CakeNamespaceImport("Cake.LibMan.Install")]
    public static class LibManInstallAliases
    {
        /// <summary>
        /// Installs client side libraries for the project in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     LibManInstall();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public static void LibManInstall(this ICakeContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.LibManInstall(new LibManInstallSettings());
        }

        /// <summary>
        /// Installs client side libraries using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <para> Installs client side libraries using the settings ('libman install')</para>
        /// <code>
        /// <![CDATA[
        ///    LibManInstall(settings =>
        ///    {
        ///        settings
        ///            .SetLibrary("jquery", "3.2.1")
        ///            .WithProvider(CdnProvider.jsdelivr)
        ///            .WithDestination("wwwroot/lib/jquery")
        ///            .AddFile("dist/jquery.min.js")
        ///            .AddFile("dist/jquery.min.map")
        ///            .WithVerbosity(LibManVerbosity.Detailed)
        ///            .FromPath(@"c:\myproject");
        ///    });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public static void LibManInstall(this ICakeContext context, Action<LibManInstallSettings> configurator)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (configurator == null)
                throw new ArgumentNullException(nameof(configurator));

            var settings = new LibManInstallSettings();
            configurator(settings);
            context.LibManInstall(settings);
        }

        /// <summary>
        /// Installs client side libraries using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para> Installs client side libraries in a specific working directory ('libman install')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = new LibManInstallSettings
        ///        {
        ///            WorkingDirectory = @"c:\myproject",
        ///            Verbosity = LibManVerbosity.Detailed,
        ///            Provider = CdnProvider.jsdelivr,
        ///            Library = "jquery@3.4.1",
        ///            Destination = "wwwroot/lib/jquery",
        ///            Files =
        ///            {
        ///               "dist/jquery.min.js",
        ///               "dist/jquery.min.map"
        ///            },
        ///        };
        ///     LibManInstall(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public static void LibManInstall(this ICakeContext context, LibManInstallSettings settings)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            LibManAddinInformation.LogVersionInformation(context.Log);
            var installer = new LibManInstaller(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            installer.Install(settings);
        }
    }
}
