namespace Dto
{
    public class DtoFlight
    {
        public string departureStation { get; set; } = null!;

        public string arrivalStation { get; set; } = null!;

        public double price { get; set; }

        DtoTransport Transport { get; set; }

        public string Nivel { get; set; }

    }
}