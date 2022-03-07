using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class WelfareProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<welfare> getByJobId(long job_id)
        {
            try
            {
                var result = new List<welfare>();
                foreach(var welfare in db.welfares.ToList())
                {
                    if(welfare.job_id == job_id)
                    {
                        result.Add(welfare);
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
