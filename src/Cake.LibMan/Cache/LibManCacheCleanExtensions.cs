using System;

namespace Cake.LibMan.Cache
{
    /// <summary>
    /// Extensions for <see cref="LibManCacheCleanSettings"/>.
    /// </summary>
    public static class LibManCacheCleanExtensions
    {
        /// <summary>
        /// Sets the cdn provider to clear the cache for. Does not support filesystem provider.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="provider">Cdn Provider.</param>        
        /// <returns>The <paramref name="settings"/> instance with <see cref="LibManCacheCleanSettings.Provider"/> set to <paramref name="provider"/>.</returns>
        public static LibManCacheCleanSettings WithProvider(this LibManCacheCleanSettings settings, CdnProvider provider)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (provider == CdnProvider.filesystem)
                throw new ArgumentException($"Invalid cdn Provider: {CdnProvider.filesystem}", nameof(provider));

            settings.Provider = provider;
            return settings;
        }
    }
}
