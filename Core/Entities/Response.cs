namespace Core.Entities
{
    /// <summary>
    /// Class to define api response.
    /// </summary>
    /// <typeparam name="T">Response type.</typeparam>
    public class Response<T>
    {
        /// <summary>
        /// Response data.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Response status.
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Response message.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Class constructor.
        /// </summary>
        public Response()
        {
        }
    }
}