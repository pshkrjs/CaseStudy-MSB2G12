using System;
using System.Collections.Generic;
using static Resources.Constants;
/*
 * ConsoleAlert generates suitable Alerts corresponding to the anomalies found in the Patient
 */
namespace AlertSystem
{
    public class ConsoleAlert : IAlert
    {
		/*
		 * Alert method writes the Anomalies found in the particular patient
		 * against the normal conditions
		 */
	    public void Alert(Patient.Patient patient, List<string> anomalyList)
        {
            Console.WriteLine(AlertPatientDetailFormat, new DateTime(1970,1,1).AddMilliseconds(patient.TimeStamp), patient.PatientName);
            foreach (var anomaly in anomalyList)
            {
                Console.WriteLine(AlertPatientAnomalyFormat, anomaly, typeof(Patient.Patient).GetProperty(anomaly).GetValue(patient));
            }
        }
    }
}
