using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Library
{
    public class Manage
    {
        public static List<Person> People { get; set; }
        public string FileListName { get; set; } = "ListInJsonFile.txt";
        public bool isExistFileList { get; set; }

        public Manage()
        {
            this.GetFileList();
        }

        public void GetFileList()
        {
            isExistFileList = File.Exists(FileListName);

            if (!isExistFileList)
                throw new FileDoesntExist();

            var file = File.ReadAllText(FileListName);

            People = JsonConvert.DeserializeObject<List<Person>>(file);
        }
    }
}
