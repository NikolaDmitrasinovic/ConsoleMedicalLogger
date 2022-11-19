using ConsoleMedicalLogger.MedicalExams;
using ConsoleMedicalLogger.Persons.IPerson;
using ConsoleMedicalLogger.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MedicalExams;

namespace ConsoleMedicalLogger.Persons
{
    internal class Doctor : Person, IDoctor
    {
        public string Specialization { get; set; }
        private List<Patient> myPatients;

        public Doctor(string name, string surname, string specialization):base(name, surname)
        {
            Specialization = specialization;
            myPatients = new List<Patient>();

            Logger.LogEntry($"Kreiran doktor \"{name}\"");
        }

        public void CallForExam(Patient patient, string examName)
        {
            examName = examName.Trim().ToLower().Replace(" ", string.Empty);
            ExamList chosenExam = Enum.IsDefined(typeof(ExamList), examName) ? (ExamList)Enum.Parse(typeof(ExamList), examName): ExamList.unknown;

            MedicalExam exam;

            switch (chosenExam) //need better way to chose the exam
            {
                case ExamList.bloodpressure:
                    exam = new BloodPressure(patient);
                    break;
                case ExamList.sugarlevel:
                    exam = new SugarLevel(patient);
                    break;
                case ExamList.cholesterollevel:
                    exam = new CholesterolLevel(patient);
                    break;
                default:
                    Console.WriteLine("Greska pri izboru pregleda");
                    return;
            }

            patient.MyExams.Add(exam);
            Logger.LogEntry($"Kreiran pregled: \"{exam.ToString()}\", pacijent: \"{patient.Name}\"");
        }

        public void AddRemovePatient(Patient patient)
        {
            if (myPatients.Contains(patient))
            {
                myPatients.Remove(patient);
            }
            else
            {
                myPatients.Add(patient);
            }
        }
    }
}
