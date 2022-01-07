namespace Core.DTOs
{
    /// <summary>
    /// Add advetisement dto class.
    /// </summary>
    public class AddAdvertisementDto
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Marca { get; set; } = string.Empty;
        [System.ComponentModel.DataAnnotations.Required]
        public string Modelo { get; set; } = string.Empty;
        [System.ComponentModel.DataAnnotations.Required]
        public string Versao { get; set; } = string.Empty;
        [System.ComponentModel.DataAnnotations.Required]
        public int Ano { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public int Quilometragem { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Observacao { get; set; } = string.Empty;
        
        /// <summary>
        /// Class constructor.
        /// </summary>
        public AddAdvertisementDto()
        {
        }
    }
}