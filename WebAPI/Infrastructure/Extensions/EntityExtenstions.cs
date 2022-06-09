using System;
using WebAPI.Models;
using Work.Model.Models;

namespace WebAPI.Infrastructure.Extensions
{
    public static class EntityExtenstions
    {
        public static void UpdateCategory(this Category category, CategoryViewModel categoryViewModel)
        {
            category.category_id = categoryViewModel.category_id;
            category.seo_alias = categoryViewModel.seo_alias;
            category.name = categoryViewModel.name;
            category.seo_title = categoryViewModel.seo_title;
            category.seo_description = categoryViewModel.seo_description;
            category.category_logo = categoryViewModel.category_logo;
            category.created_at = categoryViewModel.created_at;
            category.created_by = categoryViewModel.created_by;
            category.modified_at = categoryViewModel.modified_at;
            category.modified_by = categoryViewModel.modified_by;
            category.status = categoryViewModel.status;
        }

        public static void UpdateProvince(this Province province, ProvinceViewModel provinceViewModel)
        {
            province.province_id = provinceViewModel.province_id;
            province.seo_alias = provinceViewModel.seo_alias;
            province.name = provinceViewModel.name;
            province.seo_title = provinceViewModel.seo_title;
            province.seo_description = provinceViewModel.seo_description;
            province.created_at = provinceViewModel.created_at;
            province.created_by = provinceViewModel.created_by;
            province.modified_at = provinceViewModel.modified_at;
            province.modified_by = provinceViewModel.modified_by;
            province.status = provinceViewModel.status;
        }

        public static void UpdateWorkingType(this WorkingType workingType, WorkingTypeViewModel workingTypeViewModel)
        {
            workingType.working_type_id = workingTypeViewModel.working_type_id;
            workingType.seo_alias = workingTypeViewModel.seo_alias;
            workingType.name = workingTypeViewModel.name;
            workingType.seo_title = workingTypeViewModel.seo_title;
            workingType.seo_description = workingTypeViewModel.seo_description;
            workingType.created_at = workingTypeViewModel.created_at;
            workingType.created_by = workingTypeViewModel.created_by;
            workingType.modified_at = workingTypeViewModel.modified_at;
            workingType.modified_by = workingTypeViewModel.modified_by;
            workingType.status = workingTypeViewModel.status;
        }

        public static void UpdateWelfareType(this WelfareType welfareType, WelfareTypeViewModel welfareTypeViewModel)
        {
            welfareType.welfare_type_id = welfareTypeViewModel.welfare_type_id;
            welfareType.seo_alias = welfareTypeViewModel.seo_alias;
            welfareType.name = welfareTypeViewModel.name;
            welfareType.seo_title = welfareTypeViewModel.seo_title;
            welfareType.seo_description = welfareTypeViewModel.seo_description;
            welfareType.created_at = welfareTypeViewModel.created_at;
            welfareType.created_by = welfareTypeViewModel.created_by;
            welfareType.modified_at = welfareTypeViewModel.modified_at;
            welfareType.modified_by = welfareTypeViewModel.modified_by;
            welfareType.status = welfareTypeViewModel.status;
        }

        public static void UpdateSalaryRange(this SalaryRange salaryRange, SalaryRangeViewModel salaryRangeViewModel)
        {
            salaryRange.salary_range_id = salaryRangeViewModel.salary_range_id;
            salaryRange.seo_alias = salaryRangeViewModel.seo_alias;
            salaryRange.name = salaryRangeViewModel.name;
            salaryRange.seo_title = salaryRangeViewModel.seo_title;
            salaryRange.seo_description = salaryRangeViewModel.seo_description;
            salaryRange.created_at = salaryRangeViewModel.created_at;
            salaryRange.created_by = salaryRangeViewModel.created_by;
            salaryRange.modified_at = salaryRangeViewModel.modified_at;
            salaryRange.modified_by = salaryRangeViewModel.modified_by;
            salaryRange.status = salaryRangeViewModel.status;
        }

        public static void UpdateLevel(this Level level, LevelViewModel levelViewModel)
        {
            level.level_id = levelViewModel.level_id;
            level.seo_alias = levelViewModel.seo_alias;
            level.name = levelViewModel.name;
            level.seo_title = levelViewModel.seo_title;
            level.seo_description = levelViewModel.seo_description;
            level.created_at = levelViewModel.created_at;
            level.created_by = levelViewModel.created_by;
            level.modified_at = levelViewModel.modified_at;
            level.modified_by = levelViewModel.modified_by;
            level.status = levelViewModel.status;
        }

