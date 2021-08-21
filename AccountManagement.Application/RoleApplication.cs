using _01_Framework.Application;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _repository;

        public RoleApplication(IRoleRepository repository)
        {
            _repository = repository;
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

            var role = new Role(command.Name);

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

            role.Edit(command.Name);

            _repository.Edit(role);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}
