using System;
using System.Collections.Generic;
using System.Text;

namespace CMSLibrary
{
    public class CustomerSQLRepository : ICustomerRepository
    {
        public string GetCustomerdetails()
        {
            Customer customer = new Customer();
            customer.Source = "SQL";
            return customer.Source;
        }
    }
}
