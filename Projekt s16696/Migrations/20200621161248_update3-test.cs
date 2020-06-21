using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_s16696.Migrations
{
    public partial class update3test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Campaigns_IdCampaign",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Buildings_FromIdBuilding",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Buildings_ToIdBuilding",
                table: "Campaigns");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Campaigns_IdCampaign",
                table: "Banners",
                column: "IdCampaign",
                principalTable: "Campaigns",
                principalColumn: "IdCampaign");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Buildings_FromIdBuilding",
                table: "Campaigns",
                column: "FromIdBuilding",
                principalTable: "Buildings",
                principalColumn: "IdBuilding");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Buildings_ToIdBuilding",
                table: "Campaigns",
                column: "ToIdBuilding",
                principalTable: "Buildings",
                principalColumn: "IdBuilding");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Campaigns_IdCampaign",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Buildings_FromIdBuilding",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Buildings_ToIdBuilding",
                table: "Campaigns");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Campaigns_IdCampaign",
                table: "Banners",
                column: "IdCampaign",
                principalTable: "Campaigns",
                principalColumn: "IdCampaign",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Buildings_FromIdBuilding",
                table: "Campaigns",
                column: "FromIdBuilding",
                principalTable: "Buildings",
                principalColumn: "IdBuilding",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Buildings_ToIdBuilding",
                table: "Campaigns",
                column: "ToIdBuilding",
                principalTable: "Buildings",
                principalColumn: "IdBuilding",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
