﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using twitter_clone.Context;

namespace twitter_clone.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20210524221047_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("UserUser", b =>
                {
                    b.Property<string>("FollowersAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FollowersEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("FollowingAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FollowingEmail")
                        .HasColumnType("TEXT");

                    b.HasKey("FollowersAt", "FollowersEmail", "FollowingAt", "FollowingEmail");

                    b.HasIndex("FollowingAt", "FollowingEmail");

                    b.ToTable("UserUser");
                });

            modelBuilder.Entity("twitter_clone.Models.User", b =>
                {
                    b.Property<string>("At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.HasKey("At", "Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.HasOne("twitter_clone.Models.User", null)
                        .WithMany()
                        .HasForeignKey("FollowersAt", "FollowersEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("twitter_clone.Models.User", null)
                        .WithMany()
                        .HasForeignKey("FollowingAt", "FollowingEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}