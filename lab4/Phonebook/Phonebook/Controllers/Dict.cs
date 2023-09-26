using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Phonebook.Models.Dict;

namespace Phonebook.Controllers
{
 
    public class DictController : Controller
    {
        public PhoneBook book;
        public PhoneBookDb db;
        public DictController(PhoneBookDb context)
        {
            book = new PhoneBook();
            db = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index() {
            return View(await db.PhoneBookRaws.ToListAsync());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSave(string surname,string phone)
        {
            await db.PhoneBookRaws.AddAsync(new PhoneBookRaw(surname, phone));
            await db.SaveChangesAsync();
            return   RedirectToAction("Index", "Dict");
           
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSave(string id,string newSurname,string newPhone)
        {
            PhoneBookRaw? old= await db.PhoneBookRaws.FindAsync(id);
            old.Surname = newSurname;
            old.PhoneNumber = newPhone;
            await db.SaveChangesAsync();
            return  RedirectToAction("Index", "Dict");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSave(string id)
        {
            PhoneBookRaw? del= await db.PhoneBookRaws.FindAsync(Guid.Parse(id));
            db.PhoneBookRaws.Remove(del);
            await db.SaveChangesAsync();
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
