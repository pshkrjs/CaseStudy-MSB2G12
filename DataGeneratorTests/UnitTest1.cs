using System;
using System.CodeDom;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PatientDataGenerator;
using Resources;
using Patient;
namespace DataGeneratorTests
{
	[TestClass]
	public class DataGeneratorTest
	{
		[TestMethod]
		public void ChangePulseTest()
		{
			Patient.Patient patient = new Patient.Patient("ABCDE123", "ABCDE");
			DataGenerator testobj = new DataGenerator(patient, @"\ABCDE123.txt");
			var value = testobj.ChangePulse();
			Assert.IsTrue((value >= 0) && (value < 230));
		}
		[TestMethod]
		public void ChangeTemperatureTest()
		{
			Patient.Patient patient = new Patient.Patient("ABCDE123", "ABCDE");
			DataGenerator testobj = new DataGenerator(patient, @"\ABCDE123.txt");
			var value = testobj.ChangeTemperature();
			Assert.IsTrue((value >= 89) && (value < 110));
		}
		[TestMethod]
		public void ChangeSpo2Test()
		{
			Patient.Patient patient = new Patient.Patient("ABCDE123", "ABCDE");
			DataGenerator testobj = new DataGenerator(patient, @"\ABCDE123.txt");
			var value = testobj.ChangeSpo2();
			Assert.IsTrue((value >= 0) && (value < 100));
		}

	}
}


	

