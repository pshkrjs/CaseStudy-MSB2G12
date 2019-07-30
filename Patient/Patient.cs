using System;

namespace Patient
{
    [Serializable]
    public class Patient
    {
        public string PatientId { get; }
        public int Spo2 { get; set; }
        public int PulseRate { get; set; }
        public decimal Temperature { get; set; }

        public Patient(string pId, int spo2, int pulse, decimal temp)
        {
            PatientId = pId;
            Spo2 = spo2;
            PulseRate = pulse;
            Temperature = temp;
        }
    }
}
