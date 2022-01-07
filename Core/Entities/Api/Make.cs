namespace Core.Entities
{
    /// <summary>
    /// Class to define vehicle brand.
    /// </summary>
    public class Make
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Vehicle brand.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}