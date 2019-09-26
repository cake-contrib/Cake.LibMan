using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing;
using Cake.Testing.Fixtures;

namespace Cake.LibMan.Tests
{
    internal abstract class LibManFixture<TSettings> : LibManFixture<TSettings, ToolFixtureResult>
        where TSettings : ToolSettings, new()
    {
        protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
        {
            return new ToolFixtureResult(path, process);
        }
    }

    internal abstract class LibManFixture<TSettings, TFixtureResult> : ToolFixture<TSettings, TFixtureResult>
        where TSettings : ToolSettings, new()
        where TFixtureResult : ToolFixtureResult
    {
        private readonly ICakeLog _log = new FakeLog();

        protected LibManFixture()
            : base("libman")
        {
            _log.Verbosity = Verbosity.Normal;
        }

        protected ICakeLog Log
        {
            get
            {
                return _log;
            }
        }
    }
}
