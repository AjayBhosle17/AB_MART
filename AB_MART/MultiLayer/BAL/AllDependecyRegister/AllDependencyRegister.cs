﻿using BAL.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.AllDependecyRegister
{
    public class AllDependencyRegister
    {
        public static void DependecyRegister(IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //add automapper dependecy

            services.AddAutoMapper(typeof(MyMapperProfile));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }
    }
}
