using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class DistrictProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<district> getAll()
        {
            try
            {
                return db.districts.ToList();
            }
            catch
            {
                return null;
            }
        }
        public district getById(int id)
        {
            try
            {
                return db.districts.FirstOrDefault(d => d.district_id == id);
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
                    if (obj.district_seo_alias_en.ToLower() == seo_alias.ToLower() || obj.district_seo_alias_vn.ToLower() == seo_alias.ToLower())
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
