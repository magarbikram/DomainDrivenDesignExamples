using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Buildings
{
    /// <summary>
    /// SERVICE
    /// </summary>
    public interface IWarehousePacker
    {
        public void Pack(IEnumerable<Container> containersToFill, IEnumerable<Drum> drumsToPack);
        /*
         ASSERTION: At end of Pack(), the ContainerSpecification of each Drum shall be satisfied by its Container.
                    If no complete solution can be found, an exception shall be thrown.
         */
    }
}
