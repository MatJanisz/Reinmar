﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Reinmar.Infrastructure.DataAccess;
using System;

namespace Reinmar.Api.Migrations
{
    [DbContext(typeof(ReinmarDbContext))]
    [Migration("20180317184356_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reinmar.Common.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Reinmar.Common.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateFrom");

                    b.Property<string>("Event");

                    b.Property<string>("Location");

                    b.Property<Guid?>("WaybillBodiesId");

                    b.HasKey("Id");

                    b.HasIndex("WaybillBodiesId");

                    b.ToTable("Statusses");
                });

            modelBuilder.Entity("Reinmar.Common.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Domain");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Reinmar.Common.Entities.Waybill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("HeaderId");

                    b.HasKey("Id");

                    b.HasIndex("HeaderId");

                    b.ToTable("Waybills");
                });

            modelBuilder.Entity("Reinmar.Common.Entities.WaybillBody", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CargoName");

                    b.Property<string>("Category");

                    b.Property<string>("Code");

                    b.Property<bool>("IsAssembly");

                    b.Property<bool>("IsCollection");

                    b.Property<int>("Quantity");

                    b.Property<string>("Service");

                    b.Property<int>("SitId");

                    b.Property<Guid?>("WaybillHeadersId");

                    b.Property<Guid?>("WaybillId");

                    b.Property<int>("Zone");

                    b.HasKey("Id");

                    b.HasIndex("WaybillHeadersId");

                    b.HasIndex("WaybillId");

                    b.ToTable("WaybillBodies");
                });

            modelBuilder.Entity("Reinmar.Common.Entities.WaybillHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CashOnDelivery");

                    b.Property<string>("City");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("HouseNumber");

                    b.Property<string>("InvoiceId");

                    b.Property<string>("Notes");

                    b.Property<string>("OrderName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostalCode");

                    b.Property<int>("SitId");

                    b.Property<string>("StreetName");

                    b.HasKey("Id");

                    b.ToTable("WaybillHeaders");
                });

            modelBuilder.Entity("Reinmar.Common.Entities.Role", b =>
                {
                    b.HasOne("Reinmar.Common.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Reinmar.Common.Entities.Status", b =>
                {
                    b.HasOne("Reinmar.Common.Entities.WaybillBody", "WaybillBodies")
                        .WithMany("Status")
                        .HasForeignKey("WaybillBodiesId");
                });

            modelBuilder.Entity("Reinmar.Common.Entities.Waybill", b =>
                {
                    b.HasOne("Reinmar.Common.Entities.WaybillHeader", "Header")
                        .WithMany()
                        .HasForeignKey("HeaderId");
                });

            modelBuilder.Entity("Reinmar.Common.Entities.WaybillBody", b =>
                {
                    b.HasOne("Reinmar.Common.Entities.WaybillHeader", "WaybillHeaders")
                        .WithMany()
                        .HasForeignKey("WaybillHeadersId");

                    b.HasOne("Reinmar.Common.Entities.Waybill")
                        .WithMany("Body")
                        .HasForeignKey("WaybillId");
                });
#pragma warning restore 612, 618
        }
    }
}
