using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace LeaveManagement.Web.Exceptions
{
    public class NoAllocationAvailableException : Exception
    {
        public NoAllocationAvailableException()
        {
        }

        public override string Message
        {
            get
            {
                return $"No leave type allocation exists for the type of leave requested";
            }
        }
    }
}
