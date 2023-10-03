using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.WebApp.Data
{
    public class VerityOperatingSystem
    {
        public bool CheckIsPhone()
        {
            if(OperatingSystem.IsBrowser() || OperatingSystem.IsMacOS() || OperatingSystem.IsWindows())
            {
                return false;
            }else{
                return true;
            }
        }
    }
}