using Shouldly;
using Xunit;

namespace Cake.LibMan.Tests.Cache
{
    public class LibManCacheCleanTests
    {
        public sealed class TheCacheCleanMethod
        {
            [Fact]
            public void Should_Redirect_Standard_Error()
            {
                var fixture = new LibManCacheCleanToolFixture();
                fixture.Settings.RedirectStandardError = true; ;

                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardError);
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new LibManCacheCleanToolFixture();
                fixture.Settings = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_CdnProvider_Is_Filesystem()
            {
                // Given
                var fixture = new LibManCacheCleanToolFixture();
                fixture.Settings.Provider = CdnProvider.filesystem;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsNotSupportException();
                result.Message.ShouldBe($"The cdn provider '{fixture.Settings.Provider}' does not support cache cleaning.");
            }

            [Theory]
            [InlineData(CdnProvider.Default, "cache clean")]
            [InlineData(CdnProvider.cdnjs, "cache clean cdnjs")]
            [InlineData(CdnProvider.jsdelivr, "cache clean jsdelivr")]
            [InlineData(CdnProvider.unpkg, "cache clean unpkg")]
            public void Should_Add_CdnProvider_To_Arguments_If_Not_Null(CdnProvider provider, string expected)
            {
                // Given
                var fixture = new LibManCacheCleanToolFixture();
                fixture.Settings.Provider = provider;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }
        }

    }
}
