using CSharpFunctionalExtensions;
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
    public abstract class InvoiceSpecificationForQuery : InvoiceSpecification
    {
        public abstract string AsSqlQuery();

        public abstract Expression<Func<Invoice, bool>> AsLinqQuery();

        public abstract ISet<Invoice> SatisfyingElementsFrom(IInvoiceRepository invoiceRepository);
    }
}
