using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IHomeSlideRepository : IRepository<HomeSlide>
    {
    }

    public class HomeSlideRepository : RepositoryBase<HomeSlide>, IHomeSlideRepository
    {
        public HomeSlideRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}