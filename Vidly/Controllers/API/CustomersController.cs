using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        private IMapper _iMapper;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>()
                    .ForMember(m => m.Id, opt => opt.Ignore());
                cfg.CreateMap<CustomerDto, Customer>()
                    .ForMember(m => m.Id, opt => opt.Ignore());
            });
            _iMapper = config.CreateMapper();
        }

        //Get /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(_iMapper.Map<Customer, CustomerDto>);
        }


        //Get /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            CustomerDto destination = new CustomerDto();
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            destination = _iMapper.Map<Customer, CustomerDto>(customer);
            return Ok(destination);
        }


        //post /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _iMapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "" + customer.Id), customerDto);
        }

        //PUT /api/customers/api
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _iMapper.Map<Customer, Customer>(customerDb, customerDb);

            _context.SaveChanges();
        }

        //Delete /api/customers/1
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerDb);
            _context.SaveChanges();
        }
    }
}
