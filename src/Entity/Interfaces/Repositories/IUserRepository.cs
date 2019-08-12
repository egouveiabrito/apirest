using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Entity.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Signup(User user);
        User Signin(Login login);
        User Me(int Id);



        bool IsEmailExist(string email);
        int Authenticate(string email, string password);

    }
}
