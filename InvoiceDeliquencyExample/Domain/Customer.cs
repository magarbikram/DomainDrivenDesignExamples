using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDeliquencyExample
{
    public class Customer
    {
        public Customer(string name, bool isInGoodStanding)
        {
            Name = name;
            IsInGoodStanding = isInGoodStanding;
        }

        public bool IsInGoodStanding { get; private set; }
        public string Name { get; }

        internal int GetPaymentGracePeriod()
        {
            throw new NotImplementedException();
        }
    }
}
