using System;
using Patient;

namespace AlertSystem
{
    public class AlertImpl : IAlert
    {
        public void Alert(string patientId)
        {
            Console.WriteLine($"Patient No. {patientId} has abnormal values !!!");
        }
    }
}
