using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFurnitureStore.Migrations
{
    public partial class migration_v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_order_OrderModelId",
                table: "order_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_product_ProductModelId",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_order_detail_OrderModelId",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_order_detail_ProductModelId",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "OrderModelId",
                table: "order_detail");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                table: "order_detail");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                table: "product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_product_id",
                table: "order_detail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_client_id",
                table: "order",
                column: "client_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_client_client_id",
                table: "order",
                column: "client_id",
                principalTable: "client",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_order_order_id",
                table: "order_detail",
                column: "order_id",
                principalTable: "order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_product_product_id",
                table: "order_detail",
                column: "product_id",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_category_id",
                table: "product",
                column: "category_id",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_client_client_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_order_order_id",
                table: "order_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_order_detail_product_product_id",
                table: "order_detail");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_category_id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_category_id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_order_detail_product_id",
                table: "order_detail");

            migrationBuilder.DropIndex(
                name: "IX_order_client_id",
                table: "order");

            migrationBuilder.AddColumn<int>(
                name: "OrderModelId",
                table: "order_detail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductModelId",
                table: "order_detail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_OrderModelId",
                table: "order_detail",
                column: "OrderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_ProductModelId",
                table: "order_detail",
                column: "ProductModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_order_OrderModelId",
                table: "order_detail",
                column: "OrderModelId",
                principalTable: "order",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_detail_product_ProductModelId",
                table: "order_detail",
                column: "ProductModelId",
                principalTable: "product",
                principalColumn: "id");
        }
    }
}
