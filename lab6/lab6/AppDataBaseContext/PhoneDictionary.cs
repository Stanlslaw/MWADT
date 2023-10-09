using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDataBaseContext.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppDataBaseContext
{
    public class PhoneDictionary : IPhoneDictionary
    {
        public static readonly string Name = "DataBase";
        private readonly PhoneDbContext _dbContext;

        public PhoneDictionary(PhoneDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task AddPhoneRaw(PhoneRaw raw)
        {
           await _dbContext.AddAsync(raw);
           await _dbContext.SaveChangesAsync();
        }

        public PhoneRaw GetPhoneRawById(string id)
        {
            return _dbContext.Raws.FirstOrDefault(r => r.Id == Guid.Parse(id));
        }

        public  List<PhoneRaw> GetPhoneRaws()
        {
            return _dbContext.Raws.ToList<PhoneRaw>();
        }

        public async Task RemovePhoneRaw(string id)
        {
            var remRaw = _dbContext.Raws.FirstOrDefault(r => r.Id == Guid.Parse(id));
            _dbContext.Remove(_dbContext.Raws.Remove(remRaw));
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePhoneRaw(string id, string? name, string? phone)
        {
            var changedRaw = _dbContext.Raws.FirstOrDefault(r => r.Id == Guid.Parse(id));
            changedRaw.PhoneNumber = phone??changedRaw.PhoneNumber;
            changedRaw.Name = name??changedRaw.Name;
            _dbContext.Raws.Update(changedRaw);
            await _dbContext.SaveChangesAsync();
        }

      

     
    }
}
