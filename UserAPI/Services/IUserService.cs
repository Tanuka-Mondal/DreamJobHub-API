﻿using UserAPI.Models;

namespace UserAPI.Services
{
    public interface IUserService
    {
        int AddUser(User user);
        bool BlockUser(int id);
        bool DeleteUser(int userId);        
        bool EditUser(int id, User newUser);
        List<User> GetAllActiveUser();
        List<User> GetAllBlockedUser();
        List<User> GetAllInactiveUser();
        List<User> GetAllUnBlockedUser();
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByName(string name);
        User Login(LoginUser loginUser);
        bool UnblockUser(int id);
    }
}
