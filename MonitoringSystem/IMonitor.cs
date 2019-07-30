using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem
{
    interface IMonitor
    {
        void CheckStatus(string fileName);
        void Alert(string patienId);
    }
}
