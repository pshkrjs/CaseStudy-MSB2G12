using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using PatientDataGenerator;

namespace PatientTests
{
    [TestClass]
    public class PatientTests
    {
        private static string patientId = "ZXREA142";
        private static string patientName = "Pushkaraj";
        private static string sourcePath = "";
        private static Patient.Patient patient;
        private static DataGenerator dataGenerator;

        [AssemblyInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            patient = new Patient.Patient(patientId, patientName);
            dataGenerator = new DataGenerator(patient, sourcePath);
        }

        [TestMethod]
        public void SetPulseRateTest()
        {
            var expectedPulseRate = dataGenerator.GeneratePulseRate();
            patient.PulseRate = expectedPulseRate;

            var actualPulseRate = patient.PulseRate;
            AreEqual(expectedPulseRate, actualPulseRate);
        }
        [TestMethod]
        public void SetSpo2Test()
        {
            var expectedSpo2 = dataGenerator.GenerateSpo2();
            patient.Spo2 = expectedSpo2;

            var actualSpo2 = patient.Spo2;
            AreEqual(expectedSpo2, actualSpo2);
        }
        [TestMethod]
        public void SetTemperatureTest()
        {
            var expectedTemperature = dataGenerator.GenerateTemperature();
            patient.Temperature = expectedTemperature;

            var actualTemperature = patient.Temperature;
            AreEqual(expectedTemperature, actualTemperature);
        }
    }
}
