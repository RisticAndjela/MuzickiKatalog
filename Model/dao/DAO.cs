using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace muzickiKatalog.Model.dao
{
    public class Dao<T>
    {
        private readonly string _filename;

        public Dao(string filename) { _filename = filename; }
       
        public bool WriteDictionaryToFile(Dictionary<string, T> items)
        {
            try
            {
                string data = JsonConvert.SerializeObject(items, Formatting.Indented);
                File.WriteAllText(_filename, data);
            }
            catch (IOException)
            {
                Console.WriteLine("Error writing to file: " + _filename);
                return false;
            }
            return true;
        }

        public Dictionary<string, T> ReadDictionaryFromFile()
        {
            Dictionary<string, T> items = new();
            try
            {
                string data = File.ReadAllText(_filename);
                items = JsonConvert.DeserializeObject<Dictionary<string, T>>(data);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error with file: " + _filename);
                items = new Dictionary<string, T>();
            }
            return items;
        }

        public bool WriteListToFile(List<T> items)
        {
            try
            {
                string data = JsonConvert.SerializeObject(items, Formatting.Indented);
                File.WriteAllText(_filename, data);
            }
            catch (IOException)
            {
                Console.WriteLine("Error writing to file: " + _filename);
                return false;
            }
            return true;
        }
        public List<T> ReadListFromFile()
        {
            List<T> items = new();
            try
            {
                string data = File.ReadAllText(_filename);
                items = JsonConvert.DeserializeObject<List<T>>(data);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error with file: " + _filename);
                items = new List<T>();
            }
            return items;
        }


    }
}
