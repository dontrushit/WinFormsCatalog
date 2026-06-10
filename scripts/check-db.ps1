param(
    [string]$ConnectionString = "Host=localhost;Port=5432;Database=catalog;Username=catalog;Password=catalog"
)

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot

Write-Host "Applying migrations (if needed)..."
$env:ConnectionStrings__CatalogDb = $ConnectionString
dotnet ef database update --project "$root\WinFormsCatalog.Core" --startup-project "$root\WinFormsCatalog" --configuration Release

Write-Host ""
Write-Host "Running database integration tests..."
$env:CATALOG_DB_CONNECTION = $ConnectionString
dotnet test "$root\WinFormsCatalog.Tests\WinFormsCatalog.Tests.csproj" -c Release --filter "FullyQualifiedName~IntegrationTests|FullyQualifiedName~OrderService"
