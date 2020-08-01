using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    class Program
    {
        static void ExecuteCommand(string command)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd", "/c " + command);
            processInfo.StandardOutputEncoding = Encoding.UTF8;
            processInfo.RedirectStandardOutput = true;
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;
            Process process = Process.Start(processInfo);
            WriteLine(process.StandardOutput.ReadToEnd());
        }

        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            bool isRunning = false;

            foreach(var p in processes)
            {
                if(p.ProcessName.Contains("IDM"))
                {
                    isRunning = true;
                }
            }

            if(!isRunning)
            {
                ExecuteCommand("RUNDLL32.EXE powrprof.dll,SetSuspendState 0,1,0");
            }
        }
    }
}
