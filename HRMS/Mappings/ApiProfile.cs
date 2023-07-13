using AutoMapper;
using HRMS.Core.Models;
using HRMS.Models;

namespace HRMS.Mappings;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<PositionInsert, Position>()
            .ForMember(x => x.Department, opt => opt.MapFrom(y => new Department { Id = y.DepartmentId ?? 0 }))
            .ForMember(x => x.PayGrade, opt => opt.MapFrom(y => new PayGrade { Id = y.PayGradeId ?? 0 }))
            .ForMember(x => x.RequiredEducation, opt => opt.MapFrom(y => new Education { Id = y.RequiredEducationId ?? 0 }));

        CreateMap<PositionUpdate, Position>()
            .ForMember(x => x.Department, opt => opt.MapFrom(y => new Department { Id = y.DepartmentId ?? 0 }))
            .ForMember(x => x.PayGrade, opt => opt.MapFrom(y => new PayGrade { Id = y.PayGradeId ?? 0 }))
            .ForMember(x => x.RequiredEducation, opt => opt.MapFrom(y => new Education { Id = y.RequiredEducationId ?? 0 }));
    }
}