using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class HomeSlideProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<home_slide> getAll()
        {
            try
            {
                return db.home_slides.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
