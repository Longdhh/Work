using System.Collections.Generic;
using System.Linq;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IFunctionRepository : IRepository<Function>
    {
        List<Function> GetListFunctionWithPermission(string userId);
    }

    public class FunctionRepository : RepositoryBase<Function>, IFunctionRepository
    {
        public FunctionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// Get list permission follow by permission
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Function> GetListFunctionWithPermission(string userId)
        {
            var query = (from f in DbContext.functions
                         join p in DbContext.permissions on f.ID equals p.FunctionId
                         join r in DbContext.application_roles on p.RoleId equals r.Id
                         join ur in DbContext.user_roles on r.Id equals ur.RoleId
                         join u in DbContext.Users on ur.UserId equals u.Id
                         where u.Id == userId && (p.CanRead == true)
                         select f);
            var parentIds = query.Select(x => x.ParentId).Distinct();
            query = query.Union(DbContext.functions.Where(f => parentIds.Contains(f.ID)));

            return query.ToList();
        }
    }
}