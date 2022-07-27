using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Buildings
{
    public class PrototypePacker : IWarehousePacker
    {

        /// <summary>
        ///This method fulfills the ASSERTION as writter. However, when an exception is thrown, Containers' conents may have changed.
        ///Rollback must be handled at a higher level.
        /// </summary>
        public void Pack(IEnumerable<Container> containersToFill, IEnumerable<Drum> drumsToPack)
        {
            foreach (Drum drum in drumsToPack)
            {
                Container container = FindContainerForDrum(containersToFill, drum);
                container.Add(drum);
            }
        }

        private Container FindContainerForDrum(IEnumerable<Container> containersToFill, Drum drumToPack)
        {
            foreach (Container container in containersToFill)
            {
                if (container.CanAccomodate(drumToPack))
                {
                    return container;
                }
            }
            throw new NoSuitableContainerFoundForDrumException(drumToPack);
        }
    }
}
