using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.Implementation
{
    /// <summary>
    /// Instance of WebMotorsApiService.
    /// </summary>
    public class WebMotorsApiService : IWebMotorsApiService
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="config"></param>
        public WebMotorsApiService(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Gets all vehicles brands.
        /// </summary>
        /// <returns>List of vehicle brands.</returns>
        public async Task<Core.Entities.Response<IList<Core.Entities.Make>>> GetAllMake()
        {
            var makeUrl = _config.GetValue<string>("WebMotorsUrls:Make");
            return await GetDataFromApi<Core.Entities.Make>(null, makeUrl);
        }

        /// <summary>
        /// Gets vehicle model by id.
        /// </summary>
        /// <param name="id">Model id.</param>
        /// <returns>Vehicle models.</returns>
        public async Task<Core.Entities.Response<IList<Core.Entities.Model>>> GetModelById(int id)
        {
            var modelUrl = $"{_config.GetValue<string>("WebMotorsUrls:Model")}{id}";
            return await GetDataFromApi<Core.Entities.Model>(id, modelUrl);
        }

        /// <summary>
        /// Gets vehicle by id.
        /// </summary>
        /// <param name="id">Vehicle id.</param>
        /// <returns>Vehicles.</returns>
        public async Task<Core.Entities.Response<IList<Core.Entities.Vehicles>>> GetVehiclesById(int id)
        {
            var vehiclesUrl = $"{_config.GetValue<string>("WebMotorsUrls:Vehicles")}{id}";
            return await GetDataFromApi<Core.Entities.Vehicles>(id, vehiclesUrl);
        }

        /// <summary>
        /// Gets vehicle version by id.
        /// </summary>
        /// <param name="id">Version id.</param>
        /// <returns>Vehicle versions.</returns>
        public async Task<Core.Entities.Response<IList<Core.Entities.Version>>> GetVersionById(int id)
        {
            var versionUrl = $"{_config.GetValue<string>("WebMotorsUrls:Version")}{id}";
            return await GetDataFromApi<Core.Entities.Version>(id, versionUrl);
        }

        private async Task<Core.Entities.Response<IList<T>>> GetDataFromApi<T>(int? id, string url)
        {
            var serviceResponse = new Core.Entities.Response<IList<T>>();

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                    {
                        serviceResponse.Success = false;
                        serviceResponse.Message = "Erro ao carregar as versoes";

                        return serviceResponse;
                    }

                    serviceResponse.Data = await System.Text.Json.JsonSerializer.DeserializeAsync<IList<T>>(await response.Content.ReadAsStreamAsync());
                }
                catch (Exception ex)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = ex.Message;
                }
            }


            return serviceResponse;
        }
    }
}