using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMedicalLogger.Persons.IPerson
{
    internal interface IPatient
    {
        void ChosePersonalDoctor(Doctor doctor);

        void TakeExam();
    }
}
