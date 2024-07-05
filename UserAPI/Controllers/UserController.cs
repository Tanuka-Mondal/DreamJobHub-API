using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.AOP;
using UserAPI.Logging;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [ServiceFilter(typeof(UserLogger))]
    [UserExceptionHandler]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly ITokenGeneratorService _tokenGeneratorService;
        public UserController(IUserService userService, ITokenGeneratorService tokenGeneratorService)
        {
            _userService = userService;
            _tokenGeneratorService = tokenGeneratorService;
        }
        [HttpGet]
        [Route("getAllUsers")]
        public ActionResult GetAllUsers()
        {
            List<User> users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("addUser")]
        public ActionResult AddUser(User user)
        {
            int userAddResult = _userService.AddUser(user);
            return Created("api/adduser", userAddResult);
        }

        [HttpDelete]
        [Route("deleteUser")]
        public ActionResult DeleteUser(int userId)
        {
            bool userDeleteResult = _userService.DeleteUser(userId);
            return Ok(userDeleteResult);
        }

        [HttpPut]
        [Route("editUser")]
        public ActionResult EditUser(int id, User newUser)
        {
            bool userEditResult = _userService.EditUser(id, newUser);
            return Ok(userEditResult);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginUser loginUser)
        {
            User user = _userService.Login(loginUser);
            if (user != null)
            {
                string userToken = _tokenGeneratorService.GenerateToken(user.Id, user.Name, user.Role);
                return Ok(userToken);
            }
            else
            {
                return NotFound("");
            }
        }

        [HttpGet]
        [Route("getUserByName/{name}")]

        public ActionResult GetUserByName(string name)
        {
            User user = _userService.GetUserByName(name);
            return Ok(user);
        }

        [HttpGet]
        [Route("getUserById/{id:int}")]

        public ActionResult GetUserById(int id)
        {
            User user = _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPatch]
        [Route("blockUser")]
        public ActionResult BlockUser(int id)
        {
            bool userBlockResult = _userService.BlockUser(id);
            return Ok(userBlockResult);
        }

        [HttpPatch]
        [Route("unblockUser")]
        public ActionResult UnblockUser(int id)
        {
            bool userUnblockResult = _userService.UnblockUser(id);
            return Ok(userUnblockResult);
        }

        [HttpGet]
        [Route("getBlockedUsers")]
        public ActionResult GetAllBlockedUser()
        {
            List<User> users = _userService.GetAllBlockedUser();
            return Ok(users);
        }

        [HttpGet]
        [Route("getUnblockedUsers")]
        public ActionResult GetAllUnblockedUser()
        {
            List<User> users = _userService.GetAllUnBlockedUser();
            return Ok(users);
        }

        [HttpGet]
        [Route("getActiveUsers")]
        public ActionResult GetAllActiveUser()
        {
            List<User> users = _userService.GetAllActiveUser();
            return Ok(users);
        }

        [HttpGet]
        [Route("getInactiveUsers")]
        public ActionResult GetAllInactiveUser()
        {
            List<User> users = _userService.GetAllInactiveUser();
            return Ok(users);
        }

        
    }
}
