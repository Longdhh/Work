using System.Collections.Generic;
using System.Linq;
using Work.Data.Infrastructure;
using Work.Model.Models;

namespace Work.Data.Repositories
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        List<Permission> GetByUserId(string userId);
    }

    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<Permission> GetByUserId(string userId)
        {
            var query = from f in DbContext.functions
                        join p in DbContext.permissions on f.ID equals p.FunctionId
                        join r in DbContext.application_roles on p.RoleId equals r.Id
                        join ur in DbContext.user_roles on r.Id equals ur.RoleId
                        join u in DbContext.Users on ur.UserId equals u.Id
                        where u.Id == userId
                        select p;
            return query.ToList();
        }
    }
}