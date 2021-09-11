namespace BannerManagement.ApplicationContract.Slider
{
    public class SliderViewModel
    {
        public long Id { get; set; }
        public string TitleOne { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public bool Status { get; set; }
        public bool IsRemove { get; set; }
        public string LifeTime { get; set; }
        public string CreationDate { get; set; }
    }
}