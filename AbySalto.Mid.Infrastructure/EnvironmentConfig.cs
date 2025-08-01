using DotNetEnv;
namespace AbySalto.Mid.Infrastructure;

public static class EnvConfig
{
    public static readonly string POSTGRES_DB;
    public static readonly string POSTGRES_USER;
    public static readonly string POSTGRES_PASSWORD;
    public static readonly string DB_CONNECTION_STRING;

    static EnvConfig()
    {
        Env.Load("../.env");

        POSTGRES_DB = GetRequired("POSTGRES_DB");
        POSTGRES_USER = GetRequired("POSTGRES_USER");
        POSTGRES_PASSWORD = GetRequired("POSTGRES_PASSWORD");
        DB_CONNECTION_STRING = $"Server=localhost;Database={POSTGRES_DB};Username={POSTGRES_USER};Password={POSTGRES_PASSWORD}";
    }

    private static string GetRequired(string key)
    {
        var value = Environment.GetEnvironmentVariable(key);
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"Missing environment variable: {key}");
        }

        return value;
    }
}
