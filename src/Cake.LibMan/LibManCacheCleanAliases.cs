using Cake.Core;
using Cake.Core.Annotations;
using Cake.LibMan.Cache;
using System;

namespace Cake.LibMan
{
    /// <summary>
    /// LibMan Cache Clean aliases
    /// </summary>
    [CakeAliasCategory("LibMan")]
    [CakeNamespaceImport("Cake.LibMan.Cache")]
    public static class LibManCacheCleanAliases
    {
        /// <summary>
        /// letes Clears library cache using the default settings
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     LibManCacheClean();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Cache")]
        public static void LibManCacheClean(this ICakeContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.LibManCacheClean(new LibManCacheCleanSettings());
        }

        /// <summary>
        /// Clears library cache using the specified configurator <see cref="LibManCacheCleanSettings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <para> Clears library cache using the via LibMan using the settings returned by a configurator. ('libman cache clean')</para>
        /// <code>
        /// <![CDATA[
        ///        LibManCacheClean(settings =>
        ///        {
        ///            settings
        ///                .WithProvider(CdnProvider.Default)
        ///                .WithVerbosity(LibManVerbosity.Detailed)
        ///                .FromPath(@"c:\myproject");
        ///        });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Cache")]
        public static void LibManCacheClean(this ICakeContext context, Action<LibManCacheCleanSettings> configurator)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (configurator == null)
                throw new ArgumentNullException(nameof(configurator));

            var settings = new LibManCacheCleanSettings();
            configurator(settings);
            context.LibManCacheClean(settings);
        }

        /// <summary>
        /// Clears library cache using the specified <see cref="LibManCacheCleanSettings"/> settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Clears library cache using the specified using the specified settings. ('libman cache clean')</para>
        /// <code>
        /// <![CDATA[
        ///      var settings = new LibManCacheCleanSettings
        ///      {
        ///         WorkingDirectory = @"c:\myproject",
        ///         Verbosity = LibManVerbosity.Detailed,
        ///         Provider = CdnProvider.Default
        ///      };
        ///      LibManCacheClean(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Cache")]
        public static void LibManCacheClean(this ICakeContext context, LibManCacheCleanSettings settings)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            LibManAddinInformation.LogVersionInformation(context.Log);
            var tool = new LibManCacheCleanTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            tool.CacheClean(settings);
        }
    }
}
