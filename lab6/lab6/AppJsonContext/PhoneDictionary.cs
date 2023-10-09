using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppJsonContext.Interfaces;
using Newtonsoft.Json;

namespace AppJsonContext
{
    public class PhoneDictionary : IPhoneDictionary
    {
        public static readonly string Name = "Json";
        private List<PhoneRaw> raws;
        private string _filePath;

        public PhoneDictionary(string filePath)
        {
            _filePath=filePath;
            LoadData();
        }
        public void AddPhoneRaw(PhoneRaw raw)
        {
            raws.Add(raw);
            SaveData();
        }

        public PhoneRaw GetPhoneRawById(string id)
        {
            return raws.FirstOrDefault(r => r.Id == Guid.Parse(id));
        }

        public List<PhoneRaw> GetPhoneRaws()
        {
            return raws;
        }

        public void RemovePhoneRaw(string id)
        {
            var raw = GetPhoneRawById(id);
            if (raw != null)
            {
                raws.Remove(raw);
                SaveData();
            }
        }

        public void UpdatePhoneRaw(string id, string name, string phone)
        {
            var raw = GetPhoneRawById(id);
            if (raw != null)
            {
                raw.Name = name;
                raw.PhoneNumber=phone;
                SaveData();
            }
        }

        private void LoadData()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                raws = JsonConvert.DeserializeObject<List<PhoneRaw>>(json)??new List<PhoneRaw>();
            }
            else
            {
                raws = new List<PhoneRaw>();
            }
        }

        private void SaveData()
        {
            var json = JsonConvert.SerializeObject(raws);
            File.WriteAllText(_filePath, json);
        }
    }
}
