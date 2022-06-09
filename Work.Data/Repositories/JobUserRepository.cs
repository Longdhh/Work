using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IJobUserRepository : IRepository<JobUser>
    {
    }

    public class JobUserRepository : RepositoryBase<JobUser>, IJobUserRepository
    {
        public JobUserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}