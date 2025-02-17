﻿using AutoMapper;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() { 
        CreateMap<BookDtoForUpdate,Book>}
    }
}
