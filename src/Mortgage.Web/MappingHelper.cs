using AutoMapper;
using Mortgage.Data.DTO;
using Mortgage.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mortgage.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProspectDTO, Prospect>()
                .ForMember(des => des.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(des => des.AnnualInterest, opt => opt.MapFrom(src => src.AnnualInterest))
                .ForMember(des => des.LoanAmount, opt => opt.MapFrom(src => src.LoanAmount))
                .ForMember(des => des.LoanTerm, opt => opt.MapFrom(src => src.LoanTerm))
                .ReverseMap();
        }
     }
}
