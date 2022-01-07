namespace Infrastructure.Services
{
    /// <summary>
    /// When a class implements this interface, this class should use Advertisement Service methods.
    /// </summary>
    public interface IAdvertisementService
    {
        /// <summary>
        /// Gets advertisement by id.
        /// </summary>
        /// <param name="id">Advertisement id.</param>
        /// <returns>Especific advertisement.</returns>
        Task<Core.Entities.Response<Core.DTOs.GetAdvertisementDto>> GetById(int id);

        /// <summary>
        /// Gets all advertisements.
        /// </summary>
        /// <returns>List of advertisements.</returns>
        Task<Core.Entities.Response<System.Collections.Generic.IList<Core.DTOs.GetAdvertisementDto>>> GetAll();

        /// <summary>
        /// Inserts into db an advertisement.
        /// </summary>
        /// <param name="AdvertisementDto">Advertisement model</param>
        /// <returns>Api response.</returns>
        Task<Core.Entities.Response<Core.DTOs.GetAdvertisementDto>> Insert(Core.DTOs.AddAdvertisementDto AdvertisementDto);

        /// <summary>
        /// Updates an advertisement.
        /// </summary>
        /// <param name="AdvertisementDto">Advertisement model</param>
        /// <returns>Api response.</returns>
        Task<Core.Entities.Response<Core.DTOs.GetAdvertisementDto>> Update(Core.DTOs.UpdateAdvertisementDto AdvertisementDto);

        /// <summary>
        /// Deletes an advertisement by id.
        /// </summary>
        /// <param name="id">Advertisement id.</param>
        /// <returns>True in case of success.</returns>
        Task<Core.Entities.Response<bool>> Delete(int id);
    }
}