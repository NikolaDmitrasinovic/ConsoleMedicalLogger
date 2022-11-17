﻿using ConsoleMedicalLogger.MedicalExams;
using ConsoleMedicalLogger.Persons.IPerson;
using ConsoleMedicalLogger.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMedicalLogger.Persons
{
    internal class Patient : Person, IPatient
    {
        public string PersonalId { get; set; }
        public string MedicalRecordId { get; set; } //need singleton to generate val
        public Doctor? chosenDoctor { get; set; }
        public List<MedicalExam> MyExams { get; set; }

        public Patient(string name, string surname, string _personalId, string medicalRecordId):base(name, surname)
        {
            PersonalId = _personalId;
            MedicalRecordId = medicalRecordId;
            MyExams= new List<MedicalExam>();

            Logger.LogEntry($"Kreiran pacijent \"{Name}\"");
        }

        public Patient()
        {
            PersonalId = string.Empty;
            MedicalRecordId = string.Empty;
            MyExams = new List<MedicalExam>();
        }

        public void ChosePersonalDoctor(Doctor doctor)
        {
            if (chosenDoctor == doctor)
            {
                Console.WriteLine("Pacijent je vec registrovan kod imenovanog lekara");
                return;
            }
            else if (chosenDoctor != null && chosenDoctor != doctor)
            {
                chosenDoctor.MyPatients.Remove(this);
                chosenDoctor = doctor;
                chosenDoctor.MyPatients.Add(this);
            }
            else
            {
                chosenDoctor = doctor;
                chosenDoctor.MyPatients.Add(this);
            }

            Logger.LogEntry($"Izabran lekar: \"{doctor.Name}\", pacijent: \"{Name}\"");
        }

        public void TakeExam()
        {
            if (MyExams.Count>0)
            {
                MyExams[0].TakeExam();
                MyExams[0].done= true;

                MyExams = MyExams.Where(ex => ex.done == true).ToList();
            }            
        }

        //option to take all the exams
        public void TakeAllExams()
        {
            foreach (MedicalExam exam in MyExams)
            {
                exam.TakeExam();
                exam.done = true;
            }
            MyExams = MyExams.Where(ex => ex.done == true).ToList();
        }
    }
}
