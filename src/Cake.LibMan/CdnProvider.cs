using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.LibMan
{
    /// <summary>
    /// The name of the provider to use for the library acquisition.
    /// </summary>
    public enum CdnProvider
    {
        /// <summary>
        /// The #1 free and open source CDN built to make life easier for developers. https://cdnjs.com
        /// </summary>
        cdnjs,
        /// <summary>
        /// The filesystem provider allows you to copy files from local file system, network drives and custom URIs. 
        /// </summary>
        filesystem,
        /// <summary>
        /// A free, fast, and reliable Open Source CDN for npm and GitHub
        /// </summary>
        jsdelivr,
        /// <summary>
        /// A fast, global content delivery network for everything on npm. Use it to quickly and easily load any file from any package using a URL.
        /// </summary>
        unpkg
    }
}
