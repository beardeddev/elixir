using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicorn.Data.Contracts
{
    public interface IUser : IEntity
    {
        string Email { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string PasswordHash { get; set; }
        string PasswordSalt { get; set; }
        string PersistenceToken { get; set; }
    }
}
