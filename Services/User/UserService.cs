using O2W.DbContext;
using O2W.DTOs.User;

namespace O2W.Services.User;

public class UserService
{
    private readonly O2WDbContext _context;
    
    public  UserService(O2WDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Models.User.User> CreateAsync(UserDto dto)
    {
        Models.User.User user = new Models.User.User
        {
            Id = dto.Id,
            Naam =  dto.Naam,
            Geboortedatum =  dto.Geboortedatum,
            Email = dto.Email,
            WachtwoordHash = dto.WachtwoordHash,
            Land = dto.Land,
            Stad =  dto.Stad,
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }
}