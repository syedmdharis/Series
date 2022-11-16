using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Series.Core;
using Series.Data;

namespace Series.Pages.Series
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ISeriesData seriesData;

        public string? Message { get; set; }
        public IEnumerable<SeriesCollection> SeriesCollection { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, ISeriesData seriesData)
        {
            this.config = config;
            this.seriesData = seriesData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            SeriesCollection = seriesData.GetSeriesByName(SearchTerm);
        }
    }
}
