using System;
using System.IO;
using MonitoringSystem;
using System.Timers;
using PatientDataGenerator;
using AlertSystem;
using Resources;

namespace Icu
{
    class Implementation
    {
        private Timer _monitoringTimer, _patientDataGeneratorTimer;
        private IMonitor _monitor;
        private IGeneratorInterface _dataGenerator;
        private Random _rand = new Random();

        public Implementation()
        {
            var patientId = PatientIdGenerator();
            var patientName = "Mr. XYZ";
            var sourcePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"Dataset_{patientId}.txt");
            var patient = new Patient.Patient(patientId, patientName);
            _dataGenerator = new DataGenerator(patient, sourcePath);
            _monitor = new Monitor(patient, sourcePath, new ConsoleAlert());
        }

        public void StartMonitoring()
        {
            Console.WriteLine(Constants.ExitMessage);
            Console.WriteLine(Constants.PatientDataGeneratorMessage);
            _patientDataGeneratorTimer = new Timer(Constants.DataGeneratorInterval * Constants.NO_OF_MILLIS_IN_A_SECOND);
            _patientDataGeneratorTimer.Elapsed += PatientDataGeneratorEvent;
            _patientDataGeneratorTimer.AutoReset = true;
            _patientDataGeneratorTimer.Enabled = true;

            Console.WriteLine(Constants.MonitoringMessage);
            Console.WriteLine(Constants.Ranges, Constants.Spo2ValidMin, Constants.Spo2ValidMax, Constants.TemperatureValidMin, Constants.TemperatureValidMax, Constants.PulseRateMin, Constants.PulseRateMax);
			_monitoringTimer = new Timer(Constants.MonitoringInterval * Constants.NO_OF_MILLIS_IN_A_SECOND);
            _monitoringTimer.Elapsed += MonitoringSystemEvent;
            _monitoringTimer.AutoReset = true;
            _monitoringTimer.Enabled = true;

            Console.ReadLine();
            _monitoringTimer.Stop();
            _monitoringTimer.Dispose();
            _patientDataGeneratorTimer.Stop();
            _patientDataGeneratorTimer.Dispose();
            Console.WriteLine("Disconnecting Monitoring System");
        }
        private void MonitoringSystemEvent(Object source, ElapsedEventArgs e)
        {
            _monitor.CheckStatus();
        }
        private void PatientDataGeneratorEvent(Object source, ElapsedEventArgs e)
        {
            _dataGenerator.UpdateValues();
        }

        private string PatientIdGenerator()
        {
			_rand = new Random();
	        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[5];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[_rand.Next(chars.Length)];
            }

            var randInt = _rand.Next(100, 999);
	        var patID = new string(stringChars) + randInt.ToString();

			using (File.Create(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
				$"Dataset_{patID}.txt"))) { }

			return patID;
        }
    }
}
