using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IBSS.VendingMachines.Data;

namespace IBSS.VendingMachines.Migrations
{
    [DbContext(typeof(MachineDB))]
    partial class MachineDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IBSS.VendingMachines.Models.Machines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcceptableCoinsText");

                    b.Property<string>("Name");

                    b.Property<decimal>("TotalAmount");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("IBSS.VendingMachines.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("PictureUrl")
                        .HasAnnotation("MaxLength", 1024);

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });
        }
    }
}
