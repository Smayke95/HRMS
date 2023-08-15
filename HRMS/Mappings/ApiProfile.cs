using AutoMapper;
using HRMS.Core.Models;
using HRMS.Models;
using Task = HRMS.Core.Models.Task;
using TaskStatus = HRMS.Core.Models.TaskStatus;

namespace HRMS.Mappings;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<CityInsert, City>()
            .ForMember(x => x.Country, opt => opt.MapFrom(y => new Country { Id = y.CountryId ?? 0 }));

        CreateMap<CityUpdate, City>()
            .ForMember(x => x.Country, opt => opt.MapFrom(y => new Country { Id = y.CountryId ?? 0 }));

        CreateMap<CountryInsert, Country>();

        CreateMap<CountryUpdate, Country>();

        CreateMap<DepartmentInsert, Department>()
            .ForMember(x => x.ParentDepartment, opt => opt.MapFrom(y => new Department { Id = y.ParentDepartmentId ?? 0 }))
            .ForMember(x => x.Supervisor, opt => opt.MapFrom(y => new Employee { Id = y.SupervisorId ?? 0 }));

        CreateMap<DepartmentUpdate, Department>()
            .ForMember(x => x.ParentDepartment, opt => opt.MapFrom(y => new Department { Id = y.ParentDepartmentId ?? 0 }))
            .ForMember(x => x.Supervisor, opt => opt.MapFrom(y => new Employee { Id = y.SupervisorId ?? 0 }));

        CreateMap<EmployeeInsert, Employee>()
            .ForMember(x => x.BirthPlace, opt => opt.MapFrom(y => new City { Id = y.BirthPlaceId ?? 0 }))
            .ForMember(x => x.City, opt => opt.MapFrom(y => new City { Id = y.CityId ?? 0 }))
            .ForMember(x => x.Citizenship, opt => opt.MapFrom(y => new Country { Id = y.CitizenshipId ?? 0 }))
            .ForMember(x => x.Education, opt => opt.MapFrom(y => new Education { Id = y.EducationId ?? 0 }));

        CreateMap<EmployeeUpdate, Employee>()
            .ForMember(x => x.BirthPlace, opt => opt.MapFrom(y => new City { Id = y.BirthPlaceId ?? 0 }))
            .ForMember(x => x.City, opt => opt.MapFrom(y => new City { Id = y.CityId ?? 0 }))
            .ForMember(x => x.Citizenship, opt => opt.MapFrom(y => new Country { Id = y.CitizenshipId ?? 0 }))
            .ForMember(x => x.Education, opt => opt.MapFrom(y => new Education { Id = y.EducationId ?? 0 }));

        CreateMap<EmployeePositionInsert, EmployeePosition>()
            .ForMember(x => x.Employee, opt => opt.MapFrom(y => new Employee { Id = y.EmployeeId }))
            .ForMember(x => x.Position, opt => opt.MapFrom(y => new Position { Id = y.PositionId }));

        CreateMap<EventInsert, Event>()
            .ForMember(x => x.Employee, opt => opt.MapFrom(y => new Employee { Id = y.EmployeeId ?? 0 }));

        CreateMap<EventUpdate, Event>()
            .ForMember(x => x.Employee, opt => opt.MapFrom(y => new Employee { Id = y.EmployeeId ?? 0 }));

        CreateMap<EventTypeInsert, EventType>();
           
        CreateMap<EventTypeUpdate, EventType>();
            
        CreateMap<MessageInsert, Message>()
            .ForMember(x => x.Employee, opt => opt.MapFrom(y => new Employee { Id = y.EmployeeId }));

        CreateMap<PositionInsert, Position>()
            .ForMember(x => x.Department, opt => opt.MapFrom(y => new Department { Id = y.DepartmentId ?? 0 }))
            .ForMember(x => x.PayGrade, opt => opt.MapFrom(y => new PayGrade { Id = y.PayGradeId ?? 0 }))
            .ForMember(x => x.RequiredEducation, opt => opt.MapFrom(y => new Education { Id = y.RequiredEducationId ?? 0 }));

        CreateMap<PositionUpdate, Position>()
            .ForMember(x => x.Department, opt => opt.MapFrom(y => new Department { Id = y.DepartmentId ?? 0 }))
            .ForMember(x => x.PayGrade, opt => opt.MapFrom(y => new PayGrade { Id = y.PayGradeId ?? 0 }))
            .ForMember(x => x.RequiredEducation, opt => opt.MapFrom(y => new Education { Id = y.RequiredEducationId ?? 0 }));

        CreateMap<ProjectInsert, Project>();

        CreateMap<ProjectUpdate, Project>();

        CreateMap<TaskInsert, Task>()
            .ForMember(x => x.Project, opt => opt.MapFrom(y => new Project { Id = y.ProjectId ?? 0 }))
            .ForMember(x => x.Status, opt => opt.MapFrom(y => new TaskStatus { Id = y.StatusId ?? 0 }))
            .ForMember(x => x.Type, opt => opt.MapFrom(y => new TaskType { Id = y.TypeId ?? 0 }))
            .ForMember(x => x.Employee, opt => opt.MapFrom(y => new Employee { Id = y.EmployeeId ?? 0 }));

        CreateMap<TaskUpdate, Task>()
            .ForMember(x => x.Project, opt => opt.MapFrom(y => new Project { Id = y.ProjectId ?? 0 }))
            .ForMember(x => x.Status, opt => opt.MapFrom(y => new TaskStatus { Id = y.StatusId ?? 0 }))
            .ForMember(x => x.Type, opt => opt.MapFrom(y => new TaskType { Id = y.TypeId ?? 0 }))
            .ForMember(x => x.Employee, opt => opt.MapFrom(y => new Employee { Id = y.EmployeeId ?? 0 }));

        CreateMap<TaskStatusInsert, TaskStatus>();

        CreateMap<TaskStatusUpdate, TaskStatus>();

        CreateMap<TaskTypeInsert, TaskType>();

        CreateMap<TaskTypeUpdate, TaskType>();
    }
}