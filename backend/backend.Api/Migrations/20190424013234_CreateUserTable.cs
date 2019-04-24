using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Api.Migrations
{
    public partial class CreateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    user_name = table.Column<string>(maxLength: 64, nullable: true),
                    nick_name = table.Column<string>(maxLength: 64, nullable: true),
                    phone = table.Column<string>(maxLength: 64, nullable: true),
                    email = table.Column<string>(maxLength: 64, nullable: true),
                    is_verify_phone = table.Column<int>(nullable: false),
                    is_verify_email = table.Column<int>(nullable: false),
                    password = table.Column<string>(maxLength: 64, nullable: true),
                    user_role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
