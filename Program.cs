using System;
using System.IO.Ports;
using System.IO;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];
            Parser parser = new Parser();
            parser.Parse(filePath);

            OperatingSystem sys = Environment.OSVersion;
            PlatformID pid = sys.Platform;

            string portation = args[1];
            if (portation.ToLower() == "windows" || portation != "" || pid == PlatformID.WinCE)
            {
                //Thanks to .NET Core and its prohibition to support System.IO.Ports only on 
                //Windows these lines are commented and class useless if you are not on windows
                // --------------------
                string device = args[2] != "" ? args[2] : "COM1";
                int baudrate = !String.IsNullOrEmpty(args[3]) ? int.Parse(args[3]) : 115200;
                Sender sender = new Sender(device, baudrate);
                foreach(Note note in parser.getTones())
                {
                    sender.Send(note);
                    Task.Delay((int)Math.Round(note.getDuration())).Wait();
                }
            }
            else
            {
                foreach (Note note in parser.getTones())
                {
                    Console.WriteLine(
                    String.Format(
                        "{0},{1},{2}",
                        note.getName(),
                        note.getFrequency(),
                        note.getDuration()
                    )
                );
                    Task.Delay((int)Math.Round(note.getDuration())).Wait(); //Waiting when tone is playing - a bit messy but still..
                }
            }
        }
    }
}
