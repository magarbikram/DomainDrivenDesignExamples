using InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDeliquencyExample.Application
{
    internal class ContainerMonitoringApplication
    {
        public void Monitor()
        {
            IList<Container> unsafeContainers = new List<Container>();
            IEnumerable<Container> containers = GetContainers();
            foreach (Container container in containers)
            {
                if (!container.IsSafelyPacked())
                {
                    unsafeContainers.Add(container);
                }
            }
            Report(unsafeContainers);
        }

        private void Report(IList<Container> unsafeContainers)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Container> GetContainers()
        {
            throw new NotImplementedException();
        }
    }
}
