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
    public interface ICountryService
    {
        Country Add(Country Country);

        void Update(Country Country);

        Country Delete(int id);

        IEnumerable<Country> GetAll();

        IEnumerable<Country> GetAll(string keyword);

        Country getById(long id);

        void SaveChanges();
    }

    public class CountryService : ICountryService
    {
        private ICountryRepository _CountryRepository;
        private IUnitOfWork _unitOfWork;

        public CountryService(ICountryRepository CountryRepository, IUnitOfWork unitOfWork)
        {
            this._CountryRepository = CountryRepository;
            this._unitOfWork = unitOfWork;
        }

        public Country Add(Country Country)
        {
            return _CountryRepository.Add(Country);
        }

        public Country Delete(int id)
        {
            return _CountryRepository.Delete(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return _CountryRepository.GetAll();
        }

        public IEnumerable<Country> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _CountryRepository.GetMulti(x => x.name.Contains(keyword));
            else
                return _CountryRepository.GetAll();
        }

        public IEnumerable<Country> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _CountryRepository.GetMultiPaging(x => x.status, out totalRow, pageSize, page);
        }

        public Country getById(long id)
        {
            return _CountryRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Country Country)
        {
            _CountryRepository.Update(Country);
        }
    }
}
