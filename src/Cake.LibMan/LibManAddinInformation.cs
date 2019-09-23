using Cake.Core.Diagnostics;
using System.Reflection;

namespace Cake.LibMan
{
    /// <summary>
    /// Helper to log addin version information
    /// </summary>
    internal static class LibManAddinInformation
    {
        private static readonly string InformationalVersion = typeof(LibManAddinInformation).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        private static readonly string AssemblyVersion = typeof(LibManAddinInformation).GetTypeInfo().Assembly.GetName().Version.ToString();
        private static readonly string AssemblyName = typeof(LibManAddinInformation).GetTypeInfo().Assembly.GetName().Name;

        /// <summary>
        /// verbosely log addin version information
        /// </summary>
        /// <param name="log"></param>
        public static void LogVersionInformation(ICakeLog log)
        {
            log.Verbose(entry => entry("Using addin: {0} v{1} ({2})", AssemblyName, AssemblyVersion, InformationalVersion));
        }
    }
}
