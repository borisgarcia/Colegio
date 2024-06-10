using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Grados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfesorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grados_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlumnoGrados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AlumnoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GradoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Seccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoGrados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlumnoGrados_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoGrados_Grados_GradoId",
                        column: x => x.GradoId,
                        principalTable: "Grados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Alumnos",
                columns: new[] { "Id", "Apellidos", "CreatedDate", "FechaNacimiento", "Genero", "ModifiedDate", "Nombre" },
                values: new object[,]
                {
                    { new Guid("2adc4147-1831-42a5-88cd-dda4bae18b0d"), "Doe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 10, 8, 20, 0, 694, DateTimeKind.Local).AddTicks(8484), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John" },
                    { new Guid("d8323dd7-b47a-44f3-833e-dd66910f9ef2"), "Doe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 10, 8, 20, 0, 694, DateTimeKind.Local).AddTicks(8454), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane" }
                });

            migrationBuilder.InsertData(
                table: "Profesores",
                columns: new[] { "Id", "Apellidos", "CreatedDate", "Genero", "ModifiedDate", "Nombre" },
                values: new object[,]
                {
                    { new Guid("6c6836f9-6cfc-4619-a4e6-f84b7cf84b96"), "Parker", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter" },
                    { new Guid("a4e94be4-753a-469a-bca6-55641df746a7"), "Dafoe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Willem" }
                });

            migrationBuilder.InsertData(
                table: "Grados",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Nombre", "ProfesorId" },
                values: new object[,]
                {
                    { new Guid("70e283fd-491e-476d-ab4f-f542ab810ee6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "II B", new Guid("a4e94be4-753a-469a-bca6-55641df746a7") },
                    { new Guid("fb0f36cd-98e4-426b-8cad-47425ba09864"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I A", new Guid("6c6836f9-6cfc-4619-a4e6-f84b7cf84b96") }
                });

            migrationBuilder.InsertData(
                table: "AlumnoGrados",
                columns: new[] { "Id", "AlumnoId", "CreatedDate", "GradoId", "ModifiedDate", "Seccion" },
                values: new object[,]
                {
                    { new Guid("b57668c0-3494-42c6-9bf4-b62a7681fc47"), new Guid("d8323dd7-b47a-44f3-833e-dd66910f9ef2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70e283fd-491e-476d-ab4f-f542ab810ee6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1" },
                    { new Guid("bbcfe11b-96b4-4430-b080-7e1bc83c12ae"), new Guid("2adc4147-1831-42a5-88cd-dda4bae18b0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fb0f36cd-98e4-426b-8cad-47425ba09864"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoGrados_AlumnoId",
                table: "AlumnoGrados",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoGrados_GradoId",
                table: "AlumnoGrados",
                column: "GradoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grados_ProfesorId",
                table: "Grados",
                column: "ProfesorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoGrados");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Grados");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
