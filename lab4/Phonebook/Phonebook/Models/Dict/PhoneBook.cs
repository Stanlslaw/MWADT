using Newtonsoft.Json;

namespace Phonebook.Models.Dict;

public class PhoneBook
{
    
    private List<PhoneBookRaw> _phoneBookList = new ();
    public string Path { get; set; } = "././wwwroot/PhonesBookData.json";

    public PhoneBook()
    {
        RefreshList();
    }

    public List<PhoneBookRaw> GetBook()
    {
        RefreshList();
        return _phoneBookList.OrderBy(el=>el.Surname).ToList();
    }

    public PhoneBookRaw AddRaw(string surname, string phone)
    {
        PhoneBookRaw newRaw = new PhoneBookRaw(surname, phone);
        _phoneBookList.Add(newRaw);
        File.WriteAllText(Path, JsonConvert.SerializeObject(_phoneBookList));
        return newRaw;
    }

    public PhoneBookRaw DeleteRaw(string  id)
    {
        PhoneBookRaw deletedItem = _phoneBookList.Find(item => item.Id == Guid.Parse(id));
        _phoneBookList.Remove(deletedItem);
        File.WriteAllText(Path, JsonConvert.SerializeObject(_phoneBookList));
        return deletedItem;
    }

    public PhoneBookRaw UpdateRaw(string id,string surname, string phone)
    {
        int updatedItemIndex = _phoneBookList.FindIndex(item => item.Id == Guid.Parse(id));
        PhoneBookRaw oldItem = (PhoneBookRaw)_phoneBookList[updatedItemIndex].Clone();
        PhoneBookRaw updatedItem = _phoneBookList[updatedItemIndex];
        updatedItem.Surname = surname;
        updatedItem.PhoneNumber = phone;
        File.WriteAllText(Path, JsonConvert.SerializeObject(_phoneBookList));
        return oldItem;
    }
    public bool HasData()
    {
        RefreshList();
        if (_phoneBookList.Count == 0) return false;
        return true;
    }
    private void RefreshList()
    {
        string json = File.ReadAllText(Path);
        _phoneBookList = JsonConvert.DeserializeObject<List<PhoneBookRaw>>(json)??_phoneBookList;
    }
    
}