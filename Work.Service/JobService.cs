using System.Collections.Generic;
using System.Linq;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface IJobService
    {
        Job Add(Job job, List<JobCategory> categories, List<Welfare> welfares);

        void Update(Job job, List<JobCategory> categories, List<Welfare> welfares);

        void UpdateRegistedCount(int id);

        void RegisterJob(JobUser jobUser);
        JobUser UnregisterJob(int id);
        void SendJob(int id);
        void PublicJob(int id);
        void UnpublicJob(int id);
        Job Delete(int id);

        IEnumerable<JobUser> GetAllRegistedByJobId(long jobId);
        IEnumerable<JobUser> GetAllRegistedByUserId(string userId);
        IEnumerable<Job> GetActive();
        IEnumerable<Job> GetAllActiveAndPending(string keyword);
        IEnumerable<Job> GetAllActive(string keyword);

        IEnumerable<Job> GetAllByCompanyId(string companyId);
        IEnumerable<Job> GetAllActiveByCompanyId(string companyId);

        IEnumerable<Job> GetAllByCategoryPaging(long categoryId, int page, int pageSize, out int totalRow);

        IEnumerable<Job> GetAllByWorkingTypePaging(long workingTypeId);

        IEnumerable<Job> GetAllByLevelPaging(long levelId, int page, int pageSize, out int totalRow);

        Job getById(long id);

        List<JobCategory> GetJobCategories(long jobId);

        List<Welfare> GetWelfares(long jobId);

        void SaveChanges();
    }

    public class JobService : IJobService
    {
        private IJobRepository _jobRepository;
        private IJobUserRepository _jobUserRepository;
        private IJobCategoryRepository _jobCategoryRepository;
        private IWelfareRepository _welfareRepository;
        private IUnitOfWork _unitOfWork;

        public JobService(IJobRepository jobRepository, IJobUserRepository jobUserRepository, IJobCategoryRepository jobCategoryRepository, IWelfareRepository welfareRepository, IUnitOfWork unitOfWork)
        {
            this._jobRepository = jobRepository;
            this._jobUserRepository = jobUserRepository;
            this._jobCategoryRepository = jobCategoryRepository;
            this._welfareRepository = welfareRepository;
            this._unitOfWork = unitOfWork;
        }

        public Job Add(Job job, List<JobCategory> categories, List<Welfare> welfares)
        {
            try
            {
                _jobRepository.Add(job);
                foreach (var category in categories)
                {
                    _jobCategoryRepository.Add(category);
                }
                foreach (var welfare in welfares)
                {
                    _welfareRepository.Add(welfare);
                }
                return job;
            }
            catch
            {
                throw;
            }
        }

        public void Update(Job job, List<JobCategory> categories, List<Welfare> welfares)
        {
            try
            {
                _jobRepository.Update(job);
                var listCategories = _jobCategoryRepository.GetMulti(x => x.job_id == job.job_id);
                var listWelfares = _welfareRepository.GetMulti(x => x.job_id == job.job_id);
                foreach (var item in listCategories)
                {
                    _jobCategoryRepository.Delete(item);
                }
                foreach (var category in categories)
                {
                    _jobCategoryRepository.Add(category);
                }
                foreach (var item in listWelfares)
                {
                    _welfareRepository.Delete(item);
                }
                foreach (var welfare in welfares)
                {
                    _welfareRepository.Add(welfare);
                }
            }
            catch
            {
                throw;
            }
        }

        public void RegisterJob(JobUser jobUser)
        {
            _jobUserRepository.Add(jobUser);
        }
        public JobUser UnregisterJob(int id)
        {
            return _jobUserRepository.Delete(id);
        }
        public void SendJob(int id)
        {
            var job = _jobRepository.GetSingleById(id);
            job.status = "Pending";
            _jobRepository.Update(job);
        }
        public void PublicJob(int id)
        {
            var job = _jobRepository.GetSingleById(id);
            job.status = "Active";
            _jobRepository.Update(job);
        }
        public void UnpublicJob(int id)
        {
            var job = _jobRepository.GetSingleById(id);
            job.status = "Inactive";
            _jobRepository.Update(job);
        }
        public void UpdateRegistedCount(int id)
        {
            var job = _jobRepository.GetSingleById(id);
            job.job_registed_user += 1;
            _jobRepository.Update(job);
        }

        public Job Delete(int id)
        {
            try
            {
                var listCategories = _jobCategoryRepository.GetMulti(x => x.job_id == id);
                var listWelfares = _welfareRepository.GetMulti(x => x.job_id == id);
                foreach (var item in listCategories)
                {
                    _jobCategoryRepository.Delete(item);
                }
                foreach (var item in listWelfares)
                {
                    _welfareRepository.Delete(item);
                }
                return _jobRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Job> GetActive()
        {
            return _jobRepository.GetMulti(x => x.status == "Active" && x.job_end_date > System.DateTime.Now);
        }
        public IEnumerable<Job> GetAllActiveAndPending(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _jobRepository.GetMulti(x => (x.name.Contains(keyword) || x.seo_description.Contains(keyword)) && (x.status=="Active" || x.status=="Pending"));

            else
                return _jobRepository.GetMulti(x => (x.status == "Active" || x.status == "Pending"));
        }
        public IEnumerable<Job> GetAllActive(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _jobRepository.GetMulti(x => (x.name.Contains(keyword) || x.seo_description.Contains(keyword)) && x.status == "Active" && x.job_end_date > System.DateTime.Now);

            else
                return _jobRepository.GetMulti(x=> x.status == "Active" && x.job_end_date > System.DateTime.Now);
        }

        public IEnumerable<Job> GetAllByCompanyId(string companyId)
        {
            return _jobRepository.GetMulti(x => x.Id == companyId);
        }
        public IEnumerable<Job> GetAllActiveByCompanyId(string companyId)
        {
            return _jobRepository.GetMulti(x => x.Id == companyId && x.status=="Active" && x.job_end_date > System.DateTime.Now);
        }
        public IEnumerable<Job> GetAllByCategoryPaging(long categoryId, int page, int pageSize, out int totalRow)
        {
            return _jobRepository.GetAllByCategory(categoryId, page, pageSize, out totalRow);
        }

        public IEnumerable<JobUser> GetAllRegistedByJobId(long jobId)
        {
            return _jobUserRepository.GetMulti(x => x.job_id == jobId);
        }
        public IEnumerable<JobUser> GetAllRegistedByUserId(string userId)
        {
            return _jobUserRepository.GetMulti(x => x.Id == userId);
        }
        public IEnumerable<Job> GetAllByWorkingTypePaging(long workingTypeId)
        {
            return _jobRepository.GetMulti(x => x.status == "Active" && x.working_type_id == workingTypeId);
        }

        public IEnumerable<Job> GetAllByLevelPaging(long levelId, int page, int pageSize, out int totalRow)
        {
            var query = _jobRepository.GetMulti(x => x.status == "Active" && x.level_id == levelId);
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public Job getById(long id)
        {
            return _jobRepository.GetSingleById(id);
        }

        public List<JobCategory> GetJobCategories(long jobId)
        {
            return _jobCategoryRepository.GetMulti(x => x.job_id == jobId).ToList();
        }

        public List<Welfare> GetWelfares(long jobId)
        {
            return _welfareRepository.GetMulti(x => x.job_id == jobId).ToList();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}