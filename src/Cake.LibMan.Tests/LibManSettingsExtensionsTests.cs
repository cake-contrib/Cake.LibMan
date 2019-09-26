using Cake.LibMan.Install;
using Shouldly;
using Xunit;

namespace Cake.LibMan.Tests
{
    public sealed class LibManSettingsExtensionsTests
    {
        public sealed class TheWithLogLevelMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                LibManSettings settings = null;

                // When
                var result = Record.Exception(() => settings.WithVerbosity(LibManVerbosity.Default));

                // Then
                result.IsArgumentNullException(nameof(settings));
            }

            [Theory]
            [InlineData(LibManVerbosity.Default)]
            [InlineData(LibManVerbosity.Detailed)]
            [InlineData(LibManVerbosity.Normal)]
            [InlineData(LibManVerbosity.Quiet)]
            public void Should_Set_LogLevel(LibManVerbosity verbosity)
            {
                // Given
                var settings = new LibManInstallSettings();

                // When
                settings.WithVerbosity(verbosity);

                // Then
                settings.Verbosity.ShouldBe(verbosity);
            }
        }

        public sealed class TheFromPathMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                LibManSettings settings = null;

                // When
                var result = Record.Exception(() => settings.FromPath(@"c:\temp"));

                // Then
                result.IsArgumentNullException(nameof(settings));
            }

            [Fact]
            public void Should_Throw_If_Path_Is_Null()
            {
                // Given
                var settings = new LibManInstallSettings();

                // When
                var result = Record.Exception(() => settings.FromPath(null));

                // Then
                result.IsArgumentNullException("path");
            }

            [Fact]
            public void Should_Set_WorkingDirectory()
            {
                // Given
                var settings = new LibManInstallSettings();

                // When
                settings.FromPath(@"c:\temp");

                // Then
                settings.WorkingDirectory.ToString().ShouldBe(@"c:/temp");
            }
        }
    }
}
