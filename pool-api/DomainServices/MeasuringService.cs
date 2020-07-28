using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pool_api.AppData;
using pool_api.DomainModels;

namespace pool_api.DomainServices
{
    public class MeasuringService : IMeasuringService
    {
        private readonly IRepository<Measuring> _measuringRepository;

        public MeasuringService(IRepository<Measuring> measuringRepository)
        {
            _measuringRepository = measuringRepository;
        }

        public async Task<IActionResult> Log(string temperature, string pH)
        {
            return await Task.Run(async () =>
            {
                var measuring = new Measuring
                {
                    Temperature = Convert.ToDecimal(temperature.Replace('.', ',')),
                    Ph = Convert.ToDecimal(pH.Replace('.', ',')),
                    LogDateTime = DateTime.Now
                };


                await _measuringRepository.CreateAsync(measuring);

                return new OkObjectResult("measuring OK");
            });
        }
    }
}