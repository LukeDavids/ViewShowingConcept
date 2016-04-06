using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewShowingConcept.Core.Models
{
    public class Customer
    {
        public Customer() {
        }

        private string _id;
        public string Id {
            get {
                return _id;
            }
            set {
                _id = value;
            }
        } 

        private string _customerName;
        public string CustomerName {
            get {
                return _customerName;
            }
            set {
                _customerName = value;
            }
        }

        private int _customerAge;
        public int CustomerAge {
            get { return _customerAge; }
            set {
                _customerAge = value;
            }
        }

        public Customer(string Id, string CustomerName, int CustomerAge) {
            //setId(Id);
            //setCustomerName(CustomerName);
            //setCustomerAge(CustomerAge);
            this.CustomerAge = CustomerAge;
            this.CustomerName = CustomerName;
            this.Id = Id;
        }

        //public string getId() {
        //    return this.Id;
        //}

        //public string getCustomerName() {
        //    return this.CustomerName;
        //}

        //public int getCustomerAge() {
        //    return this.CustomerAge;
        //}

        //public void setId(string Id) {
        //    this.Id = Id;
        //}

        //public void setCustomerName(string CustomerName) {
        //    this.CustomerName = CustomerName;
        //}

        //public void setCustomerAge(int CustomerAge) {
        //    this.CustomerAge = CustomerAge;
        //}
    }
}
