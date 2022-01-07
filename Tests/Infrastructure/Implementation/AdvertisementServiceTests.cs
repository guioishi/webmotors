using Infrastructure.Data;
using Infrastructure.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Infrastructure.Implementation
{
    public class AdvertisementServiceTests
    {
        public Mock<IDataContext> dataContext = new Mock<IDataContext>();
        public Mock<AutoMapper.IMapper> mapper = new Mock<AutoMapper.IMapper>();
        public AdvertisementService advertisementService;

        [SetUp]
        public void Setup()
        {
            advertisementService = new AdvertisementService(dataContext.Object, mapper.Object);
        }

        [Test]
        public async Task GetAll_Success()
        {

            //dataContext.Setup(x => x.Advertisement).Returns()
            //var response = await advertisementService.GetAll();
            //Assert.True()
        }
    }
}
