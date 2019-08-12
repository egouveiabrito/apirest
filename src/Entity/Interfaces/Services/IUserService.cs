using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Entity.Interfaces.Services
{
    public interface IUserService
    {
        User Signup(User user);
        string Signin(Login login);
        User Me(int Id);

        int Authenticate(string email, string password);
    }
}
