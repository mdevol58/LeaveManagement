using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CancelLeaveRequest(int leaveRequestId);

        Task ChangeAprovalStatus(int leaveRequestId,
                                 bool approved);

        Task CreateLeaveRequest(LeaveRequestCreateVM request);

        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();

        Task<List<LeaveRequest>> GetAllAsync(string employeeId);

        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id);

        Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails();
    }
}
