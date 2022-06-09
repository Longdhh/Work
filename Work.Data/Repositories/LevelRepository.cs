using System.Collections.Generic;
using System.Linq;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface ILevelRepository : IRepository<Level>
    {
        IEnumerable<Level> getByAlias(string alias);
    }

    public class LevelRepository : RepositoryBase<Level>, ILevelRepository
    {
        public LevelRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public IEnumerable<Level> getByAlias(string alias)
        {
            return this.DbContext.levels.Where(x => x.seo_alias == alias);
        }
    }
}