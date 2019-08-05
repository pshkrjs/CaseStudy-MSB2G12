using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using PatientDataGenerator;
using static Resources.Constants;

namespace PatientTests
{
    [TestClass]
    public class PatientTests
    {
        private static Patient.Patient _patient;
        private static DataGenerator _dataGenerator;

        [AssemblyInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            _patient = new Patient.Patient(DemoPatientId, DemoPatientName);
            _dataGenerator = new DataGenerator(_patient, DemosourcePath);
        }

        [TestMethod]
        public void SetPulseRateTest()
        {
            var expectedPulseRate = _dataGenerator.GeneratePulseRate();
            _patient.PulseRate = expectedPulseRate;

            var actualPulseRate = _patient.PulseRate;
            AreEqual(expectedPulseRate, actualPulseRate);
        }
        [TestMethod]
        public void SetSpo2Test()
        {
            var expectedSpo2 = _dataGenerator.GenerateSpo2();
            _patient.Spo2 = expectedSpo2;

            var actualSpo2 = _patient.Spo2;
            AreEqual(expectedSpo2, actualSpo2);
        }
        [TestMethod]
        public void SetTemperatureTest()
        {
            var expectedTemperature = _dataGenerator.GenerateTemperature();
            _patient.Temperature = expectedTemperature;

            var actualTemperature = _patient.Temperature;
            AreEqual(expectedTemperature, actualTemperature);
        }
    }
}
