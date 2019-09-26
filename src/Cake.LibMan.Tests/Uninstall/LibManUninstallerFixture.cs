using Cake.LibMan.Uninstall;

namespace Cake.LibMan.Tests.Uninstall
{
    internal sealed class LibManUninstallerFixture : LibManFixture<LibManUninstallSettings>
    {
        protected override void RunTool()
        {
            var tool = new LibManUninstaller(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.Uninstall(Settings);
        }
    }
}
