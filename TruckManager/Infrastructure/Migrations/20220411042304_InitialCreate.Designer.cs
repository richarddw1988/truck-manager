﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TruckManager.Infrastructure.Context;

#nullable disable

namespace TruckManager.Infrastructure.Migrations
{
    [DbContext(typeof(TruckManagerContext))]
    [Migration("20220411042304_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TruckManager.Domain.Entity.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(true)
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("BIT")
                        .HasColumnName("ATIVO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.ToTable("MODELO", (string)null);
                });

            modelBuilder.Entity("TruckManager.Domain.Entity.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .IsUnicode(true)
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("INT")
                        .HasColumnName("ANO_FABRICACAO");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("INT")
                        .HasColumnName("ANO_MODELO");

                    b.Property<int>("IdModelo")
                        .HasColumnType("INT")
                        .HasColumnName("ID_MODELO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.HasIndex("IdModelo");

                    b.ToTable("TRUCK", (string)null);
                });

            modelBuilder.Entity("TruckManager.Domain.Entity.Truck", b =>
                {
                    b.HasOne("TruckManager.Domain.Entity.Modelo", "Modelo")
                        .WithOne()
                        .HasForeignKey("TruckManager.Domain.Entity.Truck", "IdModelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modelo");
                });
#pragma warning restore 612, 618
        }
    }
}
