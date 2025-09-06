using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalAM.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CNPJ = table.Column<string>(type: "char(14)", maxLength: 14, nullable: true),
                    Ativa = table.Column<bool>(type: "bit", nullable: false),
                    CriadaEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtualizadaEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: true),
                    Genero = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PlanoSaude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NumeroCarteiraPlano = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    Empresa = table.Column<byte>(type: "tinyint", nullable: true),
                    Usuario = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    IdHospital = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CNPJ = table.Column<string>(type: "char(14)", maxLength: 14, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.IdHospital);
                    table.ForeignKey(
                        name: "FK_Hospital_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "IdEmpresa");
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdHospital = table.Column<int>(type: "int", nullable: true),
                    Diagnostico = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MedicoIdMedico = table.Column<int>(type: "int", nullable: true),
                    PacienteIdPaciente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_Consulta_Hospital_IdHospital",
                        column: x => x.IdHospital,
                        principalTable: "Hospital",
                        principalColumn: "IdHospital");
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_PacienteIdPaciente",
                        column: x => x.PacienteIdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    IdExame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConsulta = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    SolicitadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResultadoTexto = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ResultadoArquivoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Pedido = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.IdExame);
                    table.ForeignKey(
                        name: "FK_Exame_Consulta_IdConsulta",
                        column: x => x.IdConsulta,
                        principalTable: "Consulta",
                        principalColumn: "IdConsulta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescricao",
                columns: table => new
                {
                    IdPrescricao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConsulta = table.Column<int>(type: "int", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidaAte = table.Column<DateTime>(type: "date", nullable: true),
                    Conteudo = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescricao", x => x.IdPrescricao);
                    table.ForeignKey(
                        name: "FK_Prescricao_Consulta_IdConsulta",
                        column: x => x.IdConsulta,
                        principalTable: "Consulta",
                        principalColumn: "IdConsulta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHospital = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: true),
                    Genero = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CRM = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Especialidade = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    Empresa = table.Column<byte>(type: "tinyint", nullable: true),
                    PrescricaoIdPrescricao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_Medico_Prescricao_PrescricaoIdPrescricao",
                        column: x => x.PrescricaoIdPrescricao,
                        principalTable: "Prescricao",
                        principalColumn: "IdPrescricao");
                });

            migrationBuilder.CreateTable(
                name: "HospitalMedico",
                columns: table => new
                {
                    HospitalIdHospital = table.Column<int>(type: "int", nullable: false),
                    MedicosIdMedico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalMedico", x => new { x.HospitalIdHospital, x.MedicosIdMedico });
                    table.ForeignKey(
                        name: "FK_HospitalMedico_Hospital_HospitalIdHospital",
                        column: x => x.HospitalIdHospital,
                        principalTable: "Hospital",
                        principalColumn: "IdHospital",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalMedico_Medico_MedicosIdMedico",
                        column: x => x.MedicosIdMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdHospital",
                table: "Consulta",
                column: "IdHospital");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MedicoIdMedico",
                table: "Consulta",
                column: "MedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteIdPaciente",
                table: "Consulta",
                column: "PacienteIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_IdConsulta",
                table: "Exame",
                column: "IdConsulta");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_IdEmpresa",
                table: "Hospital",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalMedico_MedicosIdMedico",
                table: "HospitalMedico",
                column: "MedicosIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_PrescricaoIdPrescricao",
                table: "Medico",
                column: "PrescricaoIdPrescricao");

            migrationBuilder.CreateIndex(
                name: "IX_Prescricao_IdConsulta",
                table: "Prescricao",
                column: "IdConsulta");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Medico_MedicoIdMedico",
                table: "Consulta",
                column: "MedicoIdMedico",
                principalTable: "Medico",
                principalColumn: "IdMedico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Hospital_IdHospital",
                table: "Consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Medico_MedicoIdMedico",
                table: "Consulta");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "HospitalMedico");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Prescricao");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
