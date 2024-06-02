using System.Linq.Expressions;

namespace EComm_Store_Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        
        // A list which would be holding all the "DbSet<T>.Include()" operations
        List<Expression<Func<T, object>>> Includes { get; }
    }
}