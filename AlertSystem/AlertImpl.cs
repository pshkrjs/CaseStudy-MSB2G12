using System;
using Patient;

namespace AlertSystem
{
    public class AlertImpl : IAlert
    {
        public void Alert(string patient_id)
        {
            Console.Write($"Patient No. {patient_Id} has abnormal values !!!");
        }
    }
}
