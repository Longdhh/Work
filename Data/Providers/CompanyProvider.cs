using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data.Providers
{
    public class CompanyProvider
    {
        WorkDataContext db = new WorkDataContext();
        public List<company> getAll()
        {
            try
            {
                return db.companies.ToList();
            }
            catch
            {
                return null;
            }
        }
        public company getById(int id)
        {
            try
            {
                return db.companies.FirstOrDefault(c => c.company_id == id);
            }
            catch
            {
                return null;
            }
        }
        public bool checkDupplicateSeoAlias(string seo_alias)
        {
            try
            {
                bool status = false;
                var list_seo_alias = new List<string>();
                foreach (var obj in getAll())
                {
                    if (obj.company_seo_alias_en.ToLower() == seo_alias.ToLower() || obj.company_seo_alias_vn.ToLower() == seo_alias.ToLower())
                    {
                        status = true;
                    }
                }
                return status;
            }
            catch
            {
                return false;
            }
        }

        public List<company> getCompaniesByCountry(country country)
        {
            try
            {
                var result = new List<company>();
                foreach (var company in getAll())
                {
                    if (country.country_id == company.country_id)
                    {
                        result.Add(company);
                    }
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
        public List<company> getCompaniesByProvince(province province)
        {
            try
            {
                var result = new List<company>();
                foreach (var company in getAll())
                {
                    if (province.province_id == company.province_id)
                    {
                        result.Add(company);
                    }
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public List<company> getCompaniesByProvince(district district)
        {
            try
            {
                var result = new List<company>();
                foreach (var company in getAll())
                {
                    if (district.district_id == company.district_id)
                    {
                        result.Add(company);
                    }
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
        public List<company> getCompaniesByProvince(ward ward)
        {
            try
            {
                var result = new List<company>();
                foreach (var company in getAll())
                {
                    if (ward.ward_id == company.ward_id)
                    {
                        result.Add(company);
                    }
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public bool insertCompany(company company)
        {
            try
            {
                if (company.company_seo_title_vn == null || company.company_seo_title_vn == "")
                {
                    company.company_seo_title_vn = company.company_name_vn;
                }
                if (company.company_seo_title_en == null || company.company_seo_title_en == "")
                {
                    company.company_seo_title_en = company.company_name_en;
                }
                if (company.company_seo_alias_vn == null || company.company_seo_alias_vn == "")
                {
                    company.company_seo_alias_vn = ToSeoAlias(company.company_name_vn, 255);
                }
                if (company.company_seo_alias_en == null || company.company_seo_alias_en == "")
                {
                    company.company_seo_alias_en = ToSeoAlias(company.company_name_en, 255);
                }
                if (company.company_seo_description_en == null || company.company_seo_description_en == "")
                {
                    company.company_seo_description_en = company.company_description_en;
                }
                if (company.company_seo_description_vn == null || company.company_seo_description_vn == "")
                {
                    company.company_seo_description_vn = company.company_description_vn;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private string ToSeoAlias(string title, int maxLength)
        {
            var match = Regex.Match(title.ToLower(), "[\\w]+");
            StringBuilder result = new StringBuilder("");
            bool maxLengthHit = false;
            while (match.Success && !maxLengthHit)
            {
                if (result.Length + match.Value.Length <= maxLength)
                {
                    result.Append(match.Value + "-");
                }
                else
                {
                    maxLengthHit = true;
                    // Handle a situation where there is only one word and it is greater than the max length.
                    if (result.Length == 0) result.Append(match.Value.Substring(0, maxLength));
                }
                match = match.NextMatch();
            }
            // Remove trailing '-'
            if (result[result.Length - 1] == '-') result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
}
