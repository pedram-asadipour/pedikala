using System.Collections.Generic;

namespace _01_PedikalaQuery.Contract.Slider
{
    public interface ISliderQuery
    {
        List<SliderQueryModel> GetAllSlider();
    }
}