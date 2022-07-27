using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Buildings
{
    public abstract class Chemical
    {
        public ContainerSpecification? ContainerSpecification { get; private set; }

        public void SetContainerSpecification(ContainerSpecification containerSpecification)
        {
            ContainerSpecification = containerSpecification;
        }
    }
}
