using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IScaleRepository : IRepository<Scale>
    {
    }

    public class ScaleRepository : RepositoryBase<Scale>, IScaleRepository
    {
        public ScaleRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}
