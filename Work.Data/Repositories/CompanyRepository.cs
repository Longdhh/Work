using System.Collections.Generic;
using System.Linq;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<Company> getByAlias(string alias);
    }

    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public IEnumerable<Company> getByAlias(string alias)
        {
            return this.DbContext.companies.Where(x => x.seo_alias == alias);
        }
    }
}