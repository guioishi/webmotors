using Microsoft.AspNetCore.Mvc;

namespace WebMotors.Controllers
{
    /// <summary>
    /// Advertisement controller class.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AdvertisementController : ControllerBase
    {
        private readonly Infrastructure.Services.IAdvertisementService _AdvertisementService;
        private readonly AutoMapper.IMapper _mapper;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="AdvertisementService">AdvertisementService object.</param>
        /// <param name="mapper">Mapper object.</param>
        public AdvertisementController(Infrastructure.Services.IAdvertisementService AdvertisementService, AutoMapper.IMapper mapper)
        {
            _AdvertisementService = AdvertisementService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all advertisement.
        /// </summary>
        /// <returns>Http status ok in case of success.</returns>
        [HttpGet]
        public async Task<ActionResult<Core.Entities.Response<List<Core.DTOs.GetAdvertisementDto>>>> GetAll()
        {
            return Ok(await _AdvertisementService.GetAll());
        }

        /// <summary>
        /// Gets advertisement by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Http status ok in case of success.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Core.Entities.Response<List<Core.DTOs.GetAdvertisementDto>>>> Get(int id)
        {
            return Ok(await _AdvertisementService.GetById(id));
        }

        /// <summary>
        /// Insert new advertisement.
        /// </summary>
        /// <param name="addAdvertisement">Advertisement add model.</param>
        /// <returns>Http status ok in case of success.</returns>
        [HttpPost]
        public async Task<ActionResult<Core.Entities.Response<List<Core.DTOs.GetAdvertisementDto>>>> Add(Core.DTOs.AddAdvertisementDto addAdvertisement)
        {
            return Ok(await _AdvertisementService.Insert(addAdvertisement));
        }

        /// <summary>
        /// Updates an advertisement.
        /// </summary>
        /// <param name="updatedAdvertisement">Advertisement update model.</param>
        /// <returns>Http status ok in case of success.</returns>
        [HttpPut]
        public async Task<ActionResult<Core.Entities.Response<List<Core.DTOs.GetAdvertisementDto>>>> Update(Core.DTOs.UpdateAdvertisementDto updatedAdvertisement)
        {
            var response = await _AdvertisementService.Update(updatedAdvertisement);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Deletes an advertisement.
        /// </summary>
        /// <param name="id">advertisement id.</param>
        /// <returns>Http status ok in case of success.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Core.Entities.Response<List<Core.DTOs.GetAdvertisementDto>>>> Delete(int id)
        {
            var response = await _AdvertisementService.Delete(id);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}

