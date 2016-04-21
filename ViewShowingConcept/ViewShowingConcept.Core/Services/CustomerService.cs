using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewShowingConcept.Core.Models;
using MvvmCross.Plugins.Messenger;

namespace ViewShowingConcept.Core.Services
{
    public static class CustomerService
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

        public static Customer GetCustomer(string Id) {
            Customer custObject = new Customer();

            foreach (Customer customer in getCustomerList()) {
                if (customer.Id.Equals(Id))
                {
                    custObject = customer;
                    return custObject;
                }
            }
            return null;
        }
    }
}
