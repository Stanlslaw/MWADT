using lab8.Data;
using lab8.Models;
using lab8.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace lab8.Controllers;
[ApiController]
[Route("api")]
public class PhoneBookController:Controller
{
    private protected IPhoneDictionary _phoneDictionary;
    public PhoneBookController(IPhoneDictionary phoneDictionary)
    {
        _phoneDictionary = phoneDictionary;
    }
    [HttpGet]
    [Route("getall")]
    public async Task<IActionResult> GetAll()
    {
        List<PhoneRecord> records = await _phoneDictionary.GetAll();
        return Ok(records);
    }
}