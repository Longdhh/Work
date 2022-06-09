using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IJobCategoryRepository : IRepository<JobCategory>
    {
    }

    public class JobCategoryRepository : RepositoryBase<JobCategory>, IJobCategoryRepository
    {
        public JobCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}