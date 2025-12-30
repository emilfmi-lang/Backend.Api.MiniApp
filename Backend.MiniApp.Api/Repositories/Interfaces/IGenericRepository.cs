using Backend.MiniApp.Api.Data;
using Backend.MiniApp.Api.Models.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Backend.MiniApp.Api.Repositories.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    void Update(T entity);
    Task DeleteAsync(int id);
    Task SaveChangeAsync();
    Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate);
}
