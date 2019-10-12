using System.Threading.Tasks;
using Countries.Prism.Models;

namespace Countries.Prism.Services
{
    public interface IApiService
    {
        Task<Response> GetCountry(
            string urlBase,
            string servicePrefix,
            string controller);

        Task<Response> GetCountries(
            string urlBase,
            string servicePrefix,
            string controller);
    }
}
