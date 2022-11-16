using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Series.Core;
using Series.Data;

namespace Series.Pages.Series
{
    public class DetailModel : PageModel
    {
        private readonly ISeriesData seriesData;
        public SeriesCollection? seriesCollection { get; set; }

        public DetailModel(ISeriesData seriesData)
        {
            this.seriesData = seriesData;
        }
        public IActionResult OnGet(int seriesID)
        {
            seriesCollection = seriesData.GetByID(seriesID);
            if(seriesCollection == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
