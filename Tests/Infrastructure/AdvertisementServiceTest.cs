using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Services.Implementation;
using MockQueryable.Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors;

namespace Tests.Infrastructure
{
    public class AdvertisementServiceTest
    {
        private IAdvertisementService _advertisementService;

        [SetUp]
        public void Setup()
        {
            var mappingConfig = new AutoMapper.MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            var data = new System.Collections.Generic.List<Core.Entities.Advertisement>
        {
            new Core.Entities.Advertisement { Id = 1, Marca = "Chevrolet", Modelo = "Cruze Sport6", Versao = "LTZ+", Ano = 2017, Quilometragem = 50000, Observacao = "Branco Perolado" },
            new Core.Entities.Advertisement { Id = 2, Marca = "Chevrolet", Modelo = "Cruze", Versao = "LTZ+", Ano = 2017, Quilometragem = 40000, Observacao = "Branco" },
            new Core.Entities.Advertisement { Id = 3, Marca = "Volkswagen", Modelo = "Nivus", Versao = "Highline", Ano = 2021, Quilometragem = 2000, Observacao = "0KM" }
        }.AsQueryable().BuildMockDbSet();

            var mockAdContext = new Moq.Mock<DataContext>();
            mockAdContext.Setup(c => c.Advertisement).Returns(data.Object);

            _advertisementService = new AdvertisementService(mockAdContext.Object, mappingConfig.CreateMapper());
        }

        [Test]
        public async System.Threading.Tasks.Task AdvertisementService_TestGetAll()
        {
            var adCount = 3;
            var response = await _advertisementService.GetAll();

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual(adCount, response.Data?.Count);
        }

        [Test]
        public async System.Threading.Tasks.Task AdvertisementService_TestGetSingle()
        {
            var response = await _advertisementService.GetById(1);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);

            var ad = response.Data;
        }

        [Test]
        public async System.Threading.Tasks.Task AdvertisementService_TestDelete()
        {
            var response = await _advertisementService.Delete(1);

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.Data);
            Assert.IsEmpty(response.Message);
        }

        [Test]
        public async System.Threading.Tasks.Task AdvertisementService_TestUpdate()
        {
            var obj = new Core.DTOs.UpdateAdvertisementDto
            {
                Id = 1
            };
            var response = await _advertisementService.Update(obj);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
            Assert.IsEmpty(response.Message);
        }

        [Test]
        public async System.Threading.Tasks.Task AdvertisementService_TestPost()
        {
            var obj = new Core.DTOs.AddAdvertisementDto();
            var response = await _advertisementService.Insert(obj);
            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.Data);
            Assert.IsEmpty(response.Message);
        }
    }
}
