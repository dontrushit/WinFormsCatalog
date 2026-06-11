using Npgsql;

namespace WinFormsCatalog.Helpers;

public static class DatabaseErrorHelper
{
    public static string ToUserMessage(Exception exception)
    {
        if (TryFindPostgresException(exception, out var postgres))
        {
            return postgres.SqlState switch
            {
                PostgresErrorCodes.InvalidPassword => "Неверный логин или пароль PostgreSQL.",
                "3D000" => "База данных catalog не найдена.",
                "42P01" => "Таблицы не созданы. Выполните install-catalog.sql или init-db.ps1.",
                PostgresErrorCodes.ConnectionFailure => "PostgreSQL недоступен на localhost:5432.",
                _ => $"Ошибка PostgreSQL ({postgres.SqlState}): {postgres.MessageText}"
            };
        }

        if (exception is NpgsqlException { InnerException: TimeoutException })
        {
            return "Таймаут подключения к PostgreSQL.";
        }

        return exception.Message;
    }

    private static bool TryFindPostgresException(Exception exception, out PostgresException postgres)
    {
        for (var current = exception; current is not null; current = current.InnerException)
        {
            if (current is PostgresException pg)
            {
                postgres = pg;
                return true;
            }
        }

        postgres = null!;
        return false;
    }
}
