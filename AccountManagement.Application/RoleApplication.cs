using _01_Framework.Application;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _repository;
        private readonly IColleagueRoleRepository _colleagueRoleRepository;
        private readonly IEnumerable<IPermissionExposer> _exposers;

        public RoleApplication(IRoleRepository repository, IEnumerable<IPermissionExposer> exposers, IColleagueRoleRepository colleagueRoleRepository)
        {
            _repository = repository;
            _exposers = exposers;
            _colleagueRoleRepository = colleagueRoleRepository;
        }

        public List<RoleViewModel> GetAll()
        {
            return _repository.GetAll();
        }

        public EditRole GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Create(CreateRole command)
        {
            var operationResult = new OperationResult();

            if (_repository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.Exists);

            var permissions = new List<RolePermission>();

            command.Permission?.ForEach(code => permissions.Add(new RolePermission(code)));

            var role = new Role(command.Name,permissions);

            _repository.Create(role);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditRole command)
        {
            var operationResult = new OperationResult();
            var role = _repository.GetBy(command.Id);

            if (role == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_repository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Exists);

            var permissions = new List<RolePermission>();

            command.Permission?.ForEach(permission => permissions.Add(new RolePermission(permission)));

            role.Edit(command.Name, permissions);

            _repository.Edit(role);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public List<SelectListItem> GetPermissions(List<string> currentRolePermissions)
        {
            var allPermissionsWithGroup = new List<SelectListItem>();

            foreach (var exposer in _exposers)
            {
                var permissionDictionaries = exposer.Expose();

                foreach (var (key,currentPermissions) in permissionDictionaries)
                {
                    var group = new SelectListGroup()
                    {
                        Name = key
                    };

                    foreach (var permission in currentPermissions)
                    {
                        var item = new SelectListItem(permission.Name,permission.Permission.ToString())
                        {
                            Group = group
                        };

                        if (currentRolePermissions.Any(code => code == permission.Permission))
                            item.Selected = true;

                        allPermissionsWithGroup.Add(item);
                    }
                }
            }

            return allPermissionsWithGroup;
        }

        public EditColleagueRole GetColleagueRole()
        {
            return _colleagueRoleRepository.GetColleagueRole();
        }

        public OperationResult EditColleagueRole(EditColleagueRole command)
        {
            var operationResult = new OperationResult();
            var colleagueRole = _colleagueRoleRepository.GetBy(command.Id);

            if (colleagueRole == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            colleagueRole.Edit(command.RoleId);

            _colleagueRoleRepository.Edit(colleagueRole);

            _colleagueRoleRepository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}