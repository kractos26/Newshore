using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class DtoJourney
    {
        public List<DtoFlight> Flights { get; set; }

        public string? Origin { get; set; }

        public string? Destination { get; set; }

        public double? Price { get; set; }

        public int IdTipoMoneda { get; set; }


        public DtoJourney() { 
          this.Flights = new List<DtoFlight>();
        }
    }
}
