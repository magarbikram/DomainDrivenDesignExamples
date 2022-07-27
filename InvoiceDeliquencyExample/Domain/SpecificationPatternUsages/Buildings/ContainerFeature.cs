namespace InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Buildings
{
    public class ContainerFeature
    {
        public ContainerFeature(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; }
        public string Name { get; }
    }
}