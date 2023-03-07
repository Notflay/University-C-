using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myFirstBackend.DataAccess;
using myFirstBackend.Helpers;
using myFirstBackend.Models.DataModels;
using NuGet.Frameworks;
using System.Collections.Generic;

namespace myFirstBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UniversityDBContext _context;

        public AccountController(UniversityDBContext context, JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _context = context;
        }

        // Example Users
        // TODO: Change by real users in DB 
        private IEnumerable<User> Logins = new List<User>()
        {
            new User(){
                Id = 1,
                Email = "sebas@gmail.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User(){
                Id = 2,
                Email = "martin@gmail.com",
                Name = "User1",
                Password = "pepe"
            }
        };

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();

                // TODO:
                // Search a user in context with a LinQ
                var searchUser = (from user in _context.Users
                                  where user.Name == userLogin.UserName && user.Password == userLogin.Password
                                  select user).FirstOrDefault();

                Console.WriteLine("User Found: ", searchUser);


                // TODO: Change to searchuser
                // var valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                if (searchUser != null)
                {
                    // var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuiId = Guid.NewGuid()
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong password");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }

        // Permite colocar el nombre para buscar segun ello el primer usuario que fue creado por name
        [HttpGet("{name}")]
        public IActionResult GetUserWhere(string name)
        {
            var lista = _context.Users.ToList().FirstOrDefault(u => u.CreatedBy.Equals(name, StringComparison.OrdinalIgnoreCase));
            /* // Busca solo el primero que fue creado por Sebastian 
            var lista = _context.Users.ToList().FirstOrDefault(u => u.CreatedBy.Equals("Sebastian", StringComparison.OrdinalIgnoreCase));
            
            /* // Busca todos los que fueron creado por sebastian
            var lista = from user in _context.Users
                        where user.CreatedBy == "Sebastian"
                        select user;
            */
            return Ok(lista);
        }
    }
}
