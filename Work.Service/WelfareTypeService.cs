using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface IWelfareTypeService
    {
        WelfareType Add(WelfareType welfareType);

        void Update(WelfareType welfareType);

        WelfareType Delete(int id);

        IEnumerable<WelfareType> GetAll();

        IEnumerable<WelfareType> GetAll(string keyword);

        WelfareType getById(long id);

        void SaveChanges();
    }

    public class WelfareTypeService : IWelfareTypeService
    {
        private IWelfareTypeRepository _welfareTypeRepository;
        private IUnitOfWork _unitOfWork;

        public WelfareTypeService(IWelfareTypeRepository welfareTypeRepository, IUnitOfWork unitOfWork)
        {
            this._welfareTypeRepository = welfareTypeRepository;
            this._unitOfWork = unitOfWork;
        }

        public WelfareType Add(WelfareType welfareType)
        {
            return _welfareTypeRepository.Add(welfareType);
        }

        public WelfareType Delete(int id)
        {
            return _welfareTypeRepository.Delete(id);
        }

        public IEnumerable<WelfareType> GetAll()
        {
            return _welfareTypeRepository.GetAll();
        }

        public IEnumerable<WelfareType> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _welfareTypeRepository.GetMulti(x => x.name.Contains(keyword) || x.seo_description.Contains(keyword));
            else
                return _welfareTypeRepository.GetAll();
        }

        public WelfareType getById(long id)
        {
            return _welfareTypeRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(WelfareType welfareType)
        {
            _welfareTypeRepository.Update(welfareType);
        }
    }
}