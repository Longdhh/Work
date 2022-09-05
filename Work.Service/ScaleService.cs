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
    public interface IScaleService
    {
        Scale Add(Scale Scale);

        void Update(Scale Scale);

        Scale Delete(int id);

        IEnumerable<Scale> GetAll();

        IEnumerable<Scale> GetAll(string keyword);

        Scale getById(long id);

        void SaveChanges();
    }

    public class ScaleService : IScaleService
    {
        private IScaleRepository _ScaleRepository;
        private IUnitOfWork _unitOfWork;

        public ScaleService(IScaleRepository ScaleRepository, IUnitOfWork unitOfWork)
        {
            this._ScaleRepository = ScaleRepository;
            this._unitOfWork = unitOfWork;
        }

        public Scale Add(Scale Scale)
        {
            return _ScaleRepository.Add(Scale);
        }

        public Scale Delete(int id)
        {
            return _ScaleRepository.Delete(id);
        }

        public IEnumerable<Scale> GetAll()
        {
            return _ScaleRepository.GetAll();
        }

        public IEnumerable<Scale> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _ScaleRepository.GetMulti(x => x.name.Contains(keyword));
            else
                return _ScaleRepository.GetAll();
        }

        public IEnumerable<Scale> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _ScaleRepository.GetMultiPaging(x => x.status, out totalRow, pageSize, page);
        }

        public Scale getById(long id)
        {
            return _ScaleRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Scale Scale)
        {
            _ScaleRepository.Update(Scale);
        }
    }
}
