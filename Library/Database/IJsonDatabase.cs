using System.Collections.Generic;

namespace Library.Database
{
    public interface IJsonDatabase
    {
        /// <summary>
        /// Pobiera zapisane dane z pliku
        /// </summary>
        /// <returns>Zwraca cala liste uzytkownikow z pliku json zapisanego w pliku tekstowym</returns>
        public List<Person> GetData();

        /// <summary>
        /// Nazwa pliku w ktorym zapisane sa dane
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Flaga, ktora okresla czy istnieje plik z baza danych
        /// </summary>
        public bool IsFileExist { get; set; }
    }
}
