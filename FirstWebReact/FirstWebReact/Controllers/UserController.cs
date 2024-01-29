using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FirstWebReact.Model;
using System.Linq;

namespace FirstWebReact.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataUserContext _userContext;
        public UserController(DataUserContext dataUserContext) {

            _userContext = dataUserContext;
        }
        [HttpGet]
        [Route("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            var users = _userContext.Users.Select(s => new User{
                UserId = s.UserId,
                Username = s.Username,
                PasswordHash = s.PasswordHash,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address,
            }).ToList();
            return users;
        }
    }
}
