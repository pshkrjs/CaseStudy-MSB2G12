using System;
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

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.ReadLine();
            _monitoringSystemTimer.Stop();
            _monitoringSystemTimer.Dispose();

            Console.WriteLine("Terminating the application...");
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
            _monitoringSystem.Start();
        }
        private static void PatientDataGeneratorEvent(Object source, ElapsedEventArgs e)
        {
            _patientDataGenerator.UpdateValues();
        }
    }
}
