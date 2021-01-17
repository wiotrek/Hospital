using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Library.Database
{
    public class JsonDatabase : IJsonDatabase<Person>
    {
        public string FileName { get; set; } = "JsonDatabase.txt";

        public List<Person> GetData()
        {
            if (!File.Exists(FileName))
                throw new FileDoesntExist();

            var dbFile = File.ReadAllText(FileName);
            var dbJson = JsonConvert.DeserializeObject<List<Person>>(dbFile);

            return dbJson;
        }
        
        public void UpdateDatabase(List<Person> people)
        {
            var json = JsonConvert.SerializeObject(people);
            File.WriteAllText(FileName, json);
        }
    }
}
