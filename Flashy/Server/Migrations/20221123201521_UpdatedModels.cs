using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flashy.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlashcardId",
                table: "Flashcards",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Flashcards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Flashcards",
                newName: "FlashcardId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Flashcards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
