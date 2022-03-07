using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class CountryProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<country> getAll()
        {
            try
            {
                return db.countries.ToList();
            }
            catch
            {
                return null;
            }
        }

        public country getById(int id)
        {
            try
            {
                return db.countries.FirstOrDefault(c => c.country_id == id);
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
                    if (obj.country_seo_alias_vn.ToLower() == seo_alias.ToLower() || obj.country_seo_alias_en.ToLower() == seo_alias.ToLower())
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
