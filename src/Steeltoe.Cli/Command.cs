// Copyright 2020 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.IO;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Steeltoe.Tooling;
using Steeltoe.Tooling.Controllers;

namespace Steeltoe.Cli
{
    public abstract class Command
    {
        private static readonly ILogger Logger = Logging.LoggerFactory.CreateLogger<Command>();

        private readonly IConsole _console;

        protected Command(IConsole console)
        {
            _console = console;
        }

        protected int OnExecute(CommandLineApplication app)
        {
            try
            {
                Logger.LogDebug($"working directory: {app.WorkingDirectory}");
                var context = new Context
                {
                    WorkingDirectory = app.WorkingDirectory,
                    Console = _console.Out,
                    Shell = new CommandShell(),
                    Registry = new Registry()
                };
                context.Registry.Load(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "steeltoe.rc",
                    "registry"));
                GetController().Execute(context);
                return 0;
            }
            catch (ArgumentException e)
            {
                if (!string.IsNullOrEmpty(e.Message))
                {
                    app.Error.WriteLine(e.Message);
                }

                return 1;
            }
            catch (ToolingException e)
            {
                if (!string.IsNullOrEmpty(e.Message))
                {
                    app.Error.WriteLine(e.Message);
                }

                return 2;
            }
            catch (Exception e)
            {
                Logger.LogDebug($"unhandled exception: {e}{Environment.NewLine}{e.StackTrace}");
                app.Error.WriteLine(e.Message);
                return -1;
            }
        }

        protected abstract Controller GetController();
    }
}
