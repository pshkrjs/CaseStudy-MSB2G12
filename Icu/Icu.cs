using System;
using System.Timers;
using MonitoringSystem;
using PatientDataGenerator;

namespace Icu
{
    class Icu
    {
        public static void Main()
        {
            var patientInIcu = new PatientInICU();
            patientInIcu.StartMonitoring();
        }
    }
}
