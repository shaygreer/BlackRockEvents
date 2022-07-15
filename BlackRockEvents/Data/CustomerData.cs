using BlackRockEvents.Models;
using System.Linq;

namespace BlackRockEvents.Data
{
    public class CustomerData : ICustomerData
    {
        private readonly ApplicationDbContext _applicationDbContext;
        /*This constructor injects the database as a dependency.*/
        public CustomerData(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        /* This method adds a customer to the database and saves the changes, and then returns the customer. */
        public Customer Add(Customer customer)
        {
            _applicationDbContext.Customers.Add(customer);
            _applicationDbContext.SaveChanges();
            return customer;
        }
        /*This method takes a customer id and deletes that customer from the database. */
        public void Delete(int id)
        {
            var customer = _applicationDbContext.Customers.FirstOrDefault(c => c.Customer_Id == id);
            if (customer != null)
            {
                _applicationDbContext.Remove(customer);
            }
        }
        /*This method takes a customer id and and searches the database for the customer with that id and then returns that customer.*/
        public Customer GetCustomerById(int id)
        {
            Customer customer = _applicationDbContext.Customers.FirstOrDefault(c => c.Customer_Id == id);
            return customer;

        }
        /*This method takes a cusotmer and searches the database for a customer by the same id. It then takes the old customer info from the database and updates it with the new customer info
         * sent in as a customer object in the parameter. */
        public Customer Update(Customer customer)
        {
            var cus = _applicationDbContext.Customers.SingleOrDefault(c => c.Customer_Id == customer.Customer_Id);
            if (cus != null)
            {
                cus.FirstName=customer.FirstName;
                cus.LastName=customer.LastName; 
                cus.Address=customer.Address;
                cus.City=customer.City;
                cus.State=customer.State;
                cus.Zip = customer.Zip;
                cus.Email=customer.Email;
                cus.Phone=customer.Phone;   
            }
            return customer;
        }
        /*This method takes an email and searches for the customer with the same email and then returns that customer, it will return null if no customer with that id is found. */
        public Customer GetCustomerByEmail(string email)
        {
            var customer = _applicationDbContext.Customers.FirstOrDefault(c => c.Email == email);
            if (customer != null)
            {
                return customer;
            }
            else
            {
                return null;
            }
        }
    }
}