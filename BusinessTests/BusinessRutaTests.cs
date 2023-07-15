using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Dto;
using Assert = NUnit.Framework.Assert;
namespace Business.Tests
{
    [TestClass()]
    public class BusinessRutaTests
    {
        BusinessRuta BusinessRuta;
        private Mock<IBusinessFlight> _mockBusinessFlight;

        [SetUp]
        public void SetUp()
        {
            _mockBusinessFlight = new Mock<IBusinessFlight>();
            BusinessRuta = new BusinessRuta(_mockBusinessFlight.Object);
        }

        [TestMethod()]
        public async Task ObtenerRutaAsyncTestAsync()
        {
            try
            {
                DtoJourney dtoJourney = new DtoJourney();
                dtoJourney.Destination = "CTG";
                dtoJourney.Origin = "MZL";
                dtoJourney.IdTipoMoneda = 1;

                var resultado = await BusinessRuta.ObtenerRutaAsync(dtoJourney, "1");
                Assert.IsNotEmpty("","",resultado.Any());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [TestMethod()]
        public async Task ObtenerRutaAsyncTestInvalidAsync()
        {
            try
            {
                DtoJourney dtoJourney = new DtoJourney();
                dtoJourney.Destination = "CTG";
                dtoJourney.Origin = "CTG";
                dtoJourney.IdTipoMoneda = 1;
                Assert.ThrowsAsync<Exception>(async () => await BusinessRuta.ObtenerRutaAsync(dtoJourney, "1"));

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}