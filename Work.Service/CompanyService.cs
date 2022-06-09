using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface ICompanyService
    {
        Company Add(Company company);

        void Update(Company company);

        Company Delete(string id);

        IEnumerable<Company> GetAll();

        IEnumerable<Company> GetAll(string keyword);

        Company getById(string id);

        void SaveChanges();
    }

    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;
        private IUnitOfWork _unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            this._companyRepository = companyRepository;
            this._unitOfWork = unitOfWork;
        }

        public Company Add(Company company)
        {
            return _companyRepository.Add(company);
        }

        public Company Delete(string id)
        {
            return _companyRepository.Delete(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return _companyRepository.GetAll();
        }

        public IEnumerable<Company> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _companyRepository.GetMulti(x => x.name.Contains(keyword) || x.seo_description.Contains(keyword));
            else
                return _companyRepository.GetAll();
        }

        public Company getById(string id)
        {
            return _companyRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Company company)
        {
            _companyRepository.Update(company);
        }
    }
}