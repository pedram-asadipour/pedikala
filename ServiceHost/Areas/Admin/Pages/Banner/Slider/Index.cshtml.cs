using System.Collections.Generic;
using _01_Framework.Application;
using Banner.Management.Configuration.Permission;
using BannerManagement.ApplicationContract.Slider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Banner.Slider
{
    public class IndexModel : PageModel
    {
        public List<SliderViewModel> Sliders { get; set; }

        private readonly ISliderApplication _application;

        public IndexModel(ISliderApplication application)
        {
            _application = application;
        }

        [NeedsPermission(BannerPermissions.Slider)]
        public void OnGet()
        {
            Sliders = _application.GetAll();
        }

        [NeedsPermission(BannerPermissions.Slider)]
        public PartialViewResult OnGetList()
        {
            Sliders = _application.GetAll();
            return Partial("./List", Sliders);
        }

        [NeedsPermission(BannerPermissions.CreateSlider)]
        public PartialViewResult OnGetCreate()
        {
            return Partial("./Create", new CreateSlider());
        }

        [NeedsPermission(BannerPermissions.CreateSlider)]
        public JsonResult OnPostCreate(CreateSlider command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Create(command);
            return new JsonResult(json);
        }

        [NeedsPermission(BannerPermissions.EditSlider)]
        public PartialViewResult OnGetEdit(long id)
        {
            var editSlider = _application.GetDetail(id);
            return Partial("./Edit", editSlider);
        }

        [NeedsPermission(BannerPermissions.EditSlider)]
        public JsonResult OnPostEdit(EditSlider command)
        {
            if (!ModelState.IsValid)
                return new JsonResult(new OperationResult().Failed(ValidationMessages.AllRequired));

            var json = _application.Edit(command);
            return new JsonResult(json);
        }

        [NeedsPermission(BannerPermissions.RemoveRestoreSlider)]
        public JsonResult OnGetRemove(long id)
        {
            var json = _application.Removed(id);
            return new JsonResult(json);
        }

        [NeedsPermission(BannerPermissions.RemoveRestoreSlider)]
        public JsonResult OnGetRestore(long id)
        {
            var json = _application.Restore(id);
            return new JsonResult(json);
        }
    }
}