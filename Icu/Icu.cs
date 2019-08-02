namespace Icu
{
	/*
	 * Icu is basically the class where the execution of the project start
	 */
    class Icu
    {
		/*
		 * In the main method a patientInIcu object is created which signifies the patient to be monitored
		 * Then the Monitoring of that patient is triggered
		 */
        public static void Main()
        {
            var patientInIcu = new PatientInIcu();
            patientInIcu.StartMonitoring();
        }
    }
}
