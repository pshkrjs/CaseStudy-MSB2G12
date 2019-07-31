﻿namespace Resources
{
    public class Constants
    {
        public const string ExitMessage = "Press any key to exit.";
        public const string MonitoringMessage = "Patient Monitoring has started...";
        public const string PatientDataGeneratorMessage = "Data Generation has started...";
        public const string AlertPatientDetailFormat = "At {0}:\n\tPatient {1} had following anomalies:";
        public const string AlertPatientAnomalyFormat = "\t\tValue: {0}, acceptable range: {1} - {2}";
        public const int MonitoringInterval = 10;
        public const int DataGeneratorInterval = 1;
        public const int NumberOfPatientLogEntries = 15;
        public const int PulseRateMin = 0;
        public const int PulseRateMax = 230;
        public const int Spo2Min = 0;
        public const int Spo2Max = 100;
        public const int TemperatureMin = 89;
        public const int TemperatureMax = 110;
        public const int PulseRateValidMin = 40;
        public const int PulseRateValidMax = 100;
        public const int Spo2ValidMin = 91;
        public const int Spo2ValidMax = 100;
        public const decimal TemperatureValidMin = 97.0m;
        public const decimal TemperatureValidMax = 99.0m;
    }
}
