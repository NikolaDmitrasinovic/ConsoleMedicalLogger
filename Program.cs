using ConsoleMedicalLogger.Persons;
using ConsoleMedicalLogger.MedicalExams;

namespace ConsoleMedicalLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Medical exam logger");

            Doctor drMilan = new Doctor("Milan", "Milanovic", "opsti lekar");
            Patient patientDragan = new Patient("Dragan", "Draganic", "0101999123654", "Dd0011258");
            patientDragan.ChosePersonalDoctor(drMilan);
            drMilan.CallForExam(patientDragan, 1);
            drMilan.CallForExam(patientDragan, 0);
            patientDragan.TakeExam();
            patientDragan.TakeExam();
        }
    }
}