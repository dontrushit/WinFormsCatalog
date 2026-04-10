# WinFormsCatalog

Десктопное приложение на **C# / Windows Forms** — каталог мобильных телефонов с фильтрами, сортировкой, карточкой товара и экраном оформления заказа. Данные читаются из **Microsoft Access** (`.accdb`) через **OleDb**.

## Возможности

- Каталог в таблице: фильтры (производитель, ОС, цена, наличие), поиск, сортировка
- Карточка телефона: характеристики, цены по магазинам из БД
- Форма заказа: количество, контакты, проверка ввода

## Требования

- Windows  
- [.NET 9 SDK](https://dotnet.microsoft.com/download) (для сборки)  
- [Microsoft Access Database Engine](https://www.microsoft.com/en-us/download/details.aspx?id=54920) (ACE OLEDB 12.0) — для работы с `.accdb`

## Запуск

```bash
git clone <url>
cd <папка-клона>
dotnet build WinFormsCatalog.sln
dotnet run --project WinFormsCatalog/WinFormsCatalog.csproj
```

Или открой **`WinFormsCatalog.sln`** в Visual Studio и запусти (F5).

Файл базы **`Data/PhonesDB1.accdb`** и изображения в **`Data/Images/`** при сборке копируются в выходную папку рядом с `.exe` (см. `WinFormsCatalog.csproj`).

## Структура

| Путь | Назначение |
|------|------------|
| `WinFormsCatalog/` | Проект: формы, модель `Phones`, `DbHelper`, `PhoneImageHelper` |
| `WinFormsCatalog/Data/` | База Access и картинки |
| `WinFormsCatalog.sln` | Решение Visual Studio |

## База данных

Таблицы **Phones** (модели), **Characteristics** (характеристики, FK на телефон), **Shops** (магазины и цены, FK на телефон). Схема подробнее — в коде запроса `LoadPhonesFromDB()` в `Form1.cs`.
