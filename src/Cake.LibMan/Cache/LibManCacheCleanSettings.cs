using Cake.Core;
using Cake.Core.IO;
using System;

namespace Cake.LibMan.Cache
{
    /// <summary>
    /// Contains settings used by <see cref="LibManCacheCleanTool"/>.
    /// </summary>
    public class LibManCacheCleanSettings : LibManSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibManCacheCleanSettings"/> class.
        /// </summary>
        public LibManCacheCleanSettings()
            : base("cache clean")
        { }

        /// <summary>
        /// The name of the provider to clean the cache for. The filesystem provider doesn't use the library cache.
        /// </summary>
        public CdnProvider Provider { get; set; } = CdnProvider.Default;

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            if (Provider == CdnProvider.filesystem)
                throw new NotSupportedException($"The cdn provider '{Provider}' does not support cache cleaning.");

            if (Provider != CdnProvider.Default)
                args.Append(Provider.ToString());
        }
    }
}
