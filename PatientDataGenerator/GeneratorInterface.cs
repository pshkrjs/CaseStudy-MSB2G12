using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDataGenerator
{
	public interface IGeneratorInterface
	{
		int ChangePulse();
		int ChangeSpo2();
		decimal ChangeTemperature();
        void UpdateValues();
    }
}
