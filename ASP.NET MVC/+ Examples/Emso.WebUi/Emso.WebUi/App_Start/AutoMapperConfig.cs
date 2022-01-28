using System;
using System.Linq;
using AutoMapper;
using Emso.WebUi.Models;
using Emso.WebUi.Utils;
using Emso.WebUi.ViewModels;
using EmsoHr.Entities;

namespace Emso.WebUi
{
   /// <summary>
   ///    Auto mapper configuration
   /// </summary>
   public static class AutoMapperConfig
   {
      public static void ConfigureViewModelMapping()
      {
         Mapper.Initialize(Config);
      }

      private static void Config(IMapperConfigurationExpression expression)
      {
         #region CompanyProduct => CompanyProductViewModel

         expression.CreateMap<CompanyProduct, CompanyProductViewModel>()
            .ForMember(productVm => productVm.Title,
               configExpr => configExpr.MapFrom(model => model.Title))
            .ForMember(productVm => productVm.Description,
               configExpr => configExpr.MapFrom(product => product.Description))
            .ForMember(productVm => productVm.ImagePath,
               configExpr => configExpr.MapFrom(product => product.ImagePath));

         #endregion

         #region RssFeed => RssFeedViewModel

         expression.CreateMap<NewsFeed, RssFeedViewModel>()
            .ForMember(rssFeedVm => rssFeedVm.FeedId,
               configExpr => configExpr.MapFrom(newsFeed => newsFeed.Id))
            .ForMember(rssFeedVm => rssFeedVm.Title,
               configExpr => configExpr.MapFrom(newsFeed => newsFeed.Title))
            .ForMember(rssFeedVm => rssFeedVm.Details,
               configExpr => configExpr.MapFrom(newsFeed => newsFeed.Details))
            .ForMember(rssFeedVm => rssFeedVm.RelatedLink,
               configExpr => configExpr.MapFrom(newsFeed => newsFeed.RelatedLink))
            .ForMember(rssFeedVm => rssFeedVm.HasImageData,
               configExpr => configExpr.MapFrom(newsFeed => newsFeed.ImageData != null))
            .ForMember(rssFeedVm => rssFeedVm.NewsDate,
               configExpr => configExpr.MapFrom(newsFeed => newsFeed.NewsDate))
            .ForMember(rssFeedVm => rssFeedVm.ImageMimeType,
               configExpr => configExpr.MapFrom(newsFeed => newsFeed.ImageMimeType));

         #endregion

         #region RssFeedViewModel => RssFeed

         expression.CreateMap<RssFeedViewModel, NewsFeed>()
            .ForMember(newsFeed => newsFeed.Id,
               configExpr => configExpr.MapFrom(rssFeedVm => rssFeedVm.FeedId))
            .ForMember(newsFeed => newsFeed.Title,
               configExpr => configExpr.MapFrom(rssFeedVm => rssFeedVm.Title))
            .ForMember(newsFeed => newsFeed.Details,
               configExpr => configExpr.MapFrom(rssFeedVm => rssFeedVm.Details))
            .ForMember(newsFeed => newsFeed.RelatedLink,
               configExpr => configExpr.MapFrom(rssFeedVm => rssFeedVm.RelatedLink))
            .ForMember(newsFeed => newsFeed.NewsDate,
               configExpr => configExpr.MapFrom(rssFeedVm => rssFeedVm.NewsDate))
            .ForMember(newsFeed => newsFeed.ImageMimeType,
               configExpr => configExpr.MapFrom(rssFeedVm => rssFeedVm.ImageMimeType))
            .ForMember(newsFeed => newsFeed.ImageData,
               configExpr => configExpr.MapFrom(rssFeedVm => new byte[0]));

         #endregion

         #region SlideItem => SlideItemViewModel

         expression.CreateMap<SlideItem, SlideItemViewModel>()
            .ForMember(slideItemVm => slideItemVm.Title,
               configExpr => configExpr.MapFrom(model => model.Title))
            .ForMember(slideItemVm => slideItemVm.ImagePath,
               configExpr => configExpr.MapFrom(product => product.ImagePath));

         #endregion

         #region JobVacancy => JobVacancyViewModel

         expression.CreateMap<JobVacancy, JobVacancyViewModel>()
            .ForMember(jobVm => jobVm.Id,
               configExpr => configExpr.MapFrom(vacancy => vacancy.JobId))
            .ForMember(jobVm => jobVm.Title,
               configExpr => configExpr.MapFrom(vacancy => vacancy.JobTitle))
            .ForMember(jobVm => jobVm.City,
               configExpr => configExpr.MapFrom(vacancy => vacancy.LocationCity))
            .ForMember(jobVm => jobVm.SalaryLevel,
               configExpr => configExpr.MapFrom(vacancy => vacancy.SalaryLevel))
            .ForMember(jobVm => jobVm.WorkExperience,
               configExpr => configExpr.MapFrom(vacancy => ConvertEmploymentType(vacancy)))
            .ForMember(jobVm => jobVm.EmploymentType,
               configExpr => configExpr.MapFrom(vacancy => ConvertJobVacancy(vacancy)))
            .ForMember(jobVm => jobVm.IsActive,
               configExpr => configExpr.MapFrom(vacancy => vacancy.IsActive))
            .ForMember(jobVm => jobVm.Responsibilities,
               configExpr =>
                  configExpr.MapFrom(
                     vacancy =>
                        vacancy.JobVacancyMainResponsibilities.Select(
                           responsibility => responsibility.ResponsibilityItem).ToList()))
            .ForMember(jobVm => jobVm.Misc,
               configExpr =>
                  configExpr.MapFrom(vacancy => vacancy.JobVacancyMiscs.Select(misc => misc.MiscItem).ToList()))
            .ForMember(jobVm => jobVm.Requirements,
               configExpr =>
                  configExpr.MapFrom(
                     vacancy =>
                        vacancy.JobVacancyRequirements.Select(requirement => requirement.RequirementItem).ToList()))
            .ForMember(jobVm => jobVm.RestRequirements,
               configExpr =>
                  configExpr.MapFrom(
                     vacancy =>
                        vacancy.JobVacancyRestRequirements.Select(requirement => requirement.MiscRequirement).ToList()))
            .ForMember(jobVm => jobVm.WorkingConditions,
               configExpr =>
                  configExpr.MapFrom(
                     vacancy =>
                        vacancy.JobVacancyWorkingConditions.Select(condition => condition.ConditionItem).ToList()));

         #endregion

         #region JobVacancyViewModel => JobVacancy

         expression.CreateMap<JobVacancyViewModel, JobVacancy>()
            .ForMember(vacancy => vacancy.JobId,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.Id))
            .ForMember(vacancy => vacancy.JobTitle,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.Title))
            .ForMember(vacancy => vacancy.LocationCity,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.City))
            .ForMember(vacancy => vacancy.SalaryLevel,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.SalaryLevel))
            .ForMember(vacancy => vacancy.WorkExperience,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.WorkExperience.ToString()))
            .ForMember(vacancy => vacancy.EmploymentType,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.EmploymentType.ToString()))
            .ForMember(vacancy => vacancy.IsActive,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.IsActive))
            .ForMember(vacancy => vacancy.JobVacancyMainResponsibilities,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.ToResponsibilities()))
            .ForMember(vacancy => vacancy.JobVacancyMiscs,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.ToMisc()))
            .ForMember(vacancy => vacancy.JobVacancyRequirements,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.ToRequirements()))
            .ForMember(vacancy => vacancy.JobVacancyRestRequirements,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.ToRestRequirements()))
            .ForMember(vacancy => vacancy.JobVacancyWorkingConditions,
               configExpr => configExpr.MapFrom(vacancyVm => vacancyVm.ToWorkingConditions()));

         #endregion
      }

      private static Experience ConvertEmploymentType(JobVacancy vacancy)
      {
         Experience experience;
         return Enum.TryParse(vacancy.WorkExperience, true, out experience)
            ? experience
            : default(Experience);
      }

      private static EmploymentType ConvertJobVacancy(JobVacancy vacancy)
      {
         EmploymentType employmentType;
         return Enum.TryParse(vacancy.EmploymentType, true, out employmentType)
            ? employmentType
            : default(EmploymentType);
      }      
   }
}