using ConsoleMedicalLogger.Logs;
using ConsoleMedicalLogger.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMedicalLogger.MedicalExams
{
    internal class BloodPressure : MedicalExam
    {
        public int ValueTtop { get; }
        public int ValueBottom { get; }
        public int Pulse { get; }

        private Random rnd = new Random();

        public BloodPressure()
        {
            //random vals for demo purposes
            ValueTtop = rnd.Next(91, 135);
            ValueBottom = rnd.Next(72, 90);
            Pulse = rnd.Next(60, 100);
        }

        public override void TakeExam()
        {
            Logger.LogEntry($"Uradjen test Krvni pritisak, pacijent: \"{SelectPatient.Name}\", rezultati: donji: {ValueBottom}, gornji: {ValueTtop}, otkucaji: {Pulse}");
        }

        public override string ToString() => "Krvni pritisak";
    }
}
