using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface IWorkingTypeService
    {
        WorkingType Add(WorkingType workingType);

        void Update(WorkingType WorkingType);

        WorkingType Delete(int id);

        IEnumerable<WorkingType> GetAll();

        IEnumerable<WorkingType> GetAll(string keyword);

        WorkingType getById(long id);

        void SaveChanges();
    }

    public class WorkingTypeService : IWorkingTypeService
    {
        private IWorkingTypeRepository _workingTypeRepository;
        private IUnitOfWork _unitOfWork;

        public WorkingTypeService(IWorkingTypeRepository workingTypeRepository, IUnitOfWork unitOfWork)
        {
            this._workingTypeRepository = workingTypeRepository;
            this._unitOfWork = unitOfWork;
        }

        public WorkingType Add(WorkingType WorkingType)
        {
            return _workingTypeRepository.Add(WorkingType);
        }

        public WorkingType Delete(int id)
        {
            return _workingTypeRepository.Delete(id);
        }

        public IEnumerable<WorkingType> GetAll()
        {
            return _workingTypeRepository.GetAll();
        }

        public IEnumerable<WorkingType> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _workingTypeRepository.GetMulti(x => x.name.Contains(keyword) || x.seo_description.Contains(keyword));
            else
                return _workingTypeRepository.GetAll();
        }

        public WorkingType getById(long id)
        {
            return _workingTypeRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(WorkingType workingType)
        {
            _workingTypeRepository.Update(workingType);
        }
    }
}