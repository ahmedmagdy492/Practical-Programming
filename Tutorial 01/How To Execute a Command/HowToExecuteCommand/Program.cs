using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HowToExecuteCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter Your Name: ");
            string name = ReadLine();
            string result = CommandExecutor.ExecuteCommand($"echo {name}");
            WriteLine(result);
        }
    }
}
