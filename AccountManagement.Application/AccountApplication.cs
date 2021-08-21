using System.Collections.Generic;
using System.Net.NetworkInformation;
using _01_Framework.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _repository;
        private readonly IFileManager _fileManager;
        private readonly IPasswordHasher _passwordHasher;

        public AccountApplication(IAccountRepository repository, IFileManager fileManager, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _fileManager = fileManager;
            _passwordHasher = passwordHasher;
        }

        public List<AccountViewModel> GetAll(AccountSearchModel searchModel)
        {
            return _repository.GetAll(searchModel);
        }

        public EditAccount GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Create(CreateAccount command)
        {
            var operationResult = new OperationResult();

            if (_repository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operationResult.Failed(ApplicationMessages.Exists);

            if (command.Password != command.RePassword)
                return operationResult.Failed(ApplicationMessages.PasswordNotMatch);

            var profileImage = _fileManager.Uploader(command.ProfileImage, "کاربران");

            var password = _passwordHasher.Hash(command.Password);

            var account = new Account(command.Fullname, command.Username, password, command.Mobile,command.RoleId,profileImage);

            _repository.Create(account);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operationResult = new OperationResult();

            var account = _repository.GetBy(command.Id);

            if (account == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_repository.Exists(x => (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Exists);

            var profileImage = _fileManager.Uploader(command.ProfileImage, "کاربران");

            if(command.ProfileImage != null)
                _fileManager.Remove(account.ProfileImage);

            account.Edit(command.Fullname, command.Username, command.Mobile, command.RoleId, profileImage);

            _repository.Edit(account);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult ChangePassword(ChangePasswordAccount command)
        {
            var operationResult = new OperationResult();

            var account = _repository.GetBy(command.Id);

            if (account == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (command.NewPassword != command.RePassword)
                return operationResult.Failed(ApplicationMessages.PasswordNotMatch);

            var password = _passwordHasher.Hash(command.NewPassword);

            account.ChangePassword(password);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}
