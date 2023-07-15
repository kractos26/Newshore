using DataAcess.Models;
using DataAcess.Repositories;
using Dto;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Business
{
    public class BusinessRuta : IBusinessRuta
    {
        
        private List<DtoJourney> rutas = new List<DtoJourney>();
        private List<DtoFlight> nodos = new List<DtoFlight>();
        private List<DtoFlight> flights = new List<DtoFlight>();
        private string Origen = string.Empty;
        private string Destino = string.Empty;
        private readonly IBusinessFlight _businessFlight;
       

        public string Nivel { get; set; }

        public BusinessRuta(IBusinessFlight businessFlight)
        {
           
            nodos = new List<DtoFlight>();
            _businessFlight = businessFlight;
            _businessFlight.Nivel = Nivel;
        }

        public async Task<List<DtoJourney>> ObtenerRutaAsync(DtoJourney journey, string nivel)
        {
            
            
            flights = await _businessFlight.GetAllAsync(new DtoFlight() { Nivel = nivel});

          
            this.Origen = journey.Origin;
            this.Destino = journey.Destination;
            try
            {
                string validacion = string.Empty;
                validacion = Validations(journey);
                if (validacion != string.Empty)
                {
                    throw new Exception(validacion);
                }

                await RecorrerRutas(journey);
                return rutas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private async Task RecorrerRutas(DtoJourney journey)
        {
            List<DtoFlight> flightOrigen = new List<DtoFlight>();
            flightOrigen = await _businessFlight.Buscar(new DtoFlight() { departureStation = journey.Origin});
            if (flightOrigen.Any())
            {
                foreach (var item in flightOrigen)
                {
                    nodos.Add(new DtoFlight
                    {
                        arrivalStation = item.arrivalStation,
                        departureStation = item.departureStation,
                        price = item.price
                    });

                    
                    if (item.arrivalStation == journey.Destination)
                    {
                        journey.Flights = nodos;
                        journey.Flights.ForEach(x =>
                        {  
                            x.price = USDtoCoin(journey.IdTipoMoneda, x.price);
                        });
                        journey.Price = journey.Flights.Sum(x=>x.price);
                        journey.Origin = this.Origen;
                        journey.Destination = this.Destino;
                        
                        rutas.Add(journey); 
                        nodos = new List<DtoFlight>();
                        continue;
                    }
                    else
                    {
                        await RecorrerRutas(new DtoJourney()
                        {
                            Origin = item.arrivalStation,
                            Destination = journey.Destination,
                            IdTipoMoneda = journey.IdTipoMoneda
                        });

                    }

                    
                }


            }
        
        }


        private static string Validations(DtoJourney dtoJourney)
        {
            string mensaje = string.Empty;
            if (dtoJourney.Origin == dtoJourney.Destination)
            {
                mensaje += "El origen y el destino no pueden ser lo mismo";
            }
            if (dtoJourney.Origin?.Length != 3 || dtoJourney.Destination?.Length != 3)
            {
                mensaje += "La cantidad de caracteres para el origen y el destino es de minimo 3 caracteres";
            }
            return mensaje;
        }

        private double USDtoCoin(int tipoMoneda, double valorMoneda)
        {
            double valor = valorMoneda;
            switch (tipoMoneda)
            {
                case 1://COP
                    valor = valorMoneda * 4099;
                    break;
                case 2:
                    valor = valorMoneda * 0.89;
                    break;

                case 3:
                    valor = valorMoneda * 16.826;
                    break;

            }
            return valor;
        }
    }
}
