using System.Collections.Generic;
using System.Linq;
using _01_Framework.Domain;
using BannerManagement.ApplicationContract.Slider;

namespace BannerManagement.Domain.SliderAgg
{
    public interface ISliderRepository : IGenericRepository<Slider,long>
    {
        List<SliderViewModel> GetAll();
        EditSlider GetDetail(long id);
    }
}