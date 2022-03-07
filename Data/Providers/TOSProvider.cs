using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class TOSProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<term_of_service> getAll()
        {
            try
            {
                return this.db.term_of_services.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
