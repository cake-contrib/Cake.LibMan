using Cake.LibMan.Uninstall;
using Shouldly;
using Xunit;

namespace Cake.LibMan.Tests.Uninstall
{
    public sealed class LibManUninstallSettingsExtensionTests
    {
        public sealed class TheSetLibraryMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                LibManUninstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.SetLibrary("jquery"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Library_Is_Null()
            {
                // Given
                var settings = new LibManUninstallSettings();

                // When
                var result = Record.Exception(() => settings.SetLibrary(null));

                // Then
                result.IsArgumentNullException("libraryName");
            }

            [Fact]
            public void Should_Throw_If_Library_Is_Empty()
            {
                // Given
                var settings = new LibManUninstallSettings();

                // When
                var result = Record.Exception(() => settings.SetLibrary(string.Empty));

                // Then
                result.IsArgumentNullException("libraryName");
            }

            [Fact]
            public void Should_Throw_If_Library_Is_WhiteSpace()
            {
                // Given
                var settings = new LibManUninstallSettings();

                // When
                var result = Record.Exception(() => settings.SetLibrary(" "));

                // Then
                result.IsArgumentNullException("libraryName");
            }

            [Fact]
            public void Should_Set_Library()
            {
                // Given
                var settings = new LibManUninstallSettings();
                var libraryName = "jquery";

                // When
                settings.SetLibrary(libraryName);

                // Then
                settings.Library.ShouldBe(libraryName);
            }
        }

    }
}
