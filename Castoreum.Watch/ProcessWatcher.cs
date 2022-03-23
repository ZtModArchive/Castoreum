using Castoreum.Interface.Service.Watch;
using System;
using System.Diagnostics;
using System.IO;

namespace Castoreum.Watch
{
    public class ProcessWatcher : IProcessWatcher
    {
        public void Watch(string program, string arg)
        {
            using var process = new Process();
            process.StartInfo.FileName = program;
            process.StartInfo.Arguments = arg;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            using (StreamWriter writer = new("castorlog.txt"))
            {
                while (!process.StandardOutput.EndOfStream)
                {
                    string line = process.StandardOutput.ReadLine();
                    Console.WriteLine($"{line}");
                    writer.WriteLine($"{line}");
                }
            }

            process.WaitForExit();
        }
    }
}
