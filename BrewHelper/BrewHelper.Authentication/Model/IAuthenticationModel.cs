using System.Threading.Tasks;
using BrewHelper.Authentication.DTO;

namespace BrewHelper.Authentication.Model
{
    public interface IAuthenticationModel
    {
        public Task<LoginResponse> LoginAsync(LoginDTO model);
    }
}