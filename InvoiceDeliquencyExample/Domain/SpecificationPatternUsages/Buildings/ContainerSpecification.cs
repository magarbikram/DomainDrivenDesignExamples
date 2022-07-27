using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Buildings
{
    public class ContainerSpecification
    {
        private readonly ContainerFeature _requiredFeature;

        public ContainerSpecification(ContainerFeature requiredFeature)
        {
            _requiredFeature = requiredFeature;
        }

        public bool IsSatisfiedBy(Container container)
        {
            return container.GetFeatures().Contains(_requiredFeature);
        }
    }
}
