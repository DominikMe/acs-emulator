﻿// <auto-generated />
using System;
using AcsEmulatorAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcsEmulatorAPI.Migrations
{
    [DbContext(typeof(AcsDbContext))]
    [Migration("20220922132629_AddChatMessageSender")]
    partial class AddChatMessageSender
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("AcsEmulatorAPI.Models.ChatMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ChatThreadId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SenderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("SenderRawId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChatThreadId");

                    b.HasIndex("SenderRawId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("AcsEmulatorAPI.Models.ChatThread", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedByRawId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Topic")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByRawId");

                    b.ToTable("ChatThreads");
                });

            modelBuilder.Entity("AcsEmulatorAPI.Models.User", b =>
                {
                    b.Property<string>("RawId")
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.HasKey("RawId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AcsEmulatorAPI.Models.UserChatThread", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChatThreadId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("ShareHistoryTime")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "ChatThreadId");

                    b.HasIndex("ChatThreadId");

                    b.ToTable("UserChatThread");
                });

            modelBuilder.Entity("AcsEmulatorAPI.Models.ChatMessage", b =>
                {
                    b.HasOne("AcsEmulatorAPI.Models.ChatThread", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatThreadId");

                    b.HasOne("AcsEmulatorAPI.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderRawId");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("AcsEmulatorAPI.Models.ChatThread", b =>
                {
                    b.HasOne("AcsEmulatorAPI.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByRawId");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("AcsEmulatorAPI.Models.UserChatThread", b =>
                {
                    b.HasOne("AcsEmulatorAPI.Models.ChatThread", "ChatThread")
                        .WithMany("UserChatThreads")
                        .HasForeignKey("ChatThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcsEmulatorAPI.Models.User", "User")
                        .WithMany("UserChatThreads")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatThread");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AcsEmulatorAPI.Models.ChatThread", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("UserChatThreads");
                });

            modelBuilder.Entity("AcsEmulatorAPI.Models.User", b =>
                {
                    b.Navigation("UserChatThreads");
                });
#pragma warning restore 612, 618
        }
    }
}
