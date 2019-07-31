using System.Collections.Generic;
using Patient;

namespace AlertSystem
{
    public interface IAlert 
    {
        void Alert(Patient.Patient patient, List<string> anomalyList);
    }
}
