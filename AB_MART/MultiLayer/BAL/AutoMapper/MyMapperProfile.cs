using AutoMapper;
using DAL.Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.AutoMapper
{
    public class MyMapperProfile :Profile
    {
        
        public MyMapperProfile()
        {

            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();    
        }
    }
}
