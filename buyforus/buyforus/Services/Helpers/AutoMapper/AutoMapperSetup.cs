using AutoMapper;
using buyforus.Services.Helpers.AutoMapper.Profiles;
using buyforus.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace buyforus.Services.Helpers.AutoMapper
{
    public static class AutoMapperSetup
    {
        public static void SetUpAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserFromOrganizationViewModel());
                cfg.AddProfile(new OrganizationViewModelFromUser());
                
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}