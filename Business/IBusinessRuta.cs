using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IBusinessRuta
    {
       public Task<List<DtoJourney>> ObtenerRutaAsync(DtoJourney journey,string nivel);
       public string Nivel { get; set; }
    }
}
