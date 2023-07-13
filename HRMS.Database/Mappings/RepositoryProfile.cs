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

        CreateMap<Department, Core.Models.Department>()
            .MaxDepth(2);

        CreateMap<Employee, Core.Models.Employee>();

        CreateMap<EmployeePosition, Core.Models.EmployeePosition>();

        CreateMap<Education, Core.Models.Education>();

        CreateMap<PayGrade, Core.Models.PayGrade>();

        CreateMap<Position, Core.Models.Position>();
        CreateMap<Core.Models.Position, Position>()
            .ForMember(x => x.DepartmentId, opt => opt.MapFrom(y => y.Department.Id))
            .ForMember(x => x.Department, opt => opt.Ignore())
            .ForMember(x => x.PayGradeId, opt => opt.MapFrom(y => y.PayGrade.Id))
            .ForMember(x => x.PayGrade, opt => opt.Ignore())
            .ForMember(x => x.RequiredEducationId, opt => opt.MapFrom(y => y.RequiredEducation.Id))
            .ForMember(x => x.RequiredEducation, opt => opt.Ignore());

        CreateMap<Project, Core.Models.Project>();

        CreateMap<Task, Core.Models.Task>();

        CreateMap<TaskComment, Core.Models.TaskComment>();

        CreateMap<TaskStatus, Core.Models.TaskStatus>();

        CreateMap<TaskType, Core.Models.TaskType>();
    }
}