using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "name", "color", "tail_length", "weight" },
                values: new object[,]
                {
                    { "Amber", "brown", 26, 28 },
                    { "Angel", "cream", 19, 27 },
                    { "Baxter", "gray", 24, 39 },
                    { "Bear", "tan", 26, 33 },
                    { "Beau", "red", 29, 29 },
                    { "Bella", "golden", 26, 31 },
                    { "Benny", "black", 30, 30 },
                    { "Biscuit", "golden", 21, 30 },
                    { "Blue", "blue", 20, 33 },
                    { "Bruno", "brown&white", 24, 31 },
                    { "Buddy", "black&white", 23, 32 },
                    { "Buster", "tan", 20, 31 },
                    { "Chance", "brown", 21, 33 },
                    { "Charlie", "red", 29, 32 },
                    { "Chester", "brown", 19, 28 },
                    { "Chloe", "brindle", 20, 34 },
                    { "Cindy", "tan", 22, 29 },
                    { "Cleo", "golden", 26, 32 },
                    { "Coco", "brown", 28, 31 },
                    { "Daisy", "golden", 19, 30 },
                    { "Dash", "tan", 21, 31 },
                    { "Dobby", "black", 21, 29 },
                    { "Duke", "chestnut", 24, 33 },
                    { "Ella", "cream", 19, 30 },
                    { "Ellie", "golden&white", 30, 29 },
                    { "Ember", "brown", 20, 32 },
                    { "Fido", "tan", 22, 28 },
                    { "Finn", "black&white", 25, 37 },
                    { "Ginger", "cream", 18, 24 },
                    { "Gizmo", "tan", 26, 32 },
                    { "Gus", "gray", 26, 32 },
                    { "Holly", "fawn", 22, 34 },
                    { "Jack", "blue", 21, 29 },
                    { "Jasper", "gray", 23, 30 },
                    { "Kira", "red", 19, 30 },
                    { "Koda", "chocolate", 25, 36 },
                    { "Lola", "fawn", 19, 27 },
                    { "Lucky", "tan", 22, 25 },
                    { "Lucy", "white", 22, 28 },
                    { "Luna", "chocolate", 22, 30 },
                    { "Maggie", "black", 20, 32 },
                    { "Marley", "black&tan", 20, 31 },
                    { "Max", "black", 25, 40 },
                    { "Milo", "black&white", 27, 38 },
                    { "Mimi", "brown", 20, 28 },
                    { "Misty", "ivory", 21, 32 },
                    { "Nala", "chestnut", 19, 28 },
                    { "Niko", "black", 25, 29 },
                    { "Nina", "brown&white", 28, 29 },
                    { "Ollie", "black", 19, 30 },
                    { "Oscar", "chocolate", 26, 26 },
                    { "Penny", "fawn", 22, 30 },
                    { "Pepper", "gray", 22, 33 },
                    { "Piper", "golden&white", 25, 32 },
                    { "Rex", "graphite", 27, 38 },
                    { "Rocco", "brown&white", 24, 36 },
                    { "Rocky", "gray", 24, 35 },
                    { "Roxy", "brindle", 20, 34 },
                    { "Ruby", "apricot", 24, 30 },
                    { "Ruff", "brown", 25, 35 },
                    { "Rusty", "black&tan", 23, 36 },
                    { "Ryder", "brown", 30, 37 },
                    { "Sadie", "ivory", 28, 25 },
                    { "Sammy", "brown", 28, 35 },
                    { "Sasha", "black", 24, 35 },
                    { "Scout", "golden", 23, 30 },
                    { "Simba", "brown&white", 21, 36 },
                    { "Snow", "white", 27, 36 },
                    { "Stella", "golden", 23, 31 },
                    { "Sunny", "fawn", 25, 29 },
                    { "Tango", "tan", 22, 29 },
                    { "Teddy", "gray", 27, 38 },
                    { "Thor", "brown", 27, 30 },
                    { "Tina", "white", 26, 28 },
                    { "Toby", "gray", 24, 35 },
                    { "Whiskey", "gray", 23, 27 },
                    { "Winston", "rust", 19, 28 },
                    { "Yuki", "golden&white", 24, 31 },
                    { "Zoey", "golden&white", 25, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Amber");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Angel");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Baxter");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Bear");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Beau");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Bella");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Benny");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Biscuit");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Blue");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Bruno");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Buddy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Buster");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Chance");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Charlie");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Chester");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Chloe");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Cindy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Cleo");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Coco");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Daisy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Dash");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Dobby");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Duke");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Ella");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Ellie");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Ember");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Fido");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Finn");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Ginger");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Gizmo");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Gus");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Holly");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Jack");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Jasper");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Kira");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Koda");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Lola");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Lucky");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Lucy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Luna");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Maggie");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Marley");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Max");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Milo");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Mimi");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Misty");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Nala");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Niko");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Nina");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Ollie");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Oscar");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Penny");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Pepper");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Piper");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Rex");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Rocco");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Rocky");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Roxy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Ruby");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Ruff");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Rusty");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Ryder");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Sadie");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Sammy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Sasha");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Scout");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Simba");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Snow");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Stella");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Sunny");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Tango");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Teddy");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Thor");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Tina");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Toby");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Whiskey");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Winston");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Yuki");

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "name",
                keyValue: "Zoey");
        }
    }
}
