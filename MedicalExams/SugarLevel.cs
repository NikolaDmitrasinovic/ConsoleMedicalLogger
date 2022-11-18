using ConsoleMedicalLogger.Logs;
using ConsoleMedicalLogger.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleMedicalLogger.MedicalExams
{
    internal class SugarLevel : MedicalExam
    {
        public int Value { get; set; }
        public DateTime LastMealTime { get; set; }

        Random rnd = new Random();

        public SugarLevel()
        {
            //random vals for demo purposes
            Value = rnd.Next(69, 125);
            LastMealTime = DateTime.Now;
        }

        public override void TakeExam()
        {
            Logger.LogEntry($"Uradjen test Nivo secera, pacijent: \"{SelectPatient.Name}\", rezultati: nivo: {Value}mg/dl, poslenji put jeo: {LastMealTime:t}");
        }

        public override string ToString()=>"Nivo secera u krvi";
    }
}
