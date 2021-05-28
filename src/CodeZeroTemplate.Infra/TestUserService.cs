using CodeZeroTemplate.Core.Services;
using CodeZeroTemplate.Data.SeedData;

namespace CodeZeroTemplate.Infra
{

    /// <inheritdoc cref="IUserService"/>
    public sealed class TestUserService : IUserService
    {
        /// <inheritdoc />
        public string GetCurrentUserId() => UserSeed.UserId;
    }
}