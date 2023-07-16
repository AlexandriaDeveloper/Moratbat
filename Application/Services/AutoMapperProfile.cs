using Application.Features.Bank.Queries.GetBanks;
using Application.Features.BankBranche;
using Application.Features.BudgetItems;
using Application.Features.Collection.Queries.GetCollictions;
using Application.Features.EmployeeBank;
using Application.Features.EmployeeCollection.Commands.AddEmployeeToCollection;
using Application.Features.EmployeeCollection.Queries.GetEmployeesInCollection;
using Application.Features.EmployeeGrade;
using Application.Features.EmployeePartTime.Commands.AddPartTimeToEmployee;
using Application.Features.Employees.Queries.GetEmployees;
using Application.Features.Grade.Queries.GetGradeById;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;

namespace Application.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //Model To Dto 
            CreateMap<EmployeeCollectionModel, EmployeeInCollectionDto>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Employee.Name))
             .ForMember(dest => dest.TabCode, opt => opt.MapFrom(src => src.Employee.TabCode))
             .ForMember(dest => dest.TegaraCode, opt => opt.MapFrom(src => src.Employee.TegaraCode))
             .ForMember(dest => dest.NationalId, opt => opt.MapFrom(src => src.Employee.NationalId))
            ;
            CreateMap<CollectionModel, CollectionDto>()
             .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.EmployeeCollection.Count));
            CreateMap<EmployeePartTimeModel, EmployeePartTimeDto>();
            CreateMap<BankBranchModel, BankBranchDto>().ReverseMap();
            CreateMap<BankModel, BankDto>().ReverseMap();
            CreateMap<GradeModel, GradeDto>().ReverseMap();
            CreateMap<EmployeeModel, EmployeeDto>()
               .ForMember(dest => dest.GradeId, opt => opt.MapFrom(src => src.Grade.FirstOrDefault(x => x.EndAt == null).GradeId))
               .ForMember(dest => dest.InPartTime, opt => opt.MapFrom(src => src.PartTime.Any(x => x.InPartTime)))
               .ForMember(dest => dest.HasPartTimeHistory, opt => opt.MapFrom(src => src.PartTime.Any(x => x != null)))
               .ReverseMap();

            CreateMap<EmployeeGradeModel, EmployeeGradeDto>()
            .ForMember(dest => dest.GradeName, opt => opt.MapFrom(src => src.Grade.Name));

            CreateMap<AccountTreeModel, AccountTreeDto>().ReverseMap();
            CreateMap<AccountTreeDetailsModel, AccountTreeDetailsDto>().ReverseMap();

            //Dto To Model
            CreateMap<EmployeeGradeDto, EmployeeGradeModel>();
            CreateMap<AddEmployeeToCollectionRequest, EmployeeCollectionModel>();
            CreateMap<EmployeePartTimeDto, EmployeePartTimeModel>()
              .ForMember(dest => dest.InPartTime, opt => opt.Ignore())
            ;
            CreateMap<EmployeeBankAccountRequest, EmployeeBankAccountModel>()
                    .ForMember(dest => dest.BankAId, opt => opt.MapFrom(src => src.BranchAId))
                    .ForMember(dest => dest.BankBId, opt => opt.MapFrom(src => src.BranchBId))
                  ;
            CreateMap<EmployeeDto, EmployeeModel>();
            CreateMap<CollectionDto, CollectionModel>();
        }

    }
}