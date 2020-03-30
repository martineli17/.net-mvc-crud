using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Crud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(500)", nullable: false),
                    descricao = table.Column<string>(type: "varchar(100)", unicode: false, nullable: false),
                    IdEstado = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(500)", nullable: false),
                    descricao = table.Column<string>(type: "varchar(100)", unicode: false, nullable: false),
                    idPais = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.id);
                    table.ForeignKey(
                        name: "FK_Estado_Pais_idPais",
                        column: x => x.idPais,
                        principalTable: "Pais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(500)", nullable: false),
                    descricao = table.Column<string>(type: "varchar(100)", unicode: false, nullable: false),
                    idEstado = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado_idEstado",
                        column: x => x.idEstado,
                        principalTable: "Estado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(500)", unicode: false, nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", unicode: false, nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", unicode: false, nullable: false),
                    idPais = table.Column<string>(type: "varchar(500)", nullable: false),
                    idEstado = table.Column<string>(type: "varchar(500)", nullable: false),
                    idCidade = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Paciente_Cidade_idCidade",
                        column: x => x.idCidade,
                        principalTable: "Cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Estado_idEstado",
                        column: x => x.idEstado,
                        principalTable: "Estado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Pais_idPais",
                        column: x => x.idPais,
                        principalTable: "Pais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_descricao",
                table: "Cidade",
                column: "descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_id",
                table: "Cidade",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_idEstado",
                table: "Cidade",
                column: "idEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_descricao",
                table: "Estado",
                column: "descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_id",
                table: "Estado",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_idPais",
                table: "Estado",
                column: "idPais");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_cpf",
                table: "Paciente",
                column: "cpf");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_id",
                table: "Paciente",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_idCidade",
                table: "Paciente",
                column: "idCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_idEstado",
                table: "Paciente",
                column: "idEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_idPais",
                table: "Paciente",
                column: "idPais");

            migrationBuilder.CreateIndex(
                name: "IX_Pais_descricao",
                table: "Pais",
                column: "descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Pais_id",
                table: "Pais",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
