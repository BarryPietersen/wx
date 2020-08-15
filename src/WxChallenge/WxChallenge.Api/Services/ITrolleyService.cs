using System.Threading.Tasks;
using WxChallenge.Core.Models;

namespace WxChallenge.Api.Services
{
    public interface ITrolleyService
    {
        Task<double> GetLowestTotal(TrolleyDetail details);
    }
}