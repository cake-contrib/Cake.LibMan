namespace Cake.LibMan
{
    /// <summary>
    /// The name of the provider to use for the library acquisition.
    /// </summary>
    public enum CdnProvider
    {
        /// <summary>
        /// Default cdn provider. Produces a blank argument
        /// </summary>
        Default = 0,
        /// <summary>
        /// The #1 free and open source CDN built to make life easier for developers. https://cdnjs.com
        /// </summary>
        cdnjs = 1,
        /// <summary>
        /// The filesystem provider allows you to copy files from local file system, network drives and custom URIs. 
        /// </summary>
        filesystem = 2,
        /// <summary>
        /// A free, fast, and reliable Open Source CDN for npm and GitHub
        /// </summary>
        jsdelivr = 4,
        /// <summary>
        /// A fast, global content delivery network for everything on npm. Use it to quickly and easily load any file from any package using a URL.
        /// </summary>
        unpkg = 8
    }
}
