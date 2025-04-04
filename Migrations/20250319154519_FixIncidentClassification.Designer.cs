﻿// <auto-generated />
using System;
using IncidentBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IncidentBook.Migrations
{
    [DbContext(typeof(IncidentContext))]
    [Migration("20250319154519_FixIncidentClassification")]
    partial class FixIncidentClassification
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IncidentBook.Models.ClientItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ClientItems");
                });

            modelBuilder.Entity("IncidentBook.Models.ClosedIncidentsItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Resolution")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ClosedIncidentsItems");
                });

            modelBuilder.Entity("IncidentBook.Models.IncidentClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassificationName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("IncidentClassifications");
                });

            modelBuilder.Entity("IncidentBook.Models.IncidentItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ClassificationId")
                        .HasColumnType("integer");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("boolean");

                    b.Property<int?>("ResolutionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ResolutionId");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("IncidentBook.Models.IncidentItem", b =>
                {
                    b.HasOne("IncidentBook.Models.IncidentClassification", "Classification")
                        .WithMany("Incidents")
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IncidentBook.Models.ClientItem", "ClientItem")
                        .WithMany("Incidents")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IncidentBook.Models.ClosedIncidentsItem", "Resolution")
                        .WithMany("Incidents")
                        .HasForeignKey("ResolutionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Classification");

                    b.Navigation("ClientItem");

                    b.Navigation("Resolution");
                });

            modelBuilder.Entity("IncidentBook.Models.ClientItem", b =>
                {
                    b.Navigation("Incidents");
                });

            modelBuilder.Entity("IncidentBook.Models.ClosedIncidentsItem", b =>
                {
                    b.Navigation("Incidents");
                });

            modelBuilder.Entity("IncidentBook.Models.IncidentClassification", b =>
                {
                    b.Navigation("Incidents");
                });
#pragma warning restore 612, 618
        }
    }
}
