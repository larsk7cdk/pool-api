using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pool_api.Models;

namespace pool_api.DomainServices
{
    public interface IMeasureService
    {
        Task<IActionResult> Create(MeasureRequest measurings);
        Task<IActionResult> Create(MeasureRequest[] measurings);
    }
}