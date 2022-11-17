using ConsoleMedicalLogger.Logs;
using ConsoleMedicalLogger.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMedicalLogger.MedicalExams
{
    internal class CholesterolLevel : MedicalExam
    {
        public double Value { get; set; }
        public DateTime LastMealTime { get; set; }

        Random rnd = new Random();

        public override void TakeExam()
        {
            //just some simulated values
            Value = rnd.NextDouble() * 10;
            LastMealTime = DateTime.Now;

            Logger.LogEntry($"Uradjen test Nivo holesterola, pacijent: \"{SelectPatient.Name}\", rezultati: nivo: {Value:0.00} mmol/L, poslenji put jeo: {LastMealTime:t}");
        }

        public override string ToString() => "Nivo holesterola u krvi";
    }
}
