using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
