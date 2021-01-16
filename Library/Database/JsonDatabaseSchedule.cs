using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Library.Database
{
    public class JsonDatabaseSchedule : IJsonDatabase<Day>
    {
        public string FileName { get; set; } = "JsonDatabaseSchedule.txt";

        public List<Day> GetData()
        {
            if (!File.Exists(FileName))
                throw new FileDoesntExist();

            var dbFile = File.ReadAllText(FileName);
            var dbJson = JsonConvert.DeserializeObject<List<Day>>(dbFile);

            return dbJson;
        }

        public void UpdateDatabase(List<Day> list)
        {
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(FileName, json);
        }
    }
}
