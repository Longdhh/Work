using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface IErrorService
    {
        Error Create(Error error);

        void SaveChanges();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRepository _ErrorRepository;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository ErrorRepository, IUnitOfWork unitOfWork)
        {
            this._ErrorRepository = ErrorRepository;
            this._unitOfWork = unitOfWork;
        }

        public Error Create(Error error)
        {
            return _ErrorRepository.Add(error);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}