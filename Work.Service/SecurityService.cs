using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface ISecurityService
    {
        Security Add(Security Security);

        void Update(Security Security);

        void Delete(int id);

        IEnumerable<Security> GetAll();

        IEnumerable<Security> GetAllPaging(int page, int pageSize, out int totalRow);

        Security getById(long id);

        void SaveChanges();
    }

    public class SecurityService : ISecurityService
    {
        private ISecurityRepository _SecurityRepository;
        private IUnitOfWork _unitOfWork;

        public SecurityService(ISecurityRepository SecurityRepository, IUnitOfWork unitOfWork)
        {
            this._SecurityRepository = SecurityRepository;
            this._unitOfWork = unitOfWork;
        }

        public Security Add(Security Security)
        {
            return _SecurityRepository.Add(Security);
        }

        public void Delete(int id)
        {
            _SecurityRepository.Delete(id);
        }

        public IEnumerable<Security> GetAll()
        {
            return _SecurityRepository.GetAll();
        }

        public IEnumerable<Security> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _SecurityRepository.GetMultiPaging(x => x.status, out totalRow, pageSize, page);
        }

        public Security getById(long id)
        {
            return _SecurityRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Security Security)
        {
            _SecurityRepository.Update(Security);
        }
    }
}