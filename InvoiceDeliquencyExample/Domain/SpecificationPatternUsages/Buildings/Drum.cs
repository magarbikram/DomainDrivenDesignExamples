namespace InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Buildings
{
    public class Drum
    {
        public double Size { get; internal set; }

        public ContainerSpecification GetContainerSpecification()
        {
            throw new NotImplementedException();
        }
    }
}