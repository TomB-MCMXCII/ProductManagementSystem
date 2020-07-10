using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManegement.Core.Interfaces.Services
{
    public interface IUserService
    {
        void CheckDefaultAdmin();
        bool IsAdmin(string email, string password);
        bool UserExists(string email, string password);
    }
}
