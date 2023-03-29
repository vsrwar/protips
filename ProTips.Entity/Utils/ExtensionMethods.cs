using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ProTips.Entity.Utils;

public static class ExtensionMethods
{
    public static IQueryable<T> IncludeIf<T>(this IQueryable<T> query, bool condition, params Expression<Func<T, Base>>[] includes) where T : class
    {
        if (!condition)
        {
            return query;
        }

        foreach (var includeProperty in includes)
        {
            query = query.Include(includeProperty);
        }

        return query;
    }
    public static IQueryable<T> IncludeIf<T>(this IQueryable<T> query, bool condition, params string[] includes) where T : class
    {
        if (!condition)
        {
            return query;
        }

        foreach (var includeProperty in includes)
        {
            query = query.Include(includeProperty);
        }

        return query;
    }
}