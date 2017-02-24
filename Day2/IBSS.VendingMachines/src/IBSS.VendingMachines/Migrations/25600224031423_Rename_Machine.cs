using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IBSS.VendingMachines.Migrations
{
    public partial class Rename_Machine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slot_Machines_MachinesId",
                table: "Slot");

            migrationBuilder.RenameColumn(
                name: "MachinesId",
                table: "Slot",
                newName: "MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_Slot_MachinesId",
                table: "Slot",
                newName: "IX_Slot_MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slot_Machines_MachineId",
                table: "Slot",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slot_Machines_MachineId",
                table: "Slot");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "Slot",
                newName: "MachinesId");

            migrationBuilder.RenameIndex(
                name: "IX_Slot_MachineId",
                table: "Slot",
                newName: "IX_Slot_MachinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slot_Machines_MachinesId",
                table: "Slot",
                column: "MachinesId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
