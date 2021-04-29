using Microsoft.EntityFrameworkCore.Migrations;
using TechnicalChallengeApp.DataRepository.Table;

namespace TechnicalChallengeApp.DataRepository.Migrations
{
    public partial class AddLastTotalColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: nameof(SessionData.LastTotal),
                table: nameof(SessionData),
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: nameof(SessionData.LastTotal),
                table: nameof(SessionData));
        }
    }
}
