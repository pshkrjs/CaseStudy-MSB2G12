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
        private static Patient.Patient _patient;
        private static DataGenerator _dataGenerator;

        [AssemblyInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            _patient = new Patient.Patient(demoPatientId, demoPatientName);
            _dataGenerator = new DataGenerator(_patient, demosourcePath);
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
            var generatedTemperature = _dataGenerator.GenerateTemperature();
            IsTrue(MinMaxBoundary(generatedTemperature, TemperatureMin, TemperatureMax));
        }

        [TestMethod]
        public void GenerateSpo2Test()
        {
            var generatedSpo2 = _dataGenerator.GenerateSpo2();
            IsTrue(MinMaxBoundary(generatedSpo2, Spo2Min, Spo2Max));
        }

        [TestMethod]
        public void GeneratePulseRateTest()
        {
            var generatedPulseRate = _dataGenerator.GeneratePulseRate();
            IsTrue(MinMaxBoundary(generatedPulseRate, PulseRateMin, PulseRateMax));
        }
    }
}