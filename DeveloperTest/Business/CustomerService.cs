using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using System.Linq;

namespace DeveloperTest.Business.Interfaces
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context) { this.context = context; }

        public CustomerModel CreateCustomer(BaseCustomerModel customer)
        {
            var addedCustomer = context.Customers.Add(new Customer
            {
                Name = customer.Name,
                Type = customer.Type
            });

            context.SaveChanges();

            return new CustomerModel
            {
                Id = addedCustomer.Entity.Id,
                Name = customer.Name,
                Type = customer.Type
            };
        }

        public CustomerModel GetCustomer(int id)
        {
            return this.context.Customers.Where(x => x.Id == id).Select(x => new CustomerModel
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type
            }).SingleOrDefault();
        }

        public CustomerModel[] GetCustomers()
        {
            return this.context.Customers.Select(x => new CustomerModel
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type
            }).ToArray();
        }
    }
}
