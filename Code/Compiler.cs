using System;
using System.Collections.Generic;
//using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.Collections;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Symbols;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Microsoft.CodeAnalysis.Diagnostics;
//using Microsoft.CodeAnalysis.Text;
//using Roslyn.Utilities;

namespace Code
{
    public class Compiler
    {
        private static List<string> modules;
        private static string entryfilename = "",
                       libpath = "",
                       outputfilename = "",
                       outputdir = "";
        private static bool mchecked  = false,
                     clschecks = false,
                     debug     = false,
                     nostdlib  = false,
                     noconfig  = false,
                     nowarn    = false,
                     optimize  = true,
                     unsafes   = false,
                     verbose   = false;
        private int warnlevel = 4;

        private const string version = "v1.0";

        public Compiler(string[] args)
        {
            parseArgs(args);
            if (entryfilename != null && outputfilename != null) Compile(entryfilename, outputfilename);
        }

        public static void Compile(string input, string output)
        {
            Parser p = new Parser(input, output);
        }

        public static void Compile(string filename)
        {
            /* CommandLineParser parser,
             * string responseFile,
             * string[] args,
             * BuildPaths buildPaths,
             * string additionalReferenceDirectories,
             * IAnalyzerAssemblyLoader assemblyLoader
             */
        }

        private static void parseArgs(string[] args)
        {
            foreach(var arg in args)
            {
                string a1="", a2 = "";
                if (arg.StartsWith("-") && !arg.Contains("=")) // -h
                    a1 = arg.Substring(2);
                else if (arg.StartsWith("--") && !arg.Contains("=")) // --noconfig, --help
                    a1 = arg.Substring(2);
                else if (arg.StartsWith("-") && arg.Contains("=")) // -out=base.exe
                {
                    a1 = arg.Substring(1, arg.IndexOf('='));
                    a2 = arg.Substring(arg.IndexOf('=') + 1);
                }
                else if (arg.StartsWith("--") && arg.Contains("=")) // --entry=base.cd
                {
                    a1 = arg.Substring(2, arg.IndexOf('='));
                    a2 = arg.Substring(arg.IndexOf('=') + 1);
                }
                switch (a1)
                {
                    //case "addmodule": break;
                    //case "checked": break;
                    //case "clscheck": break;
                    //case "debug": break;
                    case "entry": if (a2 != null) entryfilename = a2; break;
                    case "help": helpMessage(); break;
                    case "h": helpMessage(); break;
                    //case "lib": break;
                    //case "L": break;
                    //case "nostdlib": break;
                    //case "noconfig": break;
                    //case "nowarn": break;
                    //case "optimize": break;
                    case "out": if (a2 != null) outputfilename = a2; break;
                    case "o": if (a2 != null) outputfilename = a2; break;
                    case "outdir": if (a2 != null && Directory.Exists(a2)) outputdir = a2; break;
                    //case "unsafe": break;
                    case "verbose": verbose = true; break;
                    case "v": verbose = true; break;
                    case "version": Console.WriteLine("Code Programming Language\nVersion: " + version); break;
                    //case "warn": break;
                }
            }
        }

        public static void helpMessage()
        {
            // code.exe -o=base.exe base.cd
            Console.WriteLine("Code Programming Language");
            Console.WriteLine("Version: " + version + "\n");
            Console.WriteLine("Usage:");
            Console.WriteLine("code.exe [options] <filename>\n");
            Console.WriteLine("[Options]:");
            Console.WriteLine("--addmodule=MODULE,[MODULE2]\tIncludes the specified modules in the resulting assembly. Modules are created by calling the compiler with the --target=module option.");
            Console.WriteLine("--checked=true\tIf true, then all math operations will be checked, false otherwise. By default, it is false.");
            Console.WriteLine("--clscheck=true\tIf true, then CLS(Common Language Specification) checks with be made, false otherwise. By default, it is true.");
            Console.WriteLine("--debug=true\tIf true, then debugging information will be generated, false otherwise. By default, it is false.");
            Console.WriteLine("--entry=<SOURCE-FILE>\tTells the compiler which source file will be entry point for the compilation.");
            Console.WriteLine("--help, -h\tPrint this message.");
            Console.WriteLine("--lib=<PATH>, -L=<PATH>\tDirects the compiler to look for libraries in the specified path.");
            Console.WriteLine("--nostdlib\tUse this flag if you want to compile with the core library. This makes the compiler load its internal types from the assembly being compiled.");
            Console.WriteLine("--noconfig\t");
            Console.WriteLine("--nowarn\tMakes the compiler configuration to be loaded. The compiler by default has ref. to the system assemblies.");
            Console.WriteLine("--optimize\tControls whether to perform optimizations on the code. The default is to optimize.");
            Console.WriteLine("--out=<FILE>, -o=<FILE>\tNames the output file to be generated.");
            Console.WriteLine("--outdir=<PATH>\tTells the compiler where to put the output files.");
            Console.WriteLine("--unsafe\tEnables compilation of unsafe code.");
            Console.WriteLine("--verbose, -v\tDebugging. Turns on verbose yacc parsing.");
            Console.WriteLine("--version\tShows the compiler version.");
            Console.WriteLine("--warn=<LEVEL>\tSets the warn level. O is the lowest and 4 is the highest. The default is 4.");
        }
    }
}