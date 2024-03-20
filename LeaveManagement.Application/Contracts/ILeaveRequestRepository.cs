using LeaveManagement.Common.Models;
using LeaveManagement.Data;

namespace LeaveManagement.Application.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool> CancelLeaveRequest(int leaveRequestId);

        Task ChangeAprovalStatus(int leaveRequestId,
                                 bool approved);

        Task CreateLeaveRequest(LeaveRequestCreateVM request);

        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();

        Task<List<LeaveRequestVM>> GetAllAsync(string employeeId);

        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id);

        Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails();
    }
}
