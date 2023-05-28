 using Microsoft.AspNetCore.Mvc;
using ZucoBackend.Models;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ZucoBackend.Services
{
    public class LoginService
    {
        private AppDbContext db;
        private IConfiguration configuration;

        public LoginService(AppDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }
        public async Task<Admin> Register(AdminDto adminDto)
        {
            CreatePasswordHash(adminDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            Admin admin = new Admin()
            {
                Username = adminDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            db.Admins.Add(admin);
            await db.SaveChangesAsync();
            return admin;
        }

        internal async Task<Admin> GetAdmin(string username)
        {
            var admin = await db.Admins.FindAsync(username);
            return admin;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            };
        }
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return hash.SequenceEqual(passwordHash);
            }
        }

        public string CreateToken(Admin admin)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.Username)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("Appsettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
