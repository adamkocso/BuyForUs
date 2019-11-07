using AutoMapper;
using buyforus.Models;
using buyforus.ViewModels;

namespace buyforus.Services.Helpers.AutoMapper.Profiles
{
    public class UserFromOrganizationViewModel : Profile
    {
        public UserFromOrganizationViewModel()
        {
            CreateMap<OrganizationViewModel, User>();
        }
    }
}