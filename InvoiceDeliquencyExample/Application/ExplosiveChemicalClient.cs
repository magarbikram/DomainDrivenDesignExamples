using InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDeliquencyExample.Application
{
    public class ExplosiveChemicalClient
    {
        public void SetupSpecification()
        {
            Tnt tnt = new Tnt();
            tnt.SetContainerSpecification(new ContainerSpecification(new ContainerFeature("Armored", "Armored")));
        }
    }
}
