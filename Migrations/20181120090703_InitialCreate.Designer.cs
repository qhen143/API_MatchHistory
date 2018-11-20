﻿// <auto-generated />
using API_MatchHistory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_MatchHistory.Migrations
{
    [DbContext(typeof(MatchHistoryContext))]
    [Migration("20181120090703_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("API_MatchHistory.Models.MatchHistoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("Date");

                    b.Property<string>("Game");

                    b.Property<string>("Home");

                    b.Property<string>("Location");

                    b.Property<string>("Opposition");

                    b.Property<string>("Winner");

                    b.HasKey("Id");

                    b.ToTable("MatchHistoryItem");
                });
#pragma warning restore 612, 618
        }
    }
}