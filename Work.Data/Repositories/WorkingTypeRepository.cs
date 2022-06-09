using System.Collections.Generic;
using System.Linq;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IWorkingTypeRepository : IRepository<WorkingType>
    {
        IEnumerable<WorkingType> getByAlias(string alias);
    }

    public class WorkingTypeRepository : RepositoryBase<WorkingType>, IWorkingTypeRepository
    {
        public WorkingTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public IEnumerable<WorkingType> getByAlias(string alias)
        {
            return this.DbContext.working_types.Where(x => x.seo_alias == alias);
        }
    }
}