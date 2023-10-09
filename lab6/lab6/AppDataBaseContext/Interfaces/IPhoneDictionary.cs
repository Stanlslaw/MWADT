using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataBaseContext.Interfaces
{
    public interface IPhoneDictionary
    {
        List<PhoneRaw> GetPhoneRaws();
        PhoneRaw GetPhoneRawById(string id);
        Task UpdatePhoneRaw(string id, string name, string phone);
        Task AddPhoneRaw(PhoneRaw phone);
        Task RemovePhoneRaw(string id);
    }
}
