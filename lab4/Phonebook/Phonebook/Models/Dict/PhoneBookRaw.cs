using Newtonsoft.Json;

namespace Phonebook.Models.Dict;

[Serializable]
public class PhoneBookRaw:ICloneable
{
    public Guid Id { get;set;}
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }

    public PhoneBookRaw(string surname, string phoneNumber)
    {
        Surname = surname;
        PhoneNumber = phoneNumber;
        Id = Guid.NewGuid();
    }
    [JsonConstructor]
    public PhoneBookRaw(Guid id, string surname, string phoneNumber)
    {
        Surname = surname;
        PhoneNumber = phoneNumber;
        Id = id;
    }

    public object Clone() => new PhoneBookRaw(Id, Surname, PhoneNumber);
}
