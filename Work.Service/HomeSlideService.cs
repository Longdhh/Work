using System.Collections.Generic;
using Work.Data.Infrastructure;
using Work.Data.Repositories;
using Work.Model.Models;

namespace Work.Service
{
    public interface IHomeSlideService
    {
        HomeSlide Add(HomeSlide homeSlide);

        void Update(HomeSlide homeSlide);

        HomeSlide Delete(int id);

        IEnumerable<HomeSlide> GetAll();

        IEnumerable<HomeSlide> GetAll(string keyword);

        HomeSlide getById(long id);

        void SaveChanges();
    }

    public class HomeSlideService : IHomeSlideService
    {
        private IHomeSlideRepository _homeSlideRepository;
        private IUnitOfWork _unitOfWork;

        public HomeSlideService(IHomeSlideRepository homeSlideRepository, IUnitOfWork unitOfWork)
        {
            this._homeSlideRepository = homeSlideRepository;
            this._unitOfWork = unitOfWork;
        }

        public HomeSlide Add(HomeSlide homeSlide)
        {
            return _homeSlideRepository.Add(homeSlide);
        }

        public HomeSlide Delete(int id)
        {
            return _homeSlideRepository.Delete(id);
        }

        public IEnumerable<HomeSlide> GetAll()
        {
            return _homeSlideRepository.GetAll();
        }

        public IEnumerable<HomeSlide> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _homeSlideRepository.GetMulti(x => x.home_slide_name.Contains(keyword));
            else
                return _homeSlideRepository.GetAll();
        }

        public HomeSlide getById(long id)
        {
            return _homeSlideRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(HomeSlide homeSlide)
        {
            _homeSlideRepository.Update(homeSlide);
        }
    }
}