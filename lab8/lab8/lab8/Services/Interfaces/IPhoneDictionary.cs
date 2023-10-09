using lab8.Models;

namespace lab8.Services.Interfaces;

public interface IPhoneDictionary
{
    Task<PhoneRecord> GetById(string id);
    Task<List<PhoneRecord>> GetAll();
    Task Add(string name, string phone);
    Task Update(string id,string name, string phone);
    Task Delete(string id);
}