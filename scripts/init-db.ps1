param(
    [string]$ConnectionString = "Host=localhost;Port=5432;Database=catalog;Username=postgres;Password=YOUR_PASSWORD"
)

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot

Write-Host "Applying EF Core migrations..."
$env:ConnectionStrings__CatalogDb = $ConnectionString
dotnet ef database update --project "$root\WinFormsCatalog.Core" --startup-project "$root\WinFormsCatalog"
Write-Host "Database is ready."
