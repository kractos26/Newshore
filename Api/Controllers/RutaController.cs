using Api.ViewModels;
using Business;
using Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        IBusinessRuta _businessRuta;
        private readonly ILogger<RutaController> _logger;
        public RutaController(IBusinessRuta businessRuta, ILogger<RutaController> logger)
        {
            this._businessRuta = businessRuta;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<List<DtoJourney>>> Get([FromQuery] RequestRuta request)
        {
            try
            {
                DtoJourney dtoJourney = new DtoJourney();
                dtoJourney.Origin = request.Origin;
                dtoJourney.Destination = request.Destination;
                dtoJourney.IdTipoMoneda = request.IdTipoMoneda;
                this._businessRuta.Nivel = request.Nivel;
                List<DtoJourney> dtoJourneys = await this._businessRuta.ObtenerRutaAsync(dtoJourney, request.Nivel);
                _logger.LogInformation("Se ha procesado correctamente");
                return Ok(dtoJourneys);
            }
            catch (Exception ex)
            {
               _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


    }
}
