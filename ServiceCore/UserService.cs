using ServiceCore.Context;
using ServiceCore.Entities;
using System;

namespace ServiceCore
{
    public sealed class UserService : IUserService
    {
        private readonly IUserContext userContext;
        public UserService(IUserContext userContext)
        {
            this.userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        public void AddUser(string name, string email)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (email == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            userContext.Users.Add(new User
            {
                Name = name,
                Email = email,
                Created = DateTimeOffset.UtcNow
            });
            userContext.SaveChanges();
        }

    }
}
