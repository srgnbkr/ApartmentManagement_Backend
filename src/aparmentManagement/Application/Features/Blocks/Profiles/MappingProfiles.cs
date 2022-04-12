using Application.Features.Blocks.DTOs;
using Application.Features.Blocks.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blocks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Block, BlockListDto>().ReverseMap();
            CreateMap<IPaginate<Block>, BlockListModel>().ReverseMap();
            CreateMap<Block, BlockDto>().ReverseMap();
        }
    }
}
