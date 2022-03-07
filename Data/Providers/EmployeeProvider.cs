using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class EmployeeProvider
    {
        WorkDataContext db = new WorkDataContext();
        public user getById(int id)
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
