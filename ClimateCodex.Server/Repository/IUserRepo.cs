using System;
using System.Collections.Generic;
using ClimateCodex.Server.Data;
using ClimateCodex.Server.Models;

namespace ClimateCodex.Server.Repository
{
    public interface IUserRepo
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void DeleteById(int id);
    }
    public class UserRepo : IUserRepo
    {
        private readonly ClimateCodexDbContext _db;

        public UserRepo(ClimateCodexDbContext db)
        {
            _db = db;
        }

        public void Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User not found");

            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public User GetById(int id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }
    }
}