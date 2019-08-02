using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem
{
	/*
	 * IMonitor Interface has two methods:: CheckStatus and Alert
	 * CheckStatus:: which is called every 10 seconds to check the status of the each of the values and
	   trigger Alert if anomalies are found
	 */
    public interface IMonitor
    {
        void CheckStatus();
        void Alert(List<string> anomalyList);
    }
}
