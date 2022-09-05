using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IBlogCategoryRepository : IRepository<BlogCategory>
    {
    }

    public class BlogCategoryRepository : RepositoryBase<BlogCategory>, IBlogCategoryRepository
    {
        public BlogCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

    }
}
