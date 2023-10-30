using lab8.Data;
using lab8.Models;
using lab8.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace lab8.Controllers;
[ApiController]
[Route("api/phonebookcontroller")]
public class PhoneBookController:Controller
{
    private protected IPhoneDictionary _phoneDictionary;
    
    public PhoneBookController(IPhoneDictionary phoneDictionary)
    {
        _phoneDictionary = phoneDictionary;
    }
    [HttpGet]
    [Route("getallrecords")]
    public async Task<IActionResult> GetAllRecords()
    {
        List<PhoneRecord> records = await _phoneDictionary.GetAll();
        return Json(records);
    }
    [HttpGet]
    [Route("getrecordbyid/{id:minlength(36):maxlength(36)}")]
    public async Task<IActionResult> GetRecordByID(string? id)
    {
        PhoneRecord record = await _phoneDictionary.GetById(id);
        return Json(record);
    }
    [HttpPost]
    [Route("addrecord")]
    public async Task<IActionResult> AddRecord(string name, string phone)
    {
        await _phoneDictionary.Add(name,phone);
        return Ok();
    }
    [HttpPut]
    [Route("updaterecord")]
    public async Task<IActionResult> UpdateRecord(string id, string? name, string? phone)
    {
        await _phoneDictionary.Update(id, name!, phone!);
        return Ok();
    }
    [HttpDelete]
    [Route("deleterecord")]
    public async Task<IActionResult> DeleteRecord(string id)
    {
        await _phoneDictionary.Delete(id);
        return Ok();
    }
}