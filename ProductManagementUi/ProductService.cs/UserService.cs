using ProductManegement.Core.Interfaces;
using ProductManegement.Core.Interfaces.Services;
using ProductManegement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProductManagement.Service
{
    public class UserService : IUserService
    {
        private IProductManagementDbContext _context;
        public UserService(IProductManagementDbContext context)
        {
            _context = context;
        }
        public void CheckDefaultAdmin()
        {
            var admin =  _context.Users.Where(x => x.Email == "admin@admin.lv").Where(x => x.IsAdmin == true).ToList();
            if(admin.Count() == 0)
            {
                var adminUser = new User()
                {
                    Email = "admin@admin.lv",
                    Password = "admin123",
                    IsAdmin = true
                };
                _context.Users.Add(adminUser);
                _context.SaveChanges();
            } 
        }
        public bool IsAdmin(string email,string password)
        {
            var user = _context.Users.Where(x => x.Email == email).Where(x => x.Password == password).FirstOrDefault();
            if (user != null)
            {
                if (user.IsAdmin)
                {
                    return true;
                }
            }
            return false;
        }
        public bool UserExists(string email, string password)
        {
            var user = _context.Users.Where(x => x.Email == email).Where(x => x.Password == password).FirstOrDefault();
            if(user == null)
            {
                return false;
            }
            return true;
        }
    }
}
