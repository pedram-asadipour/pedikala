using _01_Framework.Domain;
using AccountManagement.Application.Contract.Role;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IGenericRepository<Role,long>
    {
        List<RoleViewModel> GetAll();
        EditRole GetDetail(long id);
    }
}
