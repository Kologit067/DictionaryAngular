using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DictionaryCoreAngular.Import.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Word_WordText",
                table: "Word");

            migrationBuilder.CreateIndex(
                name: "IX_Word_WordText_DictionaryId",
                table: "Word",
                columns: new[] { "WordText", "DictionaryId" },
                unique: true,
                filter: "[DictionaryId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Word_WordText_DictionaryId",
                table: "Word");

            migrationBuilder.CreateIndex(
                name: "IX_Word_WordText",
                table: "Word",
                column: "WordText",
                unique: true);
        }
    }
}
