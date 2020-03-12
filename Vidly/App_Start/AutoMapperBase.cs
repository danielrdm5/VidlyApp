using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public abstract class AutoMapperBase
    {
        protected readonly IMapper _mapper;

        protected AutoMapperBase()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Customer, CustomerDto>();
                x.CreateMap<CustomerDto, Customer>();
            });

            _mapper = config.CreateMapper();
        }
    }
}