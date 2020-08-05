using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToExecuteCommand
{
    public static class CommandExecutor
    {
        public static string ExecuteCommand(string command)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd", "/c " + command);
            processInfo.StandardOutputEncoding = Encoding.UTF8;
            processInfo.RedirectStandardOutput = true;
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;
            Process process = Process.Start(processInfo);
            return process.StandardOutput.ReadToEnd();
        }

    }
}
