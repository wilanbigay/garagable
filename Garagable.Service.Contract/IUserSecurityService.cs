using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garagable.Model;

namespace Garagable.Service.Contract {
    public interface IUserSecurityService {
        IEnumerable<User> GetUsers();
        User GetUserByName(string userName);
        User GetUserById(int userId);
        User GetUserByFaceBookId(string faceBookId);
        User GetUserByAccessToken(string accessToken);
        User ValidateUser(string userName, string password);


        bool CreateUser(User user, string password);
        void DeleteUser(string userName);
        void DeleteUser(int id);
        void UpdateUser(User user);
        void UpdateLastActivity(User user);
        void UpdateLastActivity(string username);
        User Login(string username, string password);

    }
}
