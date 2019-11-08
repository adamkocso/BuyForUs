using AutoMapper;
using buyforus.Models;
using buyforus.ViewModels;

namespace buyforus.Services.Helpers.AutoMapper.Profiles
{
    public class OrganizationViewModelFromUser : Profile
    {
        public OrganizationViewModelFromUser()
        {
            CreateMap<User, OrganizationViewModel>();
        }
    }
}