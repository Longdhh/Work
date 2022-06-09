using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface ITermsOfServiceRepository : IRepository<TermsOfService>
    {
    }

    public class TermsOfServiceRepository : RepositoryBase<TermsOfService>, ITermsOfServiceRepository
    {
        public TermsOfServiceRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}