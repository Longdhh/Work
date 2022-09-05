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
    public interface IBlogService
    {
        Blog Add(Blog Blog);

        void Update(Blog blog);

        Blog Delete(long id);

        IEnumerable<Blog> GetAll();
        IEnumerable<Blog> GetAll(string keyword);
        IEnumerable<Blog> GetAllActive(string keyword);
        IEnumerable<Blog> GetAllByCategoryId(long id);
        void ChangeStatus(int id);
        Blog getById(long id);

        void SaveChanges();
    }

    public class BlogService : IBlogService
    {
        private IBlogRepository _blogRepository;
        private IUnitOfWork _unitOfWork;

        public BlogService(IBlogRepository blogRepository, IUnitOfWork unitOfWork)
        {
            this._blogRepository = blogRepository;
            this._unitOfWork = unitOfWork;
        }

        public Blog Add(Blog Blog)
        {
            return _blogRepository.Add(Blog);
        }

        public Blog Delete(long id)
        {
            return _blogRepository.Delete(id);
        }

        public IEnumerable<Blog> GetAll()
        {
            return _blogRepository.GetAll();
        }

        public IEnumerable<Blog> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _blogRepository.GetMulti(x => x.name.Contains(keyword) || x.seo_description.Contains(keyword));
            else
                return _blogRepository.GetAll();
        }
        public IEnumerable<Blog> GetAllActive(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _blogRepository.GetMulti(x => (x.name.Contains(keyword) || x.seo_description.Contains(keyword)) && x.status == true);
            else
                return _blogRepository.GetMulti(x => x.status == true);
        }
        public IEnumerable<Blog> GetAllByCategoryId(long id)
        {
            return _blogRepository.GetMulti(x => (x.blog_category_id == id) && x.status == false);
        }
        public Blog getById(long id)
        {
            return _blogRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
        public void ChangeStatus(int id)
        {
            var job = _blogRepository.GetSingleById(id);
            job.status = !job.status;
            _blogRepository.Update(job);
        }
        public void Update(Blog blog)
        {
            _blogRepository.Update(blog);
        }
    }
}
