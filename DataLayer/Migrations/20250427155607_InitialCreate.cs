using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "continents",
                columns: table => new
                {
                    continent_code = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: false),
                    continent_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.continent_code);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    country_code = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: false),
                    country_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    continent_code = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.country_code);
                    table.ForeignKey(
                        name: "FK_CountriesContinents",
                        column: x => x.continent_code,
                        principalTable: "continents",
                        principalColumn: "continent_code");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "stadium",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: true),
                    country_code = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: false),
                    town_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_StadiumCountries",
                        column: x => x.country_code,
                        principalTable: "countries",
                        principalColumn: "country_code");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    country_code = table.Column<string>(type: "char(30)", maxLength: 30, nullable: false),
                    coach_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    colours = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    founded = table.Column<int>(type: "int", nullable: true),
                    team_stadium = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_TeamsCountries",
                        column: x => x.country_code,
                        principalTable: "countries",
                        principalColumn: "country_code");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "trophies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    country_code = table.Column<string>(type: "char(30)", maxLength: 30, nullable: false),
                    continent_code = table.Column<string>(type: "char(30)", maxLength: 30, nullable: false),
                    footballers = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_TrophiesContinents",
                        column: x => x.continent_code,
                        principalTable: "continents",
                        principalColumn: "continent_code");
                    table.ForeignKey(
                        name: "FK_TrophiesCountries",
                        column: x => x.country_code,
                        principalTable: "countries",
                        principalColumn: "country_code");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "footballers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    shirt_number = table.Column<int>(type: "int", nullable: true),
                    first_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    last_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    age = table.Column<int>(type: "int", nullable: true),
                    team_id = table.Column<int>(type: "int", nullable: true),
                    team_position = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    country_code = table.Column<string>(type: "char(30)", maxLength: 30, nullable: false),
                    price = table.Column<decimal>(type: "decimal(19,2)", precision: 19, nullable: false),
                    salary = table.Column<decimal>(type: "decimal(19,2)", precision: 19, nullable: false),
                    trophies = table.Column<int>(type: "int", nullable: true),
                    captain = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_FootballersCountries",
                        column: x => x.country_code,
                        principalTable: "countries",
                        principalColumn: "country_code");
                    table.ForeignKey(
                        name: "FK_FootballersTeams",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "footballerstrophy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    footballer_id = table.Column<int>(type: "int", nullable: true),
                    trophy_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees",
                        column: x => x.trophy_id,
                        principalTable: "trophies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Programs",
                        column: x => x.footballer_id,
                        principalTable: "footballers",
                        principalColumn: "id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "FK_CountriesContinents",
                table: "countries",
                column: "continent_code");

            migrationBuilder.CreateIndex(
                name: "FK_FootballersCountries",
                table: "footballers",
                column: "country_code");

            migrationBuilder.CreateIndex(
                name: "FK_FootballersTeams",
                table: "footballers",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "FK_Employees",
                table: "footballerstrophy",
                column: "trophy_id");

            migrationBuilder.CreateIndex(
                name: "FK_Programs",
                table: "footballerstrophy",
                column: "footballer_id");

            migrationBuilder.CreateIndex(
                name: "FK_StadiumCountries",
                table: "stadium",
                column: "country_code");

            migrationBuilder.CreateIndex(
                name: "FK_TeamsCountries",
                table: "teams",
                column: "country_code");

            migrationBuilder.CreateIndex(
                name: "FK_TrophiesContinents",
                table: "trophies",
                column: "continent_code");

            migrationBuilder.CreateIndex(
                name: "FK_TrophiesCountries",
                table: "trophies",
                column: "country_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "footballerstrophy");

            migrationBuilder.DropTable(
                name: "stadium");

            migrationBuilder.DropTable(
                name: "trophies");

            migrationBuilder.DropTable(
                name: "footballers");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "continents");
        }
    }
}
