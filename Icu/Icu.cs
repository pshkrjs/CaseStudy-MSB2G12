using System;
using System.IO;
using System.Timers;
using MonitoringSystem;
using PatientDataGenerator;

namespace Icu
{
    class Icu
    {
        private static Timer _monitoringSystemTimer, _patientDataGeneratorTimer;
        private static Monitor _monitoringSystem = new Monitor();
        private static DataGenerator _patientDataGenerator = new DataGenerator();

        public static void Main()
        {
            SetMonitoringSystemTimer();
            SetPatientDataGeneratorTimer();

            Console.WriteLine("\nPatient Monitoring has started...\n");
            Console.ReadLine();
            _monitoringSystemTimer.Stop();
            _monitoringSystemTimer.Dispose();
            _patientDataGeneratorTimer.Stop();
            _patientDataGeneratorTimer.Dispose();

            Console.WriteLine("Disconnecting Monitoring System");
        }

        private static void SetMonitoringSystemTimer()
        {
            // Create a timer with a two second interval.
            _monitoringSystemTimer = new Timer(10 * 1000);
            // Hook up the Elapsed event for the timer. 
            _monitoringSystemTimer.Elapsed += MonitoringSystemEvent;
            _monitoringSystemTimer.AutoReset = true;
            _monitoringSystemTimer.Enabled = true;
        }
        private static void SetPatientDataGeneratorTimer()
        {
            // Create a timer with a two second interval.
            _patientDataGeneratorTimer = new Timer(1 * 1000);
            // Hook up the Elapsed event for the timer. 
            _patientDataGeneratorTimer.Elapsed += PatientDataGeneratorEvent;
            _patientDataGeneratorTimer.AutoReset = true;
            _patientDataGeneratorTimer.Enabled = true;
        }

        private static void MonitoringSystemEvent(Object source, ElapsedEventArgs e)
        {
            var sourcePath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Dataset.txt");
            Console.WriteLine($"Patient Status at {e.SignalTime}");
            _monitoringSystem.CheckStatus(sourcePath);
        }
        private static void PatientDataGeneratorEvent(Object source, ElapsedEventArgs e)
        {
            _patientDataGenerator.UpdateValues();
        }
    }
}
