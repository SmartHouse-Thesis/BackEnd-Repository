using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PackageServices
    {
        private readonly PackageRepository _package;

        public PackageServices(PackageRepository package)
        {
            _package = package;
        }

        public async Task CreatePackage(Package pack) => await _package.AddAsync(pack);

        public async Task UpdatePackage(Package pack) => await _package.UpdateAsync(pack);
        public async Task DeletePackage(Package pack) => await _package.RemoveAsync(pack);

        public async Task<IQueryable<Package>> GetAll() => await _package.FindAllAsync();

        public async Task<Package> GetPackage(Guid id) => await _package.GetAsync(id);

        public async Task<List<Package>> GetListPackagesByManufacturer(string manuName) => await _package.GetListPackagesByManufacturer(manuName);
    }
}
