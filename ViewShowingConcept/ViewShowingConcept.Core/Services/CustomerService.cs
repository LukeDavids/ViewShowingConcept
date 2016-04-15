using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using ViewShowingConcept.Core.Models;

namespace ViewShowingConcept.Core.Services
{
    public static class CustomerService 
    {
        public static List<Customer> Customers =>
            new List<Customer>()
            {
                {new Customer("001", "John", 35)},
                {new Customer("002", "Anne", 32)},
                {new Customer("003", "Tom", 24)} 
            };
         
        public static List<Customer> getCustomerList() {
            Customer CustomerA = new Customer("001", "John", 35);
            Customer CustomerB = new Customer("002", "Anne", 32);
            Customer CustomerC = new Customer("003", "Tom", 24);

            //List<Customer> Customers = new List<Customer>();

            //Customers.Add(CustomerA);
            //Customers.Add(CustomerB);
            //Customers.Add(CustomerC);

            return Customers;
        }

        public static Customer GetCustomer(string id) {
            Customer custObject = new Customer();
            /**
            foreach (Customer customer in getCustomerList()) {
                if (customer.Id.Equals(Id))
                {
                    custObject = customer;
                    return custObject;
                }
            }*/
            try
            {
                return Customers.Find(x => (x.Id == id));
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
            
        }
    }
}
