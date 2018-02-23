using System;
using System.IO.Ports;
using System.IO;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            parser.Parse("./prelude.json");
            Console.Write(parser.getJson());
        }
    }
}