        public static void UpdateHomeSlide(this HomeSlide homeSlide, HomeSlideViewModel homeSlideViewModel)
        {
            homeSlide.home_slide_id = homeSlideViewModel.home_slide_id;
            homeSlide.link = homeSlideViewModel.link;
            homeSlide.home_slide_name = homeSlideViewModel.home_slide_name;
            homeSlide.isShowing = homeSlideViewModel.isShowing;
            homeSlide.home_slide_image = homeSlideViewModel.home_slide_image;
            homeSlide.home_slide_order_by = homeSlideViewModel.home_slide_order_by;
            homeSlide.created_at = homeSlideViewModel.created_at;
            homeSlide.created_by = homeSlideViewModel.created_by;
            homeSlide.modified_at = homeSlideViewModel.modified_at;
            homeSlide.modified_by = homeSlideViewModel.modified_by;
            homeSlide.status = homeSlideViewModel.status;
        }

        public static void UpdateCompany(this Company company, CompanyViewModel companyViewModel)
        {
            company.Id = companyViewModel.Id;
            company.name = companyViewModel.name;
            company.seo_alias = companyViewModel.seo_alias;
            company.fax = companyViewModel.fax;
            company.description = companyViewModel.description;
            company.seo_description = companyViewModel.seo_description;
            company.seo_title = companyViewModel.seo_title;
            company.address = companyViewModel.address;
            company.province_id = companyViewModel.province_id;
            company.avatar = companyViewModel.avatar;
            company.banner = companyViewModel.banner;
            company.created_at = companyViewModel.created_at;
            company.created_by = companyViewModel.created_by;
            company.modified_at = companyViewModel.modified_at;
            company.modified_by = companyViewModel.modified_by;
            company.status = companyViewModel.status;
        }

        public static void UpdateJob(this Job job, JobViewModel jobViewModel)
        {
            job.job_id = jobViewModel.job_id;
            job.seo_alias = jobViewModel.seo_alias;
            job.seo_description = jobViewModel.seo_description;
            job.seo_title = jobViewModel.seo_title;
            job.salary_range_id = jobViewModel.salary_range_id;
            job.name = jobViewModel.name;
            job.Id = jobViewModel.Id;
            job.description = jobViewModel.description;
            job.job_end_date = jobViewModel.job_end_date;
            job.job_view_count = jobViewModel.job_view_count;
            job.job_registed_user = jobViewModel.job_registed_user;
            job.working_type_id = jobViewModel.working_type_id;
            job.level_id = jobViewModel.level_id;
            job.province_id = jobViewModel.province_id;
            job.address = jobViewModel.address;
            job.job_requirement = jobViewModel.job_requirement;
            job.created_at = jobViewModel.created_at;
            job.created_by = jobViewModel.created_by;
            job.modified_at = jobViewModel.modified_at;
            job.modified_by = jobViewModel.modified_by;
            job.status = jobViewModel.status;
        }

        public static void UpdateFunction(this Function function, FunctionViewModel functionVm)
        {
            function.Name = functionVm.Name;
            function.DisplayOrder = functionVm.DisplayOrder;
            function.IconCss = functionVm.IconCss;
            function.Status = functionVm.Status;
            function.ParentId = functionVm.ParentId;
            function.Status = functionVm.Status;
            function.URL = functionVm.URL;
            function.ID = functionVm.ID;
        }

        public static void UpdatePermission(this Permission permission, PermissionViewModel permissionVm)
        {
            permission.RoleId = permissionVm.RoleId;
            permission.FunctionId = permissionVm.FunctionId;
            permission.CanCreate = permissionVm.CanCreate;
            permission.CanDelete = permissionVm.CanDelete;
            permission.CanRead = permissionVm.CanRead;
            permission.CanUpdate = permissionVm.CanUpdate;
        }

        public static void UpdateJobUser(this JobUser jobUser, JobUserViewModel jobUserVm)
        {
            jobUser.job_id = jobUserVm.job_id;
            jobUser.Id = jobUserVm.Id;
            jobUser.name = jobUserVm.name;
            jobUser.phone_number = jobUserVm.name;
            jobUser.email = jobUserVm.email;
            jobUser.resume = jobUserVm.resume;
        }

        public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }

        public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        {
            appUser.Id = appUserViewModel.Id;
            appUser.name = appUserViewModel.name;
            appUser.seo_title = appUserViewModel.seo_title;
            appUser.seo_description = appUserViewModel.seo_description;
            appUser.description = appUserViewModel.description;
            appUser.years_of_experience = appUserViewModel.years_of_experience;
            appUser.province_id = appUserViewModel.province_id;
            appUser.last_company = appUserViewModel.last_company;
            appUser.level_id = appUserViewModel.level_id;
            appUser.birthday = appUserViewModel.birthday;
            appUser.Email = appUserViewModel.Email;
            appUser.address = appUserViewModel.address;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
            appUser.gender = appUserViewModel.gender;
            appUser.status = appUserViewModel.status;
            appUser.avatar = appUserViewModel.avatar;
            appUser.modified_at = appUserViewModel.modified_at;
            appUser.modified_by = appUserViewModel.modified_by;
            appUser.created_at = appUserViewModel.created_at;
            appUser.created_by = appUserViewModel.created_by;
        }
    }
}