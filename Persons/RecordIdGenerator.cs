using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMedicalLogger.Persons
{
    internal sealed class RecordIdGenerator
    {
        private static RecordIdGenerator instance = null;
        public static RecordIdGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecordIdGenerator();
                }
                return instance;
            }
        }

        private Random rnd;

        private RecordIdGenerator()
        {
            rnd = new Random();
        }
        
        public string GetNewId(Patient patient)
        {
            string id = patient.Surname.Substring(0, 1) + patient.Name.Substring(0, 1);

            for (int i = 0; i < 5; i++)
            {
                id += rnd.Next(10);
            }

            return id;
        }
    }
}
