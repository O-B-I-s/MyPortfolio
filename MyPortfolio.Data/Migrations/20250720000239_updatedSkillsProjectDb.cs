using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedSkillsProjectDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the foreign key only if it exists
            migrationBuilder.Sql(@"
        IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Skills_Projects_ProjectId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Skills]'))
        BEGIN
            ALTER TABLE [Skills] DROP CONSTRAINT [FK_Skills_Projects_ProjectId];
        END");

            // Drop the index only if it exists
            migrationBuilder.Sql(@"
        IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Skills]') AND name = 'IX_Skills_ProjectId')
        BEGIN
            DROP INDEX [IX_Skills_ProjectId] ON [Skills];
        END");

            // Drop the column if it exists
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Skills");

            // Create the many-to-many junction table
            migrationBuilder.CreateTable(
                name: "ProjectAndSkills",
                columns: table => new
                {
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAndSkills", x => new { x.ProjectsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ProjectAndSkills_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectAndSkills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAndSkills_SkillsId",
                table: "ProjectAndSkills",
                column: "SkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectAndSkills");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ProjectId",
                table: "Skills",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Projects_ProjectId",
                table: "Skills",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
