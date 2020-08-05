using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pool_api.AppData;
using pool_api.DomainModels;
using pool_api.Models;

namespace pool_api.DomainServices
{
    public class MeasureService : IMeasureService
    {
        private readonly IRepository<Measure> _measureRepository;

        public MeasureService(IRepository<Measure> measureRepository)
        {
            _measureRepository = measureRepository;
        }

        public async Task<IActionResult> Create(MeasureRequest measuring)
        {
            return await Task.Run(async () =>
            {
                var e = Convert.ToUInt64(measuring.EpochTime);
                var timestamp = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)
                    .AddSeconds(e)
                    .DateTime;


                await _measureRepository.CreateAsync(new Measure
                {
                    Temperature = measuring.Temperature,
                    Timestamp = timestamp
                });


                return new OkObjectResult("Measure create OK");
            });
        }

        public async Task<IActionResult> Create(MeasureRequest[] measurings)
        {
            return await Task.Run(async () =>
            {
                var list = measurings.ToList();
                foreach (var m in measurings)
                    await _measureRepository.CreateAsync(new Measure
                    {
                        Temperature = m.Temperature,
                        Timestamp = new DateTime()
                    });


                return new OkObjectResult("Measure create OK");
            });
        }

        public async Task<IActionResult> Create(string temperature, string pH, string timestamp)
        {
            return await Task.Run(async () =>
            {
                var measure = new Measure
                {
                    Temperature = Convert.ToDecimal(temperature.Replace('.', ',')),
                    Ph = Convert.ToDecimal(pH.Replace('.', ',')),
                    Timestamp = DateTime.Parse(timestamp)
                };


                await _measureRepository.CreateAsync(measure);

                return new OkObjectResult("Measure create OK");
            });
        }
    }
}