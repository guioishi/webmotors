using Core.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Implementation
{
    /// <summary>
    /// Instance od AdvertisementService
    /// </summary>
    public class AdvertisementService : IAdvertisementService
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly Infrastructure.Data.IDataContext _context;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="adContext">Database data context.</param>
        /// <param name="mapper">Aplication mapper</param>
        public AdvertisementService(Infrastructure.Data.IDataContext adContext, AutoMapper.IMapper mapper)
        {
            _context = adContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets advertisement by id.
        /// </summary>
        /// <param name="id">Advertisement id.</param>
        /// <returns>Especific advertisement.</returns>
        public async Task<Core.Entities.Response<Core.DTOs.GetAdvertisementDto>> GetById(int id)
        {
            var serviceResponse = new Core.Entities.Response<Core.DTOs.GetAdvertisementDto>();

            var dbAdvertisement = await _context.Advertisement.FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<Core.DTOs.GetAdvertisementDto>(dbAdvertisement);

            return serviceResponse;
        }

        /// <summary>
        /// Inserts into db an advertisement.
        /// </summary>
        /// <param name="AdvertisementDto">Advertisement model</param>
        /// <returns>Api response.</returns>
        public async Task<Core.Entities.Response<Core.DTOs.GetAdvertisementDto>> Insert(Core.DTOs.AddAdvertisementDto AdvertisementDto)
        {
            var serviceResponse = new Core.Entities.Response<Core.DTOs.GetAdvertisementDto>();
            
            var Advertisement = _mapper.Map<Core.Entities.Advertisement>(AdvertisementDto);

            _context.Advertisement.Add(_mapper.Map<Core.Entities.Advertisement>(Advertisement));
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<Core.DTOs.GetAdvertisementDto>(Advertisement);

            return serviceResponse;
        }

        /// <summary>
        /// Deletes an advertisement by id.
        /// </summary>
        /// <param name="id">Advertisement id.</param>
        /// <returns>True in case of success.</returns>
        public async Task<Core.Entities.Response<bool>> Delete(int id)
        {
            var serviceResponse = new Core.Entities.Response<bool>();

            try
            {
                var Advertisement = await _context.Advertisement.FirstOrDefaultAsync(a => a.Id == id);

                if (Advertisement == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Data = false;
                    serviceResponse.Message = "Anuncio nao encontrado";

                    return serviceResponse;
                }

                _context.Advertisement.Remove(Advertisement);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Data = false;
                serviceResponse.Message = ex.Message;
            }

            serviceResponse.Data = true;
            return serviceResponse;
        }

        /// <summary>
        /// Gets all advertisements.
        /// </summary>
        /// <returns>List of advertisements.</returns>
        public async Task<Core.Entities.Response<System.Collections.Generic.IList<Core.DTOs.GetAdvertisementDto>>> GetAll()
        {
            var allAds = await _context.Advertisement.ToListAsync();

            var serviceResponse = new Core.Entities.Response<System.Collections.Generic.IList<Core.DTOs.GetAdvertisementDto>>()
            {
                Data = allAds.ToList().Select(ad => _mapper.Map<Core.DTOs.GetAdvertisementDto>(ad)).ToList()
            };

            return serviceResponse;
        }

        /// <summary>
        /// Updates an advertisement.
        /// </summary>
        /// <param name="AdvertisementDto">Advertisement model</param>
        /// <returns>Api response.</returns>
        public async Task<Core.Entities.Response<GetAdvertisementDto>> Update(UpdateAdvertisementDto AdvertisementDto)
        {
            var serviceResponse = new Core.Entities.Response<Core.DTOs.GetAdvertisementDto>();

            try
            {
                var Advertisement = await _context.Advertisement.FirstOrDefaultAsync(ad => ad.Id == AdvertisementDto.Id);

                if (Advertisement == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Anuncio nao encontrado";

                    return serviceResponse;
                }

                Advertisement.Ano = AdvertisementDto.Ano;
                Advertisement.Marca = AdvertisementDto.Marca;
                Advertisement.Modelo = AdvertisementDto.Modelo;
                Advertisement.Observacao = AdvertisementDto.Observacao;
                Advertisement.Quilometragem = AdvertisementDto.Quilometragem;
                Advertisement.Versao = AdvertisementDto.Versao;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<Core.DTOs.GetAdvertisementDto>(Advertisement);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}