using Xunit;

namespace Cake.LibMan.Tests.Restore
{
    public class LibManRestoreTests
    {
        public sealed class TheRestoreMethod
        {
            [Fact]
            public void Should_Redirect_Standard_Error()
            {
                var fixture = new LibManRestoreFixture();
                fixture.Settings.RedirectStandardError = true;

                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardError);
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new LibManRestoreFixture();
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
                var fixture = new LibManRestoreFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("restore", result.Args);
            }
        }

    }
}
