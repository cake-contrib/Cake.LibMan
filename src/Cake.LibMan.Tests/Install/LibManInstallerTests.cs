using Xunit;

namespace Cake.LibMan.Tests.Install
{
    public class LibManInstallerTests
    {
        public sealed class TheInstallMethod
        {
            [Fact]
            public void Should_Redirect_Standard_Error()
            {
                var fixture = new LibManInstallerFixture();
                fixture.Settings.RedirectStandardError = true;
                fixture.Settings.Library = "jquery";

                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardError);
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new LibManInstallerFixture();
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
                var fixture = new LibManInstallerFixture();
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
                var fixture = new LibManInstallerFixture();
                fixture.Settings.Library = "jquery";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("install jquery", result.Args);
            }

            [Fact]
            public void Should_Add_Destination_To_Arguments_If_Not_Null()
            {
                // Given
                var fixture = new LibManInstallerFixture();
                fixture.Settings.Library = "jquery";
                fixture.Settings.Destination = "lib/jquery";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("install jquery --destination \"lib/jquery\"", result.Args);
            }


            [Theory]
            [InlineData(CdnProvider.Default, "install jquery")]
            [InlineData(CdnProvider.cdnjs, "install jquery --provider cdnjs")]
            [InlineData(CdnProvider.filesystem, "install jquery --provider filesystem")]
            [InlineData(CdnProvider.jsdelivr, "install jquery --provider jsdelivr")]
            [InlineData(CdnProvider.unpkg, "install jquery --provider unpkg")]
            public void Should_Add_CdnProvider_To_Arguments_If_Not_Null(CdnProvider provider, string expected)
            {
                // Given
                var fixture = new LibManInstallerFixture();
                fixture.Settings.Library = "jquery";
                fixture.Settings.Provider = provider;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }

            [Fact]
            public void Should_Add_Files_Destination_Provider_To_Arguments_If_Not_Null()
            {
                // Given
                var fixture = new LibManInstallerFixture();
                fixture.Settings.Library = "jquery@3.2.1";
                fixture.Settings.Provider = CdnProvider.jsdelivr;
                fixture.Settings.Destination = "wwwroot/lib/jquery";
                fixture.Settings.Files.Add("dist/jquery.min.js");
                fixture.Settings.Files.Add("dist/jquery.slim.min.js");

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("install jquery@3.2.1 --destination \"wwwroot/lib/jquery\" --provider jsdelivr --files \"dist/jquery.min.js\" --files \"dist/jquery.slim.min.js\"", result.Args);
            }
        }
    }
}
