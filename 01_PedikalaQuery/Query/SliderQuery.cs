using System;
using System.Collections.Generic;
using System.Linq;
using _01_PedikalaQuery.Contract.Slider;
using BannerManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_PedikalaQuery.Query
{
    public class SliderQuery : ISliderQuery
    {
        private readonly BannerContext _bannerContext;

        public SliderQuery(BannerContext bannerContext)
        {
            _bannerContext = bannerContext;
        }

        public List<SliderQueryModel> GetAllSlider()
        {
            return _bannerContext.Sliders
                .Where(x => !x.IsRemove && x.LifeTime >= DateTime.Now)
                .Select(x => new SliderQueryModel
                {
                    Id = x.Id,
                    TitleOne = x.TitleOne,
                    TitleTwo = x.TitleTwo,
                    Description = x.Description,
                    Image = x.Image,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    Link = x.Link
                })
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .ToList();
        }
    }
}