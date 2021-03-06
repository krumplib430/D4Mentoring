﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NoteTaking.DataAccess.EfCore;
using System;

namespace NoteTaking.DataAccess.EfCore.Migrations
{
    [DbContext(typeof(NoteTakingContext))]
    [Migration("20170828143740_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("NoteTaking.DataAccess.EfCore.Models.NoteDao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Note");

                    b.Property<Guid?>("UserDaoId");

                    b.HasKey("Id");

                    b.HasIndex("UserDaoId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("NoteTaking.DataAccess.EfCore.Models.UserDao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("Lastname");

                    b.Property<DateTime>("RegisteredDateTime");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NoteTaking.DataAccess.EfCore.Models.NoteDao", b =>
                {
                    b.HasOne("NoteTaking.DataAccess.EfCore.Models.UserDao")
                        .WithMany("Notes")
                        .HasForeignKey("UserDaoId");
                });
#pragma warning restore 612, 618
        }
    }
}
