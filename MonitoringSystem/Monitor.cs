using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlertSystem;
using Newtonsoft.Json;

namespace MonitoringSystem
{
    public class Monitor : IMonitor
    {
        private AlertSystem.AlertImpl _alertChannel;

        public Monitor()
        {
            _alertChannel = new AlertImpl();
        }

        public void CheckStatus(string fileName)
        {
            var patientDetails = ReadPatientDetails(fileName);
            int avgSpo2 = 0, avgPulseRate = 0;
            decimal avgTemperature = 0.0m;
            foreach (var entry in patientDetails)
            {
                avgSpo2 += entry.Spo2;
                avgPulseRate += entry.PulseRate;
                avgTemperature += entry.Temperature;
            }

            avgSpo2 /= 10;
            avgPulseRate /= 10;
            avgTemperature /= 10;

            if (CheckSpo2(avgSpo2) || CheckPulseRate(avgPulseRate) || CheckTemperature(avgTemperature))
            {
                Alert(patientDetails[0].PatientId);
            }
        }

        private bool CheckTemperature(decimal avgTemperature)
        {
            return (avgTemperature < 97.0m || avgTemperature > 99.0m) ? true : false;
        }

        private bool CheckPulseRate(int avgPulseRate)
        {
            return (avgPulseRate < 40 || avgPulseRate > 100) ? true : false;
        }

        private bool CheckSpo2(int avgSpo2)
        {
            return (avgSpo2 < 91 || avgSpo2 > 100) ? true : false;
        }

        private List<Patient.Patient> ReadPatientDetails(string fileName)
        {
            List<string> lines = File.ReadAllLines(fileName).Reverse().Take(10).ToList();
            List<Patient.Patient> patientDetails = new List<Patient.Patient>(10);
            foreach (var entry in lines)
            {
                patientDetails.Add(JsonConvert.DeserializeObject<Patient.Patient>(entry));
            }

            return patientDetails;
        }

        public void Alert(string patientId)
        {
            _alertChannel.Alert(patientId);
        }
    }
}
