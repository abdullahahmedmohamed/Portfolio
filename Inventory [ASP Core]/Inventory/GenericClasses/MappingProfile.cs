using AutoMapper;
using Inventory.DTOs;
using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.GenericClasses
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //CreateMap<string, DateTime>().ConvertUsing(s => Convert.ToDateTime(s));
            //CreateMap<DateTime, string>().ConvertUsing(s => s.ToShortDateString());

            // Sell_Details
            CreateMap<Sell_DetailsDto, Sell_Details>();
            CreateMap<Sell_Details, Sell_DetailsDto>();

            // Sell
            CreateMap<SellDto, Sell>()
                .ForMember(m => m.sellId, opt => opt.Ignore())
                .ForMember(m => m.docment, opt => opt.Ignore())
                .ForMember(m => m.Sell_Details, opt => opt.Ignore());
            

            CreateMap<Sell, SellDto>()
                .ForMember(m => m.docment, opt => opt.Ignore())
                .ForMember(m => m.Sell_DetailsDto, opt => opt.Ignore());
                

        }
    }
}
