﻿using _01_Framework.Infrastructure;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Tools;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class RoleRepository : GenericRepository<Role, long>, IRoleRepository
    {
        private readonly AccountContext _context;

        public RoleRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public List<RoleViewModel> GetAll()
        {
            return _context.Roles
                .Select(x => new RoleViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreationDate = x.CreationDate.ToPersianDate()
                })
                .ToList();
        }

        public EditRole GetDetail(long id)
        {
            return _context.Roles
               .Select(x => new EditRole()
               {
                   Id = x.Id,
                   Name = x.Name
               })
               .FirstOrDefault(x => x.Id == id);
        }
    }
}
