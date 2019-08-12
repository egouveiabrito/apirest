using System.Data;
using System.Linq;
using Entity.Interfaces.Repositories;
using Entity;
using Entity.Entities;
using Infrastructure.Context;
using System;
using System.Data.Entity;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Signin(Login login)
        {
            using (var context = new DatabaseContext())
            {
                User User = context.User.Where(e => e.email == login.email && e.password == login.password).FirstOrDefault();
                LastLogin(User);
                return User;
            }
        }
        private void LastLogin(User entity)
        {
            using (var context = new DatabaseContext())
            {
                entity.last_login = DateTime.Now;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public User Signup(User entity)
        {
            using (var context = new DatabaseContext())
            {
                entity.created_at = DateTime.Now;
                context.User.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }
        public User Me(int Id)
        {
            using (var context = new DatabaseContext())
            {
                return context.User.Where(e => e.id == Id).FirstOrDefault();
            }
        }

        public bool IsEmailExist(string email)
        {
            using (var context = new DatabaseContext())
            {
                return context.User.Any(e => e.email == email);
            }
        }
        public int Authenticate(string email, string password)
        {
            using (var context = new DatabaseContext())
            {
                var User = context.User.Where(e => e.email == email && e.password == password).FirstOrDefault();
                if (User != null) return User.id; else return 0;
            }
        }

    }
}