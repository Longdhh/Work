using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IPublicTextRepository : IRepository<PublicText>
    {
    }

    public class PublicTextRepository : RepositoryBase<PublicText>, IPublicTextRepository
    {
        public PublicTextRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}
