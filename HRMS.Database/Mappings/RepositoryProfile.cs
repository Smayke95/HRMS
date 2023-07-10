using AutoMapper;
using HRMS.Database.Models;
using Task = HRMS.Database.Models.Task;
using TaskStatus = HRMS.Database.Models.TaskStatus;

namespace HRMS.Database.Mappings;

public class RepositoryProfile : Profile
{
    public RepositoryProfile()
    {
        CreateMap<City, Core.Models.City>();

        CreateMap<Country, Core.Models.Country>();

        CreateMap<Department, Core.Models.Department>();

        CreateMap<Employee, Core.Models.Employee>();

        CreateMap<EmployeePosition, Core.Models.EmployeePosition>();

        CreateMap<Education, Core.Models.Education>();

        CreateMap<PayGrade, Core.Models.PayGrade>();

        CreateMap<Position, Core.Models.Position>();

        CreateMap<Project, Core.Models.Project>();

        CreateMap<Task, Core.Models.Task>();

        CreateMap<TaskComment, Core.Models.TaskComment>();

        CreateMap<TaskStatus, Core.Models.TaskStatus>();

        CreateMap<TaskType, Core.Models.TaskType>();
    }
}