using Xunit;

namespace Cake.LibMan.Tests.Clean
{
    public class LibManCleanTests
    {
        public sealed class TheCleanMethod
        {
            [Fact]
            public void Should_Redirect_Standard_Error()
            {
                var fixture = new LibManCleanFixture();
                fixture.Settings.RedirectStandardError = true;

                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardError);
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new LibManCleanFixture();
                fixture.Settings = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Add_Mandatory_Arguments()
            {
                // Given
                var fixture = new LibManCleanFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("clean", result.Args);
            }
        }

    }
}
