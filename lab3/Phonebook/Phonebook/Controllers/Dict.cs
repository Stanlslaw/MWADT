using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Phonebook.Models.Dict;

namespace Phonebook.Controllers
{
 
    public class DictController : Controller
    {
        public PhoneBook book;

        public DictController()
        {
            book = new PhoneBook();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(book.GetBook());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSave(string surname,string phone)
        { 
            book.AddRaw(surname,phone);
            return   RedirectToAction("Index", "Dict");
           
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateSave(string id,string newSurname,string newPhone)
        {
            book.UpdateRaw(id, newSurname, newPhone);
            return  RedirectToAction("Index", "Dict");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteSave(string id)
        {
            book.DeleteRaw(id);
            return  RedirectToAction("Index", "Dict");
        }

        public IActionResult Error(string code)
        {
            ViewData["StatusCode"] = code;
            ViewData["OrigURl"] = HttpContext.Features.Get<IStatusCodeReExecuteFeature>().OriginalPath;
            ViewData["Method"] = HttpContext.Request.Method;
            return View();
        }
    }
}
