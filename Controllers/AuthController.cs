using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace JWTWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // create method to register user
        public static User user = new User();
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password,out byte[] passwordHash,out byte[] passwordSalt);
            user.Username= request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return (user);
        }
         [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if (user.Username != request.Username)
            {
               return BadRequest(" User not Found ");
            }
            if (!VerifyPaswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }
               return Ok(" Here is token!!! ");
        }
    
        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            // cryptograpy algorithm reference
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPaswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
