using Cake.Core;
using Cake.Core.Annotations;
using Cake.LibMan.Restore;
using System;

namespace Cake.LibMan
{
    /// <summary>
    /// LibMan Install aliases
    /// </summary>
    [CakeAliasCategory("LibMan")]
    [CakeNamespaceImport("Cake.LibMan.Restore")]
    public static class LibManRestoreAliases
    {
        /// <summary>
        /// Restores client side libraries for the project in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     LibManRestore();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Restore")]
        public static void LibManRestore(this ICakeContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.LibManRestore(new LibManRestoreSettings());
        }

        /// <summary>
        /// Restores client side libraries using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <para> Restores client side libraries using the settings ('libman restore')</para>
        /// <code>
        /// <![CDATA[
        ///        LibManRestore(settings =>
        ///        {
        ///            settings
        ///                 .WithVerbosity(LibManVerbosity.Detailed)
        ///                 .FromPath(@"c:\myproject");
        ///        });        
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Restore")]
        public static void LibManRestore(this ICakeContext context, Action<LibManRestoreSettings> configurator)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (configurator == null)
                throw new ArgumentNullException(nameof(configurator));

            var settings = new LibManRestoreSettings();
            configurator(settings);
            context.LibManRestore(settings);
        }

        /// <summary>
        /// Restores client side libraries using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para> Restores client side libraries in a specific working directory ('libman restore')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = new LibManRestoreSettings
        ///        {
        ///            WorkingDirectory = @"c:\myproject",
        ///            Verbosity = LibManVerbosity.Detailed
        ///        };
        ///     LibManRestore(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Restore")]
        public static void LibManRestore(this ICakeContext context, LibManRestoreSettings settings)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            LibManAddinInformation.LogVersionInformation(context.Log);
            var tool = new LibManRestoreTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            tool.Restore(settings);
        }
    }
}
