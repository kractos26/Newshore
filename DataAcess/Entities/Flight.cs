using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Models
{
    public class Flight : Transport
    {
        public string departureStation { get; set; } = null!;

        public string arrivalStation { get; set; } = null!;

        public double price { get; set; }
    }
}
