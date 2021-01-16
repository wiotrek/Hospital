using System.Collections.Generic;

namespace Library.Database
{
    public interface IJsonDatabase<T>
    {
        /// <summary>
        /// Nazwa pliku w ktorym zapisane sa dane
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Pobiera zapisane dane z pliku
        /// </summary>
        /// <returns>Zwraca cala liste uzytkownikow z pliku json zapisanego w pliku tekstowym</returns>
        public List<T> GetData();

        /// <summary>
        /// Aktualizuje baze danych przyjmujac nowa liste
        /// </summary>
        /// <param name="list"></param>
        public void UpdateDatabase(List<T> list);
    }
}
