using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDeliquencyExample
{
    public class DelequentInvoiceSpecificationFactory
    {
        private readonly IGracePeriodPolicy _gracePeriodPolicy;

        public DelequentInvoiceSpecificationFactory(IGracePeriodPolicy gracePeriodPolicy)
        {
            _gracePeriodPolicy = gracePeriodPolicy;
        }
        public DelequentInvoiceSpecification Build()
        {
            return new DelequentInvoiceSpecification(standardGracePeriod: _gracePeriodPolicy.GetStandardGracePeriod(),
                                                     goodStandingGracePeriod: _gracePeriodPolicy.GetGoodStandingGracePeriod(),
                                                     evaluationDate: DateTimeOffset.Now);
        }
    }
}
