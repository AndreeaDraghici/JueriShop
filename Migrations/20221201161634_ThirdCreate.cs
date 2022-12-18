using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JueriOnlineShop.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComandaFinala",
                columns: table => new
                {
                    idComanda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusComanda = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaFinala", x => x.idComanda);
                });

            migrationBuilder.CreateTable(
                name: "ReviewFinal",
                columns: table => new
                {
                    idReview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    detalii = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewFinal", x => x.idReview);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CantitateFinala",
                columns: table => new
                {
                    idCantitate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantitatateTotala = table.Column<int>(type: "int", nullable: false),
                    ComandaidComanda = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CantitateFinala", x => x.idCantitate);
                    table.ForeignKey(
                        name: "FK_CantitateFinala_ComandaFinala_ComandaidComanda",
                        column: x => x.ComandaidComanda,
                        principalTable: "ComandaFinala",
                        principalColumn: "idComanda");
                });

            migrationBuilder.CreateTable(
                name: "ProdusFinal",
                columns: table => new
                {
                    idProdus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeProdus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descriereProdus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pretProdus = table.Column<int>(type: "int", nullable: false),
                    photoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reviewidReview = table.Column<int>(type: "int", nullable: true),
                    commandaidComanda = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdusFinal", x => x.idProdus);
                    table.ForeignKey(
                        name: "FK_ProdusFinal_ComandaFinala_commandaidComanda",
                        column: x => x.commandaidComanda,
                        principalTable: "ComandaFinala",
                        principalColumn: "idComanda");
                    table.ForeignKey(
                        name: "FK_ProdusFinal_ReviewFinal_reviewidReview",
                        column: x => x.reviewidReview,
                        principalTable: "ReviewFinal",
                        principalColumn: "idReview");
                });

            migrationBuilder.CreateTable(
                name: "CosFinal",
                columns: table => new
                {
                    idCos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantitateidCantitate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosFinal", x => x.idCos);
                    table.ForeignKey(
                        name: "FK_CosFinal_CantitateFinala_cantitateidCantitate",
                        column: x => x.cantitateidCantitate,
                        principalTable: "CantitateFinala",
                        principalColumn: "idCantitate");
                });

            migrationBuilder.CreateTable(
                name: "CategorieFinala",
                columns: table => new
                {
                    idCategorie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denumire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    produsidProdus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieFinala", x => x.idCategorie);
                    table.ForeignKey(
                        name: "FK_CategorieFinala_ProdusFinal_produsidProdus",
                        column: x => x.produsidProdus,
                        principalTable: "ProdusFinal",
                        principalColumn: "idProdus");
                });

            migrationBuilder.CreateTable(
                name: "UserFinal",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    produsidProdus = table.Column<int>(type: "int", nullable: true),
                    cosidCos = table.Column<int>(type: "int", nullable: true),
                    reviewidReview = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFinal", x => x.idUser);
                    table.ForeignKey(
                        name: "FK_UserFinal_CosFinal_cosidCos",
                        column: x => x.cosidCos,
                        principalTable: "CosFinal",
                        principalColumn: "idCos");
                    table.ForeignKey(
                        name: "FK_UserFinal_ProdusFinal_produsidProdus",
                        column: x => x.produsidProdus,
                        principalTable: "ProdusFinal",
                        principalColumn: "idProdus");
                    table.ForeignKey(
                        name: "FK_UserFinal_ReviewFinal_reviewidReview",
                        column: x => x.reviewidReview,
                        principalTable: "ReviewFinal",
                        principalColumn: "idReview");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CantitateFinala_ComandaidComanda",
                table: "CantitateFinala",
                column: "ComandaidComanda");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieFinala_produsidProdus",
                table: "CategorieFinala",
                column: "produsidProdus");

            migrationBuilder.CreateIndex(
                name: "IX_CosFinal_cantitateidCantitate",
                table: "CosFinal",
                column: "cantitateidCantitate");

            migrationBuilder.CreateIndex(
                name: "IX_ProdusFinal_commandaidComanda",
                table: "ProdusFinal",
                column: "commandaidComanda");

            migrationBuilder.CreateIndex(
                name: "IX_ProdusFinal_reviewidReview",
                table: "ProdusFinal",
                column: "reviewidReview");

            migrationBuilder.CreateIndex(
                name: "IX_UserFinal_cosidCos",
                table: "UserFinal",
                column: "cosidCos");

            migrationBuilder.CreateIndex(
                name: "IX_UserFinal_produsidProdus",
                table: "UserFinal",
                column: "produsidProdus");

            migrationBuilder.CreateIndex(
                name: "IX_UserFinal_reviewidReview",
                table: "UserFinal",
                column: "reviewidReview");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CategorieFinala");

            migrationBuilder.DropTable(
                name: "UserFinal");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CosFinal");

            migrationBuilder.DropTable(
                name: "ProdusFinal");

            migrationBuilder.DropTable(
                name: "CantitateFinala");

            migrationBuilder.DropTable(
                name: "ReviewFinal");

            migrationBuilder.DropTable(
                name: "ComandaFinala");
        }
    }
}
