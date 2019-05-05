using AutoMapper;
using Domain.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tender, TenderDto>();
            CreateMap<TenderDto, Tender>();

            CreateMap<TenderTag, TenderTagDto>();
            CreateMap<TenderTagDto, TenderTag>();

        }
    }
}
