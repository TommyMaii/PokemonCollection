﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonCollections.Context;

#nullable disable

namespace PokemonCollections.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241203133919_WithUser")]
    partial class WithUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokemonCardPokemonCollection", b =>
                {
                    b.Property<int>("Cardsid")
                        .HasColumnType("int");

                    b.Property<int>("Collectionsid")
                        .HasColumnType("int");

                    b.HasKey("Cardsid", "Collectionsid");

                    b.HasIndex("Collectionsid");

                    b.ToTable("PokemonCardPokemonCollection");
                });

            modelBuilder.Entity("PokemonCollections.Models.PokemonCard", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PokemonCollections.Models.PokemonCollection", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("PokemonCollections.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PokemonCardPokemonCollection", b =>
                {
                    b.HasOne("PokemonCollections.Models.PokemonCard", null)
                        .WithMany()
                        .HasForeignKey("Cardsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonCollections.Models.PokemonCollection", null)
                        .WithMany()
                        .HasForeignKey("Collectionsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonCollections.Models.PokemonCollection", b =>
                {
                    b.HasOne("PokemonCollections.Models.User", null)
                        .WithMany("PokemonCollections")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonCollections.Models.User", b =>
                {
                    b.Navigation("PokemonCollections");
                });
#pragma warning restore 612, 618
        }
    }
}
