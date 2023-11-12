using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        { }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Camisa",
                Price = 69.9M,
                Description = "Camisa do Iron Maiden",
                CategoryName = "T-Shirt",
                ImageUrl = "https://static.lojaconsuladodorock.com.br/produto/multifotos/hd/20220309144626_7390992610_DZ.jpg",
            },
            new Product
            {
                Id = 2,
                Name = "Jeans Azul",
                Price = 49.9M,
                Description = "Jeans Azul Clássico",
                CategoryName = "Pants",
                ImageUrl = "https://images.bestsellerclothing.in/data/only/15-sep-2022/255136001_g2.jpg?width=1080&height=1355&mode=fill&fill=blur&format=auto  "
            },
            new Product
            {
                Id = 3,
                Name = "Tênis de Corrida",
                Price = 79.99M,
                Description = "Tênis leve de corrida",
                CategoryName = "Footwear",
                ImageUrl = "https://cdn.thewirecutter.com/wp-content/media/2021/10/running-shoes-2048px-3097.jpg"
            },
            new Product
            {
                Id = 4,
                Name = "Jaqueta de Couro",
                Price = 129.99M,
                Description = "Jaqueta de Couro",
                CategoryName = "Jackets",
                ImageUrl = "https://thursdayboots.com/cdn/shop/products/1024x1024-Womens-Jackets-Racer-Black-102722-1.jpg?v=1667863479"
            },
            new Product
            {
                Id = 5,
                Name = "Mouse Gamer",
                Price = 39.99M,
                Description = "Mouse Gamer de alta performance",
                CategoryName = "Electronics",
                ImageUrl = "https://i.zst.com.br/thumbs/12/31/3a/1730615274.jpg"
            },
            new Product
            {
                Id = 6,
                Name = "Mesa de Escritório",
                Price = 199.99M,
                Description = "Mesa resistente de escritório",
                CategoryName = "Furniture",
                ImageUrl = "https://moveispollo.com.br/wp-content/uploads/2021/03/frente.jpg"
            },
            new Product
            {
                Id = 7,
                Name = "Mochila",
                Price = 29.99M,
                Description = "Mochila espaçosa de viagem",
                CategoryName = "Bags",
                ImageUrl = "https://m.media-amazon.com/images/I/41+HVMKtPmL._AC_SY1000_.jpg"
            },
            new Product
            {
                Id = 8,
                Name = "Relógio de Pulso",
                Price = 99.99M,
                Description = "Relógio de pulso elegante",
                CategoryName = "Accessories",
                ImageUrl = "https://boxwebstore.com.br/wp-content/uploads/2021/07/Rolex-GMT-MASTER-II-40mm-3-600x600.jpg"
            },
            new Product
            {
                Id = 9,
                Name = "Câmera Digital",
                Price = 149.99M,
                Description = "Câmera digital compacta",
                CategoryName = "Photography",
                ImageUrl = "https://cdn.awsli.com.br/600x450/1545/1545522/produto/60996689/ddc807c8b6.jpg"
            },
            new Product
            {
                Id = 10,
                Name = "Alto Falante Bluetooth",
                Price = 59.99M,
                Description = "Alto falante portátil bluetooth",
                CategoryName = "Audio",
                ImageUrl = "https://www.artis.in/cdn/shop/products/1_f5b3377c-c870-420f-bc6a-5cd4b3a5a7c7.jpg?v=1653639993"
            },
            new Product
            {
                Id = 11,
                Name = "Mesa de Jantar",
                Price = 299.99M,
                Description = "Mesa de jantar moderna",
                CategoryName = "Furniture",
                ImageUrl = "https://m.media-amazon.com/images/I/71meUAsP6IL._AC_UF1000,1000_QL80_.jpg"
            }

            );

        }
    }
}
