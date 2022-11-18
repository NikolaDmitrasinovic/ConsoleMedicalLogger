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
        public double Value { get; }
        public DateTime LastMealTime { get; }

        Random rnd = new Random();

        public CholesterolLevel()
        {
            //random vals for demo purposes
            Value = rnd.NextDouble() * 10;
            LastMealTime = DateTime.Now;
        }

        public override void TakeExam()
        {
            Logger.LogEntry($"Uradjen test Nivo holesterola, pacijent: \"{SelectPatient.Name}\", rezultati: nivo: {Value:0.00} mmol/L, poslenji put jeo: {LastMealTime:t}");
        }

        public override string ToString() => "Nivo holesterola u krvi";
    }
}
