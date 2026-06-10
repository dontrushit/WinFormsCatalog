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
                PostgresErrorCodes.InvalidPassword =>
                    "Ошибка авторизации PostgreSQL.\n\n" +
                    "Проверьте логин и пароль в appsettings.Development.json " +
                    "(см. appsettings.example.json).",
                "3D000" =>
                    "База данных 'catalog' не найдена.\n\n" +
                    "Создайте базу и выполните database/install-catalog.sql " +
                    "или команду: .\\scripts\\init-db.ps1",
                "42P01" =>
                    "Таблицы каталога не созданы.\n\n" +
                    "Выполните database/install-catalog.sql в DBeaver " +
                    "или команду: .\\scripts\\init-db.ps1",
                PostgresErrorCodes.ConnectionFailure =>
                    "Не удалось подключиться к PostgreSQL на localhost:5432.\n\n" +
                    "Убедитесь, что сервер запущен.",
                _ =>
                    $"Ошибка PostgreSQL ({postgres.SqlState}): {postgres.MessageText}"
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
