using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewShowingConcept.Core.Models;

namespace ViewShowingConcept.Core.Services
{
    public static class CustomerServices
    {
        public static List<Customer> getCustomerList() {
            Customer CustomerA = new Customer("001", "John", 35);
            Customer CustomerB = new Customer("002", "Anne", 32);
            Customer CustomerC = new Customer("003", "Tom", 24);

            List<Customer> Customers = new List<Customer>();

            Customers.Add(CustomerA);
            Customers.Add(CustomerB);
            Customers.Add(CustomerC);

            return Customers;
        }
    }
}
