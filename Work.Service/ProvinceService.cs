using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface IProvinceService
    {
        Province Add(Province province);

        void Update(Province province);

        Province Delete(int id);

        IEnumerable<Province> GetAll();

        IEnumerable<Province> GetAll(string keyword);

        Province getById(long id);

        void SaveChanges();
    }

    public class ProvinceService : IProvinceService
    {
        private IProvinceRepository _provinceRepository;
        private IUnitOfWork _unitOfWork;

        public ProvinceService(IProvinceRepository provinceRepository, IUnitOfWork unitOfWork)
        {
            this._provinceRepository = provinceRepository;
            this._unitOfWork = unitOfWork;
        }

        public Province Add(Province province)
        {
            return _provinceRepository.Add(province);
        }

        public Province Delete(int id)
        {
            return _provinceRepository.Delete(id);
        }

        public IEnumerable<Province> GetAll()
        {
            return _provinceRepository.GetAll();
        }

        public IEnumerable<Province> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _provinceRepository.GetMulti(x => x.name.Contains(keyword) || x.seo_description.Contains(keyword));
            else
                return _provinceRepository.GetAll();
        }

        public IEnumerable<Province> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _provinceRepository.GetMultiPaging(x => x.status, out totalRow, pageSize, page);
        }

        public Province getById(long id)
        {
            return _provinceRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Province province)
        {
            _provinceRepository.Update(province);
        }
    }
}