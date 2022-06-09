using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface ISalaryRangeService
    {
        SalaryRange Add(SalaryRange salaryRange);

        void Update(SalaryRange salaryRange);

        SalaryRange Delete(int id);

        IEnumerable<SalaryRange> GetAll();

        IEnumerable<SalaryRange> GetAll(string keyword);

        SalaryRange getById(long id);

        void SaveChanges();
    }

    public class SalaryRangeService : ISalaryRangeService
    {
        private ISalaryRangeRepository _salaryRangeRepository;
        private IUnitOfWork _unitOfWork;

        public SalaryRangeService(ISalaryRangeRepository salaryRangeRepository, IUnitOfWork unitOfWork)
        {
            this._salaryRangeRepository = salaryRangeRepository;
            this._unitOfWork = unitOfWork;
        }

        public SalaryRange Add(SalaryRange salaryRange)
        {
            return _salaryRangeRepository.Add(salaryRange);
        }

        public SalaryRange Delete(int id)
        {
            return _salaryRangeRepository.Delete(id);
        }

        public IEnumerable<SalaryRange> GetAll()
        {
            return _salaryRangeRepository.GetAll();
        }

        public IEnumerable<SalaryRange> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _salaryRangeRepository.GetMulti(x => x.name.Contains(keyword) || x.seo_description.Contains(keyword));
            else
                return _salaryRangeRepository.GetAll();
        }

        public SalaryRange getById(long id)
        {
            return _salaryRangeRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(SalaryRange SalaryRange)
        {
            _salaryRangeRepository.Update(SalaryRange);
        }
    }
}