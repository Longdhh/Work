using AutoMapper;
using WebAPI.Models;
using Work.Model.Models;

namespace WebAPI.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<HomeSlide, HomeSlideViewModel>();
                cfg.CreateMap<JobCategory, JobCategoryViewModel>();
                cfg.CreateMap<Welfare, WelfareViewModel>();
                cfg.CreateMap<Job, JobViewModel>();
                cfg.CreateMap<ApplicationRole, ApplicationRoleViewModel>();
                cfg.CreateMap<Level, LevelViewModel>();
                cfg.CreateMap<Province, ProvinceViewModel>();
                cfg.CreateMap<Security, SecurityViewModel>();
                cfg.CreateMap<ApplicationUser, ApplicationUserViewModel>();
                cfg.CreateMap<TermsOfService, TermsOfServiceViewModel>();
                cfg.CreateMap<WelfareType, WelfareTypeViewModel>();
                cfg.CreateMap<WorkingType, WorkingTypeViewModel>();
                cfg.CreateMap<SalaryRange, SalaryRangeViewModel>();
                cfg.CreateMap<Announcement, AnnouncementViewModel>();
                cfg.CreateMap<AnnouncementUser, AnnouncementUserViewModel>();
            });
        }
    }
}