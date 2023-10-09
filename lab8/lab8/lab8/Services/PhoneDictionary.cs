using lab8.Data;
using lab8.Models;
using lab8.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab8.Services;

public class PhoneDictionary:IPhoneDictionary
{
    private protected PhoneDictionaryDbContext _dbContext;

    public PhoneDictionary(PhoneDictionaryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PhoneRecord> GetById(string id)
    {
        return await _dbContext.PhoneRecords.FirstOrDefaultAsync(r => r.Id == Guid.Parse(id));
    }

    public async Task<List<PhoneRecord>> GetAll()
    {
        return await _dbContext.PhoneRecords.ToListAsync();
    }

    public async Task Add(string name, string phone)
    {
        var newRecord = new PhoneRecord() { Id = Guid.NewGuid(), Name = name, PhoneNumber = phone };
        await _dbContext.PhoneRecords.AddAsync(newRecord);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(string id, string? name, string? phone)
    {
        var updatedRecord= await _dbContext.PhoneRecords.FirstOrDefaultAsync(r => r.Id == Guid.Parse(id));
        updatedRecord.PhoneNumber = phone??updatedRecord.PhoneNumber;
        updatedRecord.Name = name??updatedRecord.Name;
        _dbContext.PhoneRecords.Update(updatedRecord);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(string id)
    {
        var deletedRecord= await _dbContext.PhoneRecords.FirstOrDefaultAsync(r => r.Id == Guid.Parse(id));
        _dbContext.Remove(deletedRecord);
        await _dbContext.SaveChangesAsync();
    }
}