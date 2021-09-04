using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository : GenericRepository<Account,long> , IAccountRepository
    {
        private readonly AccountContext _context;
        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public List<AccountViewModel> GetAll(AccountSearchModel searchModel)
        {
            var query = _context.Accounts
                .Include(x => x.Role)
                .Select(x => new AccountViewModel
                {
                    Id = x.Id,
                    Fullname = x.Fullname,
                    Username = x.Username,
                    Mobile = x.Mobile,
                    RoleId = x.RoleId,
                    Role = x.Role.Name,
                    ProfileImage = x.ProfileImage,
                    CreationDate = x.CreationDate.ToPersianDate()
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Fullname))
                query = query.Where(x => x.Fullname.Contains(searchModel.Fullname));

            if (!string.IsNullOrWhiteSpace(searchModel.Username))
                query = query.Where(x => x.Username.Contains(searchModel.Username));

            if (searchModel.RoleId > 0)
                query = query.Where(x => x.RoleId == searchModel.RoleId);

            query = query.AsNoTracking();

            return query.ToList();
        }

        public List<SelectModel> GetAllSelectModel()
        {
            return _context.Accounts
                .Select(x => new SelectModel
                {
                    Id = x.Id,
                    Name = x.Username
                })
                .AsNoTracking()
                .ToList();
        }

        public EditAccount GetDetail(long id)
        {
            return _context.Accounts
                .Select(x => new EditAccount
                {
                    Id = x.Id,
                    Fullname = x.Fullname,
                    Username = x.Username,
                    Mobile = x.Mobile,
                    RoleId = x.RoleId,
                })
                .FirstOrDefault(x => x.Id == id);
        }

        public Account GetAccountBy(string username)
        {
            return _context.Accounts
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Username == username);
        }
    }
}