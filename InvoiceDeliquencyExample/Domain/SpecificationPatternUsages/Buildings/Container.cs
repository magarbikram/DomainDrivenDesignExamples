namespace InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Buildings
{
    public class Container
    {
        private double _capacity;
        private ISet<Drum> _drums = new HashSet<Drum>();
        public IEnumerable<Drum> Drums => _drums.AsEnumerable();
        public IEnumerable<ContainerFeature> GetFeatures()
        {
            return null;
        }
        public bool IsSafelyPacked()
        {
            foreach (Drum drum in Drums)
            {
                if (!drum.GetContainerSpecification().IsSatisfiedBy(this))
                {
                    return false;
                }
            }
            return true;
        }

        public bool HasSpaceFor(Drum drum)
        {
            if (RemainingSpace() >= drum.Size)
            {
                return true;
            }
            return false;
        }

        public void Add(Drum drum)
        {
            if (CanAccomodate(drum))
            {
                _drums.Add(drum);
            }
        }

        public double RemainingSpace()
        {
            double totalContentSize = 0.0;
            foreach (Drum drum in Drums)
            {
                totalContentSize += drum.Size;
            }
            return _capacity - totalContentSize;
        }

        public bool CanAccomodate(Drum drum)
        {
            if (HasSpaceFor(drum) && drum.GetContainerSpecification().IsSatisfiedBy(this))
            {
                return true;
            }
            return false;
        }
    }
}