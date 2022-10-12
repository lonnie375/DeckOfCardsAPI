using DeckOfCardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult>Index()
        {
            HttpClient web = new HttpClient(); //Opens the connection 
            web.BaseAddress = new Uri("https://www.deckofcardsapi.com/"); //Connects us to the website 
            var connection = await web.GetAsync($"api/deck/new/shuffle/?deck_count=1"); //Gets information
            Rootobject member = await connection.Content.ReadAsAsync<Rootobject>(); //Returns information 

            var connection2 = await web.GetAsync($"api/deck/{member.deck_id}/draw/?count=5"); //Gets information
            Rootobject member2 = await connection2.Content.ReadAsAsync<Rootobject>(); //Returns information 

            return View(member2);
        }

        //public async Task<IActionResult>Draw()
        //{
        //    HttpClient web = new HttpClient(); //Opens the connection 
        //    web.BaseAddress = new Uri("https://www.deckofcardsapi.com/"); //Connects us to the website 
        //    var connection = await web.GetAsync($"api/deck/{}/draw/?count=2"); //Gets information
        //    Card member2 = await connection.Content.ReadAsAsync<Card>(); //Returns information 
        //    return View(member2);
           
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}