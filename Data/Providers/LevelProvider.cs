using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class LevelProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<level> getAll()
        {
            try
            {
                return db.levels.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
