﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IBSS.VendingMachines.Data;

namespace IBSS.VendingMachines.Migrations
{
    [DbContext(typeof(MachineDB))]
    [Migration("25600222042446_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IBSS.VendingMachines.Models.Machines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcceptableCoinsText");

                    b.Property<decimal>("TotalAmount");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });
        }
    }
}
