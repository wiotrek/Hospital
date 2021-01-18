namespace Library
{
    public class Person : Human, IPerson
    {
        public Professions Posada { get; set; }
        public Specializations Specjalizacja { get; set; }


        /// <returns>Tak naprawde tego nie potrzebujemy</returns>
        public override string ToString()
        {
            return base.ToString() + $" {Posada.ProffesionsToPolishtString()} spec. {Specjalizacja}";
        }
    }
}
