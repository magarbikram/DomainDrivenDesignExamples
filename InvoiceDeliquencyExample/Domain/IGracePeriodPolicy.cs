namespace InvoiceDeliquencyExample
{
    public interface IGracePeriodPolicy
    {
        GracePeriod GetStandardGracePeriod();
        GracePeriod GetGoodStandingGracePeriod();
    }
}