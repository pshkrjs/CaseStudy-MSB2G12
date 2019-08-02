using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Resources;
/*
 * PatientDataGenerator generates data(temperature,spo2 and pulse rate) every second and writes into a file
 * so that MonitoringSystem checks the status
 */
namespace PatientDataGenerator
{
    public class DataGenerator : IGeneratorInterface
    {
        private readonly Patient.Patient _patient;
        private Random _rand;
        private readonly string _sourcePath;


        public decimal GenerateTemperature()
        {
			var temp = new decimal(_rand.Next(Constants.TemperatureMin, Constants.TemperatureMax) + _rand.NextDouble());
			return Math.Round(temp, 1);
		}
		/*
		 * UpdateValues method writes the generated values into a file
		 * file size is restricted to 15 lines
		 * after 15 lines latest entry gets added removing the oldest entry
		 */
        public void UpdateValues()
        {
            _patient.Spo2 = GenerateSpo2();
            _patient.PulseRate = GeneratePulseRate();
            _patient.Temperature = GenerateTemperature();
            var lineCount = File.ReadLines(_sourcePath).Count();
            StreamWriter streamWriter;

            if (lineCount < Constants.NumberOfPatientLogEntries)
            {
                streamWriter = new StreamWriter(_sourcePath, true);
                streamWriter.WriteLine(JsonConvert.SerializeObject(_patient));
            }
            else
			{
               
                List<string> logList = new List<string>();
				var logFile = File.ReadAllLines(_sourcePath).Skip(1);
				streamWriter = new StreamWriter(_sourcePath, false);
				foreach (var entry in logFile) logList.Add(entry);
				foreach (var logItem in logList)
				{
					streamWriter.WriteLine(logItem);
				}
				streamWriter.WriteLine(JsonConvert.SerializeObject(_patient));
            }
            streamWriter.Flush();
            streamWriter.Dispose();
        }

		public int GeneratePulseRate()
		{
				return _rand.Next(Constants.PulseRateMin, Constants.PulseRateMax);

			}

		public int GenerateSpo2()
		{
			return _rand.Next(Constants.Spo2Min, Constants.Spo2Max);
		}

		public DataGenerator(Patient.Patient patient, string sourcePath)
        {
            _rand = new Random();
            _patient = patient;
            _sourcePath = sourcePath;
        }
    }
}
