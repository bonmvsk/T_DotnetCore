using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IBSS.VendingMachines.Data;

namespace IBSS.VendingMachines.Migrations
{
    [DbContext(typeof(MachineDB))]
    [Migration("25600223063158_Add_Slot")]
    partial class Add_Slot
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

            modelBuilder.Entity("IBSS.VendingMachines.Models.Slot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MachinesId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("MachinesId");

                    b.HasIndex("ProductId");

                    b.ToTable("Slot");
                });

            modelBuilder.Entity("IBSS.VendingMachines.Models.Slot", b =>
                {
                    b.HasOne("IBSS.VendingMachines.Models.Machines")
                        .WithMany("Slots")
                        .HasForeignKey("MachinesId");

                    b.HasOne("IBSS.VendingMachines.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
        }
    }
}
