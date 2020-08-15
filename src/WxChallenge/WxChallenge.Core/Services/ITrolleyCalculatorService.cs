using WxChallenge.Core.Models;

namespace WxChallenge.Core.Services
{
    public interface ITrolleyCalculatorService
    {
        double GetLowestTotal(TrolleyDetail details);
    }
}