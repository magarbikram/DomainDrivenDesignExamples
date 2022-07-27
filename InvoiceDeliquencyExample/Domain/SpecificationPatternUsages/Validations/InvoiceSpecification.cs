using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDeliquencyExample.SpecificationPatternUsages.Validations
{
    public abstract class InvoiceSpecification : ValueObject
    {
        public abstract bool IsSatisfiedBy(Invoice invoice);
    }
}
