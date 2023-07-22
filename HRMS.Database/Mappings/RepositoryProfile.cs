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
        CreateMap<Core.Models.City, City>()
            .ForMember(x => x.CountryId, opt => opt.MapFrom(y => y.Country.Id))
            .ForMember(x => x.Country, opt => opt.Ignore());

        CreateMap<Country, Core.Models.Country>()
            .ReverseMap();

        CreateMap<Department, Core.Models.Department>()
            .MaxDepth(2);
        CreateMap<Core.Models.Department, Department>()
            .ForMember(x => x.ParentDepartmentId, opt => opt.MapFrom(y => y.ParentDepartment.Id))
            .ForMember(x => x.ParentDepartment, opt => opt.Ignore())
            .ForMember(x => x.SupervisorId, opt => opt.MapFrom(y => y.Supervisor.Id))
            .ForMember(x => x.Supervisor, opt => opt.Ignore());

        CreateMap<Employee, Core.Models.Employee>()
            .ForMember(x => x.Roles, opt => opt.MapFrom(y => y.Roles.Select(z => z.Role)));
        CreateMap<Core.Models.Employee, Employee>()
            .ForMember(x => x.BirthPlaceId, opt => opt.MapFrom(y => y.BirthPlace.Id))
            .ForMember(x => x.BirthPlace, opt => opt.Ignore())
            .ForMember(x => x.CityId, opt => opt.MapFrom(y => y.City.Id))
            .ForMember(x => x.City, opt => opt.Ignore())
            .ForMember(x => x.CitizenshipId, opt => opt.MapFrom(y => y.Citizenship.Id))
            .ForMember(x => x.Citizenship, opt => opt.Ignore())
            .ForMember(x => x.EducationId, opt => opt.MapFrom(y => y.Education.Id))
            .ForMember(x => x.Education, opt => opt.Ignore());

        CreateMap<EmployeePosition, Core.Models.EmployeePosition>();
        CreateMap<Core.Models.EmployeePosition, EmployeePosition>()
            .ForMember(x => x.EmployeeId, opt => opt.MapFrom(y => y.Employee.Id))
            .ForMember(x => x.Employee, opt => opt.Ignore())
            .ForMember(x => x.PositionId, opt => opt.MapFrom(y => y.Position.Id))
            .ForMember(x => x.Position, opt => opt.Ignore());

        CreateMap<EmployeeRole, Core.Models.EmployeeRole>();
        CreateMap<Core.Models.EmployeeRole, EmployeeRole>()
            .ForMember(x => x.EmployeeId, opt => opt.MapFrom(y => y.Employee.Id))
            .ForMember(x => x.Employee, opt => opt.Ignore());

        CreateMap<Education, Core.Models.Education>()
            .ReverseMap();

        CreateMap<Message, Core.Models.Message>();
        CreateMap<Core.Models.Message, Message>()
            .ForMember(x => x.EmployeeId, opt => opt.MapFrom(y => y.Employee.Id))
            .ForMember(x => x.Employee, opt => opt.Ignore());

        CreateMap<PayGrade, Core.Models.PayGrade>()
            .ReverseMap();

        CreateMap<Position, Core.Models.Position>();
        CreateMap<Core.Models.Position, Position>()
            .ForMember(x => x.DepartmentId, opt => opt.MapFrom(y => y.Department.Id))
            .ForMember(x => x.Department, opt => opt.Ignore())
            .ForMember(x => x.PayGradeId, opt => opt.MapFrom(y => y.PayGrade.Id))
            .ForMember(x => x.PayGrade, opt => opt.Ignore())
            .ForMember(x => x.RequiredEducationId, opt => opt.MapFrom(y => y.RequiredEducation.Id))
            .ForMember(x => x.RequiredEducation, opt => opt.Ignore());

        CreateMap<Project, Core.Models.Project>()
            .ReverseMap();

        CreateMap<Task, Core.Models.Task>()
            .ReverseMap();

        CreateMap<TaskComment, Core.Models.TaskComment>()
            .ReverseMap();

        CreateMap<TaskStatus, Core.Models.TaskStatus>()
            .ReverseMap();

        CreateMap<TaskType, Core.Models.TaskType>()
            .ReverseMap();
    }
}