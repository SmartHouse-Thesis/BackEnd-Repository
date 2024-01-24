using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public  class RoleService 
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task CreateRole(Role role) => await _roleRepository.AddAsync(role);

        public async Task UpdateRole(Role role) => await _roleRepository.UpdateAsync(role);
        public async Task DeleteRole(Role role) => await _roleRepository.RemoveAsync(role);

        public async Task<IQueryable<Role>> GetAll() => await _roleRepository.FindAllAsync();

        public async Task<Role> GetRole(Guid id) => await _roleRepository.GetAsync(id);

        public async Task<Role> getRoleByRoleName(string roleName) => await _roleRepository.GetRoleByRoleName(roleName);
    }
}
