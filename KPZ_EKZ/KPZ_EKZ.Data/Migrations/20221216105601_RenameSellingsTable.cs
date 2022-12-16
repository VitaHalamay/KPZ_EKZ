using Microsoft.EntityFrameworkCore.Migrations;

namespace KPZ_EKZ.Data.Migrations
{
    public partial class RenameSellingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellingEntities_CarItems_CarItemId",
                table: "SellingEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_SellingEntities_Sellers_SellerId",
                table: "SellingEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellingEntities",
                table: "SellingEntities");

            migrationBuilder.RenameTable(
                name: "SellingEntities",
                newName: "Sellings");

            migrationBuilder.RenameIndex(
                name: "IX_SellingEntities_SellerId",
                table: "Sellings",
                newName: "IX_Sellings_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_SellingEntities_CarItemId",
                table: "Sellings",
                newName: "IX_Sellings_CarItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellings",
                table: "Sellings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellings_CarItems_CarItemId",
                table: "Sellings",
                column: "CarItemId",
                principalTable: "CarItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellings_Sellers_SellerId",
                table: "Sellings",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellings_CarItems_CarItemId",
                table: "Sellings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellings_Sellers_SellerId",
                table: "Sellings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellings",
                table: "Sellings");

            migrationBuilder.RenameTable(
                name: "Sellings",
                newName: "SellingEntities");

            migrationBuilder.RenameIndex(
                name: "IX_Sellings_SellerId",
                table: "SellingEntities",
                newName: "IX_SellingEntities_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Sellings_CarItemId",
                table: "SellingEntities",
                newName: "IX_SellingEntities_CarItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellingEntities",
                table: "SellingEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SellingEntities_CarItems_CarItemId",
                table: "SellingEntities",
                column: "CarItemId",
                principalTable: "CarItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellingEntities_Sellers_SellerId",
                table: "SellingEntities",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
