﻿using AutoMapper;
using AutoMapper.QueryableExtensions;

using LeaveManagement.Application.Contracts;
using LeaveManagement.Common.Constants;
using LeaveManagement.Common.Models;
using LeaveManagement.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Application.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly AutoMapper.IConfigurationProvider configurationProvider;
        private readonly IEmailSender emailSender;
        private readonly IMapper mapper;

        public LeaveAllocationRepository(ApplicationDbContext context,
                                         UserManager<Employee> userManager,
                                         ILeaveTypeRepository leaveTypeRepository,
                                         AutoMapper.IConfigurationProvider configurationProvider,
                                         IEmailSender emailSender,
                                         IMapper mapper) :
            base(context)
        {
            this.userManager = userManager;
            this.leaveTypeRepository = leaveTypeRepository;
            this.configurationProvider = configurationProvider;
            this.emailSender = emailSender;
            this.mapper = mapper;
        }

        public async Task<bool> AllocationExists(string employeeId,
                                                 int leaveTypeId,
                                                 int period)
        {
            return await context.LeaveAllocations.AnyAsync(leaveAllocation => (leaveAllocation.EmployeeId == employeeId) &&
                                                                              (leaveAllocation.LeaveTypeId == leaveTypeId) &&
                                                                              (leaveAllocation.Period == period));
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await context.LeaveAllocations
                                           .Include(leaveAllocation => leaveAllocation.LeaveType)
                                           .Where(leaveAllocation => leaveAllocation.EmployeeId == employeeId)
                                           .ProjectTo<LeaveAllocationVM>(configurationProvider)
                                           .ToListAsync();
            var employee = await userManager.FindByIdAsync(employeeId);
            var employeeAllocationModel = mapper.Map<EmployeeAllocationVM>(employee);

            employeeAllocationModel.LeaveAllocations = allocations;

            return employeeAllocationModel;
        }

        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await context.LeaveAllocations.FirstOrDefaultAsync(leaveAllocation => ((leaveAllocation.EmployeeId == employeeId) &&
                                                                                          (leaveAllocation.LeaveTypeId == leaveTypeId)));
        }

        public async Task<LeaveAllocationEditVM?> GetEmployeeAllocation(int id)
        {
            var allocation = await context.LeaveAllocations
                                          .Include(leaveAllocation => leaveAllocation.LeaveType)
                                          .FirstOrDefaultAsync(leaveAllocation => leaveAllocation.Id == id);

            if (allocation == null)
            {
                return null;
            }

            var employee = await userManager.FindByIdAsync(allocation.EmployeeId);
            var model = mapper.Map<LeaveAllocationEditVM>(allocation);

            model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(allocation.EmployeeId));

            return model;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await leaveTypeRepository.GetAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>();
            var employeesWithNewAllocations = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                {
                    continue;
                }

                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType.DefaultDays
                });

                employeesWithNewAllocations.Add(employee);
            }

            await AddRangeAsync(allocations);

            foreach (Employee employee in employeesWithNewAllocations)
            {
                if (employee.Email is not null)
                {
                    await emailSender.SendEmailAsync(employee.Email,
                                                     $"Leave Allocation Posted for {period}",
                                                     $"Your {leaveType.Name} has been posted for the perios of {period}.  You have been given {leaveType.DefaultDays} days.");
                }
            }
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            var leaveAllocation = await GetAsync(model.Id);

            if (leaveAllocation == null)
            {
                return false;
            }

            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;

            await UpdateAsync(leaveAllocation);

            return true;
        }
    }
}
