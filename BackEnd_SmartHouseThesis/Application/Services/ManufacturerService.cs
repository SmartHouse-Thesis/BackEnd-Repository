using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ManufacturerService
    {
        private readonly ManufactureRepository _manufacture;

        public ManufacturerService(ManufactureRepository manufacture)
        {
            _manufacture = manufacture;
        }

        public async Task CreateManufacture(Manufacturer manu) => await _manufacture.AddAsync(manu);

        public async Task UpdateManufacture(Manufacturer manu) => await _manufacture.UpdateAsync(manu);
        public async Task DeleteFacture(Manufacturer manu) => await _manufacture.RemoveAsync(manu);

        public async Task<IQueryable<Manufacturer>> GetAll() => await _manufacture.FindAllAsync();

        public async Task<Manufacturer> GetManufacture(Guid id) => await _manufacture.GetAsync(id);
    }
}
