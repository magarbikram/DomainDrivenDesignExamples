using InvoiceDeliquencyExample.Infrastructure;
using InvoiceDeliquencyExample.SpecificationPatternUsages.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Queries
{
    public class DelequentInvoiceSpecificationForQuery : InvoiceSpecificationForQuery
    {
        public DelequentInvoiceSpecificationForQuery(DateTimeOffset evaluationDate)
        {
            EvaluationDate = evaluationDate;
        }

        public DateTimeOffset EvaluationDate { get; }

        public override Expression<Func<Invoice, bool>> AsLinqQuery()
        {
            return (Invoice invoice) => invoice.DueDate <= EvaluationDate;
        }

        /// <summary>
        /// Design problem: Most important, the details of table structure have leaked into the DOMAIN LAYER;
        /// This is a simple illustration of how to keep the rule in just one place.
        /// </summary>
        /// <returns></returns>
        public override string AsSqlQuery()
        {
            return @$"Select * FROM Invoice, Customer
                        WHERE Invoice.CustomerId = Customer.Id AND
                              Invoice.DueDate + Customer.GracePeriod < '{SqlUtility.DateAsSql(EvaluationDate)}'";
        }

        /// <summary>
        /// This puts sql in repository , while specification controls which query to use
        /// </summary>
        /// <param name="invoiceRepository"></param>
        /// <returns></returns>
        public override ISet<Invoice> SatisfyingElementsFrom(IInvoiceRepository invoiceRepository)
        {
            //Delequency rule is defined as: "grace period past as of EvaluationDate"
            return invoiceRepository.SelectWhereGracePeriodPast(EvaluationDate);
        }


        public override bool IsSatisfiedBy(Invoice invoice)
        {
            int gracePeriodInDays = invoice.Customer.GetPaymentGracePeriod();
            DateTimeOffset firmDeadline = invoice.DueDate.AddDays(gracePeriodInDays);
            return EvaluationDate > firmDeadline;//if evaluation date is after firm dead line, invoice is delequent
        }

        /// <summary>
        /// This implementation is more generic and have delequent business rule in specification itself.
        /// We will take performance hit with this approach, because we pull out more Invoices and then have to select from them in memory
        /// </summary>
        /// <param name="invoiceRepository"></param>
        /// <returns></returns>
        public ISet<Invoice> SatisfyingElementsFromWithActualBusinessRule(IInvoiceRepository invoiceRepository)
        {
            //Delequency rule is defined as: "grace period past as of EvaluationDate"
            ISet<Invoice> pastDueInvoices = invoiceRepository.SelectWhereDueDateIsBefore(EvaluationDate);
            ISet<Invoice> delequentInvoices = new HashSet<Invoice>();
            foreach (Invoice invoice in pastDueInvoices)
            {
                if (IsSatisfiedBy(invoice))
                {
                    delequentInvoices.Add(invoice);
                }
            }
            return delequentInvoices;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EvaluationDate;
        }
    }
}
