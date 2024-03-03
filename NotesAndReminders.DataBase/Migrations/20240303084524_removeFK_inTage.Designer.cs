﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotesAndReminders.DataBase.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NotesAndReminders.DataBase.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240303084524_removeFK_inTage")]
    partial class removeFK_inTage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NotesAndReminders.DataBase.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NoteId"));

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("NoteId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("NotesAndReminders.DataBase.Models.Reminder", b =>
                {
                    b.Property<int>("ReminderId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ReminderId");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("NotesAndReminders.DataBase.Models.Tage", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TagId"));

                    b.Property<int?>("NoteId")
                        .HasColumnType("integer");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TagId");

                    b.HasIndex("NoteId");

                    b.ToTable("Tages");
                });

            modelBuilder.Entity("NotesAndReminders.DataBase.Models.Reminder", b =>
                {
                    b.HasOne("NotesAndReminders.DataBase.Models.Note", "Note")
                        .WithMany()
                        .HasForeignKey("ReminderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");
                });

            modelBuilder.Entity("NotesAndReminders.DataBase.Models.Tage", b =>
                {
                    b.HasOne("NotesAndReminders.DataBase.Models.Note", null)
                        .WithMany("Tages")
                        .HasForeignKey("NoteId");
                });

            modelBuilder.Entity("NotesAndReminders.DataBase.Models.Note", b =>
                {
                    b.Navigation("Tages");
                });
#pragma warning restore 612, 618
        }
    }
}
