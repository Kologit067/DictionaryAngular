using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DictionaryCoreAngular.Import.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordListWord_WordList_WordId",
                table: "WordListWord");

            migrationBuilder.CreateIndex(
                name: "IX_WordListWord_WordListId",
                table: "WordListWord",
                column: "WordListId");

            migrationBuilder.AddForeignKey(
                name: "FK_WordListWord_WordList_WordListId",
                table: "WordListWord",
                column: "WordListId",
                principalTable: "WordList",
                principalColumn: "WordListId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordListWord_WordList_WordListId",
                table: "WordListWord");

            migrationBuilder.DropIndex(
                name: "IX_WordListWord_WordListId",
                table: "WordListWord");

            migrationBuilder.AddForeignKey(
                name: "FK_WordListWord_WordList_WordId",
                table: "WordListWord",
                column: "WordId",
                principalTable: "WordList",
                principalColumn: "WordListId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
