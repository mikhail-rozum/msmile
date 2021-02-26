namespace MSmile.Api.Authentication
{
    /// <summary>
    /// User model.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Employee name.
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Token.
        /// </summary>
        public string Token { get; set; }
    }
}
