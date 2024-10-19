using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Base
{
    public static class NumberValidator
    {
        public static bool ValidateInt(int value)
        {
           return (value >= 0);
        }
    }
}
