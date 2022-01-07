namespace Core.Entities
{
    /// <summary>
    /// Class to define advertisement model.
    /// </summary>
    public class Advertisement
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Vehicle brand.
        /// </summary>
        public string Marca { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle model.
        /// </summary>
        public string Modelo { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle version.
        /// </summary>
        public string Versao { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle model year.
        /// </summary>
        public int Ano { get; set; }

        /// <summary>
        /// Kilometers traveled
        /// </summary>
        public int Quilometragem { get; set; }

        /// <summary>
        /// Observations about vehicle.
        /// </summary>
        public string Observacao { get; set; } = string.Empty;

        /// <summary>
        /// Class constructor.
        /// </summary>
        public Advertisement()
        {
        }
    }
}