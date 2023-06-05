using Application.Features.Bank.Queries.GetBanks;
using Application.Features.BankBranche;
using Application.Features.EmployeeGrade;
using Application.Features.Employees.Queries.GetEmployees;
using Application.Features.Grade.Queries.GetGradeById;
using AutoMapper;
using Domain;

namespace Application.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Model To Dto 
            CreateMap<BankBranchModel, BankBranchDto>().ReverseMap();
            CreateMap<BankModel, BankDto>().ReverseMap();
            CreateMap<GradeModel, GradeDto>().ReverseMap();
            CreateMap<EmployeeModel, EmployeeDto>()
               .ForMember(dest => dest.GradeId, opt => opt.MapFrom(src => src.Grade.FirstOrDefault(x => x.EndAt == null).GradeId))
            .ReverseMap();
            CreateMap<EmployeeGradeModel, EmployeeGradeDto>()
            .ForMember(dest => dest.GradeName, opt => opt.MapFrom(src => src.Grade.Name));

            //Dto To Model
            CreateMap<EmployeeGradeDto, EmployeeGradeModel>();




        }

    }
}