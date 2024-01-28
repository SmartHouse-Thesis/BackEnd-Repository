using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public interface IOwnerService
    {
        Task<IQueryable<Owner>> GetAll();
        Task<Owner> GetOwner(Guid id);

        Task CreateOwner(Owner owner);

        Task UpdateOwner(Owner owner);

        Task DeleteOwner(Owner owner);
    }
}
