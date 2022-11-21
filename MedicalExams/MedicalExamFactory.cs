using ConsoleMedicalLogger.Persons;
using ConsoleMedicalLogger.Persons.IPerson;
using MedicalExams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMedicalLogger.MedicalExams
{
    internal class MedicalExamFactory
    {
        public static MedicalExam ExamFactory(string examName, Patient patient)
        {
            examName = examName.ToLower().Replace(" ", string.Empty);
            ExamList chosenExam = Enum.IsDefined(typeof(ExamList), examName) ? (ExamList)Enum.Parse(typeof(ExamList), examName) : ExamList.unknown;

            switch (chosenExam) 
            {
                case ExamList.bloodpressure:
                    return new BloodPressure(patient);                    
                case ExamList.sugarlevel:
                    return new SugarLevel(patient);
                case ExamList.cholesterollevel:
                    return new CholesterolLevel(patient);
                default:
                    throw new ArgumentException("Ne postoji pregled sa datim imenom");
            }
        }
    }
}
