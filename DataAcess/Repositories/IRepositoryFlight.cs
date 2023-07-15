using DataAcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repositories
{
    public interface IRepositoryFlight 
    {
        /// <summary>
        /// Obtiene todos los elementos del repositorio.
        /// </summary>
        /// <returns>Una lista de elementos de tipo T.</returns>
        Task<List<Flight>> GetAllAsync(string nivel);

        public string Nivel { get; set; }
       
    }
}
