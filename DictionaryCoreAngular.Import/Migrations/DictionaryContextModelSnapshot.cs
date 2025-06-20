﻿// <auto-generated />
using System;
using DictionaryCoreAngular.Import.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DictionaryCoreAngular.Import.Migrations
{
    [DbContext(typeof(DictionaryContext))]
    partial class DictionaryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.ComparisonType", b =>
                {
                    b.Property<int>("ComparisonTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComparisonTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComparisonTypeId");

                    b.ToTable("ComparisonType", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.Dictionary", b =>
                {
                    b.Property<int>("DictionaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DictionaryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DictionaryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Dictionary", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.DictionarySource", b =>
                {
                    b.Property<int>("DictionarySourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DictionarySourceId"));

                    b.Property<int?>("DictionaryId")
                        .HasColumnType("int");

                    b.Property<int?>("DictionaryTranslationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DictionarySourceId");

                    b.HasIndex("DictionaryId");

                    b.HasIndex("DictionaryTranslationId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DictionarySource", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.DictionarySourceWord", b =>
                {
                    b.Property<int>("DictionarySourceWordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DictionarySourceWordId"));

                    b.Property<int?>("DictionarySourceId")
                        .HasColumnType("int");

                    b.Property<string>("Transcription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WordId")
                        .HasColumnType("int");

                    b.HasKey("DictionarySourceWordId");

                    b.HasIndex("DictionarySourceId");

                    b.HasIndex("WordId", "DictionarySourceId")
                        .IsUnique()
                        .HasFilter("[WordId] IS NOT NULL AND [DictionarySourceId] IS NOT NULL");

                    b.ToTable("DictionarySourceWord", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoryId"));

                    b.Property<int?>("ComparisonTypeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("ErrorLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsPass")
                        .HasColumnType("bit");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.Property<int?>("WordListId")
                        .HasColumnType("int");

                    b.HasKey("HistoryId");

                    b.HasIndex("ComparisonTypeId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1")
                        .IsUnique()
                        .HasFilter("[UserId1] IS NOT NULL");

                    b.HasIndex("WordListId");

                    b.ToTable("History", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.HistoryRound", b =>
                {
                    b.Property<int>("HistoryRoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistoryRoundId"));

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ErrorLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("HistoryId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfAttepts")
                        .HasColumnType("int");

                    b.HasKey("HistoryRoundId");

                    b.HasIndex("HistoryId");

                    b.ToTable("HistoryRound", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.Step", b =>
                {
                    b.Property<int>("StepdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StepdId"));

                    b.Property<decimal>("ErrorLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("HistoryRoundId")
                        .HasColumnType("int");

                    b.Property<int>("PassNumber")
                        .HasColumnType("int");

                    b.Property<int>("RemainNumber")
                        .HasColumnType("int");

                    b.HasKey("StepdId");

                    b.HasIndex("HistoryRoundId");

                    b.ToTable("Step", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.StepWord", b =>
                {
                    b.Property<int>("StepdWordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StepdWordId"));

                    b.Property<decimal>("ErrorLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StepWordStatus")
                        .HasColumnType("int");

                    b.Property<int?>("StepdId")
                        .HasColumnType("int");

                    b.Property<int?>("WordListWordId")
                        .HasColumnType("int");

                    b.HasKey("StepdWordId");

                    b.HasIndex("StepdId");

                    b.HasIndex("WordListWordId");

                    b.ToTable("StepWord", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.Translation", b =>
                {
                    b.Property<int>("TranslationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TranslationId"));

                    b.Property<int?>("DictionaryId")
                        .HasColumnType("int");

                    b.Property<string>("Long")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RawA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RawB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RawC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Short")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transcription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WordId")
                        .HasColumnType("int");

                    b.HasKey("TranslationId");

                    b.HasIndex("DictionaryId");

                    b.HasIndex("WordId");

                    b.ToTable("Translation", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passwird")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordId"));

                    b.Property<int?>("DictionaryId")
                        .HasColumnType("int");

                    b.Property<string>("Transcription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("WordText")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("WordId");

                    b.HasIndex("DictionaryId");

                    b.HasIndex("WordText", "DictionaryId")
                        .IsUnique()
                        .HasFilter("[DictionaryId] IS NOT NULL");

                    b.ToTable("Word", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.WordList", b =>
                {
                    b.Property<int>("WordListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordListId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WordListGroupId")
                        .HasColumnType("int");

                    b.HasKey("WordListId");

                    b.HasIndex("WordListGroupId");

                    b.ToTable("WordList", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.WordListGroup", b =>
                {
                    b.Property<int>("WordListGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordListGroupId"));

                    b.Property<int?>("DictionaryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WordListGroupId");

                    b.HasIndex("DictionaryId");

                    b.ToTable("WordListGroup", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.WordListWord", b =>
                {
                    b.Property<int>("WordListWordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordListWordId"));

                    b.Property<int?>("WordId")
                        .HasColumnType("int");

                    b.Property<int?>("WordListId")
                        .HasColumnType("int");

                    b.HasKey("WordListWordId");

                    b.HasIndex("WordId");

                    b.HasIndex("WordListId");

                    b.ToTable("WordListWord", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.WordStatus", b =>
                {
                    b.Property<int>("WordStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordStatusId"));

                    b.Property<decimal?>("ErrorLevel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("HistoryRoundId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPass")
                        .HasColumnType("bit");

                    b.Property<int?>("WordListWordId")
                        .HasColumnType("int");

                    b.HasKey("WordStatusId");

                    b.HasIndex("HistoryRoundId");

                    b.HasIndex("WordListWordId");

                    b.ToTable("WordStatus", (string)null);
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.DictionarySource", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.Dictionary", "Dictionary")
                        .WithMany("DictionarySources")
                        .HasForeignKey("DictionaryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DictionaryCoreAngular.Import.Context.Dictionary", "DictionaryTranslation")
                        .WithMany("DictionarySourceTranslations")
                        .HasForeignKey("DictionaryTranslationId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Dictionary");

                    b.Navigation("DictionaryTranslation");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.DictionarySourceWord", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.DictionarySource", "DictionarySource")
                        .WithMany("DictionarySourceWords")
                        .HasForeignKey("DictionarySourceId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DictionaryCoreAngular.Import.Context.Word", "Word")
                        .WithMany("DictionarySourceWords")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("DictionarySource");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.History", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.ComparisonType", "ComparisonType")
                        .WithMany("Histories")
                        .HasForeignKey("ComparisonTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DictionaryCoreAngular.Import.Context.User", "User")
                        .WithMany("Histories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DictionaryCoreAngular.Import.Context.User", null)
                        .WithOne("CurrentHistory")
                        .HasForeignKey("DictionaryCoreAngular.Import.Context.History", "UserId1");

                    b.HasOne("DictionaryCoreAngular.Import.Context.WordList", "WordList")
                        .WithMany("Histories")
                        .HasForeignKey("WordListId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ComparisonType");

                    b.Navigation("User");

                    b.Navigation("WordList");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.HistoryRound", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.History", "History")
                        .WithMany("HistoryRounds")
                        .HasForeignKey("HistoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("History");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.Step", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.HistoryRound", "HistoryRound")
                        .WithMany("Steps")
                        .HasForeignKey("HistoryRoundId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HistoryRound");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.StepWord", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.Step", "Step")
                        .WithMany("StepWords")
                        .HasForeignKey("StepdId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DictionaryCoreAngular.Import.Context.WordListWord", "WordListWord")
                        .WithMany("StepWords")
                        .HasForeignKey("WordListWordId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Step");

                    b.Navigation("WordListWord");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.Translation", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.Dictionary", "Dictionary")
                        .WithMany("Translations")
                        .HasForeignKey("DictionaryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DictionaryCoreAngular.Import.Context.Word", "Word")
                        .WithMany("Translations")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Dictionary");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.Word", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.Dictionary", "Dictionary")
                        .WithMany("Words")
                        .HasForeignKey("DictionaryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Dictionary");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.WordList", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.WordListGroup", "WordListGroup")
                        .WithMany("WordLists")
                        .HasForeignKey("WordListGroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("WordListGroup");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.WordListGroup", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.Dictionary", "Dictionary")
                        .WithMany("WordListGroups")
                        .HasForeignKey("DictionaryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Dictionary");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.WordListWord", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.Word", "Word")
                        .WithMany("WordListWords")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DictionaryCoreAngular.Import.Context.WordList", "WordList")
                        .WithMany("WordListWords")
                        .HasForeignKey("WordListId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Word");

                    b.Navigation("WordList");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.WordStatus", b =>
                {
                    b.HasOne("DictionaryCoreAngular.Import.Context.HistoryRound", "HistoryRound")
                        .WithMany("WordStatuses")
                        .HasForeignKey("HistoryRoundId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DictionaryCoreAngular.Import.Context.WordListWord", "WordListWord")
                        .WithMany("WordStatuses")
                        .HasForeignKey("WordListWordId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HistoryRound");

                    b.Navigation("WordListWord");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.ComparisonType", b =>
                {
                    b.Navigation("Histories");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.Dictionary", b =>
                {
                    b.Navigation("DictionarySourceTranslations");

                    b.Navigation("DictionarySources");

                    b.Navigation("Translations");

                    b.Navigation("WordListGroups");

                    b.Navigation("Words");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.DictionarySource", b =>
                {
                    b.Navigation("DictionarySourceWords");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.History", b =>
                {
                    b.Navigation("HistoryRounds");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.HistoryRound", b =>
                {
                    b.Navigation("Steps");

                    b.Navigation("WordStatuses");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.Step", b =>
                {
                    b.Navigation("StepWords");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.User", b =>
                {
                    b.Navigation("CurrentHistory");

                    b.Navigation("Histories");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.Word", b =>
                {
                    b.Navigation("DictionarySourceWords");

                    b.Navigation("Translations");

                    b.Navigation("WordListWords");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.WordList", b =>
                {
                    b.Navigation("Histories");

                    b.Navigation("WordListWords");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.WordListGroup", b =>
                {
                    b.Navigation("WordLists");
                });

            modelBuilder.Entity("DictionaryCoreAngular.Import.Context.WordListWord", b =>
                {
                    b.Navigation("StepWords");

                    b.Navigation("WordStatuses");
                });
#pragma warning restore 612, 618
        }
    }
}
