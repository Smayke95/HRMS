using HRMS.Database.Models;
using HRMS.Database.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Database.Seed;

public static class EmployeeRoleData
{
    public static void SeedData(this EntityTypeBuilder<EmployeeRole> entity)
    {
        entity.HasData(
            new EmployeeRole
            {
                Id = 1,
                EmployeeId = 1,
                Role = Role.Admin
            },
            new EmployeeRole
            {
                Id = 2,
                EmployeeId = 1,
                Role = Role.Manager
            },
            new EmployeeRole
            {
                Id = 3,
                EmployeeId = 1,
                Role = Role.Employee
            },
            new EmployeeRole
            {
                Id = 4,
                EmployeeId = 2,
                Role = Role.Manager
            },
            new EmployeeRole
            {
                Id = 5,
                EmployeeId = 2,
                Role = Role.Employee
            },
            new EmployeeRole
            {
                Id = 6,
                EmployeeId = 3,
                Role = Role.Employee
            },
            new EmployeeRole
            {
                Id = 7,
                EmployeeId = 4,
                Role = Role.Employee
            },
            new EmployeeRole
            {
                Id = 8,
                EmployeeId = 5,
                Role = Role.Employee
            },
            new EmployeeRole
            {
                Id = 9,
                EmployeeId = 6,
                Role = Role.Employee
            },
            new EmployeeRole
            {
                Id = 10,
                EmployeeId = 7,
                Role = Role.Employee
            },
            new EmployeeRole
            {
                Id = 11,
                EmployeeId = 8,
                Role = Role.Employee
            },
            new EmployeeRole
            {
                Id = 12,
                EmployeeId = 9,
                Role = Role.Employee
            },
            new EmployeeRole
            {
                Id = 13,
                EmployeeId = 10,
                Role = Role.Employee
            }
        );
    }
}