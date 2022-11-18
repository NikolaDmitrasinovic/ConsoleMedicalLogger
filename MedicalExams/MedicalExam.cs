using ConsoleMedicalLogger.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMedicalLogger.MedicalExams
{
    internal abstract class MedicalExam
    {
        public Patient SelectPatient { get; set; }
        public bool done { get; set; }

        public MedicalExam()
        {
            SelectPatient = new Patient();
            done = false;
        }

        public virtual void TakeExam() { }
    }
}
