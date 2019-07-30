using System;
using Newtonsoft.Json;

namespace PatientDataGenerator
{
    public class DataGenerator : IGeneratorInterface
    {
        private readonly Patient.Patient _patient;
        public int ChangePulse()
        {
            var rand = new Random();
            return rand.Next(0, 230);

        }

        public int ChangeSpo2()
        {
            var rand = new Random();
            return rand.Next(0, 100);
        }

        public decimal ChangeTemperature()
        {
            var rand = new Random();
            var temp = new decimal(rand.Next(89, 110) + rand.NextDouble());
            return Math.Round(temp, 1);
        }

        private static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[5];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }

        public void UpdateValues()
        {
            _patient.Spo2 = ChangeSpo2();
            _patient.PulseRate = ChangePulse();
            _patient.Temperature = ChangeTemperature();
            Console.WriteLine(JsonConvert.SerializeObject(_patient));
        }


        public DataGenerator()
        {
            var rand = new Random();
            var randInt = rand.Next(100, 999);
            var patId = RandomString() + randInt.ToString();
            _patient = new Patient.Patient(patId, ChangeSpo2(), ChangePulse(), ChangeTemperature());

        }
    }
}
