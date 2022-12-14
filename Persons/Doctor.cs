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
            availableDoctors.Add(this);

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
                UpdateAvailability();
            }
        }

        public void RemovePatient(Patient patient)
        {
            if (MyPatients.Contains(patient))
            {
                MyPatients.Remove(patient);
                patientsCount--;
                UpdateAvailability();
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

        public static Doctor GetFreeDoctor()
        {
            if (availableDoctors.Count>0)
            {
                int patientsNum = availableDoctors[0].patientsCount;
                foreach (Doctor doc in availableDoctors)
                {
                    if (patientsNum > doc.patientsCount)
                    {
                        patientsNum = doc.patientsCount;
                    }
                }
                List<Doctor> doctors = availableDoctors.Where(d => d.patientsCount == patientsNum).ToList();

                Random rdm = new Random();
                return doctors[rdm.Next(0, doctors.Count())];
            }
            return null;
        }

        public static bool AnyFreeDoctors()
        {
            if (availableDoctors.Count> 0)
            {
                return true;
            }
            return false;
        }
    }
}
