using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class LanguageProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<language> getAll()
        {
            try
            {
                return db.languages.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
