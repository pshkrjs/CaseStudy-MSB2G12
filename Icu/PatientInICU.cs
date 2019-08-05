using System;
using System.IO;
using MonitoringSystem;
using System.Timers;
using PatientDataGenerator;
using AlertSystem;
using static Resources.Constants;

namespace Icu
{
	/*
	 * PatientInICU class tries to demonstrate a patient in ICU
	 * for simplicity we have considered::
	 *                every second data is generated
	 *                every 10 seconds data is monitored for the anomalies
	 */
    class PatientInIcu
    {
        private Timer _monitoringTimer, _patientDataGeneratorTimer;
        private IMonitor _monitor;
        private IGeneratorInterface _dataGenerator;
        private Random _rand = new Random();

		/*
		 * In the constructor objects of Patient, DataGenerator and Monitoring
		 * correspondingly begins the data generation(every second) and monitoring(every 10th second)
		 */
        public PatientInIcu()
        {
            var patientId = PatientIdGenerator();
            var patientName = "Mr.Pushkar";
            var sourcePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"Dataset_{patientId}.txt");
            var patient = new Patient.Patient(patientId, patientName);
            _dataGenerator = new DataGenerator(patient, sourcePath);
            _monitor = new Monitor(patient, sourcePath, new ConsoleAlert());
        }
		/*
		 * StartMonitoring method basically starts the monitoring on the specified patient
		 * Timer is used,so that monitoring system is triggered every 10 seconds
		 */
        public void StartMonitoring()
        {
            Console.WriteLine(ExitMessage);
            Console.WriteLine(PatientDataGeneratorMessage);
            _patientDataGeneratorTimer = new Timer(DataGeneratorInterval * NoOfMillisInASecond);
            _patientDataGeneratorTimer.Elapsed += PatientDataGeneratorEvent;
            _patientDataGeneratorTimer.AutoReset = true;
            _patientDataGeneratorTimer.Enabled = true;

            Console.WriteLine(MonitoringMessage);
            Console.WriteLine(Ranges, Spo2ValidMin, Spo2ValidMax, TemperatureValidMin, TemperatureValidMax, PulseRateValidMin, PulseRateValidMax);

			_monitoringTimer = new Timer(MonitoringInterval * NoOfMillisInASecond);
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
            _dataGenerator.GenerateValues();
        }
		/*
		 * PatientIdGenerator function generates unique id for the patients in ICU
		 */
        private string PatientIdGenerator()
        {
			_rand = new Random();
	        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var randString = new char[5];

            for (int i = 0; i < randString.Length; i++)
            {
                randString[i] = chars[_rand.Next(chars.Length)];
            }

            var randInt = _rand.Next(100, 999);
	        var patId = new string(randString) + randInt.ToString();

			using (File.Create(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
				$"Dataset_{patId}.txt"))) { }

			return patId;
        }
    }
}
