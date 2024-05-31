namespace schoolManagementSystem
{
    public static class DatabaseConnection
    {
        public static string ConnectionString { get; } = "server=kypc\\SQLEXPRESS;database=StudentManagementSystem;integrated security=true;";
    }
}