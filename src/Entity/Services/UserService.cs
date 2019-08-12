using Entity.Entities;
using Entity.Interfaces.Repositories;
using Entity.Interfaces.Services;
using Entity.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Me(int Id)
        {
            return _userRepository.Me(Id);
        }
        public void ValidarLogin(Login login)
        {
            if (login.email == null || login.email == string.Empty)
                throw new Exception("Missing fields");

            if (login.password == null || login.password == string.Empty)
                throw new Exception("Missing fields");
        }
        public void ValidarSave(User user)
        {

            if (_userRepository.IsEmailExist(user.email))
                throw new Exception("E-mail already exists");

            if (!IsValidate.IsEmail(user.email))
                throw new Exception("Invalid fields");

            if (user.firstName.Length == 1)
                throw new Exception("Invalid fields");

            if (user.lastName.Length == 1)
                throw new Exception("Invalid fields");

            if (user.firstName == null || user.firstName == string.Empty)
                throw new Exception("Missing fields");

            if (user.lastName == null || user.lastName == string.Empty)
                throw new Exception("Missing fields");

            if (user.password == null || user.password == string.Empty)
                throw new Exception("Missing fields");

            if (user.phones.Count == 0)
                throw new Exception("Missing fields");

            foreach (var phone in user.phones)
            {
                if (phone.number.Length == 1)
                    throw new Exception("Invalid fields");

                if (phone.country_code.Length == 1)
                    throw new Exception("Invalid fields");

                if (phone.area_code.Length == 1)
                    throw new Exception("Invalid fields");

                if (phone.number == null || phone.number == string.Empty)
                    throw new Exception("Missing fields");

                if (phone.country_code == null || phone.country_code == string.Empty)
                    throw new Exception("Missing fields");

                if (phone.area_code == null || phone.area_code == string.Empty)
                    throw new Exception("Missing fields");
            }

        }


        public User Signup(User user)
        {
            ValidarSave(user);
            return _userRepository.Signup(user);
        }
        public string Signin(Login login)
        {
            User User = _userRepository.Signin(login);

            if (User == null)
                throw new Exception("Invalid e-mail or password");

            return $@"Usuário { User.firstName} logado com sucesso.";
        }
        public int Authenticate(string email, string password)
        {
            return _userRepository.Authenticate(email, password);
        }
    }
}






