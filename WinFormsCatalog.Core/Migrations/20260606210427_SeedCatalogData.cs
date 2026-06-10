using Microsoft.EntityFrameworkCore.Migrations;
using WinFormsCatalog.Data.Seed;

#nullable disable

namespace WinFormsCatalog.Migrations
{
    /// <inheritdoc />
    public partial class SeedCatalogData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(CatalogSeed.GetSql());
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                TRUNCATE orders, shops, characteristics, phones RESTART IDENTITY CASCADE;
                """);
        }
    }
}
