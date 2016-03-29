using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewShowingConcept.Core.Models
{
    public class Customer
    {
        private string Id;
        private string CustomerName;
        private int CustomerAge;

        public Customer() {
        }

        public Customer(string Id, string CustomerName, int CustomerAge) {
            setId(Id);
            setCustomerName(CustomerName);
            setCustomerAge(CustomerAge);
        }

        public string getId() {
            return this.Id;
        }

        public string getCustomerName() {
            return this.CustomerName;
        }

        public int getCustomerAge() {
            return this.CustomerAge;
        }

        public void setId(string Id) {
            this.Id = Id;
        }

        public void setCustomerName(string CustomerName) {
            this.CustomerName = CustomerName;
        }

        public void setCustomerAge(int CustomerAge) {
            this.CustomerAge = CustomerAge;
        }
    }
}
