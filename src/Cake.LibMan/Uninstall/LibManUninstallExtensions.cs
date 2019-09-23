using System;

namespace Cake.LibMan.Uninstall
{
    /// <summary>
    /// Extensions for <see cref="LibManUninstallSettings"/>.
    /// </summary>
    public static class LibManUninstallExtensions
    {
        /// <summary>
        /// Uninstalls a client side library by name.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="libraryName">Name of the client side library. e.g - jquery.</param>        
        /// <returns>The <paramref name="settings"/> instance with <see cref="LibManUninstallSettings.Library"/> set to <paramref name="libraryName"/>.</returns>
        public static LibManUninstallSettings SetLibrary(this LibManUninstallSettings settings, string libraryName)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(libraryName))
                throw new ArgumentNullException(nameof(libraryName));

            settings.Library = libraryName;
            return settings;
        }
    }
}
