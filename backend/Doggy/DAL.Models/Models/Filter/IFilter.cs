using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models.Models.Filter
{
    public interface IFilter<T>
         where T : class
    {
        IQueryable<T> Filter(DbSet<T> entities);
    }
}
