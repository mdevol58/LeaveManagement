namespace LeaveManagement.Web.Data
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }

        public int LeaveTypeId { get; set; }

        public int EmployeeId { get; set; }

        public LeaveType LeaveType { get; set; }
    }
}
