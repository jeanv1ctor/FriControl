using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriControl_Api.Migrations
{
    public partial class ModelandoColunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_FornecedorModel_FornecedorModelId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FornecedorModel",
                table: "FornecedorModel");

            migrationBuilder.RenameTable(
                name: "FornecedorModel",
                newName: "Fornecedores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Fornecedores_FornecedorModelId",
                table: "Items",
                column: "FornecedorModelId",
                principalTable: "Fornecedores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Fornecedores_FornecedorModelId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores");

            migrationBuilder.RenameTable(
                name: "Fornecedores",
                newName: "FornecedorModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FornecedorModel",
                table: "FornecedorModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_FornecedorModel_FornecedorModelId",
                table: "Items",
                column: "FornecedorModelId",
                principalTable: "FornecedorModel",
                principalColumn: "Id");
        }
    }
}
