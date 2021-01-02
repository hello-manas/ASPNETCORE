using System;
using System.Collections.Generic;
using System.Text;

namespace CMSLibrary
{
    public class CustomerOracleRepository : ICustomerRepository
    {
        public string GetCustomerdetails()
        {
            Customer customer = new Customer();
            customer.Source = "Oracle";
            return customer.Source;
        }
    }
}
