using System.Collections.Generic;
using System.Linq;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IJobRepository : IRepository<Job>
    {
        IEnumerable<Job> getByAlias(string alias);

        IEnumerable<Job> GetAllByCategory(long categoryId, int pageIndex, int pageSize, out int totalRow);
    }

    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        public JobRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public IEnumerable<Job> getByAlias(string alias)
        {
            return this.DbContext.jobs.Where(x => x.seo_alias == alias);
        }

        public IEnumerable<Job> GetAllByCategory(long categoryId, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from j in DbContext.jobs
                        join jc in DbContext.job_categories
                        on j.job_id equals jc.job_id
                        where jc.category_id == categoryId
                        select j;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}