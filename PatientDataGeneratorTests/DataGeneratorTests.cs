using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using PatientDataGenerator;
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
            _patient = new Patient.Patient(DemoPatientId, DemoPatientName);
            _dataGenerator = new DataGenerator(_patient, DemosourcePath);
        }

        private bool MinMaxBoundary(decimal value, decimal minValue, decimal maxValue)
        {
            if (value >= minValue && value <= maxValue)
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