﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary
{
    public enum PISources
    {
        Unknown,
        OnSystemQFPV
    }

    public class Enum<T> where T : Enum
    {
        /// <summary>
        /// Returns an Enum's values as a comma separated list "val1, val2, ...";
        /// </summary>
        public static string AsCsvList => string.Join(", ", Enum.GetNames(typeof(T)));

        /// <summary>
        /// Returns a list of Enum values in the format of [val1, val2, ...], but strips out the "Unknown" value if it exists.
        /// </summary>
        //public static string AsValidOptionsList => $"[{string.Join(", ", Enum.GetNames(typeof(T)).Where(t => !t.valueIs("Unknown")))}]";
    }


    public class SampleProgram
    {
        private const string SourceOption = "/Source=";
        //private static readonly string SourceValidValues = Enum<PISources>.AsValidOptionsList;

        //private static Settings Settings = new Settings();

        private static List<PISources> _importSources = null;
        public List<PISources> ImportSources => _importSources ?? (_importSources = GetSourcesFromArgument());

        private List<PISources> GetSourcesFromArgument()
        {
            var sources = new List<PISources>();

            var sourceNames = ""; // CommandLine.ValueOf(SourceOption);
            if (string.IsNullOrWhiteSpace(sourceNames))
                return sources;

            var parms = sourceNames.Split(',');

            foreach (var sourceName in parms.Select(s => s?.Trim()?.Trim('"'))) //.Where(s => s.hasValue()))
            {
                if (!Enum.TryParse(sourceName, true, out PISources source))
                {
                    source = PISources.Unknown;
                }

                if (!sources.Contains(source))
                    sources.Add(source);
            }

            return sources;
        }

        /*
        private void Tests()
        {
            var val = CommandLine.Arguments;
            var x = CommandLine.ValueOf(ConfigFileOption);
            var y = CommandLine.HasArgument(ConfigFileOption);

            var z = Enum<PISources>.AsCsvList;
            var zz = Enum<PISources>.AsValidOptionsList;

            if (ImportSources.isNullOrEmpty())
            {
                isHealthy = false;

                Console.WriteLine();
                TryMsg(MessageType.Error,
                    $"A \"/Source=\" parameter must be supplied using a valid option: {SourceValidValues}. {(CommandLine.HasArgument(ConfigFileOption) ? $"Parameter value \"{CommandLine.ValueOf(ConfigFileOption)}\" is invalid." : "")}");
            }
            else if (ImportSources.Contains(PISources.Unknown))
            {
                isHealthy = false;

                Console.WriteLine();
                TryMsg(MessageType.Error,
                    $"One or more values listed in the \"/Source=\" parameter is invalid.{(CommandLine.HasArgument(ConfigFileOption) ? $" Parameter value: \"{CommandLine.ValueOf(ConfigFileOption)}\" " : " ")}Valid options are: {SourceValidValues}.");
            }
        }
        */
    }
}
