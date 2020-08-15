using System.Collections.Generic;
using System.Threading.Tasks;
using WxChallenge.Core.Models;

namespace WxChallenge.Api.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
    }
}