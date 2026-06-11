# WinFormsCatalog

Каталог мобильных телефонов: WinForms + PostgreSQL.

## Возможности

- список телефонов с фильтрами и сортировкой
- карточка товара и цены в магазинах
- оформление заказа

## Запуск

1. Поднять PostgreSQL (`docker compose up -d` или локальный сервер).
2. Создать БД `catalog` и выполнить `database/install-catalog.sql`  
   либо: `.\scripts\init-db.ps1`
3. Скопировать `WinFormsCatalog\appsettings.example.json` в `appsettings.Development.json` и указать пароль.
4. `dotnet run --project WinFormsCatalog`

## Тесты

```powershell
.\scripts\check-db.ps1
```

## Стек

.NET 9, WinForms, PostgreSQL 16, EF Core, xUnit.
