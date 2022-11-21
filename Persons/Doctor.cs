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
        public List<Patient> MyPatients { get; }

        public Doctor(string name, string surname, string specialization):base(name, surname)
        {
            Specialization = specialization;
            MyPatients = new List<Patient>();

            Logger.LogEntry($"Kreiran doktor \"{name}\"");
        }

        public void CallForExam(Patient patient, string examName)
        {
            try
            {
                MedicalExam exam = MedicalExamFactory.ExamFactory(examName, patient);
                patient.MyExams.Add(exam);
                Logger.LogEntry($"Kreiran pregled: \"{exam.ToString()}\", pacijent: \"{patient.Name}\"");
            }
            catch (Exception xcp)
            {
                Console.WriteLine(xcp.Message);
            }           
        }

        public void AddRemovePatient(Patient patient)
        {
            if (MyPatients.Contains(patient))
            {
                MyPatients.Remove(patient);
            }
            else
            {
                MyPatients.Add(patient);
            }
        }
    }
}
