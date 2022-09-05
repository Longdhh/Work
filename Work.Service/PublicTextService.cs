using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface IPublicTextService
    {
        PublicText Add(PublicText PublicText);

        void Update(PublicText PublicText);

        void Delete(int id);

        IEnumerable<PublicText> GetAll();

        IEnumerable<PublicText> GetAllPaging(int page, int pageSize, out int totalRow);

        PublicText getById(long id);

        void SaveChanges();
    }

    public class PublicTextService : IPublicTextService
    {
        private IPublicTextRepository _PublicTextRepository;
        private IUnitOfWork _unitOfWork;

        public PublicTextService(IPublicTextRepository PublicTextRepository, IUnitOfWork unitOfWork)
        {
            this._PublicTextRepository = PublicTextRepository;
            this._unitOfWork = unitOfWork;
        }

        public PublicText Add(PublicText PublicText)
        {
            return _PublicTextRepository.Add(PublicText);
        }

        public void Delete(int id)
        {
            _PublicTextRepository.Delete(id);
        }

        public IEnumerable<PublicText> GetAll()
        {
            return _PublicTextRepository.GetAll();
        }

        public IEnumerable<PublicText> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _PublicTextRepository.GetMultiPaging(x => x.status, out totalRow, pageSize, page);
        }

        public PublicText getById(long id)
        {
            return _PublicTextRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(PublicText PublicText)
        {
            _PublicTextRepository.Update(PublicText);
        }
    }
}
