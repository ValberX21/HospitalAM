using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Core.Enums
{
    public enum PasswordVerifyResult
    {
        Failed = 0,
        Success = 1,
        SuccessRehashNeeded = 2
    }
}
