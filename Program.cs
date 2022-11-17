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
            Patient pacDragan = new Patient("Dragan", "Draganic", "0101999123654", "Dd0011258");
            pacDragan.ChosePersonalDoctor(drMilan);
            drMilan.CallForExam(pacDragan, 1);
            drMilan.CallForExam(pacDragan, 0);
            pacDragan.TakeExam();
            pacDragan.TakeExam();
        }
    }
}