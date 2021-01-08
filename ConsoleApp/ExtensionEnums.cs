using Library;

namespace ConsoleApp
{
    public static class ExtensionEnums
    {
        /// <summary>
        /// odmienia zawod na polski
        /// </summary>
        /// <param name="profession"></param>
        /// <returns></returns>
        public static string ProffesionsToPolishString(this Professions profession)
        {
            switch (profession)
            {
                case Professions.Nurse:
                    return "pielegniarzy/pielegniarek";
                case Professions.Doctor:
                    return "doktorow/doktorek";
                case Professions.Administrator:
                    return "administratorow/administratorek";
                default:
                    return "nieznanych";
            }
        }
    }
}
