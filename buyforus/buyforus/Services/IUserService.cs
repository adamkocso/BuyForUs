using System.Threading.Tasks;

namespace buyforus.Services
{
    public interface IUserService
    {
        Task LogoutAsync();
    }
}