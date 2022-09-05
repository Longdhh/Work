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
    public interface IBlogCategoryService
    {
        BlogCategory Add(BlogCategory blogCategory);

        void Update(BlogCategory blogCategory);

        BlogCategory Delete(long id);

        IEnumerable<BlogCategory> GetAll();

        IEnumerable<BlogCategory> GetAll(string keyword);

        BlogCategory getById(long id);

        void SaveChanges();
    }
    public class BlogCategoryService : IBlogCategoryService
    {
        private IBlogCategoryRepository _blogCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._blogCategoryRepository = blogCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public BlogCategory Add(BlogCategory Blog)
        {
            return _blogCategoryRepository.Add(Blog);
        }

        public BlogCategory Delete(long id)
        {
            return _blogCategoryRepository.Delete(id);
        }

        public IEnumerable<BlogCategory> GetAll()
        {
            return _blogCategoryRepository.GetAll();
        }

        public IEnumerable<BlogCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _blogCategoryRepository.GetMulti(x => x.name.Contains(keyword) || x.seo_description.Contains(keyword));
            else
                return _blogCategoryRepository.GetAll();
        }
        public IEnumerable<BlogCategory> GetAllActive(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _blogCategoryRepository.GetMulti(x => (x.name.Contains(keyword) || x.seo_description.Contains(keyword)) && x.status == true);
            else
                return _blogCategoryRepository.GetMulti(x => x.status == true);
        }
        public IEnumerable<BlogCategory> GetAllByBlogCategoryId(long id)
        {
            return _blogCategoryRepository.GetMulti(x => (x.blog_category_id == id) && x.status == true);
        }
        public BlogCategory getById(long id)
        {
            return _blogCategoryRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(BlogCategory blogCategory)
        {
            _blogCategoryRepository.Update(blogCategory);
        }
    }
}
