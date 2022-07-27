namespace InvoiceDeliquencyExample
{
    public class Invoice
    {
        public Customer Customer { get; private set; }
        public DateTimeOffset DueDate { get; private set; }

        public Invoice(Customer customer, DateTimeOffset dueDate)
        {
            Customer = customer;
            DueDate = dueDate;
        }

        public bool IsOverdue()
        {
            return DueDate < DateTimeOffset.Now;
        }
    }
}