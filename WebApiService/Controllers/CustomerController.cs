using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BasicWebApi.Models;

namespace BasicWebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private Customer[] _customers = new Customer[]
        {
            new Customer { Id=1, Company="ACME", City="abc", Country="USA" },
            new Customer { Id=2, Company="Some", City="other", Country="place" },
            new Customer { Id=3, Company="MyBuy", City="Portland", Country="There" }
        };

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _customers.FirstOrDefault(cust => cust.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
