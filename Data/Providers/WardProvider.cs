using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class WardProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<ward> getAll()
        {
            try
            {
                return db.wards.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
