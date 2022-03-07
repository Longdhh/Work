using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class TagProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<tag> getAll()
        {
            try
            {
                return db.tags.ToList();
            } catch
            {
                return null;
            }
        }
    }
}
