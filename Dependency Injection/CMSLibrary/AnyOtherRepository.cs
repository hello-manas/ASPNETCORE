using System;
using System.Collections.Generic;
using System.Text;

namespace CMSLibrary
{
    public class AnyOtherRepository : ICustomerRepository
    {
        public string GetCustomerdetails()
        {
            Customer customer = new Customer();
            customer.Source = "Any Other Repository";
            return customer.Source;
        }
    }
}
