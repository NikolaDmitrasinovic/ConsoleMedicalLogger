using ConsoleMedicalLogger.MedicalExams;
using ConsoleMedicalLogger.Persons.IPerson;
using ConsoleMedicalLogger.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public void CallForExam(Patient patient, int examId)
        {
            MedicalExam exam = new MedicalExam();

            switch (examId) //need better way to chose the exam
            {
                case 0:
                    exam = new BloodPressure();
                    break;
                case 1:
                    exam = new SugarLevel();
                    break;
                case 2:
                    exam = new CholesterolLevel();
                    break;
                default:
                    Console.WriteLine("Greska pri izboru pregleda");
                    return;
            }

            exam.SelectPatient = patient;
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
