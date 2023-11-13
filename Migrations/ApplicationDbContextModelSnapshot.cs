﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeachersBingoApi.Data;

#nullable disable

namespace TeachersBingoApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TeachersBingoApi.Models.Bingo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Bingos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bingo 1"
                        });
                });

            modelBuilder.Entity("TeachersBingoApi.Models.Phrase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BingoId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BingoId");

                    b.ToTable("Phrase");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BingoId = 1,
                            Content = "Phrase 1"
                        },
                        new
                        {
                            Id = 2,
                            BingoId = 1,
                            Content = "Phrase 2"
                        },
                        new
                        {
                            Id = 3,
                            BingoId = 1,
                            Content = "Phrase 3"
                        },
                        new
                        {
                            Id = 4,
                            BingoId = 1,
                            Content = "Phrase 4"
                        },
                        new
                        {
                            Id = 5,
                            BingoId = 1,
                            Content = "Phrase 5"
                        },
                        new
                        {
                            Id = 6,
                            BingoId = 1,
                            Content = "Phrase 6"
                        },
                        new
                        {
                            Id = 7,
                            BingoId = 1,
                            Content = "Phrase 7"
                        },
                        new
                        {
                            Id = 8,
                            BingoId = 1,
                            Content = "Phrase 8"
                        },
                        new
                        {
                            Id = 9,
                            BingoId = 1,
                            Content = "Phrase 9"
                        });
                });

            modelBuilder.Entity("TeachersBingoApi.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CurrentBingoChoices")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TeachersBingoApi.Models.Phrase", b =>
                {
                    b.HasOne("TeachersBingoApi.Models.Bingo", "Bingo")
                        .WithMany("Phrases")
                        .HasForeignKey("BingoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bingo");
                });

            modelBuilder.Entity("TeachersBingoApi.Models.Bingo", b =>
                {
                    b.Navigation("Phrases");
                });
#pragma warning restore 612, 618
        }
    }
}
