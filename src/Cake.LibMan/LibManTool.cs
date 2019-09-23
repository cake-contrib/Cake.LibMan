using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using System;
using System.Collections.Generic;

namespace Cake.LibMan
{
    /// <summary>
    /// Base class for all LibMan tools.
    /// </summary>
    /// <typeparam name="TSettings">The settings type.</typeparam>
    public abstract class LibManTool<TSettings> : Tool<TSettings>
        where TSettings : LibManSettings
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LibManTool{TSettings}"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        protected LibManTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICakeLog log)
            : base(fileSystem, environment, processRunner, tools)
        {
            CakeLog = log;
        }

        /// <summary>
        /// Cake log instance.
        /// </summary>
        public ICakeLog CakeLog { get; }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected sealed override string GetToolName()
        {
            return "LibMan";
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected sealed override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "libman", "libman.exe" };
        }

        /// <summary>
        /// Runs libman.
        /// </summary>
        /// <param name="settings">The settings.</param>
        protected void RunCore(TSettings settings)
        {
            RunCore(settings, new ProcessSettings(), null);
        }

        /// <summary>
        /// Runs libman.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="processSettings">The process settings. <c>null</c> for default settings.</param>
        /// <param name="postAction">Action which should be executed after running libman. <c>null</c> for no action.</param>
        protected void RunCore(TSettings settings, ProcessSettings processSettings, Action<IProcess> postAction)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (!settings.CakeVerbosityLevel.HasValue)
                settings.CakeVerbosityLevel = CakeLog.Verbosity;

            processSettings.RedirectStandardError = settings.RedirectStandardError;
            processSettings.RedirectStandardOutput = settings.RedirectStandardOutput;

            var args = GetArguments(settings);
            Run(settings, args, processSettings, postAction);
        }

        /// <summary>
        /// Builds the arguments for libman.
        /// </summary>
        /// <param name="settings">Settings used for building the arguments.</param>
        /// <returns>Argument builder containing the arguments based on <paramref name="settings"/>.</returns>
        protected ProcessArgumentBuilder GetArguments(TSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings.Evaluate(args);

            CakeLog.Verbose("libman arguments: {0}", args.RenderSafe());

            return args;
        }
    }
}
