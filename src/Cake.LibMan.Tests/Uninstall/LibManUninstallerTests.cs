using Xunit;

namespace Cake.LibMan.Tests.Uninstall
{
    public class LibManRestoreTests
    {
        public sealed class TheUninstallMethod
        {
            [Fact]
            public void Should_Redirect_Standard_Error()
            {
                var fixture = new LibManUninstallerFixture();
                fixture.Settings.RedirectStandardError = true;
                fixture.Settings.Library = "jquery";

                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardError);
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new LibManUninstallerFixture();
                fixture.Settings = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Library_Is_Null()
            {
                // Given
                var fixture = new LibManUninstallerFixture();
                fixture.Settings.Library = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("Library");
            }

            [Fact]
            public void Should_Add_Library_To_Arguments_If_Not_Null()
            {
                // Given
                var fixture = new LibManUninstallerFixture();
                fixture.Settings.Library = "jquery";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("uninstall jquery", result.Args);
            }
        }

    }
}
