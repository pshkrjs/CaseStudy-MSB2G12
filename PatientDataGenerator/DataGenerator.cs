using System;

namespace PatientDataGenerator
{
	public class DataGenerator : IGeneratorInterface
	{
		private Patient.Patient pat;
		public int ChangePulse()
		{
			Random rand= new Random();
			return rand.Next(0,230);

		}

		public int ChangeSpo2()
		{
			Random rand = new Random();
			return rand.Next(0, 100);
		}

		public decimal ChangeTemperature()
		{
			var rand = new Random();
			var temp = new decimal(rand.Next(89,110)+rand.NextDouble());
			return Math.Round(temp,1);
		}
		string random_string()
		{
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			var stringChars = new char[5];
			var random = new Random();

			for (int i = 0; i<stringChars.Length; i++)
			{
				stringChars[i] = chars[random.Next(chars.Length)];
			}

			var finalString = new String(stringChars);
			return finalString;
		}

		public void UpdateValues()
		{
			ChangeSpo2();
			ChangePulse();
			ChangeTemperature();
		}
	

		public DataGenerator()
		{
			Random rand = new Random();
			var randInt = rand.Next(100, 999);
			string patId = random_string() + randInt.ToString();
			pat = new Patient.Patient(patId,ChangeSpo2(),ChangePulse(),ChangeTemperature());
			
		}
	}
}
