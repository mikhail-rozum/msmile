namespace MSmile.Api.Authentication
{
    /// <summary>
    /// Authentication model.
    /// </summary>
    public class AuthenticationModel
    {
        /// <summary>
        /// Login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Password hash.
        /// </summary>
        public string PasswordHash { get; set; }
    }
}
