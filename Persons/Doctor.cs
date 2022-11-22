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

        private int patientsCount = 0;

        private static List<Doctor> availableDoctors = new List<Doctor>();

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

        public void AddPatient(Patient patient)
        {
            if (TestAvailability() && !MyPatients.Contains(patient))
            {
                MyPatients.Add(patient);
                patientsCount++;
            }
        }

        public void RemovePatient(Patient patient)
        {
            if (MyPatients.Contains(patient))
            {
                MyPatients.Remove(patient);
                patientsCount--;
            }
        }

        private bool TestAvailability()
        {
            if (availableDoctors.Contains(this))
            {
                return true;
            }

            return false;
        }

        private void UpdateAvailability()
        {
            if (patientsCount < 5 && !TestAvailability())
            {
                availableDoctors.Add(this);
            }
            else if (patientsCount >= 5 && TestAvailability())
            {
                availableDoctors.Remove(this);
            }
        }
    }
}
