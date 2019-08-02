using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using PatientDataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Resources.Constants;

namespace PatientDataGeneratorTests
{
    [TestClass]
    public class DataGeneratorTests
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

        private bool MinMaxBoundary(decimal value, decimal minValue, decimal maxValue)
        {
            if (value > minValue && value < maxValue)
                return true;
            return false;
        }

        [TestMethod]
        public void GenerateTemperatureTest()
        {
            var generatedTemperature = dataGenerator.GenerateTemperature();
            IsTrue(MinMaxBoundary(generatedTemperature, TemperatureMin, TemperatureMax));
        }

        [TestMethod]
        public void GenerateSpo2Test()
        {
            var generatedSpo2 = dataGenerator.GenerateSpo2();
            IsTrue(MinMaxBoundary(generatedSpo2, Spo2Min, Spo2Max));
        }

        [TestMethod]
        public void GeneratePulseRateTest()
        {
            var generatedPulseRate = dataGenerator.GeneratePulseRate();
            IsTrue(MinMaxBoundary(generatedPulseRate, PulseRateMin, PulseRateMax));
        }
    }
}