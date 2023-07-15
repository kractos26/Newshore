using AutoMapper;
using DataAcess.Models;
using DataAcess.Repositories;
using Dto;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessFlight : IBusinessFlight
    {
        private readonly IRepositoryFlight _repositoryFlight;
        private readonly IMapper _mapper;
        List<DtoFlight> _flights = new List<DtoFlight>();

        public string Nivel { get ; set ; }

        public BusinessFlight(IRepositoryFlight repositoryFlight, IMapper mapper)
        {
            this._repositoryFlight = repositoryFlight;
          
            this._mapper = mapper;
            
        }

       

        public Task<List<DtoFlight>> Buscar(DtoFlight dtoFlight)
        {
            try
            {
                List<DtoFlight> flights = _flights.Where(x => x.departureStation == (dtoFlight.departureStation ?? x.departureStation) && x.arrivalStation == (dtoFlight.arrivalStation ?? x.arrivalStation)).ToList();
                return Task.FromResult(flights);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task GetData(string nivel)
        {
            try
            {
                List<Flight> flights = await _repositoryFlight.GetAllAsync(nivel);
                _flights = _mapper.Map<List<DtoFlight>>(flights);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DtoFlight> TraerUno(DtoFlight dtoFlight)
        {
            try
            {
                DtoFlight flight = _flights.FirstOrDefault(x => x.departureStation == (dtoFlight.departureStation ?? x.departureStation) && x.arrivalStation == (dtoFlight.arrivalStation ?? x.arrivalStation));
                return flight;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<DtoFlight>> GetAllAsync(DtoFlight dtoFlight)
        {
            try
            {
                await GetData(dtoFlight.Nivel);
                return _flights;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
