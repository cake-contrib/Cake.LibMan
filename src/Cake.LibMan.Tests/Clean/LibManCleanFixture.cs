using Cake.LibMan.Clean;

namespace Cake.LibMan.Tests.Clean
{
    internal sealed class LibManCleanFixture : LibManFixture<LibManCleanSettings>
    {
        protected override void RunTool()
        {
            var tool = new LibManCleanTool(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.Clean(Settings);
        }
    }
}
