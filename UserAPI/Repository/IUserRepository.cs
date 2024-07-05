using UserAPI.Models;

namespace UserAPI.Repository
{
    public interface IUserRepository
    {
        int AddUser(User user);
        bool BlockUser(User userEditObject);
        bool DeleteUser(User userDeleteDetails);
        bool EditUser(User userEditObject, User newUser);
        List<User> GetAllActiveUser();
        List<User> GetAllBlockedUser();
        List<User> GetAllInactiveUser();
        List<User> GetAllUnBlockedUser();
        List<User> GetAllUsers();
        User GetUserById(int userId);
        User GetUserName(string? name);
        User Login(LoginUser loginUser);
        bool UnblockUser(User userEditObject);
    }
}
