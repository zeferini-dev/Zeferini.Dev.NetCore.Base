using System;

namespace NetCore.Base.Model.Request
{
    public abstract class RequestBase
    {        
        public Guid SysUsuSessionId { get; private set; }
        private Guid RequestId { get; set; } = Guid.NewGuid();
        private DateTime RequestedIn { get; set; } = DateTime.Now;

        protected RequestBase()
        {
        }

        protected RequestBase(Guid sysUsuSessionId)
        {
            SysUsuSessionId = sysUsuSessionId;
        }

    }
}
