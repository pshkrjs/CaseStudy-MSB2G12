using System;
using System.Collections.Generic;
using Resources;

namespace AlertSystem
{
    public class ConsoleAlert : IAlert
    {
        public void Alert(Patient.Patient patient, List<string> anomalyList)
        {
            Console.WriteLine(Constants.AlertPatientDetailFormat, patient.TimeStamp, patient.PatientId);
            foreach (var anomaly in anomalyList)
            {
                Console.WriteLine(Constants.AlertPatientAnomalyFormat, typeof(Patient.Patient).GetProperty(anomaly).GetValue(patient), 2, 3);
            }
        }
    }
}
