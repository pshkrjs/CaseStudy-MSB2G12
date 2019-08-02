using System;
using System.Collections.Generic;
using System.Diagnostics;
using AlertSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;
using static Resources.Constants;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ConsoleAlertTests
{
    [TestClass]
    public class ConsoleAlertTests
    {
        private static Patient.Patient _patient;
        private static ConsoleAlert _alertChannel;

        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            _patient = new Patient.Patient(DemoPatientId, DemoPatientName);
            _alertChannel = new ConsoleAlert();
        }

        [TestMethod]
        public void AlertTest()
        {
            _patient.Spo2 = 65;
            _patient.PulseRate = 72;
            _patient.Temperature = 98.6m;

            var anomalyList = new List<string>()
            {
                "Spo2"
            };

            string expectedConsoleOutput;
            using (var consoleOutput = new ConsoleOutput())
            {
                Console.WriteLine(AlertPatientDetailFormat, new DateTime(1970,1,1).AddMilliseconds(_patient.TimeStamp), _patient.PatientName);
                foreach (var anomaly in anomalyList)
                {
                    Console.WriteLine(AlertPatientAnomalyFormat, anomaly, typeof(Patient.Patient).GetProperty(anomaly).GetValue(_patient));
                }
                expectedConsoleOutput = consoleOutput.GetOutput();
            }
            using (var consoleOutput = new ConsoleOutput())
            {
                _alertChannel.Alert(_patient, anomalyList);
                AreEqual(expectedConsoleOutput, consoleOutput.GetOutput());
                Trace.WriteLine(consoleOutput.GetOutput());
            }
        }
    }
}
