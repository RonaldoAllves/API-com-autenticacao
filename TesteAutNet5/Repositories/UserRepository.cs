using System.Collections.Generic;
using System.Linq;
using TesteAutNet5.Models;
using TesteAutNet5.Services;

namespace TesteAutNet5.Repositories
{
    public class UserRepository
    {
        //static var users = new List<User>();
        private static List<User> users = new List<User>();

        //users.Add(new User { Id = 1, Username = "Ronaldo", Password = "753159", Role = "Gerente" });

        public static User Get(string username, string password)
        { 
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
        public static User Set(string username, string password, string role)
        {
            var token = TokenService.GenerateToken(username,role);
            users.Add(new User { Id = users.Count+1, Username = username, Password = password, Role = role, Token = token });
            return users.Last();
        }

        public static List<User> All()
        {
            return users;
        }
    }
}