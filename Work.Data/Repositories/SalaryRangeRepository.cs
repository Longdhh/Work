using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface ISalaryRangeRepository : IRepository<SalaryRange>
    {
    }

    public class SalaryRangeRepository : RepositoryBase<SalaryRange>, ISalaryRangeRepository
    {
        public SalaryRangeRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}