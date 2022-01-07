using Microsoft.AspNetCore.Mvc;

namespace WebMotors.Controllers
{
    /// <summary>
    /// WebMotorsApi controller class.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WebMotorsApiController : ControllerBase
    {
        private readonly Infrastructure.Services.IWebMotorsApiService _webMotorsApiService;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="webMotorsApiService">Instance of WebMotorsApiService</param>
        public WebMotorsApiController(Infrastructure.Services.IWebMotorsApiService webMotorsApiService)
        {
            _webMotorsApiService = webMotorsApiService;
        }

        /// <summary>
        /// Gets all brands.
        /// </summary>
        /// <returns>Http status ok in case of success.</returns>
        [HttpGet("GetMake")]
        public async Task<ActionResult<Core.Entities.Response<IList<Core.Entities.Make>>>> Get()
        {
            return Ok(await _webMotorsApiService.GetAllMake());
        }

        /// <summary>
        /// Gets all models by id.
        /// </summary>
        /// <param name="id">Vehicle id.</param>
        /// <returns>Http status ok in case of success.</returns>
        [HttpGet("GetModel")]
        public async Task<ActionResult<Core.Entities.Response<IList<Core.Entities.Model>>>> GetModel(int id)
        {
            return Ok(await _webMotorsApiService.GetModelById(id));
        }

        /// <summary>
        /// Gets all versions by id.
        /// </summary>
        /// <param name="id">Model id.</param>
        /// <returns>Http status ok in case of success.</returns>
        [HttpGet("GetVersion")]
        public async Task<ActionResult<Core.Entities.Response<IList<Core.Entities.Version>>>> GetVersion(int id)
        {
            return Ok(await _webMotorsApiService.GetVersionById(1));
        }

        /// <summary>
        /// Gets all vechicle by id.
        /// </summary>
        /// <param name="id">Brand id.</param>
        /// <returns>Http status ok in case of success.</returns>
        [HttpGet("GetVehicles")]
        public async Task<ActionResult<Core.Entities.Response<IList<Core.Entities.Vehicles>>>> GetVehicles(int id)
        {
            return Ok(await _webMotorsApiService.GetVehiclesById(1));
        }
    }
}
