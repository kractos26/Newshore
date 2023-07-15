using Dto;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EjemploConsumoApi
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient cliente = new HttpClient())
            {
                try
                {
                    HttpResponseMessage respuesta = await cliente.GetAsync("https://recruiting-api.newshore.es/api/flights/0");

                    if (respuesta.IsSuccessStatusCode)
                    {
                        string contenido = await respuesta.Content.ReadAsStringAsync();
                        // Procesa el contenido de la respuesta según tus necesidades
                       
                        List<DtoFlight> myObject = JsonSerializer.Deserialize<List<DtoFlight>>(contenido);

                        //DtoFlight dtoFlight = new DtoFlight()
                        //{
                        //    arrivalStation = "jjj",
                        //    departureStation = "mmm",
                        //    flightCarrier = "Ttt",
                        //    price = 0,
                        //    flightNumber = "4"
                        //};

                       // string jsonString = JsonSerializer.Serialize(myObject);
                        Console.WriteLine(contenido);
                    }
                    else
                    {
                        Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + respuesta.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al realizar la solicitud: " + ex.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
