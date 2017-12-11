using System;
using System.IO;

using Code;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = File.OpenRead("../../hello.cd");
            Console.WriteLine();
            //Console.WriteLine(new StreamReader(File.OpenRead("../../hello.cd")).ReadToEnd());
            Console.ReadLine();
            //Compiler.Main(args);
            /*
             * Compiler c = new Compiler(args);
             * c.compile();
            */
        }
    }
}