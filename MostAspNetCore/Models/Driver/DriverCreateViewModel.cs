using Microsoft.AspNetCore.Mvc.Rendering;
using MostLib.Enums;

namespace MostAspNetCore.Models.Driver
{
    public class DriverCreateViewModel
    {
        public IList<string> SelectedCategories { get; set; }
        public IList<SelectListItem> AvailableCategories { get; set; }
        public MostLib.Driver Driver { get; set; }

        public DriverCreateViewModel()
        {
            SelectedCategories = new List<string>();
            var categories = Enum.GetValues(typeof(DriverLicenseCategory)).Cast<DriverLicenseCategory>().ToList();
            AvailableCategories = new List<SelectListItem>();
            foreach (var category in categories)
            {
                AvailableCategories.Add(new SelectListItem() { Value = category.ToString() });
            }
        }
    }
}
