namespace LeaveManagement.Application.Exceptions
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
