﻿using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.Models;

namespace DIMS_Core.MappingProfiles
{
    public class UserViewModelProfile : Profile
    {
        public UserViewModelProfile()
        {
            CreateMap<UserProfileModel, UserProfileViewModel>()
                .ForMember(q => q.FullName, w => w.MapFrom(q => $"{q.FirstName} {q.LastName}"))
                .ReverseMap();
        }
    }
}