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
    [Migration("20220922174028_AddParticipantsAddedMessage")]
    partial class AddParticipantsAddedMessage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("AcsEmulatorAPI.Models.AddedParticipant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AddParticipantsChatMessageId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ParticipantRawId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("ShareHistoryTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddParticipantsChatMessageId");

                    b.HasIndex("ParticipantRawId");

                    b.ToTable("AddedParticipant");
                });

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

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("SenderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("SenderRawId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SequenceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChatThreadId");

                    b.HasIndex("SenderRawId");

                    b.ToTable("ChatMessages", (string)null);
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

            modelBuilder.Entity("AcsEmulatorAPI.Models.AddParticipantsChatMessage", b =>
                {
                    b.HasBaseType("AcsEmulatorAPI.Models.ChatMessage");

                    b.ToTable("AddParticipantsChatMessages", (string)null);
                });

            modelBuilder.Entity("AcsEmulatorAPI.Models.AddedParticipant", b =>
                {
                    b.HasOne("AcsEmulatorAPI.Models.AddParticipantsChatMessage", null)
                        .WithMany("AddedParticipants")
                        .HasForeignKey("AddParticipantsChatMessageId");

                    b.HasOne("AcsEmulatorAPI.Models.User", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantRawId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");
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

            modelBuilder.Entity("AcsEmulatorAPI.Models.AddParticipantsChatMessage", b =>
                {
                    b.HasOne("AcsEmulatorAPI.Models.ChatMessage", null)
                        .WithOne()
                        .HasForeignKey("AcsEmulatorAPI.Models.AddParticipantsChatMessage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("AcsEmulatorAPI.Models.AddParticipantsChatMessage", b =>
                {
                    b.Navigation("AddedParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
