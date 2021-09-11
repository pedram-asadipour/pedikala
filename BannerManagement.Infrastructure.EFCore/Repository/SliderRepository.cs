using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using BannerManagement.ApplicationContract.Slider;
using BannerManagement.Domain.SliderAgg;
using Microsoft.EntityFrameworkCore;

namespace BannerManagement.Infrastructure.EFCore.Repository
{
    public class SliderRepository : GenericRepository<Slider,long>, ISliderRepository
    {
        private readonly BannerContext _context;

        public SliderRepository(BannerContext context) : base(context)
        {
            _context = context;
        }

        public List<SliderViewModel> GetAll()
        {
            return _context.Sliders
                .Select(x => new SliderViewModel
                {
                    Id = x.Id,
                    TitleOne = x.TitleOne,
                    Image = x.Image,
                    Link = x.Link,
                    Status = (x.IsRemove || (x.LifeTime <= DateTime.Now)),
                    IsRemove = x.IsRemove,
                    LifeTime = x.LifeTime.ToPersianDate(),
                    CreationDate = x.CreationDate.ToPersianDate()
                })
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        public EditSlider GetDetail(long id)
        {
            return _context.Sliders
                .Select(x => new EditSlider
                {
                    Id = x.Id,
                    TitleOne = x.TitleOne,
                    TitleTwo = x.TitleTwo,
                    Description = x.Description,
                    ImageAlt = x.ImageAlt,
                    ImageTitle = x.ImageTitle,
                    Link = x.Link,
                    LifeTime = x.LifeTime.ToString(CultureInfo.InvariantCulture)
                })
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}