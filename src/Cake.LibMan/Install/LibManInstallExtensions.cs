using Cake.Core;
using Cake.Core.IO;
using System;

namespace Cake.LibMan.Install
{
    /// <summary>
    /// Extensions for <see cref="LibManInstallSettings"/>.
    /// </summary>
    public static class LibManInstallExtensions
    {
        /// <summary>
        /// Sets the destination directory path to install the client side library files too.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="destination">Destination directory path.</param>        
        /// <returns>The <paramref name="settings"/> instance with <see cref="LibManInstallSettings.Destination"/> set to <paramref name="destination"/>.</returns>
        public static LibManInstallSettings WithDestination(this LibManInstallSettings settings, DirectoryPath destination)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            settings.Destination = destination ?? throw new ArgumentNullException(nameof(destination));

            return settings;
        }

        /// <summary>
        /// Sets the cbn provider to retrieve the client side library from. Cannot set to Default.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="provider">Cdn Provider.</param>        
        /// <returns>The <paramref name="settings"/> instance with <see cref="LibManInstallSettings.Provider"/> set to <paramref name="provider"/>.</returns>
        public static LibManInstallSettings WithProvider(this LibManInstallSettings settings, CdnProvider provider)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (provider == CdnProvider.Default)
                throw new ArgumentException($"Invalid cdn Provider: {CdnProvider.Default}", nameof(provider));

            settings.Provider = provider;
            return settings;
        }

        /// <summary>
        /// Installs a client side library by file Path or Url. Sets the CdnProvider to filesystem.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="filePathOrUrl">The file Path or URL to copy/download the file from</param>        
        /// <returns>The <paramref name="settings"/> instance with <see cref="LibManInstallSettings.Library"/> set to <paramref name="filePathOrUrl"/> and <see cref="LibManInstallSettings.Provider"/> set to <see cref="CdnProvider.filesystem"/>.</returns>
        public static LibManInstallSettings SetLibraryFromPath(this LibManInstallSettings settings, string filePathOrUrl)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(filePathOrUrl))
                throw new ArgumentNullException(nameof(filePathOrUrl));

            var resolvedFilePathOrUrl = filePathOrUrl;

            if (filePathOrUrl.Contains(" "))
                resolvedFilePathOrUrl = filePathOrUrl.Quote();

            settings.Provider = CdnProvider.filesystem;
            settings.Library = resolvedFilePathOrUrl;
            return settings;
        }

        /// <summary>
        /// Installs a client side library by name and version.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="libraryName">Name of the client side library. e.g - jquery.</param>        
        /// <returns>The <paramref name="settings"/> instance with <see cref="LibManInstallSettings.Library"/> set to <paramref name="libraryName"/>.</returns>
        public static LibManInstallSettings SetLibrary(this LibManInstallSettings settings, string libraryName)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(libraryName))
                throw new ArgumentNullException(nameof(libraryName));

            return settings.SetLibrary(libraryName, null, null);
        }

        /// <summary>
        /// Installs a client side library by name and scope.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="libraryName">Name of the client side library.</param>        
        /// <param name="scope">Scope of the package.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="LibManInstallSettings.Library"/> set to <paramref name="libraryName"/> and <paramref name="scope"/>.</returns>
        public static LibManInstallSettings SetScopedLibrary(this LibManInstallSettings settings, string libraryName, string scope)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(libraryName))
                throw new ArgumentNullException(nameof(libraryName));

            if (string.IsNullOrWhiteSpace(scope))
                throw new ArgumentNullException(nameof(scope));

            return settings.SetLibrary(libraryName, null, scope);
        }

        /// <summary>
        /// Installs a client side library by name and scope.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="libraryName">Name of the client side library. e.g - jquery.</param>        
        /// <param name="version">Version or tag published to the registry. e.g. - 3.2.1</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="LibManInstallSettings.Library"/> set to <paramref name="libraryName"/> and <paramref name="version"/>.</returns>
        public static LibManInstallSettings SetLibrary(this LibManInstallSettings settings, string libraryName, string version)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(libraryName))
                throw new ArgumentNullException(nameof(libraryName));

            if (string.IsNullOrWhiteSpace(version))
                throw new ArgumentNullException(nameof(version));

            return settings.SetLibrary(libraryName, version, null);
        }

        /// <summary>
        /// Installs a client side library by name, version, and scope.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="libraryName">Name of the client side library. e.g - jquery.</param>        
        /// <param name="version">Version or tag published to the registry. e.g. - 3.2.1</param>
        /// <param name="scope">Scope of the package. Null for not restricting to a scope.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="LibManInstallSettings.Library"/> set to <paramref name="libraryName"/>, <paramref name="version"/>, and <paramref name="scope"/>.</returns>
        public static LibManInstallSettings SetLibrary(this LibManInstallSettings settings, string libraryName, string version, string scope)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(libraryName))
                throw new ArgumentNullException(nameof(libraryName));

            var resolvedLibraryName = libraryName;

            if (!string.IsNullOrWhiteSpace(version))
                resolvedLibraryName = $"{libraryName}@{version}";

            if (!string.IsNullOrWhiteSpace(scope))
            {
                if (!scope.StartsWith("@"))
                    throw new ArgumentException("Scope should start with @", nameof(scope));

                resolvedLibraryName = !string.IsNullOrWhiteSpace(scope) ? $"{scope}/{resolvedLibraryName}" : resolvedLibraryName;
            }

            settings.Library = resolvedLibraryName;
            return settings;
        }

        /// <summary>
        /// Adds a specific file to restore from the library.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="file">file within the package to install</param>
        /// <returns>The <paramref name="settings"/> instance with <paramref name="file"/> added to <see cref="LibManInstallSettings.Files"/>.</returns>
        public static LibManInstallSettings AddFile(this LibManInstallSettings settings, FilePath file)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (file == null)
                throw new ArgumentNullException(nameof(file));

            settings.Files.Add(file);

            return settings;
        }
    }
}
