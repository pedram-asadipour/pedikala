using _01_Framework.Domain;
using AccountManagement.Application.Contract.Role;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IColleagueRoleRepository : IGenericRepository<ColleagueRole,long>
    {
        EditColleagueRole GetColleagueRole();
    }
}