using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IBSS.VendingMachines.Data;

namespace IBSS.VendingMachines.Migrations
{
    [DbContext(typeof(MachineDB))]
    [Migration("25600224080036_Add_Timestamp")]
    partial class Add_Timestamp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IBSS.VendingMachines.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcceptableCoinsText");

                    b.Property<string>("Name");

                    b.Property<decimal>("SellAmount");

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

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("IBSS.VendingMachines.Models.Slot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MachineId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.HasIndex("ProductId");

                    b.ToTable("Slot");
                });

            modelBuilder.Entity("IBSS.VendingMachines.Models.Slot", b =>
                {
                    b.HasOne("IBSS.VendingMachines.Models.Machine")
                        .WithMany("Slots")
                        .HasForeignKey("MachineId");

                    b.HasOne("IBSS.VendingMachines.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
        }
    }
}
