using System.Collections.Generic;
using System.Linq;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IWelfareTypeRepository : IRepository<WelfareType>
    {
        IEnumerable<WelfareType> getByAlias(string alias);
    }

    public class WelfareTypeRepository : RepositoryBase<WelfareType>, IWelfareTypeRepository
    {
        public WelfareTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public IEnumerable<WelfareType> getByAlias(string alias)
        {
            return this.DbContext.welfare_types.Where(x => x.seo_alias == alias);
        }
    }
}