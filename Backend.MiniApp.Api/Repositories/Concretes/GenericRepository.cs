using Backend.MiniApp.Api.Data;
using Backend.MiniApp.Api.Models.Common;
using Backend.MiniApp.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace Backend.MiniApp.Api.Repositories.Concretes;

public class GenericRepository<T>(AppDbContext appDbContext) : IGenericRepository<T> where T : BaseEntity
{
    public DbSet<T> Table => appDbContext.Set<T>();
    public async Task<List<T>> GetAllAsync()
    {
        return await Table.ToListAsync();
    }

    public Task<T> GetByIdAsync(int id)
    {
        return Table.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public void Update(T entity)
    {
        Table.Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            Table.Remove(entity);
            await appDbContext.SaveChangesAsync();
        }
    }
    public async Task SaveChangeAsync()
    {
        await appDbContext.SaveChangesAsync();
    }

    public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate)
    {
        return await Table.Where(predicate).ToListAsync();
    }
}
