using MongoDB.Driver;
using Shopping.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Data
{

    //constructor  for product context = setting mongodb connection
    public class ProductContext
    {
        public ProductContext (IConfiguration configuration)
        {
            //open connection and open client for mongodb database, we are providing the connection setting into the mongo client class... 

            //this will create mongo connection
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);

            //create the database (get database will look for databases, if exist it will create a database or else it will do nothing)
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            //create collection , using database object and collection method, pasting the <product> model classs
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);

            //seedata method
            SeeData(Products);

        }

        public IMongoCollection<Product> Products { get; } 
        
        //in this method we are looking if there is any item in the product collection, if not we are going to insert manycommand <mongo part>
        public static void SeeData(IMongoCollection<Product>ProductCollection)
        {
            bool existProdcut = ProductCollection.Find(p=>true).Any();
            if(!existProdcut)
            {
                ProductCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        //new method for preconfigured product
        private static IEnumerable<Product>GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Samsung S22",
                    Description = "The slim bezels flow into a symmetrical polished frame for an expansive, balanced display. As a finishing touch, the monochromatic camera housing surrounds a linear camera system.",
                    ImageFile = "product-1.png",
                    Price = 410000.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {


                    Name = "IPhone 14",
                    Description = "iPhone 14 Pro has Dynamic Island, a magical new way to interact with iPhone. And an Always‑On display, which keeps your important info at a glance..",
                    ImageFile = "product-2.png",
                    Price = 800000.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-3.png",
                    Price = 120000.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-4.png",
                    Price = 70000.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "HTC U11+ Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-5.png",
                    Price = 180000.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "LG G7 ThinQ EndofCourse",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 120000.00M,
                    Category = "Smart Phone"
                }
            };
        }


        
}
}


