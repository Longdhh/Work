using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class JobCategoryProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<job_category> getAll()
        {
            try
            {
                return db.job_categories.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
