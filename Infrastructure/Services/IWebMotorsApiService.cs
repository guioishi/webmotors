namespace Infrastructure.Services
{
    /// <summary>
    /// When a class implements this interface, this class should use Webmotors Api Service methods.
    /// </summary>
    public interface IWebMotorsApiService
    {
        /// <summary>
        /// Gets all vehicles brands.
        /// </summary>
        /// <returns>List of vehicle brands.</returns>
        Task<Core.Entities.Response<IList<Core.Entities.Make>>> GetAllMake();

        /// <summary>
        /// Gets vehicle model by id.
        /// </summary>
        /// <param name="id">Model id.</param>
        /// <returns>Vehicle models.</returns>
        Task<Core.Entities.Response<IList<Core.Entities.Model>>> GetModelById(int id);

        /// <summary>
        /// Gets vehicle by id.
        /// </summary>
        /// <param name="id">Vehicle id.</param>
        /// <returns>Vehicles.</returns>
        Task<Core.Entities.Response<IList<Core.Entities.Vehicles>>> GetVehiclesById(int id);

        /// <summary>
        /// Gets vehicle version by id.
        /// </summary>
        /// <param name="id">Version id.</param>
        /// <returns>Vehicle versions.</returns>
        Task<Core.Entities.Response<IList<Core.Entities.Version>>> GetVersionById(int id);
    }
}