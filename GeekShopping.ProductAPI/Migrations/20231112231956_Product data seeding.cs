using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class Productdataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "image_url", "name", "price" },
                values: new object[,]
                {
                    { 1L, "T-Shirt", "Camisa do Iron Maiden", "https://static.lojaconsuladodorock.com.br/produto/multifotos/hd/20220309144626_7390992610_DZ.jpg", "Camisa", 69.9m },
                    { 2L, "Pants", "Jeans Azul Clássico", "https://images.bestsellerclothing.in/data/only/15-sep-2022/255136001_g2.jpg?width=1080&height=1355&mode=fill&fill=blur&format=auto  ", "Jeans Azul", 49.9m },
                    { 3L, "Footwear", "Tênis leve de corrida", "https://cdn.thewirecutter.com/wp-content/media/2021/10/running-shoes-2048px-3097.jpg", "Tênis de Corrida", 79.99m },
                    { 4L, "Jackets", "Jaqueta de Couro", "https://thursdayboots.com/cdn/shop/products/1024x1024-Womens-Jackets-Racer-Black-102722-1.jpg?v=1667863479", "Jaqueta de Couro", 129.99m },
                    { 5L, "Electronics", "Mouse Gamer de alta performance", "https://i.zst.com.br/thumbs/12/31/3a/1730615274.jpg", "Mouse Gamer", 39.99m },
                    { 6L, "Furniture", "Mesa resistente de escritório", "https://moveispollo.com.br/wp-content/uploads/2021/03/frente.jpg", "Mesa de Escritório", 199.99m },
                    { 7L, "Bags", "Mochila espaçosa de viagem", "https://m.media-amazon.com/images/I/41+HVMKtPmL._AC_SY1000_.jpg", "Mochila", 29.99m },
                    { 8L, "Accessories", "Relógio de pulso elegante", "https://boxwebstore.com.br/wp-content/uploads/2021/07/Rolex-GMT-MASTER-II-40mm-3-600x600.jpg", "Relógio de Pulso", 99.99m },
                    { 9L, "Photography", "Câmera digital compacta", "https://cdn.awsli.com.br/600x450/1545/1545522/produto/60996689/ddc807c8b6.jpg", "Câmera Digital", 149.99m },
                    { 10L, "Audio", "Alto falante portátil bluetooth", "https://www.artis.in/cdn/shop/products/1_f5b3377c-c870-420f-bc6a-5cd4b3a5a7c7.jpg?v=1653639993", "Alto Falante Bluetooth", 59.99m },
                    { 11L, "Furniture", "Mesa de jantar moderna", "https://m.media-amazon.com/images/I/71meUAsP6IL._AC_UF1000,1000_QL80_.jpg", "Mesa de Jantar", 299.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 11L);
        }
    }
}
