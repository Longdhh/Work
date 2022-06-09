using System.Collections.Generic;
using System.Linq;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> getByAlias(string alias);
    }

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public IEnumerable<Category> getByAlias(string alias)
        {
            return this.DbContext.categories.Where(x => x.seo_alias == alias);
        }

        public IEnumerable<Category> GetAllByJobId(long jobId, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from c in DbContext.categories
                        join jc in DbContext.job_categories
                        on c.category_id equals jc.category_id
                        where jc.job_id == jobId
                        select c;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}