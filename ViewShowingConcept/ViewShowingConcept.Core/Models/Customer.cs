using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace ViewShowingConcept.Core.Models
{
    public class Customer : MvxViewModel
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
                RaisePropertyChanged(() => Id);
            }
        } 

        private string _customerName;
        public string CustomerName {
            get {
                return _customerName;
            }
            set {
                _customerName = value;
                RaisePropertyChanged(() => CustomerName);
            }
        }

        private int _customerAge;
        public int CustomerAge {
            get { return _customerAge; }
            set {
                _customerAge = value;
                RaisePropertyChanged(() => CustomerAge);
            }
        }

        public Customer(string id, string customerName, int customerAge) {
            this.CustomerAge = customerAge;
            this.CustomerName = customerName;
            this.Id = id;
        }

        public override string ToString()
        {
            return CustomerName+" : "+Id;
        }
    }
}
