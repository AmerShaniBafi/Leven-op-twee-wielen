using Microsoft.EntityFrameworkCore;
using O2W.DbContext;
using O2W.DTOs;
using O2W.Models.MotorRoute;

namespace O2W.Services;

public class MotorRouteService
{
    private readonly O2WDbContext _context;

    public MotorRouteService(O2WDbContext context)
    {
        _context = context;
    }

    public async Task<List<MotorRoute>> GetAllAsync()
    {
        return await _context.MotorRoutes.ToListAsync();
    }

    public async Task<MotorRoute?> GetByIdAsync(int id)
    {
        return await _context.MotorRoutes.FindAsync(id);
    }

    public async Task<MotorRoute> CreateAsync(MotorRouteDto dto)
    {
        MotorRoute motorRoute = new MotorRoute
        {
            Titel = dto.Titel,
            Beschrijving = dto.Beschrijving,
            Startlocatie = dto.Startlocatie,
            Eindlocatie = dto.Eindlocatie,
            KaartUrl = dto.KaartUrl,
            IsPublic = dto.IsPublic,
            AfstandKm = dto.AfstandKm,
            GeschatteReistijd = dto.GeschatteReistijd,
            Moeilijkheidsgraad = dto.Moeilijkheidsgraad,
            RouteType = dto.RouteType,
            UserId = dto.UserId,
            CreatedAt = DateTime.UtcNow
        };

        _context.MotorRoutes.Add(motorRoute);
        await _context.SaveChangesAsync();

        return motorRoute;
    }
}