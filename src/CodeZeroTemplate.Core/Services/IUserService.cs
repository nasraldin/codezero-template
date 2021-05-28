namespace CodeZeroTemplate.Core.Services
{
    /// <summary>
    /// User Service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets the Current User Id.
        /// </summary>
        /// <returns>UserId</returns>
        string GetCurrentUserId();
    }
}