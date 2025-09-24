using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDiagnostico_Consulta_IdConsulta",
                table: "ConsultaDiagnostico");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDiagnostico_Diagnostico_IdDiagnostico",
                table: "ConsultaDiagnostico");

            migrationBuilder.RenameColumn(
                name: "codAflp",
                table: "Paciente",
                newName: "CodAflp");

            migrationBuilder.AlterColumn<int>(
                name: "NroHC",
                table: "Paciente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdDiagnostico",
                table: "ConsultaDiagnostico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdConsulta",
                table: "ConsultaDiagnostico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDiagnostico_Consulta_IdConsulta",
                table: "ConsultaDiagnostico",
                column: "IdConsulta",
                principalTable: "Consulta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDiagnostico_Diagnostico_IdDiagnostico",
                table: "ConsultaDiagnostico",
                column: "IdDiagnostico",
                principalTable: "Diagnostico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDiagnostico_Consulta_IdConsulta",
                table: "ConsultaDiagnostico");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDiagnostico_Diagnostico_IdDiagnostico",
                table: "ConsultaDiagnostico");

            migrationBuilder.RenameColumn(
                name: "CodAflp",
                table: "Paciente",
                newName: "codAflp");

            migrationBuilder.AlterColumn<int>(
                name: "NroHC",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdDiagnostico",
                table: "ConsultaDiagnostico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdConsulta",
                table: "ConsultaDiagnostico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDiagnostico_Consulta_IdConsulta",
                table: "ConsultaDiagnostico",
                column: "IdConsulta",
                principalTable: "Consulta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDiagnostico_Diagnostico_IdDiagnostico",
                table: "ConsultaDiagnostico",
                column: "IdDiagnostico",
                principalTable: "Diagnostico",
                principalColumn: "Id");
        }
    }
}
