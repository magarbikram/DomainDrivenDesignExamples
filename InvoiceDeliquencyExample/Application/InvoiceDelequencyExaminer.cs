using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDeliquencyExample.Application
{
    public class InvoiceDelequencyExaminer
    {
        private readonly DelequentInvoiceSpecificationFactory _delequentInvoiceSpecificationFactory;

        public InvoiceDelequencyExaminer(DelequentInvoiceSpecificationFactory delequentInvoiceSpecificationFactory)
        {
            _delequentInvoiceSpecificationFactory = delequentInvoiceSpecificationFactory;
        }
        public void CheckDelequencyExample()
        {
            Customer customer = new Customer(name: "Enron", isInGoodStanding: false);
            Invoice invoice = new Invoice(customer, dueDate: DateTimeOffset.Now.AddDays(-32));
            DelequentInvoiceSpecification delequentInvoiceSpecification = _delequentInvoiceSpecificationFactory.Build();
            if (delequentInvoiceSpecification.IsSatisfiedBy(invoice))
            {
                //do send a delequent letter
            }
        }
    }
}
