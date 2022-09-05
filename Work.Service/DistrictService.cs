using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface IDistrictService
    {
        District Add(District District);

        void Update(District District);

        District Delete(int id);

        IEnumerable<District> GetAll();

        IEnumerable<District> GetAll(string keyword);

        District getById(long id);

        void SaveChanges();
    }

    public class DistrictService : IDistrictService
    {
        private IDistrictRepository _DistrictRepository;
        private IUnitOfWork _unitOfWork;

        public DistrictService(IDistrictRepository DistrictRepository, IUnitOfWork unitOfWork)
        {
            this._DistrictRepository = DistrictRepository;
            this._unitOfWork = unitOfWork;
        }

        public District Add(District District)
        {
            return _DistrictRepository.Add(District);
        }

        public District Delete(int id)
        {
            return _DistrictRepository.Delete(id);
        }

        public IEnumerable<District> GetAll()
        {
            return _DistrictRepository.GetAll();
        }

        public IEnumerable<District> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _DistrictRepository.GetMulti(x => x.name.Contains(keyword));
            else
                return _DistrictRepository.GetAll();
        }

        public IEnumerable<District> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _DistrictRepository.GetMultiPaging(x => x.status, out totalRow, pageSize, page);
        }

        public District getById(long id)
        {
            return _DistrictRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(District District)
        {
            _DistrictRepository.Update(District);
        }
    }
}
