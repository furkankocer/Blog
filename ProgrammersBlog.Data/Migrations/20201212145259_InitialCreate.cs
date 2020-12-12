using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProgrammersBlog.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedByName = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedByName = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedByName = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "VARBINARY(500)", nullable: false),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Picture = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedByName = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR (MAX)", nullable: false),
                    Thumbnail = table.Column<string>(maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ViewsCount = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    SeoAuthor = table.Column<string>(maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(maxLength: 70, nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedByName = table.Column<string>(maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(maxLength: 500, nullable: true),
                    Text = table.Column<string>(maxLength: 1000, nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 450, DateTimeKind.Local).AddTicks(1101), "C# İLE İLGİLİ GÜNCEL BİLGİLER", true, false, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 450, DateTimeKind.Local).AddTicks(1101), "C#", "C# KATEGORİSİ" },
                    { 2, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 450, DateTimeKind.Local).AddTicks(1101), "C++ İLE İLGİLİ GÜNCEL BİLGİLER", true, false, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 450, DateTimeKind.Local).AddTicks(1101), "C++", "C++ KATEGORİSİ" },
                    { 3, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 450, DateTimeKind.Local).AddTicks(1101), "JAVA İLE İLGİLİ GÜNCEL BİLGİLER", true, false, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 450, DateTimeKind.Local).AddTicks(1101), "JAVA", "JAVA KATEGORİSİ" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[] { 1, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 455, DateTimeKind.Local).AddTicks(967), "Admin Rolü, Tüm Haklara Sahiptir.", true, false, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 455, DateTimeKind.Local).AddTicks(967), "Admin", "Admin Rolüdür" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedByName", "ModifiedDate", "Note", "PasswordHash", "Picture", "RoleId", "Username" },
                values: new object[] { 1, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 465, DateTimeKind.Local).AddTicks(696), "İlk Admin Kullanıcıs", "furkankocer@hotmail.com", "Furkan", true, false, "Koçer", "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 465, DateTimeKind.Local).AddTicks(696), "Admin Kullanıcısı", new byte[] { 101, 49, 48, 97, 100, 99, 51, 57, 52, 57, 98, 97, 53, 57, 97, 98, 98, 101, 53, 54, 101, 48, 53, 55, 102, 50, 48, 102, 56, 56, 51, 101 }, "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU", 1, "furkankocer" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 446, DateTimeKind.Local).AddTicks(1204), new DateTime(2020, 12, 12, 17, 52, 59, 446, DateTimeKind.Local).AddTicks(1204), true, false, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 446, DateTimeKind.Local).AddTicks(1204), "C# 9 YENİLİKLERİ", "Furkan Koçer", "C# 9 YENİLİKLERİ", "c#,9,.net core", "Default.jpg", "C# 9 YENİLİKLERİ", 1, 12 },
                    { 2, 2, 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 446, DateTimeKind.Local).AddTicks(1204), new DateTime(2020, 12, 12, 17, 52, 59, 446, DateTimeKind.Local).AddTicks(1204), true, false, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 446, DateTimeKind.Local).AddTicks(1204), "C++ 9 YENİLİKLERİ", "Furkan Koçer", "C++ 9 YENİLİKLERİ", "C++,9,.net core", "Default.jpg", "C++ 9 YENİLİKLERİ", 1, 12 },
                    { 3, 3, 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 446, DateTimeKind.Local).AddTicks(1204), new DateTime(2020, 12, 12, 17, 52, 59, 446, DateTimeKind.Local).AddTicks(1204), true, false, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 446, DateTimeKind.Local).AddTicks(1204), "JAVA  YENİLİKLERİ", "Furkan Koçer", "JAVA 9 YENİLİKLERİ", "JAVA,", "Default.jpg", "JAVA  YENİLİKLERİ", 1, 12 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "Text" },
                values: new object[] { 1, 1, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 453, DateTimeKind.Local).AddTicks(1021), true, false, "InitialCreate", new DateTime(2020, 12, 12, 17, 52, 59, 453, DateTimeKind.Local).AddTicks(1021), "Firs Comment", "Hello" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
