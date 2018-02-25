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
            
            //Thanks to .NET Core and its prohibition to support System.IO.Ports only on 
            //Windows these lines are commented and class useless
            // --------------------
            //string device = args[1];
            //int baudrate = !String.IsNullOrEmpty(args[2]) ? int.Parse(args[2]) : 115200;
            //Sender sender = new Sender(device, baudrate);
            
            Parser parser = new Parser();
            parser.Parse(filePath);
            
            foreach(Note note in parser.getTones())
            {
                //sender.Send(note); - Another one useless thing just because Windows is junk
                Console.WriteLine(
                String.Format(
                    "{0},{1},{2}",
                    note.getName(),
                    note.getFrequency(), 
                    note.getDuration()
                )
            );
                Task.Delay((int)Math.Round(note.getDuration())).Wait(); //Waiting when tone is playing - a bit messy
            }
        }
    }
}
