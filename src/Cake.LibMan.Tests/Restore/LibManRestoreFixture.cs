using Cake.LibMan.Restore;

namespace Cake.LibMan.Tests.Restore
{
    internal sealed class LibManRestoreFixture : LibManFixture<LibManRestoreSettings>
    {
        protected override void RunTool()
        {
            var tool = new LibManRestoreTool(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.Restore(Settings);
        }
    }
}
