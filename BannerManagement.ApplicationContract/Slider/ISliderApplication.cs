using System.Collections.Generic;
using _01_Framework.Application;

namespace BannerManagement.ApplicationContract.Slider
{
    public interface ISliderApplication
    {
        List<SliderViewModel> GetAll();
        EditSlider GetDetail(long id);
        OperationResult Create(CreateSlider command);
        OperationResult Edit(EditSlider command);
        OperationResult Removed(long id);
        OperationResult Restore(long id);
    }
}