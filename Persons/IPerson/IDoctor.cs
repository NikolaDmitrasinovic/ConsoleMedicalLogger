using ConsoleMedicalLogger.MedicalExams;
using MedicalExams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMedicalLogger.Persons.IPerson
{
    internal interface IDoctor
    {
        void CallForExam(Patient patient, string exam);

        void AddPatient(Patient patient);
        void RemovePatient(Patient patient);
    }
}
