using API.DTOs;
using API.Entities;
using API.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository(DataContext context) : IUserRepository
{
    public async Task<MemberDto?> GetMemberByUsernameAsync(string username)
    {
        return await context.Users.Where(x => x.Username == username)
            .ProjectToType<MemberDto>()
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await context.Users
            .ProjectToType<MemberDto>()
            .ToListAsync();
    }

    public async Task<AppUser?> GetUserByIdAsync(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
        return await context.Users
            .Include(x => x.Photos)
            .SingleOrDefaultAsync(x => x.Username == username);
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await context.Users
            .Include(x => x.Photos)
            .ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Update(AppUser user)
    {
        // explicitly sets the entity as modified in EF in case of AsNoTracking uses
        context.Entry(user).State = EntityState.Modified;
    }
}
