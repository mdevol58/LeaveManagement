namespace LeaveManagement.Application.Exceptions
{
    public class InsufficientDaysExceptions : Exception
    {
        public InsufficientDaysExceptions(int daysRequested,
                                          int daysAvailable)
        {
            DaysRequested = daysRequested;
            DaysAvailable = daysAvailable;
        }

        public int DaysRequested { get; }

        public int DaysAvailable { get; }

        public override string Message
        { 
            get
            {
                return $"There are insufficient days available for this request. {DaysRequested} {((DaysRequested == 1) ? "day was" :  "days were")} requested and {DaysAvailable} {((DaysAvailable == 1) ? "day is" : "days are")} available";
            }
        }
    }
}
