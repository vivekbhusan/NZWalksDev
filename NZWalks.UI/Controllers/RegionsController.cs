using Microsoft.AspNetCore.Mvc;

namespace NZWalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            //Get All Regions and show
            try
            {
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:7285/api/Regions");
                httpResponseMessage.EnsureSuccessStatusCode();
                var stringResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                ViewBag.Response = stringResponseBody;
            }
            catch (Exception ex)
            {
                //Log the error
            }
            return View();
        }
    }
}
