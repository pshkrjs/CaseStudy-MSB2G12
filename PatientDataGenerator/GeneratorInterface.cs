namespace PatientDataGenerator
{
	public interface IGeneratorInterface
	{
		int GeneratePulseRate();
		int GenerateSpo2();
		decimal GenerateTemperature();
        void UpdateValues();
    }
}
