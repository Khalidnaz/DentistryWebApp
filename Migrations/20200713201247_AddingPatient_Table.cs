using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanetDDS.Migrations
{
    public partial class AddingPatient_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(nullable: false),
                    Lname = table.Column<string>(nullable: false),
                    DentistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Dentists_DentistId",
                        column: x => x.DentistId,
                        principalTable: "Dentists",
                        principalColumn: "DentistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DentistId",
                table: "Patients",
                column: "DentistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
