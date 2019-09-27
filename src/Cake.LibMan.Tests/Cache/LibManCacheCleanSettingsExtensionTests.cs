using Cake.LibMan.Cache;
using Shouldly;
using Xunit;

namespace Cake.LibMan.Tests.Cache
{
    public sealed class LibManCacheCleanSettingsExtensionTests
    {
        public sealed class TheSetLibraryMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                LibManCacheCleanSettings settings = null;

                // When
                var result = Record.Exception(() => settings.WithProvider(CdnProvider.Default));

                // Then
                result.IsArgumentNullException("settings");
            }
            [Fact]
            public void Should_Throw_If_CdnProvider_Is_Filesystem()
            {
                // Given
                var settings = new LibManCacheCleanSettings();

                // When
                var result = Record.Exception(() => settings.WithProvider(CdnProvider.filesystem));

                // Then
                result.IsArgumentException("provider");
            }

            [Theory]
            [InlineData(CdnProvider.Default)]
            [InlineData(CdnProvider.cdnjs)]
            [InlineData(CdnProvider.jsdelivr)]
            [InlineData(CdnProvider.unpkg)]
            public void Should_Set_CdnProvider(CdnProvider provider)
            {
                // Given
                var settings = new LibManCacheCleanSettings();

                // When
                settings.WithProvider(provider);

                // Then
                settings.Provider.ShouldBe(provider);
            }
        }

    }
}
