using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IWelfareRepository : IRepository<Welfare>
    {
    }

    public class WelfareRepository : RepositoryBase<Welfare>, IWelfareRepository
    {
        public WelfareRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}