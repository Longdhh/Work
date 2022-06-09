using System.Data.Entity;
using System.Linq;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IAnnouncementRepository : IRepository<Announcement>
    {
        IQueryable<Announcement> GetAllUnread(string userId);
    }

    public class AnnouncementRepository : RepositoryBase<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<Announcement> GetAllUnread(string userId)
        {
            var query = (from x in DbContext.announcements
                         join y in DbContext.announcement_users
                         on x.announcement_id equals y.announcement_id
                         into xy
                         from y in xy.DefaultIfEmpty()
                         where (y.has_read == false)
                         && (y.id == null || y.id == userId)
                         select x).Include(x => x.user);
            return query;
        }
    }
}