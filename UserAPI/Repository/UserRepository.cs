using Microsoft.EntityFrameworkCore;
using UserAPI.Context;
using UserAPI.Models;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public int AddUser(User user)
        {
            _userDbContext.Users.Add(user);
            int changes = _userDbContext.SaveChanges();
            return changes;
        }

        public bool BlockUser(User userEditObject)
        {
            userEditObject.IsBlocked = true;
            _userDbContext.Entry(userEditObject).State = EntityState.Modified;
            int changes = _userDbContext.SaveChanges();
            return changes > 0;
        }

        public bool DeleteUser(User userDeleteDetails)
        {
            _userDbContext.Users.Remove(userDeleteDetails);
            int changes = _userDbContext.SaveChanges();
            return changes > 0;
        }


        public bool EditUser(User userEditObject, User newUser)
        {
            userEditObject.Name = newUser.Name;
            userEditObject.Location = newUser.Location;
            userEditObject.Country = newUser.Country;
            userEditObject.Password = newUser.Password;
            userEditObject.Role = newUser.Role;
            userEditObject.IsActive = newUser.IsActive;
            userEditObject.IsBlocked = newUser.IsBlocked;

            _userDbContext.Entry(userEditObject).State = EntityState.Modified;
            int changes = _userDbContext.SaveChanges();
            return changes > 0;
        }

        public List<User> GetAllActiveUser()
        {
            return _userDbContext.Users.Where(u => u.IsActive == true).ToList();
        }

        public List<User> GetAllBlockedUser()
        {
            return _userDbContext.Users.Where(u => u.IsBlocked == true).ToList();
        }

        public List<User> GetAllInactiveUser()
        {
            return _userDbContext.Users.Where(u => u.IsActive == false).ToList();
        }

        public List<User> GetAllUnBlockedUser()
        {
            return _userDbContext.Users.Where(u => u.IsBlocked == false).ToList();
        }

        public List<User> GetAllUsers()
        {
            return _userDbContext.Users.ToList();
        }

        public User? GetUserById(int userId)
        {
            return _userDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        public User? GetUserName(string? name)
        {
            return _userDbContext.Users.Where(u => u.Name == name).FirstOrDefault();
        }

        public User? Login(LoginUser loginUser)
        {
            return _userDbContext.Users.Where(u => u.Name == loginUser.Name && u.Password == loginUser.Password).FirstOrDefault();
        }

        public bool UnblockUser(User userEditObject)
        {
            userEditObject.IsBlocked = false;
            _userDbContext.Entry(userEditObject).State = EntityState.Modified;
            int changes = _userDbContext.SaveChanges();
            return changes > 0;
        }
    }
}
