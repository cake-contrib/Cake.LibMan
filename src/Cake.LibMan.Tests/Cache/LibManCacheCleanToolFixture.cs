using Cake.LibMan.Cache;

namespace Cake.LibMan.Tests.Cache
{
    internal sealed class LibManCacheCleanToolFixture : LibManFixture<LibManCacheCleanSettings>
    {
        protected override void RunTool()
        {
            var tool = new LibManCacheCleanTool(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.CacheClean(Settings);
        }
    }
}
