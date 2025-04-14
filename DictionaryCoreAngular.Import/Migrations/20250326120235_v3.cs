using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DictionaryCoreAngular.Import.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComparisonType",
                columns: table => new
                {
                    ComparisonTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComparisonType", x => x.ComparisonTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    TranslationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RawA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RawB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RawC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Short = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Long = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transcription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WordId = table.Column<int>(type: "int", nullable: true),
                    DictionaryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.TranslationId);
                    table.ForeignKey(
                        name: "FK_Translation_Dictionary_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionary",
                        principalColumn: "DictionaryId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Translation_Word_WordId",
                        column: x => x.WordId,
                        principalTable: "Word",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    HistoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WordListGroup",
                columns: table => new
                {
                    WordListGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    DictionaryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordListGroup", x => x.WordListGroupId);
                    table.ForeignKey(
                        name: "FK_WordListGroup_Dictionary_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionary",
                        principalColumn: "DictionaryId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "WordList",
                columns: table => new
                {
                    WordListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    WordListGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordList", x => x.WordListId);
                    table.ForeignKey(
                        name: "FK_WordList_WordListGroup_WordListGroupId",
                        column: x => x.WordListGroupId,
                        principalTable: "WordListGroup",
                        principalColumn: "WordListGroupId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorLevel = table.Column<int>(type: "int", nullable: true),
                    IsPass = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    WordListId = table.Column<int>(type: "int", nullable: true),
                    ComparisonTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_History_ComparisonType_ComparisonTypeId",
                        column: x => x.ComparisonTypeId,
                        principalTable: "ComparisonType",
                        principalColumn: "ComparisonTypeId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_History_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_History_WordList_WordListId",
                        column: x => x.WordListId,
                        principalTable: "WordList",
                        principalColumn: "WordListId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "WordListWord",
                columns: table => new
                {
                    WordListWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordListId = table.Column<int>(type: "int", nullable: true),
                    WordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordListWord", x => x.WordListWordId);
                    table.ForeignKey(
                        name: "FK_WordListWord_WordList_WordId",
                        column: x => x.WordId,
                        principalTable: "WordList",
                        principalColumn: "WordListId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WordListWord_Word_WordId",
                        column: x => x.WordId,
                        principalTable: "Word",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HistoryRound",
                columns: table => new
                {
                    HistoryRoundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErrorLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfAttepts = table.Column<int>(type: "int", nullable: false),
                    HistoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryRound", x => x.HistoryRoundId);
                    table.ForeignKey(
                        name: "FK_HistoryRound_History_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "History",
                        principalColumn: "HistoryId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    StepdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassNumber = table.Column<int>(type: "int", nullable: false),
                    RemainNumber = table.Column<int>(type: "int", nullable: false),
                    ErrorLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HistoryRoundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.StepdId);
                    table.ForeignKey(
                        name: "FK_Step_HistoryRound_HistoryRoundId",
                        column: x => x.HistoryRoundId,
                        principalTable: "HistoryRound",
                        principalColumn: "HistoryRoundId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "WordStatus",
                columns: table => new
                {
                    WordStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorLevel = table.Column<int>(type: "int", nullable: true),
                    IsPass = table.Column<bool>(type: "bit", nullable: false),
                    WordListWordId = table.Column<int>(type: "int", nullable: true),
                    HistoryRoundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordStatus", x => x.WordStatusId);
                    table.ForeignKey(
                        name: "FK_WordStatus_HistoryRound_HistoryRoundId",
                        column: x => x.HistoryRoundId,
                        principalTable: "HistoryRound",
                        principalColumn: "HistoryRoundId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WordStatus_WordListWord_WordListWordId",
                        column: x => x.WordListWordId,
                        principalTable: "WordListWord",
                        principalColumn: "WordListWordId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "StepWord",
                columns: table => new
                {
                    StepdWordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StepdId = table.Column<int>(type: "int", nullable: true),
                    WordListWordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepWord", x => x.StepdWordId);
                    table.ForeignKey(
                        name: "FK_StepWord_Step_StepdId",
                        column: x => x.StepdId,
                        principalTable: "Step",
                        principalColumn: "StepdId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StepWord_WordListWord_WordListWordId",
                        column: x => x.WordListWordId,
                        principalTable: "WordListWord",
                        principalColumn: "WordListWordId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_ComparisonTypeId",
                table: "History",
                column: "ComparisonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_History_UserId",
                table: "History",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_History_WordListId",
                table: "History",
                column: "WordListId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryRound_HistoryId",
                table: "HistoryRound",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Step_HistoryRoundId",
                table: "Step",
                column: "HistoryRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_StepWord_StepdId",
                table: "StepWord",
                column: "StepdId");

            migrationBuilder.CreateIndex(
                name: "IX_StepWord_WordListWordId",
                table: "StepWord",
                column: "WordListWordId");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_DictionaryId",
                table: "Translation",
                column: "DictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_WordId",
                table: "Translation",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordList_WordListGroupId",
                table: "WordList",
                column: "WordListGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WordListGroup_DictionaryId",
                table: "WordListGroup",
                column: "DictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_WordListWord_WordId",
                table: "WordListWord",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_WordStatus_HistoryRoundId",
                table: "WordStatus",
                column: "HistoryRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_WordStatus_WordListWordId",
                table: "WordStatus",
                column: "WordListWordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StepWord");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "WordStatus");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "WordListWord");

            migrationBuilder.DropTable(
                name: "HistoryRound");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "ComparisonType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WordList");

            migrationBuilder.DropTable(
                name: "WordListGroup");
        }
    }
}
