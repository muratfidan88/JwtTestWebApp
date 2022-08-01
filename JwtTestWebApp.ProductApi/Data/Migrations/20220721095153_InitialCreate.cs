using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtTestWebApp.ProductApi.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Samsung", "Telefon", 15.5m, 10 },
                    { 2, "Ipad", "Tablet", 17.5m, 53 },
                    { 3, "Everest", "Mouse", 1.3m, 67 },
                    { 4, "Gaming", "Klavye", 1.7m, 89 },
                    { 5, "BO", "Speaker", 2.5m, 111 },
                    { 6, "GeForce", "Ekran Kartı", 15.8m, 110 },
                    { 7, "Gaming", "Mouse Pad", 0.5m, 8 },
                    { 8, "Marshall", "Kulaklık", 1.75m, 19 },
                    { 9, "Çin Malı", "Telefon Kılıfı", 0.83m, 1 },
                    { 10, "Intel", "İşlemci", 12.11m, 34 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
