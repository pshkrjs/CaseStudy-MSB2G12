using System.Collections.Generic;
namespace AlertSystem
{
	/*
	 * IAlert contains the method Alert to be implemented in the ConsoleAlert Class
	 */
    public interface IAlert 
    {
        void Alert(Patient.Patient patient, List<string> anomalyList);
    }
}
