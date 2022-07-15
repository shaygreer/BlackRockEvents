using BlackRockEvents.Models;
using System.Collections.Generic;

namespace BlackRockEvents.Data
{
    /*Interface indicating what is needed in the CustomerData Repository. */
    public interface ICustomerData
    {
        Customer GetCustomerById(int id);
        Customer Update(Customer customer);
        Customer Add(Customer customer);
        void Delete(int id);
        Customer GetCustomerByEmail(string email);

    }
}
