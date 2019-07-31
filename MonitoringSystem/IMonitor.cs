using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem
{
    public interface IMonitor
    {
        void CheckStatus();
        void Alert(List<string> anomalyList);
    }
}
