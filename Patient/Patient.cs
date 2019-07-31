using System;

namespace Patient
{
    [Serializable]
    public class Patient
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public int Spo2 { get; set; }
        public int PulseRate { get; set; }
        public decimal Temperature { get; set; }
        public long TimeStamp { get; set; }

        public Patient(string pId, string pName)
        {
            PatientId = pId;
            PatientName = pName;
            Spo2 = 96;
            PulseRate = 72;
            Temperature = 98.6m;
            TimeStamp = (long) (DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
    }
}
