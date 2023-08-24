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
        CreateMap<CityInsertUpdate, City>()
            .ForMember(x => x.Country, opt => opt.MapFrom(y => new Country { Id = y.CountryId ?? 0 }))
            .ForMember(x => x.ZipCode, opt => opt.MapFrom(y => y.ZipCode ?? ""));

        CreateMap<CountryInsertUpdate, Country>();

        CreateMap<DepartmentInsertUpdate, Department>()
            .ForMember(x => x.ParentDepartment, opt => opt.MapFrom(y => new Department { Id = y.ParentDepartmentId ?? 0 }))
            .ForMember(x => x.Supervisor, opt => opt.MapFrom(y => y.SupervisorId == null ? null : new Employee { Id = y.SupervisorId ?? 0 }));

        CreateMap<EmployeeInsertUpdate, Employee>()
            .ForMember(x => x.BirthDate, opt => opt.MapFrom(y => y.BirthDate ?? DateTime.Now))
            .ForMember(x => x.BirthPlace, opt => opt.MapFrom(y => y.BirthPlaceId == null ? null : new City { Id = y.BirthPlaceId ?? 0 }))
            .ForMember(x => x.City, opt => opt.MapFrom(y => y.CityId == null ? null : new City { Id = y.CityId ?? 0 }))
            .ForMember(x => x.Citizenship, opt => opt.MapFrom(y => y.CitizenshipId == null ? null : new Country { Id = y.CitizenshipId ?? 0 }))
            .ForMember(x => x.Education, opt => opt.MapFrom(y => y.EducationId == null ? null : new Education { Id = y.EducationId ?? 0 }));

        CreateMap<EmployeePositionInsertUpdate, EmployeePosition>()
            .ForMember(x => x.Employee, opt => opt.MapFrom(y => new Employee { Id = y.EmployeeId }))
            .ForMember(x => x.Position, opt => opt.MapFrom(y => new Position { Id = y.PositionId }));

        CreateMap<EventInsertUpdate, Event>()
            .ForMember(x => x.Employee, opt => opt.MapFrom(y => y.EmployeeId == null ? null : new Employee { Id = y.EmployeeId ?? 0 }))
            .ForMember(x => x.EventType, opt => opt.MapFrom(y => y.EventTypeId == null ? null : new EventType { Id = y.EventTypeId ?? 0 }))
            .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description ?? ""));

        CreateMap<EventTypeInsertUpdate, EventType>()
            .ForMember(x => x.Color, opt => opt.MapFrom(y => y.Color ?? "#ffffff"));

        CreateMap<MessageInsert, Message>()
            .ForMember(x => x.Employee, opt => opt.MapFrom(y => new Employee { Id = y.EmployeeId }));

        CreateMap<PositionInsertUpdate, Position>()
            .ForMember(x => x.Department, opt => opt.MapFrom(y => new Department { Id = y.DepartmentId ?? 0 }))
            .ForMember(x => x.PayGrade, opt => opt.MapFrom(y => new PayGrade { Id = y.PayGradeId ?? 0 }))
            .ForMember(x => x.RequiredEducation, opt => opt.MapFrom(y => new Education { Id = y.RequiredEducationId ?? 0 }));

        CreateMap<ProjectInsertUpdate, Project>()
            .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description ?? ""));

        CreateMap<TaskInsertUpdate, Task>()
            .ForMember(x => x.Project, opt => opt.MapFrom(y => new Project { Id = y.ProjectId ?? 0 }))
            .ForMember(x => x.Status, opt => opt.MapFrom(y => new TaskStatus { Id = y.StatusId ?? 0 }))
            .ForMember(x => x.Type, opt => opt.MapFrom(y => new TaskType { Id = y.TypeId ?? 0 }))
            .ForMember(x => x.Employee, opt => opt.MapFrom(y => new Employee { Id = y.EmployeeId ?? 0 }))
            .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description ?? ""));

        CreateMap<TaskCommentInsertUpdate, TaskComment>()
            .ForMember(x => x.Task, opt => opt.MapFrom(y => new Task { Id = y.TaskId ?? 0 }))
            .ForMember(x => x.Employee, opt => opt.MapFrom(y => new Employee { Id = y.EmployeeId ?? 0 }));

        CreateMap<TaskStatusInsertUpdate, TaskStatus>();

        CreateMap<TaskTypeInsertUpdate, TaskType>();
    }
}