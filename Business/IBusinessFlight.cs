using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IBusinessFlight
    {
        public Task<List<DtoFlight>> GetAllAsync(DtoFlight dtoFlight);
        public Task<List<DtoFlight>> Buscar(DtoFlight dtoFlight);
        public Task<DtoFlight> TraerUno(DtoFlight dtoFlight);
        public Task GetData(string nivel);
        public string Nivel { get; set; }

    }
}
