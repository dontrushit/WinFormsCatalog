-- Выполните от имени суперпользователя PostgreSQL (обычно postgres),
-- если используете локальный PostgreSQL вместо Docker.

DO
$$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_roles WHERE rolname = 'catalog') THEN
        CREATE ROLE catalog WITH LOGIN PASSWORD 'catalog';
    ELSE
        ALTER ROLE catalog WITH LOGIN PASSWORD 'catalog';
    END IF;
END
$$;

SELECT 'CREATE DATABASE catalog OWNER catalog'
WHERE NOT EXISTS (SELECT 1 FROM pg_database WHERE datname = 'catalog')\gexec

GRANT ALL PRIVILEGES ON DATABASE catalog TO catalog;
