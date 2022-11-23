using ConsoleMedicalLogger.Persons;
using ConsoleMedicalLogger.MedicalExams;
using MedicalExams;

namespace ConsoleMedicalLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Medical exam logger");

            Doctor drMilan = new Doctor("Milan", "Milanovic", "opsti lekar");
            Patient patientDragan = new Patient("Dragan", "Draganic", "0101999123654");
            drMilan.CallForExam(patientDragan, "sugarLevel");
            drMilan.CallForExam(patientDragan, "Blood Pressure");
            patientDragan.TakeExam();
            patientDragan.TakeExam();
        }
    }
}