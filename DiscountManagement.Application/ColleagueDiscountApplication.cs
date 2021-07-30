using System.Collections.Generic;
using _01_Framework.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _repository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository repository)
        {
            _repository = repository;
        }

        public List<ColleagueDiscountViewModel> GetAll(ColleagueDiscountSearchModel searchModel)
        {
            return _repository.GetAll(searchModel);
        }

        public EditColleagueDiscount GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var operationResult = new OperationResult();

            if (_repository.Exists(x => x.ProductId == command.ProductId))
                return operationResult.Failed(ApplicationMessages.Exists);

            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);

            _repository.Create(colleagueDiscount);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var operationResult = new OperationResult();
            var colleagueDiscount = _repository.GetBy(command.Id);

            if (colleagueDiscount == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_repository.Exists(x => x.ProductId == command.ProductId && command.ProductId != x.ProductId))
                return operationResult.Failed(ApplicationMessages.Exists);

            colleagueDiscount.Edit(command.ProductId, command.DiscountRate);

            _repository.Edit(colleagueDiscount);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Removed(long id)
        {
            var operationResult = new OperationResult();
            var colleagueDiscount = _repository.GetBy(id);

            if (colleagueDiscount == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            colleagueDiscount.Removed();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var colleagueDiscount = _repository.GetBy(id);

            if (colleagueDiscount == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            colleagueDiscount.Restore();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}
