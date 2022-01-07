namespace Core.DTOs
{
    /// <summary>
    /// Update advetisement dto class.
    /// </summary>
    public class UpdateAdvertisementDto
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Versao { get; set; } = string.Empty;
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; } = string.Empty;

        /// <summary>
        /// Class constructor.
        /// </summary>
        public UpdateAdvertisementDto()
        {
        }
    }
}