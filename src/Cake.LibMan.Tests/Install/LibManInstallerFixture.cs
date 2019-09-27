using Cake.LibMan.Install;

namespace Cake.LibMan.Tests.Install
{
    internal sealed class LibManInstallerFixture : LibManFixture<LibManInstallSettings>
    {
        protected override void RunTool()
        {
            var tool = new LibManInstaller(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.Install(Settings);
        }
    }
}
