using Microsoft.AspNetCore.Mvc;
using Eletro_BOB_API.Models;
using Eletro_BOB_API.Context;
using Eletro_BOB_API.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AreaContext _context;
        private readonly IConfiguration _config;
        public RegisterController(AreaContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        private string GenerateSalt(int size)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;
            for (int i = 0; i < size; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        [HttpPost]
        public async Task<IActionResult> Post(BasicUser user)
        {
            try
            {
                Users newUser = new Users();
                newUser.Login = user.Login;
                byte[] salt = Encoding.ASCII.GetBytes(GenerateSalt(15));
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: user.Password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));
                newUser.Salt = Encoding.ASCII.GetString(salt);
                newUser.Password = hashed;
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                Preference newPref = new Preference();
                newPref.ActiveNotifications = true;
                newPref.ActiveSMS = true;
                newPref.ActiveEmail = true;
                Users temp = await _context.Users.Where(u => u.Login == user.Login).FirstOrDefaultAsync();
                newPref.UserId = temp.Id;
                await _context.Preferences.AddAsync(newPref);
                await _context.SaveChangesAsync();
                var issuer = _config["Jwt:Issuer"];
                var audience = _config["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, temp.Login),
                        new Claim(JwtRegisteredClaimNames.Email, temp.Login),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                returnedUser userToReturn = new returnedUser();
                userToReturn.userId = temp.Id;
                userToReturn.jwt = jwtToken;
                userToReturn.username = temp.Login;
                return Ok(userToReturn);
            }
            catch (System.Exception)
            {
                return BadRequest("Error when creating user");
            }
        }
    }
}
