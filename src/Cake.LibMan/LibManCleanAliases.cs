using Cake.Core;
using Cake.Core.Annotations;
using Cake.LibMan.Clean;
using System;

namespace Cake.LibMan
{
    /// <summary>
    /// LibMan Install aliases
    /// </summary>
    [CakeAliasCategory("LibMan")]
    [CakeNamespaceImport("Cake.LibMan.Clean")]
    public static class LibManCleanAliases
    {
        /// <summary>
        /// Deletes library files previously restored via LibMan in the current working directory. Folders that become empty after this operation are deleted.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     LibManClean();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Clean")]
        public static void LibManClean(this ICakeContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.LibManClean(new LibManCleanSettings());
        }

        /// <summary>
        /// Deletes library files previously restored via LibMan using the settings returned by a configurator. Folders that become empty after this operation are deleted.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <para> Deletes library files previously restored via LibMan using the settings returned by a configurator. ('libman clean')</para>
        /// <code>
        /// <![CDATA[
        ///        LibManClean(settings =>
        ///        {
        ///            settings
        ///                 .WithVerbosity(LibManVerbosity.Detailed)
        ///                 .FromPath(@"c:\myproject");
        ///        });        
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Clean")]
        public static void LibManClean(this ICakeContext context, Action<LibManCleanSettings> configurator)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (configurator == null)
                throw new ArgumentNullException(nameof(configurator));

            var settings = new LibManCleanSettings();
            configurator(settings);
            context.LibManClean(settings);
        }

        /// <summary>
        /// Deletes library files previously restored via LibMan using the specified settings. Folders that become empty after this operation are deleted.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para> Deletes library files previously restored via LibMan using the specified settings. ('libman clean')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = new LibManCleanSettings
        ///        {
        ///            WorkingDirectory = @"c:\myproject",
        ///            Verbosity = LibManVerbosity.Detailed
        ///        };
        ///     LibManClean(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Clean")]
        public static void LibManClean(this ICakeContext context, LibManCleanSettings settings)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            LibManAddinInformation.LogVersionInformation(context.Log);
            var tool = new LibManCleanTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            tool.Clean(settings);
        }
    }
}
