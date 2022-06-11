using System;
using GP.Data;
using System.Collections.Generic;
using GP.Domain.Entities;
using GP.Service;
using GP.ServicePattern;
using GP.Data.Infrastructure;

//
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace GP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Partie 2: Type valeur / Type référence 
            //Provider P1 = new Provider() { ConfirmPassword = "12345", Password = "12345" };

            //Provider.SetIsApproved(P1.Password, P1.ConfirmPassword, P1.IsApproved);
            //System.Console.WriteLine("{" + P1.Password + ";" + P1.ConfirmPassword + ";" + P1.IsApproved + "}");
            //System.Console.ReadKey();

            //Provider.SetIsApproved(P1);
            //System.Console.WriteLine("{" + P1.Password + ";" + P1.ConfirmPassword + ";" + P1.IsApproved + "}");
            //System.Console.ReadKey();
            #endregion

            #region Partie 3 Encapsulation

            ///*Password Inferieur a 5*/
            //Provider P2 = new Provider() { ConfirmPassword = "123", Password = "123" };
            //System.Console.ReadKey();

            ///*Password Superieur a 5*/
            //Provider P3 = new Provider() { ConfirmPassword = "123456", Password = "123456" };
            //System.Console.ReadKey();

            #endregion

            #region Partie 4 Polymorphisme De Surcharge

            /*Login avec deux parametres*/

            //Provider P4 = new Provider() { UserName = "test", Password = "12345" };
            //bool result1 = P4.Login("test", "12346");
            //if (result1) System.Console.WriteLine("Login Reussi"); else System.Console.WriteLine("Login Non Reussi");
            //System.Console.ReadKey();

            ///*Login avec trois parametres*/

            //Provider P5 = new Provider() { UserName = "test", Password = "12345", Email = "test@gmail.com" };
            //bool result2 = P4.Login("test", "12346", "test@");
            //if (result2) System.Console.WriteLine("Login Reussi"); else System.Console.WriteLine("Login Non Reussi");
            //System.Console.ReadKey();

            #endregion

            #region Partie 4 Polymorphisme d’heritage

            ///*Produit de type Unknown*/

            //Product Prdct3 = new Product();
            //Prdct3.GetMyType();
            //System.Console.ReadKey();

            ///*Produit de type Biological*/

            //Product Prdct1 = new Biological();
            //Prdct1.GetMyType();
            //System.Console.ReadKey();


            ///*Produit de type Biological*/

            //Product Prdct2 = new Chemical();
            //Prdct2.GetMyType();
            //System.Console.ReadKey();

            #endregion

            #region Partie 5 : Itérations / Structures conditionnelles
            Provider prov1 = new Provider() { UserName = "PROV1" };
            Provider prov2 = new Provider() { UserName = "PROV2" };
            Product prod1 = new Product() { Name = "PROD1", DateProd = Convert.ToDateTime("12/12/2019") };
            Product prod2 = new Product() { Name = "PROD2", DateProd = Convert.ToDateTime("12/12/2020") };
            prov1.Products = new List<Product>() { prod1, prod2 };

            prov1.GetProducts("DATEPROD", "12/12/2019");
            System.Console.ReadKey();

            #endregion


            #region Partie 5: Collections / Itérations / Structures conditionnelles

            //Category cat1 = new Category() { Name = "CAT1" };
            //Category cat2 = new Category() { Name = "CAT2" };
            //Category cat3 = new Category() { Name = "CAT3" };
            //Provider prov1 = new Provider() { UserName = "PROV1" };
            //Provider prov2 = new Provider() { UserName = "PROV2" };
            //Provider prov3 = new Provider() { UserName = "PROV3" };
            //Provider prov4 = new Provider() { UserName = "PROV4" };
            //Provider prov5 = new Provider() { UserName = "PROV5" };
            //Product prod1 = new Product() { Name = "PROD1", MyCategory = cat1, Providers = new List<Provider>() { prov1, prov2 } };
            //Product prod2 = new Product() { Name = "PROD2", MyCategory = cat1, Providers = new List<Provider>() { prov1 } };
            //Product prod3 = new Product() { Name = "PROD4", Providers = new List<Provider>() { prov3, prov4, prov5 } };
            //cat1.Products = new List<Product>() { prod1, prod2 };

            //prov1.Products = new List<Product>() { prod1, prod2 };
            //prov2.Products = new List<Product>() { prod1};
            //prov3.Products = new List<Product>() { prod3 };


            //System.Console.WriteLine("détails des providers");
            //prov1.GetDetails();
            //prov2.GetDetails();
            //prov3.GetDetails();
            //System.Console.ReadKey();

            //////Tester les autres méthodes
            //List<Product> ListProducts = new List<Product>();
            //ListProducts.Add(prod1); ListProducts.Add(prod2); ListProducts.Add(prod3);

            //foreach (Product prd in ListProducts)
            //{
            //    prd.GetDetails();
            //}

            //ListProducts.RemoveAt(1);

            #endregion

            #region Senario de test
            ////Categories
            //Category fruit = new Category() { Name = "Fruit" };
            //Category Alimentaire = new Category() { Name = "Alimentaire" };

            ////Products
            //Product acide = new Chemical()
            //{
            //    DateProd = new DateTime(2000, 12, 12),
            //    Name = "ACIDE CITRIQUE",
            //    Description = "Monohydrate - E330 - USP32",
            //    MyCategory = Alimentaire,
            //    Price = 90,
            //    Quantity = 30,
            //    City = "Sousse"
            //};
            //Product cacao = new Chemical()
            //{
            //    DateProd = new DateTime(2000, 12, 12),
            //    Name = "POUDRE DE CACAO NATURELLE",
            //    Description = "10% -12%",
            //    MyCategory = Alimentaire,
            //    Price = 419,
            //    Quantity = 80,
            //    City = "Sfax"
            //};

            //Product dioxyde = new Chemical()
            //{
            //    DateProd = new DateTime(2000, 12, 12),
            //    Name = "DIOXYDE DE TITANE",
            //    Description = "TiO2 grade alimentaire, cosmétique et pharmaceutique.",
            //    MyCategory = Alimentaire,
            //    Price = 200,
            //    Quantity = 50,
            //    City = "Tunis"
            //};
            //Product amidon = new Chemical()
            //{
            //    DateProd = new DateTime(2000, 12, 12),
            //    Name = "AMIDON DE MAÏS",
            //    Description = "Amidon de maïs natif",
            //    MyCategory = Alimentaire,
            //    Price = 70,
            //    Quantity = 30,
            //    City = "Tunis"
            //};
            //Product blackberry = new Biological()
            //{
            //    DateProd = new DateTime(2000, 12, 12),
            //    Name = "Blackberry",
            //    Description = "",
            //    MyCategory = fruit,
            //    Price = 60,
            //    ProductId = 0,
            //    Quantity = 0

            //};

            //Product apple = new Biological()
            //{
            //    DateProd = new DateTime(2000, 12, 12),
            //    Description = "",
            //    MyCategory = fruit,
            //    Name = "Apple",
            //    Price = 100.00,
            //    ProductId = 0,
            //    Quantity = 100

            //};

            //Product avocado = new Biological()
            //{
            //    DateProd = new DateTime(2000, 12, 12),
            //    Description = "",
            //    MyCategory = fruit,
            //    Name = "Avocado",
            //    Price = 100.00,
            //    ProductId = 0,
            //    Quantity = 100

            //};

            //List<Product> products = new List<Product>() { acide, cacao, dioxyde, amidon, blackberry, apple, avocado };
            //ManageProduct manageProduct = new ManageProduct(products);

            //Provider sater = new Provider() { Id = 1, UserName = "Medical Provider" };
            //Provider sudMedical = new Provider() { Id = 2, UserName = "Fruit-SA Provider" };
            //Provider palliserSa = new Provider() { Id = 3, UserName = "Fruit-CP  Provider" };
            //Provider prov4 = new Provider() { Id = 4, UserName = "Chemical Med-Provider" };
            //Provider prov5 = new Provider() { Id = 5, UserName = "Bio Provider" };
            //List<Provider> providers = new List<Provider>() { sater, sudMedical, palliserSa, prov4, prov5 };
            //ManageProvider manageProvider = new ManageProvider(providers);
            #endregion


            #region Les méthodes anonymes 

            //System.Console.WriteLine("Resultat de l appelle de la fonction FindProducts \n . ");

            //ManageProduct.FindProducts findprdct = delegate (string c) {
            //    foreach (Product product in products)
            //    {
            //        if (product.Name.ToUpper().StartsWith(c.ToUpper()))
            //            product.GetDetails();
            //    }
            //};
            //findprdct("a");

            //System.Console.ReadKey();

            //System.Console.WriteLine("Resultat de l appelle de la fonction ScanProduct \n . ");

            //ManageProduct.ScanProduct scanprdct = delegate (Category category) {
            //    foreach (Product product in products)
            //    {
            //        if (product.MyCategory.Name.Equals(category.Name))
            //            product.GetDetails();
            //    }
            //};
            //scanprdct(fruit);

            //System.Console.ReadKey();


            //// Call By Function

            //System.Console.WriteLine("Resultat de l appelle de l appelle a travers fonction \n . ");

            //ManageProduct.FindProducts findprdct1 = new ManageProduct.FindProducts(manageProduct.GetProductByChar);

            //findprdct1("a");

            //System.Console.ReadKey();

            #endregion

            #region LinQ

            //// ----- ManageProducts 

            ////Get5Chemical()
            //System.Console.WriteLine("\n*****Les cinq premiers produits chemical qui ont un prix supérieur à 50.");
            //foreach (Product l in manageProduct.Get5Chemical(50))
            //{
            //    l.GetDetails();
            //}

            //System.Console.ReadKey();

            ////GetProductPrice()
            //System.Console.WriteLine("\n*****les produits qui ont un prix supérieur à 50 en ignorant les 2 premiers produits. ");
            //foreach (Product l in manageProduct.GetProductPrice(50))
            //{
            //    l.GetDetails();
            //}
            //System.Console.ReadKey();

            ////GetAveragePrice()
            //System.Console.WriteLine($"\nPrix moyen des produits = {manageProduct.GetAveragePrice()}");
            //System.Console.ReadKey();

            ////GetMaxPrice()
            //System.Console.WriteLine("\nLe produit de max prix est : ");
            //var prdct = manageProduct.GetMaxPrice();
            //prdct.GetDetails();
            //System.Console.ReadKey();

            ////GetCountProduct()
            //System.Console.WriteLine("\nle nombre de produits chemical de Tunis = " + manageProduct.GetCountProduct("Tunis"));
            //System.Console.ReadKey();

            ////GetChemicalCity()
            //foreach (Product l in manageProduct.GetChemicalCity())
            //{ l.GetDetails(); }
            //System.Console.ReadKey();


            ////GetChemicalGroupByCity()
            //System.Console.WriteLine("\nLa liste des produits chemical ordonnés et groupé par city.");
            //manageProduct.GetChemicalGroupByCity();
            //System.Console.ReadKey();

            //// ----- manageProvider 

            ////GetProviderByName()

            //List<Provider> listProvider = manageProvider.GetProviderByName("Med");
            //foreach (Provider l in listProvider)
            //{
            //    l.GetDetails();
            //}

            //System.Console.ReadKey();

            //// GetFirstProviderByName()
            //System.Console.WriteLine("\n*****Le premier provider contenant le mot 'Fruit'. ");
            //manageProvider.GetFirstProviderByName("Fruit").GetDetails();

            //System.Console.ReadKey();

            //// GetProviderById()
            //System.Console.WriteLine("\n*****Le provider d'identifiant 3. ");
            //manageProvider.GetProviderById(3).GetDetails();
            //System.Console.ReadKey();

            #endregion

            #region Méthodes d'extension
            //manageProduct.UpperName(apple);
            //System.Console.WriteLine("\n " + apple.Name);
            //System.Console.ReadKey();

            //System.Console.WriteLine("\n " + manageProduct.InCategory(apple, Alimentaire));
            //System.Console.ReadKey();

            #endregion

            //setup our DI
            var serviceProvider = new ServiceCollection()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<IProviderService, ProviderService>()
            .AddScoped<IFactureService, FactureService>()
            .AddScoped<IClientService, ClientService>()
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>))
            .AddSingleton<IDatabaseFactory, DatabaseFactory>()
            .AddDbContext<GestionProduitsContext>()
            .BuildServiceProvider();

            // InitData(serviceProvider);

            var serviceproduct = serviceProvider.GetService<ProductService>();

            List<Product> productlist = serviceproduct.FindMost5ExpensiveProds();
            
            foreach(var prod in productlist)
            {
                prod.GetDetails();
            }
        }

        public static void InitData(ServiceProvider srvc)
        {
            //do the actual work here
            var servicecategory = srvc.GetService<ICategoryService>();
            var serviceproduct = srvc.GetService<IProductService>();
            var serviceprovider = srvc.GetService<IProviderService>();
            var servicefacture = srvc.GetService<IFactureService>();
            var serviceclient = srvc.GetService<IClientService>();


            #region Senario de test
            //Categories
            Category fruit = new Category() { Name = "Fruit" };
            servicecategory.Add(fruit);
            Category Alimentaire = new Category() { Name = "Alimentaire" };
            servicecategory.Add(Alimentaire);

            servicecategory.Commit();

            //Products
            Adress ad1 = new Adress { City = "sousse", StreetAdress = "22" };
           
            Product acide = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "ACIDE CITRIQUE",
                Description = "Monohydrate - E330 - USP32",
                MyCategory = Alimentaire,
                Price = 90,
                Quantity = 30,
                MyAddress = ad1
            };
            serviceproduct.Add(acide);
            Adress ad2 = new Adress { City = "Sfax", StreetAdress = "22" };

            Product cacao = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "POUDRE DE CACAO NATURELLE",
                Description = "10% -12%",
                MyCategory = Alimentaire,
                Price = 419,
                Quantity = 80,
                MyAddress = ad2
            };
            serviceproduct.Add(cacao);
            Adress ad3 = new Adress { City = "Tunis", StreetAdress = "22" };

            Product dioxyde = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "DIOXYDE DE TITANE",
                Description = "TiO2 grade alimentaire, cosmétique et pharmaceutique.",
                MyCategory = Alimentaire,
                Price = 200,
                Quantity = 50,
                MyAddress = ad3
            };
            serviceproduct.Add(dioxyde);


            Product amidon = new Chemical()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "AMIDON DE MAÏS",
                Description = "Amidon de maïs natif",
                MyCategory = Alimentaire,
                Price = 70,
                Quantity = 30,
                MyAddress = ad3
            };
            serviceproduct.Add(amidon);
            Product blackberry = new Biological()
            {
                DateProd = new DateTime(2000, 12, 12),
                Name = "Blackberry",
                Description = "",
                MyCategory = fruit,
                Price = 60,
                Quantity = 0

            };
            serviceproduct.Add(blackberry);
            Product apple = new Biological()
            {
                DateProd = new DateTime(2000, 12, 12),
                Description = "",
                MyCategory = fruit,
                Name = "Apple",
                Price = 100.00,
                Quantity = 100

            };
            serviceproduct.Add(apple);
            Product avocado = new Biological()
            {
                DateProd = new DateTime(2000, 12, 12),
                Description = "",
                MyCategory = fruit,
                Name = "Avocado",
                Price = 100.00,
                Quantity = 100

            };
            serviceproduct.Add(avocado);
            serviceproduct.Commit();

            List<Product> products1 = new List<Product>() { acide, cacao, dioxyde };
            List<Product> products2 = new List<Product>() { amidon, blackberry, apple, avocado };
            List<Product> products3 = new List<Product>() { dioxyde, amidon, blackberry, apple };

            //Providers
            Provider sater = new Provider() { UserName = "Medical Provider", Products = products1, Password = "123456", Email = "test1@gmail.com" };
            Provider sudMedical = new Provider() { UserName = "Fruit-SA Provider", Products = products2, Password = "123456", Email = "test2@gmail.com" };
            Provider palliserSa = new Provider() { UserName = "Fruit-CP  Provider", Products = products3, Password = "123456", Email = "test3@gmail.com" };
            Provider prov4 = new Provider() { UserName = "Chemical Med-Provider", Password = "123456", Email = "test4@gmail.com" };
            Provider prov5 = new Provider() { UserName = "Bio Provider", Password = "123456", Email = "test5@gmail.com" };
            List<Provider> providers1 = new List<Provider>() { sater, sudMedical, palliserSa, prov4, prov5 };

            serviceprovider.Add(sater);
            serviceprovider.Add(sudMedical);
            serviceprovider.Add(palliserSa);
            serviceprovider.Add(prov4);
            serviceprovider.Add(prov5);
            serviceprovider.Commit();

            //Clients
            Client clt1 = new Client()
            {
                Prenom = "Ali",
                Nom = "Ben Salah",
                Email = "ali@gmail.com"
            };
            serviceclient.Add(clt1);
          
            Client clt2 = new Client()
            {
                Prenom = "Mhmd",
                Nom = "Ben Salah",
                Email = "mhmd@gmail.com"
            };
            serviceclient.Add(clt1);

            Client clt3 = new Client()
            {
                Prenom = "Sami",
                Nom = "Ben Salah",
                Email = "sami@gmail.com"
            };
            serviceclient.Add(clt1);
            serviceclient.Commit();

            //Factures
            Facture fact1 = new Facture()
            {
                DateAchat = new DateTime(2021,10,05),
                Prix = 150,
                Client = clt1,
                Product = acide
            
            };
            servicefacture.Add(fact1);

            Facture fact2 = new Facture()
            {
                DateAchat = new DateTime(2021, 11, 05),
                Prix = 140,
                Client = clt2,
                Product = blackberry
              
            };
            servicefacture.Add(fact2);

            servicefacture.Commit();

            #endregion
        }
    }
}
