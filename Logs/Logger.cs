using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMedicalLogger.Logs
{
    internal static class Logger
    {
        private static string appDirectory = Directory.GetCurrentDirectory();
        private static string path = appDirectory + @"..\..\..\..\MedicalLog.txt";

        public static void LogEntry(string info)
        {
            //printing events to console
            Console.WriteLine($"[{DateTime.Now:G}] " + info);

            //LogFile
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"[{DateTime.Now:G}] " + info);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"[{DateTime.Now:G}] " + info);
                }
            }
        }
    }
}
