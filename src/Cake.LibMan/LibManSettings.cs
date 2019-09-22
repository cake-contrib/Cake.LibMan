using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.LibMan
{
    /// <summary>
    /// LibMan tool settings
    /// </summary>
    public abstract class LibManSettings: ToolSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibManSettings"/> class.
        /// </summary>
        /// <param name="command">Command to run.</param>
        protected LibManSettings(string command)
        {
            Command = command;
            RedirectStandardError = false;
            RedirectStandardOutput = false;
        }

        /// <summary>
        /// Gets or sets the verbosity level which should be used to run the libman command.
        /// </summary>
        public LibManVerbosity Verbosity { get; set; }

        /// <summary>
        /// Gets or sets the process option to redirect standard error
        /// </summary>
        public bool RedirectStandardError { get; set; }

        /// <summary>
        /// Gets or sets the process option to redirect standard output
        /// </summary>
        public bool RedirectStandardOutput { get; set; }

        /// <summary>
        /// Gets or sets the Log level set by Cake.
        /// </summary>
        internal Verbosity? CakeVerbosityLevel { get; set; }

        /// <summary>
        /// Gets the command which should be run.
        /// </summary>
        protected string Command { get; private set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        internal void Evaluate(ProcessArgumentBuilder args)
        {
            args.Append(Command);
            AppendLibManSettings(args);
            EvaluateCore(args);
        }

        /// <summary>
        /// Evaluates the settings and appends LibMan specific options to arguments
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        private void AppendLibManSettings(ProcessArgumentBuilder args)
        {
            AppendLogLevel(args, Verbosity);
        }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected virtual void EvaluateCore(ProcessArgumentBuilder args)
        {
        }

        private void AppendLogLevel(ProcessArgumentBuilder args, LibManVerbosity verbosity)
        {
            const string @switch = "--verbosity";
            const string separator = " ";

            if (verbosity == LibManVerbosity.Default && CakeVerbosityLevel.HasValue)
                verbosity = CakeToLibManLogLevelConverter(CakeVerbosityLevel.Value);

            switch (verbosity)
            {
                case LibManVerbosity.Default:
                    break;
                case LibManVerbosity.Normal:
                    args.AppendSwitch(@switch, separator, "normal");
                    break;
                case LibManVerbosity.Detailed:
                    args.AppendSwitch(@switch, separator, "detailed");
                    break;
                case LibManVerbosity.Quiet:
                    args.AppendSwitch(@switch, separator, "quiet");
                    break;
            }
        }

        private static LibManVerbosity CakeToLibManLogLevelConverter(Verbosity cakeVerbosityLevel)
        {
            switch (cakeVerbosityLevel)
            {
                case Core.Diagnostics.Verbosity.Quiet:
                    return LibManVerbosity.Quiet;
                case Core.Diagnostics.Verbosity.Verbose:
                case Core.Diagnostics.Verbosity.Diagnostic:
                    return LibManVerbosity.Detailed;
                default:
                    return LibManVerbosity.Default;
            }
        }
    }
}
