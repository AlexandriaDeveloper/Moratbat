using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.EmployeeGrade;
using Application.Features.EmployeeGrade.Commands;
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