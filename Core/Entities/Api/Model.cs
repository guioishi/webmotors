namespace Core.Entities
{
    /// <summary>
    /// Class to define the car model.
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Brand Id.
        /// </summary>
        public int MakeID { get; set; }

        /// <summary>
        /// Car name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}