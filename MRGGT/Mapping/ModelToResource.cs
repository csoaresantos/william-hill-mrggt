using System;
using AutoMapper;
using MRGGT.Models;
using MRGGT.Resources;

namespace MRGGT.Mapping
{
    public class ModelToResource : Profile
    {
        public ModelToResource()
        {
            CreateMap<Brand, BrandResource>();
            CreateMap<Customer, CustomerResource>();
        }
    }
}
