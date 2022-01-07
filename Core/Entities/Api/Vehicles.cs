namespace Core.Entities
{
    /// <summary>
    /// Class to define vehicle.
    /// </summary>
    public class Vehicles
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Vehicle brand.
        /// </summary>
        public string Make { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle model.
        /// </summary>
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle version.
        /// </summary>
        public string Version { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle image.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Kilometers traveled.
        /// </summary>
        public int KM { get; set; }

        /// <summary>
        /// Vehicle price.
        /// </summary>
        public string Price { get; set; } = string.Empty;

        /// <summary>
        /// Vehicle model year.
        /// </summary>
        public int YearModel { get; set; }

        /// <summary>
        /// Vehicle year of fabrication.
        /// </summary>
        public int YearFab { get; set; }

        /// <summary>
        /// Vehicle color.
        /// </summary>
        public string Color { get; set; } = string.Empty;
    }
}