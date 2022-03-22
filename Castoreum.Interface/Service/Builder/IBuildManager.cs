using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castoreum.Interface.Service.Builder
{
    public interface IBuildManager
    {
        void BuildMod(string path, bool isZ2f);
        void BuildPackage(string path, bool isZ2f);
    }
}
