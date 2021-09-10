using System;
using System.Collections.Generic;
using _01_Framework.Application;
using _01_Framework.Tools;
using BannerManagement.ApplicationContract.Slider;
using BannerManagement.Domain.SliderAgg;

namespace BannerManagement.Application
{
    public class SliderApplication : ISliderApplication
    {
        private readonly ISliderRepository _repository;
        private readonly IFileManager _fileManager;

        public SliderApplication(ISliderRepository repository, IFileManager fileManager)
        {
            _repository = repository;
            _fileManager = fileManager;
        }

        public List<SliderViewModel> GetAll()
        {
            return _repository.GetAll();
        }

        public EditSlider GetDetail(long id)
        {
            return _repository.GetDetail(id);
        }

        public OperationResult Create(CreateSlider command)
        {
            var operationResult = new OperationResult();

            if (_repository.Exists(x => x.TitleOne == command.TitleOne && x.TitleTwo == command.TitleTwo))
                return operationResult.Failed(ApplicationMessages.Exists);

            var image = _fileManager.Uploader(command.Image, "سلایدر");

            var slider = new Slider(command.TitleOne, command.TitleTwo, command.Description, image, command.ImageAlt,
                command.ImageTitle, command.Link, command.LifeTime.ToGregorianDate());

            _repository.Create(slider);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Edit(EditSlider command)
        {
            var operationResult = new OperationResult();

            var slider = _repository.GetBy(command.Id);

            if (slider == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_repository.Exists(x => x.TitleOne == command.TitleOne 
                                        && x.TitleTwo == command.TitleTwo 
                                        && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Exists);

            var image = _fileManager.Uploader(command.Image, "سلایدر");

            if (command.Image != null)
                _fileManager.Remove(slider.Image);

            slider.Edit(command.TitleOne, command.TitleTwo, command.Description, image, command.ImageAlt,
                command.ImageTitle, command.Link, command.LifeTime.ToGregorianDate());

            _repository.Edit(slider);

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Removed(long id)
        {
            var operationResult = new OperationResult();

            var slider = _repository.GetBy(id);

            if (slider == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            slider.Removed();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();

            var slider = _repository.GetBy(id);

            if (slider == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            slider.Restore();

            _repository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}
