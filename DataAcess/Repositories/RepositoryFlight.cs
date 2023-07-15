using DataAcess.Api.Interfase;
using DataAcess.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repositories
{
    public class RepositoryFlight : IRepositoryFlight
    {
        IApiFlight _apiflight;
      
        public RepositoryFlight(IApiFlight apiFlight)
        {
            this._apiflight = apiFlight;
        }

        public string Nivel { get; set; }

        public async Task<List<Flight>> GetAllAsync(string nivel)
        {
            try
            {
                return await this._apiflight.GetAsync(nivel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
