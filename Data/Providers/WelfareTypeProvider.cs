using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class WelfareTypeProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<welfare_type> getAll()
        {
            try
            {
                return db.welfare_types.ToList();
            }
            catch
            {
                return null;
            }
        }

    }
}
