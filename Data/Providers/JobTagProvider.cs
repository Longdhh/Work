using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class JobTagProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<job_tag> getAll()
        {
            try
            {
                return db.job_tags.ToList();
            }
            catch
            {
                return null;
            }
        }
        public bool checkDupplicates(long job_id, long tag_id)
        {
            try
            {
                bool status = false;
                foreach(var obj in db.job_tags.ToList())
                {
                    if(obj.job_id == job_id && obj.tag_id == tag_id)
                    {
                        status = true;
                    }
                }
                return status;
            } catch
            {
                return false;
            }
        }
    }
}
