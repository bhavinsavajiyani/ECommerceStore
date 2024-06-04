using System.Linq.Expressions;

namespace EComm_Store_Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        
        // A list which would be holding all the "DbSet<T>.Include()" operations
        List<Expression<Func<T, object>>> Includes { get; }

        // Sort objects
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }

        int TakeRecords { get; }
        int SkipRecords { get; }
        bool IsPagingEnabled { get; }
    }
}