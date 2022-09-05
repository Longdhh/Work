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
    public interface IAddressService
    {
        Address Add(Address Address);

        void Update(Address Address);

        Address Delete(long id);

        IEnumerable<Address> GetAll();

        IEnumerable<Address> GetAll(string keyword);
        IEnumerable<Address> GetAllByCompanyId(string company_id);

        Address getById(long id);

        void SaveChanges();
    }
    public class AddressService : IAddressService
    {
        private IAddressRepository _AddressRepository;
        private IUnitOfWork _unitOfWork;

        public AddressService(IAddressRepository AddressRepository, IUnitOfWork unitOfWork)
        {
            this._AddressRepository = AddressRepository;
            this._unitOfWork = unitOfWork;
        }

        public Address Add(Address Blog)
        {
            return _AddressRepository.Add(Blog);
        }

        public Address Delete(long id)
        {
            return _AddressRepository.Delete(id);
        }

        public IEnumerable<Address> GetAll()
        {
            return _AddressRepository.GetAll();
        }

        public IEnumerable<Address> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _AddressRepository.GetMulti(x => x.name.Contains(keyword));
            else
                return _AddressRepository.GetAll();
        }
        public IEnumerable<Address> GetAllActive(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _AddressRepository.GetMulti(x => (x.name.Contains(keyword) && x.status == true));
            else
                return _AddressRepository.GetMulti(x => x.status == true);
        }
        public IEnumerable<Address> GetAllByCompanyId(string company_id)
        {
            return _AddressRepository.GetMulti(x => (x.company_id == company_id) && x.status == true);
        }
        public Address getById(long id)
        {
            return _AddressRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Address Address)
        {
            _AddressRepository.Update(Address);
        }
    }
}
