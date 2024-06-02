namespace schoolManagementSystem
{
    public static class DatabaseConnection
    {
        public static string ConnectionString { get; } = "server=kypc\\SQLEXPRESS;database=SchoolSystem;integrated security=true;";
    }
}