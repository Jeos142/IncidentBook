using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentBook.Migrations
{
    /// <inheritdoc />
    public partial class DbDroped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classification",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Resolution",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "Client",
                table: "TodoItems",
                newName: "ClientId");

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "TodoItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResolutionId",
                table: "TodoItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ClassificationId",
                table: "TodoItems",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ClientId",
                table: "TodoItems",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ResolutionId",
                table: "TodoItems",
                column: "ResolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_ClientItems_ClientId",
                table: "TodoItems",
                column: "ClientId",
                principalTable: "ClientItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_ClosedIncidentsItems_ResolutionId",
                table: "TodoItems",
                column: "ResolutionId",
                principalTable: "ClosedIncidentsItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_IncidentClassifications_ClassificationId",
                table: "TodoItems",
                column: "ClassificationId",
                principalTable: "IncidentClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_ClientItems_ClientId",
                table: "TodoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_ClosedIncidentsItems_ResolutionId",
                table: "TodoItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_IncidentClassifications_ClassificationId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_ClassificationId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_ClientId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_ResolutionId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "ResolutionId",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "TodoItems",
                newName: "Client");

            migrationBuilder.AddColumn<string>(
                name: "Classification",
                table: "TodoItems",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resolution",
                table: "TodoItems",
                type: "text",
                nullable: true);
        }
    }
}
