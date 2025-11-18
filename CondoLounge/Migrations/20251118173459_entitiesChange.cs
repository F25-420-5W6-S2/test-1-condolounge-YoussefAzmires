using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondoLounge.Migrations
{
    /// <inheritdoc />
    public partial class entitiesChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Building_BuildingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Condo_Building_BuildingId",
                table: "Condo");

            migrationBuilder.DropTable(
                name: "ApplicationUserCondo");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BuildingId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Condo",
                table: "Condo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Building",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Condo",
                newName: "Condos");

            migrationBuilder.RenameTable(
                name: "Building",
                newName: "Buildings");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Condos",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Condo_BuildingId",
                table: "Condos",
                newName: "IX_Condos_BuildingId");

            migrationBuilder.AlterColumn<string>(
                name: "CondoNumber",
                table: "Condos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Condos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Condos",
                table: "Condos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Condos_UserId",
                table: "Condos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Condos_AspNetUsers_UserId",
                table: "Condos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Condos_Buildings_BuildingId",
                table: "Condos",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Condos_AspNetUsers_UserId",
                table: "Condos");

            migrationBuilder.DropForeignKey(
                name: "FK_Condos_Buildings_BuildingId",
                table: "Condos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Condos",
                table: "Condos");

            migrationBuilder.DropIndex(
                name: "IX_Condos_UserId",
                table: "Condos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Condos");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Buildings");

            migrationBuilder.RenameTable(
                name: "Condos",
                newName: "Condo");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "Building");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Condo",
                newName: "Location");

            migrationBuilder.RenameIndex(
                name: "IX_Condos_BuildingId",
                table: "Condo",
                newName: "IX_Condo_BuildingId");

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CondoNumber",
                table: "Condo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Condo",
                table: "Condo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Building",
                table: "Building",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationUserCondo",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    condosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserCondo", x => new { x.UsersId, x.condosId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserCondo_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserCondo_Condo_condosId",
                        column: x => x.condosId,
                        principalTable: "Condo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BuildingId",
                table: "AspNetUsers",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCondo_condosId",
                table: "ApplicationUserCondo",
                column: "condosId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Building_BuildingId",
                table: "AspNetUsers",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Condo_Building_BuildingId",
                table: "Condo",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
