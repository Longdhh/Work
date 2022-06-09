using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface ILevelService
    {
        Level Add(Level level);

        void Update(Level level);

        Level Delete(int id);

        IEnumerable<Level> GetAll();

        IEnumerable<Level> GetAll(string keyword);

        Level getById(long id);

        void SaveChanges();
    }

    public class LevelService : ILevelService
    {
        private ILevelRepository _levelRepository;
        private IUnitOfWork _unitOfWork;

        public LevelService(ILevelRepository levelRepository, IUnitOfWork unitOfWork)
        {
            this._levelRepository = levelRepository;
            this._unitOfWork = unitOfWork;
        }

        public Level Add(Level level)
        {
            return _levelRepository.Add(level);
        }

        public Level Delete(int id)
        {
            return _levelRepository.Delete(id);
        }

        public IEnumerable<Level> GetAll()
        {
            return _levelRepository.GetAll();
        }

        public IEnumerable<Level> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _levelRepository.GetMulti(x => x.name.Contains(keyword) || x.seo_description.Contains(keyword));
            else
                return _levelRepository.GetAll();
        }

        public Level getById(long id)
        {
            return _levelRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Level level)
        {
            _levelRepository.Update(level);
        }
    }
}