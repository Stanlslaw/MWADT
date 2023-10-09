using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJsonContext.Interfaces
{
    public interface IPhoneDictionary
    {
        List<PhoneRaw> GetPhoneRaws();
        PhoneRaw GetPhoneRawById(string id);
        void UpdatePhoneRaw(string id, string name, string phone);
        void AddPhoneRaw(PhoneRaw phone);
        void RemovePhoneRaw(string id);
    }
}
