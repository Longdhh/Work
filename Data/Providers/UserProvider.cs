using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class UserProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<user> getAll()
        {
            try
            {
                return db.users.ToList();
            } catch
            {
                return null;
            }
        }

        public user getById(long id)
        {
            try
            {
                return db.users.FirstOrDefault(u => u.user_id == id);
            }
            catch
            {
                return null;
            }
        }
    }
}
