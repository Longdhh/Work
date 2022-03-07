using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class ProvinceProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<province> getAll()
        {
            try
            {
                return db.provinces.ToList();
            } catch
            {
                return null;
            }
        }
    }
}
