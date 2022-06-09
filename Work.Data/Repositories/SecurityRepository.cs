using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface ISecurityRepository : IRepository<Security>
    {
    }

    public class SecurityRepository : RepositoryBase<Security>, ISecurityRepository
    {
        public SecurityRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}