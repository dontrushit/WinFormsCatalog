using System.IO;

namespace WinFormsKursach.Helpers
{
    public static class DbHelper
    {
        public static string GetDbPath()
        {
            return Path.Combine(AppContext.BaseDirectory, "Data", "PhonesDB1.accdb");
        }

        public static string GetConnectionString()
        {
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={GetDbPath()}";
        }
    }
}
