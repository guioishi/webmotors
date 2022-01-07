namespace Core.Entities
{
    /// <summary>
    /// Class to define vehicle version.
    /// </summary>
    public class Version
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Vehicle model id.
        /// </summary>
        public int ModelID { get; set; }

        /// <summary>
        /// Vehicle model name.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}