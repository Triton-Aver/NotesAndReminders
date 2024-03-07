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
    [Migration("20240305192924_createDb")]
    partial class createDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NoteTage", b =>
                {
                    b.Property<int>("NoteId")
                        .HasColumnType("integer");

                    b.Property<int>("TagId")
                        .HasColumnType("integer");

                    b.HasKey("NoteId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("NoteTage");
                });

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

                    b.Property<int?>("Reminder")
                        .HasColumnType("integer");

                    b.HasKey("NoteId");

                    b.HasIndex("Reminder")
                        .IsUnique();

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("NotesAndReminders.DataBase.Models.Reminder", b =>
                {
                    b.Property<int>("ReminderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReminderId"));

                    b.Property<DateTime>("DeadLine")
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

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TagId");

                    b.ToTable("Tages");
                });

            modelBuilder.Entity("NoteTage", b =>
                {
                    b.HasOne("NotesAndReminders.DataBase.Models.Note", null)
                        .WithMany()
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NotesAndReminders.DataBase.Models.Tage", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NotesAndReminders.DataBase.Models.Note", b =>
                {
                    b.HasOne("NotesAndReminders.DataBase.Models.Reminder", "ReminderNote")
                        .WithOne("Note")
                        .HasForeignKey("NotesAndReminders.DataBase.Models.Note", "Reminder");

                    b.Navigation("ReminderNote");
                });

            modelBuilder.Entity("NotesAndReminders.DataBase.Models.Reminder", b =>
                {
                    b.Navigation("Note");
                });
#pragma warning restore 612, 618
        }
    }
}