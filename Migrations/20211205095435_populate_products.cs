using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Migrations
{
    public partial class populate_products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Boss", "Boss jeans Slim", 1200, 5, 1, "/Img/jeans01.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "DeFacto", "DeFacto jeans", 850, 4, 1, "/Img/jeans02.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "DeFacto", "DeFacto jeans", 650, 5, 1, "/Img/jeans03.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Befree", "Jeans that will let you fell free", 250, 3, 1, "/Img/jeans04.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Zarina", "Comfortable jeans", 499, 5, 1, "/Img/jeans05.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Collins", "You will enjoy it", 399, 2, 1, "/Img/jeans06.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Levi's", "Best jeans ever", 1399, 4, 1, "/Img/jeans07.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Guess Jeans", "cotton t-shirt", 59, 4, 2, "/Img/t-shirt01.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Befree", "black cotton t-shirt", 69, 5, 2, "/Img/t-shirt02.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Levi's", "gray cotton t-shirt", 199, 5, 2, "/Img/t-shirt03.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Zarina", "red cotton t-shirt", 39, 3, 2, "/Img/t-shirt04.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Adidas", "adidas cotton t-shirt", 104, 5, 2, "/Img/t-shirt05.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Fashion.Love.Story", "fashionable cotton t-shirt", 76, 2, 2, "/Img/t-shirt06.jpeg" });
            
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Rate", "CategoryId", "Image" },
                values: new object[] { "Calvin Klein Jeans", "pink cotton t-shirt", 399, 2, 2, "/Img/t-shirt07.jpeg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
