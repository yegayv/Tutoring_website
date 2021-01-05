using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutoring_Website.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    tutor_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tutor_name = table.Column<string>(nullable: false),
                    tutor_description = table.Column<string>(nullable: false),
                    tutor_subjects = table.Column<string>(nullable: false),
                    tutor_rate = table.Column<int>(nullable: false),
                    tutor_img = table.Column<string>(nullable: true),
                    tutor_rating = table.Column<float>(nullable: true),
                    tutor_date_joined = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.tutor_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tutors");
        }
    }
}
