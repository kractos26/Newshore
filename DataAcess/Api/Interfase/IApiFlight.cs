using DataAcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Api.Interfase
{
    public interface IApiFlight
    {
        public Task<List<Flight>> GetAsync(string nivel);
        public List<Flight> Flights { get; set; } 
    }
}
