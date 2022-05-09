namespace BrewHelper.Authentication.Model
{
    using System.Threading.Tasks;
    using BrewHelper.Authentication.DTO;

    public interface IAuthenticationModel
    {
        public Task<LoginResponse> LoginAsync(LoginDTO model);
    }
}