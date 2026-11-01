using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HaliSahaPortali.Migrations
{
    /// <inheritdoc />
    public partial class TablolarEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tesisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Adres = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Ilce = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "text", nullable: false),
                    Aciklama = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tesisler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sahalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ZeminTuru = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    KapaliMi = table.Column<bool>(type: "boolean", nullable: false),
                    SaatlikUcret = table.Column<decimal>(type: "numeric", nullable: false),
                    TesisId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sahalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sahalar_Tesisler_TesisId",
                        column: x => x.TesisId,
                        principalTable: "Tesisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Puan = table.Column<int>(type: "integer", nullable: false),
                    Metin = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Tarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TesisId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Tesisler_TesisId",
                        column: x => x.TesisId,
                        principalTable: "Tesisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tarih = table.Column<DateOnly>(type: "date", nullable: false),
                    BaslangicSaati = table.Column<int>(type: "integer", nullable: false),
                    IptalEdildi = table.Column<bool>(type: "boolean", nullable: false),
                    SahaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyonlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Sahalar_SahaId",
                        column: x => x.SahaId,
                        principalTable: "Sahalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_SahaId",
                table: "Rezervasyonlar",
                column: "SahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sahalar_TesisId",
                table: "Sahalar",
                column: "TesisId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_TesisId",
                table: "Yorumlar",
                column: "TesisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Sahalar");

            migrationBuilder.DropTable(
                name: "Tesisler");
        }
    }
}
