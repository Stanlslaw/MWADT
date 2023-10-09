using lab6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace lab6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext.PhoneDictionary phoneDictionaryRepository;

        public HomeController(ILogger<HomeController> logger, DataContext.PhoneDictionary phoneDictionaryRepository)
        {
            _logger = logger;
            this.phoneDictionaryRepository = phoneDictionaryRepository;
        }

        public IActionResult Index()
        {
            return View( phoneDictionaryRepository.GetPhoneRaws());
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Add(string name, string phone)
        {
            if (HttpContext.Request.Method == HttpMethods.Post)
            {
              phoneDictionaryRepository
                    .AddPhoneRaw(new DataContext.PhoneRaw(){Id=Guid.NewGuid(),Name = name,PhoneNumber = phone});
                TempData["SuccessMessage"] = "raw is created";
            }
            return View();
        }
        [HttpGet]
        [HttpPost]
        public IActionResult Delete(string id)
        {
            if (HttpContext.Request.Method == HttpMethods.Post)
            {
                phoneDictionaryRepository.RemovePhoneRaw(id);
                TempData["SuccessMessage"] = "raw is deleted";
            }
            return View();
        }
        [HttpGet]
        [HttpPost]
        public IActionResult Update(string id, string name,string phone)
        {
            if (HttpContext.Request.Method == HttpMethods.Post)
            {
                phoneDictionaryRepository
                    .UpdatePhoneRaw(id,name,phone);
                TempData["SuccessMessage"] = "raw is updated";
            }
            return View();
        }

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