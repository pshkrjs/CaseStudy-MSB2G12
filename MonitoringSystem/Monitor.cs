using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlertSystem;
using Newtonsoft.Json;
using Resources;
namespace MonitoringSystem
{
    public class Monitor : IMonitor
    {
        private IAlert _alertChannel;
        private Patient.Patient _patient;
        private string _sourcePath;

        public Monitor(Patient.Patient patient, string sourcePath, IAlert alertChannel)
        {
            _patient = patient;
            _sourcePath = sourcePath;
            _alertChannel = alertChannel;
        }

        public void CheckStatus()
        {
            var patientDetails = ReadPatientDetails();
            int avgSpo2 = 0, avgPulseRate = 0;
            decimal avgTemperature = 0.0m;
            foreach (var entry in patientDetails)
            {
                avgSpo2 += entry.Spo2;
                avgPulseRate += entry.PulseRate;
                avgTemperature += entry.Temperature;

            }

            avgSpo2 /= Constants.MonitoringInterval;
            avgPulseRate /= Constants.MonitoringInterval;
            avgTemperature /= Constants.MonitoringInterval;
            _patient.Spo2 = avgSpo2;
            _patient.PulseRate = avgPulseRate;
            _patient.Temperature = avgTemperature;
            _patient.TimeStamp = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds;
            var anomalyList = new List<string>();

            if (CheckSpo2(avgSpo2)) anomalyList.Add("Spo2");
            if (CheckPulseRate(avgSpo2)) anomalyList.Add("PulseRate");
            if (CheckTemperature(avgSpo2)) anomalyList.Add("Temperature");
            Alert(anomalyList);
        }

        private bool CheckTemperature(decimal avgTemperature)
        {
            return (avgTemperature < Constants.TemperatureValidMin || avgTemperature > Constants.TemperatureValidMax) ? true : false;
        }

        private bool CheckPulseRate(int avgPulseRate)
        {
            return (avgPulseRate < Constants.PulseRateValidMin || avgPulseRate > Constants.PulseRateValidMax) ? true : false;
        }

        private bool CheckSpo2(int avgSpo2)
        {
            return (avgSpo2 < Constants.Spo2ValidMin || avgSpo2 > Constants.Spo2ValidMax) ? true : false;
        }

        private List<Patient.Patient> ReadPatientDetails()
        {
            List<string> lines = File.ReadAllLines(_sourcePath).Reverse().Take(Constants.MonitoringInterval).ToList();
            List<Patient.Patient> patientDetails = new List<Patient.Patient>(Constants.MonitoringInterval);
            foreach (var entry in lines)
            {
                patientDetails.Add(JsonConvert.DeserializeObject<Patient.Patient>(entry));
            }

            return patientDetails;
        }

        public void Alert(List<string> anomalyList)
        {
            _alertChannel.Alert(_patient, anomalyList);
        }
    }
}
