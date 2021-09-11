using _01_PedikalaQuery.Contract.Slider;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Components
{
    public class SliderComponent : ViewComponent
    {
        private readonly ISliderQuery _query;

        public SliderComponent(ISliderQuery query)
        {
            _query = query;
        }

        public IViewComponentResult Invoke()
        {
            var slider = _query.GetAllSlider();
            return View(slider);
        }
    }
}