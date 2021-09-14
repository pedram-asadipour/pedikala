using System.Linq;
using _01_Framework.Infrastructure;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class ColleagueRoleRepository : GenericRepository<ColleagueRole,long> , IColleagueRoleRepository
    {
        private readonly AccountContext _context;
        public ColleagueRoleRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditColleagueRole GetColleagueRole()
        {
            return _context.ColleagueRole
                .Select(x => new EditColleagueRole
                {
                    Id = x.Id,
                    RoleId = x.RoleId
                })
                .AsNoTracking()
                .First();
        }
    }
}