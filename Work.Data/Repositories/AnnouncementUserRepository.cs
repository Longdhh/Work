using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IAnnouncementUserRepository : IRepository<AnnouncementUser>
    {
    }

    public class AnnouncementUserRepository : RepositoryBase<AnnouncementUser>, IAnnouncementUserRepository
    {
        public AnnouncementUserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}