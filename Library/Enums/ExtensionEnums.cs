using Library;

namespace Library
{
    public static class ExtensionEnums
    {

        /// <returns>Zwraca odmieniony zawod</returns>
        public static string ProffesionsToPolishVariantString(this Professions profession)
        {
            return profession switch
            {
                Professions.Nurse => "pielegniarzy/pielegniarek",
                Professions.Doctor => "doktorow/doktorek",
                Professions.Administrator => "administratorow/administratorek",
                Professions.Unknown => "nieznanych",
                _ => "nieznanych",
            };
        }

        /// <returns>Zwraca odmieniony zawod</returns>
        public static string ProffesionsToPolishtString(this Professions profession)
        {
            return profession switch
            {
                Professions.Nurse => "pielegniarz/pielegniarka",
                Professions.Doctor => "doktor/doktorka",
                Professions.Administrator => "administrator/administratorka",
                Professions.Unknown => "nieznany",
                _ => "nieznana",
            };
        }
    }
}
