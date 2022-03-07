using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class JobProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<job> getAll()
        {
            try
            {
                return db.jobs.ToList();
            }
            catch
            {
                return null;
            }
        }
        public job getJobById(long id)
        {
            try
            {
                return db.jobs.FirstOrDefault(j => j.job_id == id);
            }
            catch
            {
                return null;
            }
        }
        public List<job> getJobsByWelfareType(welfare_type welfareType)
        {
            try
            {
                var result = new List<job>();
                foreach (var welfare in db.welfares.ToList())
                {
                    if (welfare.welfare_type_id == welfareType.welfare_type_id)
                    {
                        if(welfare.job_id!=null)
                        {
                            result.Add(getJobById((long)welfare.job_id));
                        }
                    }
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
