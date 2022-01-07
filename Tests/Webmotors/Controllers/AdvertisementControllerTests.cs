//using Infrastructure.Services;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebMotors.Controllers;

//namespace TestProject1.Webmotors.Controllers
//{
//    public class AdvertisementControllerTests
//    {
//        public Mock<IAdvertisementService> service = new Mock<IAdvertisementService>();
//        public Mock<AutoMapper.IMapper> mapper = new Mock<AutoMapper.IMapper>();
//        public AdvertisementController advertisementController;
//        [SetUp]
//        public void Setup()
//        {
//            //advertisementController = new AdvertisementController(service.Object, mapper.Object);
//        }

//        [Test]
//        public async Task GetAll_Success()
//        {
//            advertisementController = new AdvertisementController(service.Object, mapper.Object);
//            var serviceResponse = new Core.Entities.Response<IList<Core.DTOs.GetAdvertisementDto>>()
//            {
//                Success = true
//            };
//            service.Setup(x => x.GetAll()).ReturnsAsync(serviceResponse);
//            var response = await advertisementController.GetAll();
//            Assert.AreEqual(response.Implem