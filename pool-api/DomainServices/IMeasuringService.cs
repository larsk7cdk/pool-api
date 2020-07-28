using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pool_api.DomainServices
{
    public interface IMeasuringService
    {
        Task<IActionResult> Log(string temperature, string pH);
    }
}