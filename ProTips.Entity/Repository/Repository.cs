using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProTips.Entity.Database;
using ProTips.Entity.Repository.Interfaces;
using ProTips.Entity.Utils;

namespace ProTips.Entity.Repository;

public abstract class Repository<T> : IRepository<T> where T : Base
{
    protected readonly MySqlContext Context;

    protected Repository(MySqlContext context)
    {
        Context = context;
    }
    
    public async Task<T> CreateAsync(T model)
    {
        await Context.AddAsync(model);
        await Context.SaveChangesAsync();
        return model;
    }

    public async Task<List<T>> CreateRangeAsync(List<T> model)
    {
        await Context.AddRangeAsync(model);
        await Context.SaveChangesAsync();
        return model;
    }

    public async Task<List<T>> GetAsync(params string[] includes) =>
        await Context.Set<T>()
            .Where(x => x.DeletedDate.HasValue == false)
            .IncludeIf(includes.Any(), includes)
            .AsNoTracking()
            .ToListAsync();

    public async Task<T> GetAsync(int id, params string[] includes) =>
        await Context.Set<T>()
            .IncludeIf(includes.Any(), includes)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => 
                x.Id == id
                && x.DeletedDate.HasValue == false);

    public async Task<T> UpdateAsync(T model)
    {
        Context.Update(model);
        await Context.SaveChangesAsync();
        return model;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var model = await GetAsync(id);
        if (model == null)
        {
            return false;
        }
        
        model.DeletedDate = DateTime.UtcNow;
        await UpdateAsync(model);
        return true;
    }
}