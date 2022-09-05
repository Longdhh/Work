using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
    }

    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

    }
}
