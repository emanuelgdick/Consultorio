using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Doc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDiagnostico_Consulta_IdDiagnostico",
                table: "ConsultaDiagnostico");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDiagnostico_Diagnostico_IdConsulta",
                table: "ConsultaDiagnostico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDiagnostico_Consulta_IdDiagnostico",
                table: "ConsultaDiagnostico",
                column: "IdDiagnostico",
                principalTable: "Consulta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDiagnostico_Diagnostico_IdConsulta",
                table: "ConsultaDiagnostico",
                column: "IdConsulta",
                principalTable: "Diagnostico",
                principalColumn: "Id");
        }
    }
}
