using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit25.Models;

namespace Unit25.Repositories
{
    public class UserRepository
    {

        // CREATE
        public int? AddNewUser(string name, string email)
        {
            int? newUserId;

            try
            {
                User user = new User()
                {
                    Name = name,
                    Email = email
                };

                using var db = new AppContext();
                db.Users.Add(user);
                db.SaveChanges();

                newUserId = user.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return newUserId;
        }


        // READ
        public List<User> GetAllUsers()
        {
            List<User> usersList;
            try
            {
                using var db = new AppContext();
                usersList = db.Users.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return usersList;
        }
        public User? GetUserById(int id)
        {
            User? user;
            try
            {
                using var db = new AppContext();
                user = db.Users.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return user;
        }

        public List<User> GetUsersWithSimilarEmail(string email)
        {
            List<User> usersList;
            try
            {
                using var db = new AppContext();
                usersList = db.Users.Where(x => x.Email.Contains(email)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return usersList;
        }


        // UPDATE
        public int? UpdateUser(int id, string name, string email)
        {
            int? userId = null;

            try
            {
                using var db = new AppContext();

                var user = db.Users.FirstOrDefault(x => x.Id == id);

                if (user != null)
                {
                    if (!string.IsNullOrEmpty(name))
                        user.Name = name;

                    if (!string.IsNullOrEmpty(email))
                        user.Email = email;

                    if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(email))
                        db.SaveChanges();

                    userId = user.Id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return userId;
        }


        // DELETE
        public int? DeleteUser(int id)
        {
            int? userId = null;

            try
            {
                using var db = new AppContext();

                var user = db.Users.FirstOrDefault(x => x.Id == id);

                if (user != null)
                {
                    db.Users.Remove(user);
                    userId = user.Id;

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в методе: {ex.Message}");
                throw;
            }

            return userId;
        }
    }
}
