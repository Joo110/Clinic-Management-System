using Data_Access_Layer_Clinic.Models;
using Data_Access_Layer_Clinic;
using System.Collections.Generic;

namespace Data_Business_Layer_Clinic
{
    public class clsUser
    {
        private readonly UserService _repo;

        public clsUser(UserService repo)
        {
            _repo = repo;
        }

        public int AddUser(string username, string password, int permission, int personId)
        {
            return _repo.Add(username, password, permission, personId);
        }

        public bool UpdateUser(int id, string username, string password, int permission, int personId)
        {
            return _repo.Update(id, username, password, permission, personId);
        }

        public bool DeleteUser(int id)
        {
            return _repo.Delete(id);
        }

        public List<User> GetAllUsers()
        {
            return _repo.GetAll();
        }

        public User? GetUserById(int id)
        {
            return _repo.GetById(id);
        }

        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            return _repo.GetByUsernameAndPassword(username, password);
        }

        public User? GetUserByUsername(string username)
        {
            return _repo.GetByUsername(username);
        }

        public bool UserExists(int id)
        {
            return _repo.Exists(id);
        }

        public bool UserExistsByUsername(string username)
        {
            return _repo.ExistsByUsername(username);
        }
    }
}
