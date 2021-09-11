using System;

namespace _01_PedikalaQuery.Contract.Slider
{
    public class SliderQueryModel
    {
        public long Id { get; set; }
        public string TitleOne { get;  set; }
        public string TitleTwo { get;  set; }
        public string Description { get;  set; }
        public string Image { get;  set; }
        public string ImageAlt { get;  set; }
        public string ImageTitle { get;  set; }
        public string Link { get;  set; }
    }
}