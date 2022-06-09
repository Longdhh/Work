using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface ICategoryService
    {
        Category Add(Category category);

        void Update(Category category);

        Category Delete(int id);

        IEnumerable<Category> GetAll();

        IEnumerable<Category> GetAll(string keyword);

        Category getById(long id);

        void SaveChanges();
    }

    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public Category Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public Category Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _categoryRepository.GetMulti(x => x.name.Contains(keyword) || x.seo_description.Contains(keyword));
            else
                return _categoryRepository.GetAll();
        }

        public Category getById(long id)
        {
            return _categoryRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}