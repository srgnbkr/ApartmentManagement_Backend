using Application.Features.Users.DTOs;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<User>, UserListModel>().ReverseMap();
            CreateMap<User, UserListDto>().ForMember(c => c.HomeOwnerTypeDescription, opt => opt.MapFrom(c => c.HomeOwnerType.Description));

        }
    }
}
