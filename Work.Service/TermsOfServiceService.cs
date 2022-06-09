using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface ITermsOfServiceService
    {
        TermsOfService Add(TermsOfService TermsOfService);

        void Update(TermsOfService TermsOfService);

        void Delete(int id);

        IEnumerable<TermsOfService> GetAll();

        IEnumerable<TermsOfService> GetAllPaging(int page, int pageSize, out int totalRow);

        TermsOfService getById(long id);

        void SaveChanges();
    }

    public class TermsOfServiceService : ITermsOfServiceService
    {
        private ITermsOfServiceRepository _termsOfServiceRepository;
        private IUnitOfWork _unitOfWork;

        public TermsOfServiceService(ITermsOfServiceRepository termsOfServiceRepository, IUnitOfWork unitOfWork)
        {
            this._termsOfServiceRepository = termsOfServiceRepository;
            this._unitOfWork = unitOfWork;
        }

        public TermsOfService Add(TermsOfService TermsOfService)
        {
            return _termsOfServiceRepository.Add(TermsOfService);
        }

        public void Delete(int id)
        {
            _termsOfServiceRepository.Delete(id);
        }

        public IEnumerable<TermsOfService> GetAll()
        {
            return _termsOfServiceRepository.GetAll();
        }

        public IEnumerable<TermsOfService> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _termsOfServiceRepository.GetMultiPaging(x => x.status, out totalRow, pageSize, page);
        }

        public TermsOfService getById(long id)
        {
            return _termsOfServiceRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(TermsOfService termsOfService)
        {
            _termsOfServiceRepository.Update(termsOfService);
        }
    }
}