using AutoMapper;
using AutoMapper.QueryableExtensions;

using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Exceptions;
using LeaveManagement.Web.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly AutoMapper.IConfigurationProvider configurationProvider;
        private readonly UserManager<Employee> userManager;

        public LeaveRequestRepository(ApplicationDbContext context,
                                      IMapper mapper,
                                      IHttpContextAccessor httpContextAccessor,
                                      ILeaveAllocationRepository leaveAllocationRepository,
                                      AutoMapper.IConfigurationProvider configurationProvider,
                                      UserManager<Employee> userManager) :
            base(context)
        {
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.configurationProvider = configurationProvider;
            this.userManager = userManager;
        }

        public async Task<bool> CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);

            if (leaveRequest == null)
            {
                return false;
            }

            leaveRequest.Canceled = true;

            if (leaveRequest.Approved.HasValue &&
                (leaveRequest.Approved.Value == true))
            {
                var allocation = await leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int daysRequested = (leaveRequest.EndDate - leaveRequest.StartDate).Days;

                allocation.NumberOfDays += daysRequested;
            }

            await UpdateAsync(leaveRequest);

            return true;
        }

        public async Task ChangeAprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);

            leaveRequest.Approved = approved;

            if (approved)
            {
                var allocation = await leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int daysRequested = (leaveRequest.EndDate - leaveRequest.StartDate).Days;

                allocation.NumberOfDays -= daysRequested;
            }

            await UpdateAsync(leaveRequest);
        }

        public async Task CreateLeaveRequest(LeaveRequestCreateVM request)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var allocation = await leaveAllocationRepository.GetEmployeeAllocation(user.Id, request.LeaveTypeId);

            if (allocation is null)
            {
                throw new NoAllocationAvailableException();
            }

            var daysRequested = (request.EndDate.Value - request.StartDate.Value).Days;

            if (daysRequested > allocation.NumberOfDays)
            {
                throw new InsufficientDaysExceptions(daysRequested, allocation.NumberOfDays);
            }

            var leaveRequest = mapper.Map<LeaveRequest>(request);

            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await context.LeaveRequests
                                             .Include(leaveRequest => leaveRequest.LeaveType)
                                             .ToListAsync();
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(leaveRequest => leaveRequest.Approved == true),
                PendingRequests = leaveRequests.Count(leaveRequest => !leaveRequest.Approved.HasValue),
                RejectedRequests = leaveRequests.Count(leaveRequest => leaveRequest.Approved == false),
                LeaveRequests = mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }

            return model;
        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
            return await context.LeaveRequests
                                .Include(leaveRequest => leaveRequest.LeaveType)
                                .Where(leaveRequest => leaveRequest.RequestingEmployeeId == employeeId)
                                .ProjectTo<LeaveRequestVM>(configurationProvider)
                                .ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await context.LeaveRequests
                                            .Include(leaveRequest => leaveRequest.LeaveType)
                                            .FirstOrDefaultAsync(leaveRequest => leaveRequest.Id == id);

            if (leaveRequest == null)
            {
                return null;
            }

            var model = mapper.Map<LeaveRequestVM>(leaveRequest);

            model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));

            return model;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext?.User);
            var allocation = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = await GetAllAsync(user.Id);
            var model = new EmployeeLeaveRequestViewVM(allocation, requests);

            return model;
        }
    }
}
