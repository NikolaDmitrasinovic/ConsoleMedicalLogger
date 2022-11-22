using ConsoleMedicalLogger.MedicalExams;
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
        public string PersonalId { get; }
        public string MedicalRecordId { get; }
        public Doctor? chosenDoctor { get; set; }
        public List<MedicalExam> MyExams { get; set; }

        public Patient(string name, string surname, string _personalId):base(name, surname)
        {
            RecordIdGenerator id = RecordIdGenerator.Instance;

            PersonalId = _personalId;
            MedicalRecordId = id.GetNewId(this);
            MyExams= new List<MedicalExam>();

            Logger.LogEntry($"Kreiran pacijent \"{Name}\"");

            ChosePersonalDoctor(Doctor.GetFreeDoctor());
        }

        public Patient(string name, string surname, string personalId, Doctor doctor):base(name, surname)
        {
            PersonalId = personalId;
            MedicalRecordId = RecordIdGenerator.Instance.GetNewId(this);
            MyExams = new List<MedicalExam>();

            Logger.LogEntry($"Kreiran pacijent \"{Name}\"");

            ChosePersonalDoctor(doctor);
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
                chosenDoctor.RemovePatient(this);
            }
            chosenDoctor = doctor;
            chosenDoctor.AddPatient(this);

            Logger.LogEntry($"Izabran lekar: \"{doctor.Name}\", pacijent: \"{Name}\"");
        }

        public void TakeExam()
        {
            if (MyExams.Count>0)
            {
                MyExams[0].TakeExam();
                MyExams[0].done= true;

                MyExams = MyExams.Where(ex => !ex.done).ToList();
            }            
        }
    }
}
