using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Base.Tests
{
    public static class DomainAssertExtension
    {
        public static void WithMessage(this NetCore.Base.BaseException exception, string message)
        {
            if (exception.ErrorMessages.Contains(message))
                Assert.True(true);
            else
                Assert.False(true, $"I was waiting for the message '{message}'");
        }
    }
}
