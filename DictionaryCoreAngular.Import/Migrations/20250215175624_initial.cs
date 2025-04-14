using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DictionaryCoreAngular.Import.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dictionary",
                columns: table => new
                {
                    DictionaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary", x => x.DictionaryId);
                });

            migrationBuilder.CreateTable(
                name: "DictionarySource",
                columns: table => new
                {
                    DictionarySourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DictionaryId = table.Column<int>(type: "int", nullable: true),
                    DictionaryTranslationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionarySource", x => x.DictionarySourceId);
                    table.ForeignKey(
                        name: "FK_DictionarySource_Dictionary_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionary",
                        principalColumn: "DictionaryId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DictionarySource_Dictionary_DictionaryTranslationId",
                        column: x => x.DictionaryTranslationId,
                        principalTable: "Dictionary",
                        principalColumn: "DictionaryId");
                });

            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transcription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DictionaryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.WordId);
                    table.ForeignKey(
                        name: "FK_Word_Dictionary_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionary",
                        principalColumn: "DictionaryId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DictionarySourceWord",
                columns: table => new
                {
                    DictionarySourceWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictionarySourceId = table.Column<int>(type: "int", nullable: true),
                    WordId = table.Column<int>(type: "int", nullable: true),
                    Transcription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionarySourceWord", x => x.DictionarySourceWordId);
                    table.ForeignKey(
                        name: "FK_DictionarySourceWord_DictionarySource_DictionarySourceId",
                        column: x => x.DictionarySourceId,
                        principalTable: "DictionarySource",
                        principalColumn: "DictionarySourceId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DictionarySourceWord_Word_WordId",
                        column: x => x.WordId,
                        principalTable: "Word",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dictionary_Name",
                table: "Dictionary",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DictionarySource_DictionaryId",
                table: "DictionarySource",
                column: "DictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionarySource_DictionaryTranslationId",
                table: "DictionarySource",
                column: "DictionaryTranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionarySource_Name",
                table: "DictionarySource",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DictionarySourceWord_DictionarySourceId",
                table: "DictionarySourceWord",
                column: "DictionarySourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionarySourceWord_WordId_DictionarySourceId",
                table: "DictionarySourceWord",
                columns: new[] { "WordId", "DictionarySourceId" },
                unique: true,
                filter: "[WordId] IS NOT NULL AND [DictionarySourceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Word_DictionaryId",
                table: "Word",
                column: "DictionaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DictionarySourceWord");

            migrationBuilder.DropTable(
                name: "DictionarySource");

            migrationBuilder.DropTable(
                name: "Word");

            migrationBuilder.DropTable(
                name: "Dictionary");
        }
    }
}
