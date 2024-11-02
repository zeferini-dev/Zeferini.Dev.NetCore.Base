using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Base.Tests
{
    public class GuidValidator
    {
        public static bool IsValidGuid(string guidString)
        {
            return Guid.TryParse(guidString, out _);
        }
    }
}
