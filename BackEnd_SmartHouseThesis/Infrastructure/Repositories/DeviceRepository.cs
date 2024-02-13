using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DeviceRepository : BaseRepo<Device>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<BaseRepo<Device>> _logger;
        public DeviceRepository(AppDbContext dbContext, ILogger<BaseRepo<Device>> logger) : base(dbContext, logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public DeviceRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Device>> GetListDeviceByManufacturer(string manuName)
        {
            try
            {
                List<Device> devices = await _dbContext.Device.Where(d => d.Manufacturer.Name == manuName).ToListAsync();
                return devices;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetListDeviceByManufacturer function error", typeof(BaseRepo<Device>));
                return null;
            }
        }
    }
}
