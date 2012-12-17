using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using Garagable.Data.CodeContracts;
using Garagable.Model;
using Garagable.Service.Contract;

namespace Garagable.Service {

    public class SecurityService : ISecurityService {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenCreator _tokenCreator;

        public SecurityService(
            IUnitOfWork unitOfWork, 
            ITokenCreator tokenCreator) {
            _unitOfWork = unitOfWork;
            _tokenCreator = tokenCreator;
        }

        public IEnumerable<User> GetUsers() {
            var users = _unitOfWork.UserRepository.GetAll(); 
            return users;
        }

        public User GetUserByName(string userName) {
            var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(u => u.UserName.Equals(userName));
            return user;
        }

        public User GetUserById(int userId) {
            var user = _unitOfWork.UserRepository.GetById(userId);
            return user;
        }

        public User GetUserByFaceBookId(string faceBookId) {
            var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(u => faceBookId.Equals(u.FacebookId));
            return user;
        }

        public User GetUserByAccessToken(string accessToken) {
            var user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(u => accessToken.Equals(u.AccessToken));
            return user;
        }

        public bool CreateUser(User user, string password) {
            var hashedPassword = Crypto.HashPassword(password);
            user.HashedPassword = hashedPassword;
            _unitOfWork.UserRepository.Add(user);
            Save();

            //if nothing happens, it must be successful
            return true;
        }

        public User ValidateUser(string userName, string password) {
            //password = _encryptor.Encrypt(password);
            var user = _unitOfWork.UserRepository.GetMany(u => u.UserName.Equals(userName)).FirstOrDefault();
            if (user == null)
                return null;
            return Crypto.VerifyHashedPassword(user.HashedPassword, password) 
                ? user 
                : null;
        }


        public string CreateLoginToken(User user) {
            string token = _tokenCreator.CreateToken();
            user.AccessToken = token;
            return token;
        }

        public User Login(string username, string password) {
            User user = ValidateUser(username, password);
            if (user == null)
                return null;
            string token = CreateLoginToken(user);
            user.AccessToken = token;
            UpdateLastActivity(user);
            return user;
        }



        public void DeleteUser(string userName) {
            var user = GetUserByName(userName);
            _unitOfWork.UserRepository.Delete(user);
            Save();
        }

        public void DeleteUser(int id) {
            var user = GetUserById(id);
            _unitOfWork.UserRepository.Delete(user);
            Save();
        }

        public void UpdateLastActivity(User user) {
            user.LastActivity = DateTime.Now;
            UpdateUser(user);
            Save();
        }

        public void UpdateLastActivity(string username) {
            User user = this.GetUserByName(username);
            if (user == null) return;
            this.UpdateLastActivity(user);
            Save();
        }

        public IEnumerable<Role> GetRoles() {
            var roles = _unitOfWork.RoleRepository.GetAll();
            return roles;
        }

        public Role GetRoleByName(string roleName) {
            var role = _unitOfWork.RoleRepository.GetAll().FirstOrDefault(r => r.RoleName.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            return role;
        }

        public Role GetRoleById(int id) {
            var role = _unitOfWork.RoleRepository.GetById(id);
            return role;
        }

        public Role CreateRole(Role role) {
            _unitOfWork.RoleRepository.Add(role);
            Save();
            return role;
        }

        public void DeleteRole(string roleName) {
            var role = GetRoleByName(roleName);
            _unitOfWork.RoleRepository.Delete(role);
            Save();
        }

        public void DeleteRole(int roleId) {
            var role = GetRoleById(roleId);
            _unitOfWork.RoleRepository.Delete(role);
            Save();
        }

        public void Save() {
            _unitOfWork.Commit();
        }

        public void AssignUserToRole(string userName, IEnumerable<string> roleNames) {
            User user = GetUserByName(userName);
            IEnumerable<Role> roles = roleNames.Select(GetRoleByName); //orig:  roleNames.Select(roleName => GetRoleByName(roleName));
            foreach (Role role in roles) {
                user.Roles.Add(role);
            }
            UpdateUser(user);
            Save();
        }

        public bool IsUserInRole(string userName, IEnumerable<string> roleNames) {
            bool isInRole = false;
            User user = GetUserByName(userName);
            foreach (string roleName in roleNames) {
                isInRole = user.Roles.Any(role => role.RoleName.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
                if (isInRole)
                    break;
            }
            return isInRole;
        }

        public void UpdateUser(User user) {
            _unitOfWork.UserRepository.Update(user);
        }

        public void UpdateRole(Role role) {
            _unitOfWork.RoleRepository.Update(role);
        }



    }

}
