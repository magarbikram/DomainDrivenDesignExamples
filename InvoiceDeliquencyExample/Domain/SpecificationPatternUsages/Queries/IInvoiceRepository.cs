namespace InvoiceDeliquencyExample.Infrastructure
{
    public interface IInvoiceRepository
    {
        ISet<Invoice> SelectWhereGracePeriodPast(DateTimeOffset evaluationDate);
        ISet<Invoice> SelectWhereDueDateIsBefore(DateTimeOffset evaluationDate);
    }
}