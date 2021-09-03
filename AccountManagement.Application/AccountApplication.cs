using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _repository;
        private readonly IFileManager _fileManager;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;

        public AccountApplication(IAccountRepository repository, IFileManager fileManager, IPasswordHasher passwordHasher, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _repository = repository;
            _fileManager = fileManager;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
            _roleRepository = roleRepository;
        }

        public List<AccountViewModel> GetAll(AccountSearchModel searchModel)
        {
            return _repository.GetAll(searchModel);
        }

        public EditAccount GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operationResult = new OperationResult();

            if (_repository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operationResult.Failed(ApplicationMessages.Exists + " به نام کاربری و شماره موبایل توجه کنید");

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
                return operationResult.Failed(ApplicationMessages.Exists + " به نام کاربری و شماره موبایل توجه کنید");

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

        public OperationResult LogIn(LogInAccount command)
        {
            var operationResult = new OperationResult();
            var account = _repository.GetAccountBy(command.Username);

            if (account == null)
                return operationResult.Failed(ApplicationMessages.AccountExists);

            var passwordResult = _passwordHasher.Check(account.Password,command.Password);

            if (!passwordResult.Verified)
                return operationResult.Failed(ApplicationMessages.AccountExists);

            var permissions = _roleRepository
                .GetBy(account.RoleId)
                .Permissions
                .Select(x => x.Permission)
                .ToList();

            var result = new AuthViewModel(account.Id, account.Fullname, account.Username, account.RoleId, account.Role.Name,account.Mobile,permissions);

            _authHelper.Login(result);

            return operationResult.Succeeded();
        }

        public void SignOut()
        {
            _authHelper.SignOut();
        }
    }
}
