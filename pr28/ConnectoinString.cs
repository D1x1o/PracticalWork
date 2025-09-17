using System.IO;
using System.Text;
using pr28;

namespace pr28_connection
{
    public static class ConnectoinString
    {
        private const string ConnectionFile = "connection.config";

        public static string GetConnectionString()
        {
            return $"Server={Settings.Default.serverName};" +
                   $"Database={Settings.Default.dbName};" +
                   $"User Id={Settings.Default.nameUser};" +
                   $"Password={Settings.Default.pwdUser};";
        }

        public static void UpdateConnectionString(string newConnectionString)
        {
            File.WriteAllText(ConnectionFile, newConnectionString, Encoding.UTF8);
        }

        private static string GenerateDefaultConnectionString()
        {
            return $"Server={Settings.Default.serverName};" +
                   $"Database={Settings.Default.dbName};" +
                   $"User Id={Settings.Default.nameUser};" +
                   $"Password={Settings.Default.pwdUser};";
        }
    }
}