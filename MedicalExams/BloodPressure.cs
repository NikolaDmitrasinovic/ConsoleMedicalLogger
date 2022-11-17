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
        public int ValueTtop { get; set; }
        public int ValueBottom { get; set; }
        public int Pulse { get; set; }

        private Random rnd = new Random();

        public override void TakeExam()
        {
            //just some sim vals
            ValueTtop = rnd.Next(91, 135);
            ValueBottom = rnd.Next(72, 90);
            Pulse = rnd.Next(60, 100);

            Logger.LogEntry($"Uradjen test Krvni pritisak, pacijent: \"{SelectPatient.Name}\", rezultati: donji: {ValueBottom}, gornji: {ValueTtop}, otkucaji: {Pulse}");
        }

        public override string ToString() => "Krvni pritisak";
    }
}
