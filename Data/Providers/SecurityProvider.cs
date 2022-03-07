using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class SecurityProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<security> getAll()
        {
            try
            {
                return this.db.securities.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
