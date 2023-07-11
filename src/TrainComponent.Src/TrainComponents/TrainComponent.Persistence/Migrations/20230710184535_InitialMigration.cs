using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainComponent.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainComponentNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanAssignQuantity = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponentNodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainComponentNodeTrainComponentNode",
                columns: table => new
                {
                    ChildTrainComponentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentTrainComponentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainComponentNodeTrainComponentNode", x => new { x.ChildTrainComponentsId, x.ParentTrainComponentsId });
                    table.ForeignKey(
                        name: "FK_TrainComponentNodeTrainComponentNode_TrainComponentNodes_ChildTrainComponentsId",
                        column: x => x.ChildTrainComponentsId,
                        principalTable: "TrainComponentNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainComponentNodeTrainComponentNode_TrainComponentNodes_ParentTrainComponentsId",
                        column: x => x.ParentTrainComponentsId,
                        principalTable: "TrainComponentNodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainComponentNodeTrainComponentNode_ParentTrainComponentsId",
                table: "TrainComponentNodeTrainComponentNode",
                column: "ParentTrainComponentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainComponentNodeTrainComponentNode");

            migrationBuilder.DropTable(
                name: "TrainComponentNodes");
        }
    }
}
