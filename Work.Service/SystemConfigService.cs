using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface ISystemConfigService
    {
        SystemConfig Add(SystemConfig systemConfig);

        void Update(SystemConfig systemConfig);

        void Delete(int id);

        IEnumerable<SystemConfig> GetAll();

        IEnumerable<SystemConfig> GetAllPaging(int page, int pageSize, out int totalRow);

        SystemConfig getById(long id);

        void SaveChanges();
    }

    public class SystemConfigService : ISystemConfigService
    {
        private ISystemConfigRepository _systemConfigRepository;
        private IUnitOfWork _unitOfWork;

        public SystemConfigService(ISystemConfigRepository systemConfigRepository, IUnitOfWork unitOfWork)
        {
            this._systemConfigRepository = systemConfigRepository;
            this._unitOfWork = unitOfWork;
        }

        public SystemConfig Add(SystemConfig systemConfig)
        {
            return _systemConfigRepository.Add(systemConfig);
        }

        public void Delete(int id)
        {
            _systemConfigRepository.Delete(id);
        }

        public IEnumerable<SystemConfig> GetAll()
        {
            return _systemConfigRepository.GetAll();
        }

        public IEnumerable<SystemConfig> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _systemConfigRepository.GetMultiPaging(x => x.status, out totalRow, pageSize, page);
        }

        public SystemConfig getById(long id)
        {
            return _systemConfigRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(SystemConfig systemConfig)
        {
            _systemConfigRepository.Update(systemConfig);
        }
    }
}