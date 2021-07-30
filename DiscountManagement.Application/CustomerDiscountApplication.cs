using System.Collections.Generic;
using _01_Framework.Application;
using _01_Framework.Tools;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _repository;

        public CustomerDiscountApplication(ICustomerDiscountRepository repository)
        {
            _repository = repository;
        }

        public List<CustomerDiscountViewModel> GetAll(CustomerDiscountSearchModel searchModel)
        {
            return _repository.GetAll(searchModel);
        }

        public EditCustomerDiscount GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var operationResult = new OperationResult();

            if (_repository.Exists(x => x.ProductId == command.ProductId))
                return operationResult.Failed(ApplicationMessages.Exists);

            var customerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate,
                command.StartDate.ToGregorianDate(),
                command.EndDate.ToGregorianDate(),
                command.Reason);

            _repository.Create(customerDiscount);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operationResult = new OperationResult();
            var customerDiscount = _repository.GetBy(command.Id);

            if (customerDiscount == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_repository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Exists);

            customerDiscount.Edit(command.ProductId, command.DiscountRate,
                command.StartDate.ToGregorianDate(),
                command.EndDate.ToGregorianDate(),
                command.Reason);

            _repository.Edit(customerDiscount);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Removed(long id)
        {
            var operationResult = new OperationResult();
            var customerDiscount = _repository.GetBy(id);

            if (customerDiscount == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            customerDiscount.Removed();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var customerDiscount = _repository.GetBy(id);

            if (customerDiscount == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            customerDiscount.Restore();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}