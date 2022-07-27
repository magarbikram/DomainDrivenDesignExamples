using InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Queries;

namespace InvoiceDeliquencyExample.Infrastructure
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvoiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Invoice> SelectSatisfyingWithLinqQuery(InvoiceSpecificationForQuery invoiceSpecificationForQuery)
        {
            return _appDbContext.Invoices.Where(invoiceSpecificationForQuery.AsLinqQuery()).ToList();
        }

        public IEnumerable<Invoice> SelectSatisfyingWithRawSqlQuery(InvoiceSpecificationForQuery invoiceSpecificationForQuery)
        {
            string query = invoiceSpecificationForQuery.AsSqlQuery();
            IEnumerable<Invoice> invoices = ExecuteQuery<Invoice>(query);
            return invoices;
        }

        /// <summary>
        /// This is not a business rule, just a specialized query
        /// </summary>
        /// <param name="evaluationDate"></param>
        /// <returns></returns>
        public ISet<Invoice> SelectWhereGracePeriodPast(DateTimeOffset evaluationDate)
        {
            string query = WhereGracePeriodPastSql(evaluationDate);
            return ExecuteQuery<Invoice>(query).ToHashSet();
        }

        private static string WhereGracePeriodPastSql(DateTimeOffset evaluationDate)
        {
            return @$"Select * FROM Invoice, Customer
                        WHERE Invoice.CustomerId = Customer.Id AND
                              Invoice.DueDate + Customer.GracePeriod < '{SqlUtility.DateAsSql(evaluationDate)}'";
        }

        public ISet<Invoice> SelectSatisfyingWithDoubleDispatch(InvoiceSpecificationForQuery invoiceSpecificationForQuery)
        {
            return invoiceSpecificationForQuery.SatisfyingElementsFrom(this);
        }

        private IEnumerable<T> ExecuteQuery<T>(string query)
        {
            throw new NotImplementedException();
        }

        public ISet<Invoice> SelectWhereDueDateIsBefore(DateTimeOffset evaluationDate)
        {
            return _appDbContext.Invoices.Where(invoice => invoice.DueDate < evaluationDate).ToHashSet();
        }
    }
}
