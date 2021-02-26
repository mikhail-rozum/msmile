namespace MSmile.Api.Authentication
{
    /// <summary>
    /// JWT token configuration.
    /// </summary>
    public class JwtTokenConfiguration
    {
        /// <summary>
        /// Application secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Token publisher.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Token lifetime.
        /// </summary>
        public int TokenLifetime { get; set; }
    }
}
