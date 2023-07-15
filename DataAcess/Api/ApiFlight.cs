using DataAcess.Models;
using DataAcess.Api.Interfase;
using Newtonsoft.Json;

namespace DataAcess.Context
{
    public class ApiFlight : IApiFlight
    {
        string endpoint = "https://recruiting-api.newshore.es/api/flights/";
        private readonly HttpClient _httpClient;

        public List<Flight> Flights { get; set; }

        public ApiFlight(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async public Task<List<Flight>> GetAsync(string nivel)
        {

            List<Flight> result = new List<Flight>();
            try
            {
                HttpResponseMessage respuesta = await _httpClient.GetAsync($"{endpoint}{nivel}");

                if (respuesta.IsSuccessStatusCode)
                {
                    string contenido = await respuesta.Content.ReadAsStringAsync();
                    // Procesa el contenido de la respuesta según tus necesidades

                    Flights = JsonConvert.DeserializeObject<List<Flight>>(contenido);

                }
                else
                {
                    Console.WriteLine("La solicitud no fue exitosa. Código de estado: " + respuesta.StatusCode);
                }
                return Flights;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar la solicitud: " + ex.Message);
            }

        }
    }
}
