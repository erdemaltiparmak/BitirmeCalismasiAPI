using AutoMapper;
using BitirmeCalismasiAPI.Models;
using BitirmeCalismasiAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeCalismasiAPI.Mapper
{
    public class ModelMapper:Profile
    {
        public ModelMapper()
        {
            CreateMap<Hasta, FullFieldsHastaResponseModel>().ReverseMap();
            CreateMap<Personel, PersonelResponseModel>().ReverseMap();
            CreateMap<Bileklik, BileklikResponseModel>().ReverseMap();
            CreateMap<Hasta, HastaResponseModel>().ReverseMap();
        }
    }
}
