using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using O2W.DbContext;
using O2W.Dtos.Auth;
using O2W.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace O2W.Services;

public class AuthService
{
    private readonly O2WDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(O2WDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<string> Register(RegisterDto dto)
    {
        var exists = await _context.Users
            .AnyAsync(u => u.Email == dto.Email);

        if (exists)
            throw new Exception("Email bestaat al");

        var user = new Models.User.User
        {
            Naam = dto.Naam,
            Email = dto.Email,
            WachtwoordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Stad = "",
            Land = "",
            Geboortedatum = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return GenerateJwtToken(user);
    }

    public async Task<string> Login(LoginDto dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user == null)
            throw new Exception("Gebruiker niet gevonden");

        bool validPassword = BCrypt.Net.BCrypt.Verify(
            dto.Password,
            user.WachtwoordHash
        );

        if (!validPassword)
            throw new Exception("Wachtwoord incorrect");

        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(Models.User.User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
        );

        var creds = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}