
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Projekt_s16696.DTOs;
using Projekt_s16696.Exceptions;
using Projekt_s16696.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_s16696.Services
{
    public class ClientsDBService : ControllerBase, IClientsDBService
    {
        private readonly MyDbContext _context;
        private IConfiguration _configuration { get; set; }
        private string salt = "RQpM#WvtY3WV";

        public ClientsDBService(IConfiguration configuration, MyDbContext context)
        {
            _context = context;
            _configuration = configuration;
        }
        public List<Client> AllClients()
        {
            return _context.Clients.ToList();
        }

        public IActionResult Login(LoginRequest loginReq)
        {
            try
            {
                var stat = _context.Clients.Where(p => p.Login==loginReq.Login);

                if (stat == null)
                {
                    throw new NotFoundUserException();
                }


                var val = KeyDerivation.Pbkdf2(password: loginReq.Password,
                   salt: Encoding.UTF8.GetBytes(salt),
                   prf: KeyDerivationPrf.HMACSHA512,
                   iterationCount: 10000,
                   numBytesRequested: 256/8);

                var reHashPass = Convert.ToBase64String(val);

                var checkPass = _context.Clients.Where(p => p.Password == reHashPass);

                if (checkPass == null)
                {
                    throw new NotFoundUserException("Bad Password");
                }

                var logUserId = _context.Clients.Where(p => p.Password == reHashPass && p.Login == loginReq.Login)
                    .Select(p=> p.IdClient);
                var logUser = _context.Clients.Where(p => p.Password == reHashPass && p.Login == loginReq.Login)
                    .ToList().First();

                var claims = new[]
{
                    new Claim(ClaimTypes.NameIdentifier,logUserId.ToString()  ),
                    new Claim(ClaimTypes.Role, "registered"),
                };

                SecurityKey test = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var cred = new SigningCredentials(
                    test,
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

                var tok = new JwtSecurityToken
                (
                    issuer: "self",
                    audience: "Users",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: cred

                );

                Guid refToken = Guid.NewGuid();

                logUser.clientToken = refToken.ToString();
                _context.Update(logUser);
                _context.SaveChanges();

                return Ok(new { tok = new JwtSecurityTokenHandler().WriteToken(tok), refToken });
            }
            catch (Exception e)
            {
                return StatusCode(401);
            }
        }

        public IActionResult RefreshTok(string token)
        {
            var client = _context.Clients
                    .Where(e => e.clientToken == token)
                    .ToList();


            if (client.Count == 0)
            {
                throw new NoTokenExistsException();
            }

            Client insideClient = client.First();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,insideClient.IdClient.ToString()  ),
                new Claim(ClaimTypes.Role, "registered"),
                new Claim(ClaimTypes.Role,"loggedUser")
            };

            SecurityKey test = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var cred = new SigningCredentials(
                test,
                Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

            var tok = new JwtSecurityToken
            (
                issuer: "self",
                audience: "Users",
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: cred

            );

            Guid refreshToken = Guid.NewGuid();

            insideClient.clientToken = refreshToken.ToString();

            _context.Update(insideClient);
            _context.SaveChanges();

            return Ok
            (new
            {
                token = new JwtSecurityTokenHandler().WriteToken(tok),refreshToken
                }
            );
        }


        public IActionResult Register(RegisterRequest register)
        {
            try
            {
                if (register.Password == "" || register.Login == "")
                {
                    throw new NoLoginOrPasswordException();
                }

                var loginChecker = _context.Clients.Where(e => e.Login == register.Login);
                if (loginChecker != null)
                {
                    throw new LoginExistsException();
                }

               

                var valueBytes = KeyDerivation.Pbkdf2(password: register.Password,
                              salt: Encoding.UTF8.GetBytes(salt),
                              prf: KeyDerivationPrf.HMACSHA512,
                              iterationCount: 10000,
                              numBytesRequested: 256/8);

                string generatedPassword = Convert.ToBase64String(valueBytes);


                Client client = new Client
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Email = register.Email,
                    Phone = register.Phone,
                    Login = register.Login,
                    Password =  generatedPassword
                };

                _context.Clients.Add(client);
                _context.SaveChanges();

                //security
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,client.IdClient.ToString()  ),
                    new Claim(ClaimTypes.Role, "registered"),
                };

                SecurityKey test = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var cred = new SigningCredentials(
                    test,
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

                var tok = new JwtSecurityToken
                (
                    issuer: "self",
                    audience: "Users",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: cred

                );

                Guid refToken = Guid.NewGuid();

                client.clientToken = refToken.ToString();

                _context.Update(client);
                _context.SaveChanges();

                return StatusCode(201, new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(tok),
                    refToken
                });
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
