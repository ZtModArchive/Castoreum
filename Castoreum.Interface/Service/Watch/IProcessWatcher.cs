using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castoreum.Interface.Service.Watch
{
    public interface IProcessWatcher
    {
        void LaunchProcess();
        void EndProcess();
        void Watch();
    }
}
