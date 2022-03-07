using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class CategoryProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<category> getAll()
        {
            try
            {
                return db.categories.ToList();
            }
            catch
            {
                return null;
            }
        }
        public category getById(int id)
        {
            try
            {
                return db.categories.FirstOrDefault(c => c.category_id == id);
            }
            catch
            {
                return null;
            }
        }
        public bool checkDupplicateSeoAlias(string seo_alias)
        {
            try
            {
                bool status = false;
                var list_seo_alias = new List<string>();
                foreach (var obj in getAll())
                {
                    if (obj.category_seo_alias_en.ToLower() == seo_alias.ToLower() || obj.category_seo_alias_vn.ToLower() == seo_alias.ToLower())
                    {
                        status = true;
                    }
                }
                return status;
            }
            catch
            {
                return false;
            }
        }
    }
}
