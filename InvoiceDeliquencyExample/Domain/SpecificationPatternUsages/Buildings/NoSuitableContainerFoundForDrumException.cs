using System.Runtime.Serialization;

namespace InvoiceDeliquencyExample.Domain.SpecificationPatternUsages.Buildings
{
    [Serializable]
    internal class NoSuitableContainerFoundForDrumException : Exception
    {
        private Drum _drumToPack;

        public NoSuitableContainerFoundForDrumException()
        {
        }

        public NoSuitableContainerFoundForDrumException(Drum drumToPack)
        {
            _drumToPack = drumToPack;
        }

        public NoSuitableContainerFoundForDrumException(string? message) : base(message)
        {
        }

        public NoSuitableContainerFoundForDrumException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoSuitableContainerFoundForDrumException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}