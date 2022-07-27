using CSharpFunctionalExtensions;
using InvoiceDeliquencyExample.SpecificationPatternUsages.Validations;

namespace InvoiceDeliquencyExample
{
    public class DelequentInvoiceSpecification : InvoiceSpecification
    {
        public GracePeriod StandardGracePeriod { get; private set; }

        public DelequentInvoiceSpecification(GracePeriod standardGracePeriod, GracePeriod goodStandingGracePeriod, DateTimeOffset evaluationDate)
        {
            StandardGracePeriod = standardGracePeriod;
            GoodStandingGracePeriod = goodStandingGracePeriod;
            EvaluationDate = evaluationDate;
        }

        public GracePeriod GoodStandingGracePeriod { get; private set; }
        public DateTimeOffset EvaluationDate { get; private set; }

        public override bool IsSatisfiedBy(Invoice invoice)
        {
            if (!invoice.IsOverdue())
            {
                return false;
            }
            if (invoice.Customer.IsInGoodStanding)
            {
                return IsDelequentWithGoodStandingGracePeriod(invoice);
            }
            return IsDelequentWithStandardGracePeriod(invoice);
        }

        private bool IsDelequentWithStandardGracePeriod(Invoice invoice)
        {
            TimeSpan pastDueTimeSpan = EvaluationDate - invoice.DueDate;
            if (StandardGracePeriod.IsLessThan(pastDueTimeSpan))
            {
                return true;
            }
            return false;
        }

        private bool IsDelequentWithGoodStandingGracePeriod(Invoice invoice)
        {
            TimeSpan pastDueTimeSpan = EvaluationDate - invoice.DueDate;
            if (GoodStandingGracePeriod.IsLessThan(pastDueTimeSpan))
            {
                return true;
            }
            return false;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StandardGracePeriod;
            yield return GoodStandingGracePeriod;
            yield return EvaluationDate;
        }
    }
}
