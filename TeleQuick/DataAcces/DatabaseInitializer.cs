﻿// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using Business;
using  Business.Models;
using IDataAccess;
using IDataAccess.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountManager _accountManager;
        private readonly ILogger _logger;

        public DatabaseInitializer(ApplicationDbContext context, IAccountManager accountManager, ILogger<DatabaseInitializer> logger)
        {
            _accountManager = accountManager;
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Users.AnyAsync())
            {
                _logger.LogInformation("Generating inbuilt accounts");

                const string adminRoleName = "administrator";
                const string userRoleName = "user";

                await EnsureRoleAsync(adminRoleName, "Default administrator", ApplicationPermissions.GetAllPermissionValues());
                await EnsureRoleAsync(userRoleName, "Default user", new string[] { });

                await CreateUserAsync("admin", "tempP@ss123", "Inbuilt Administrator", "admin@ebenmonney.com", "+1 (123) 000-0000", new string[] { adminRoleName });
                await CreateUserAsync("user", "tempP@ss123", "Inbuilt Standard User", "user@ebenmonney.com", "+1 (123) 000-0001", new string[] { userRoleName });

                _logger.LogInformation("Inbuilt account generation completed");
            }



            if (!await _context.Customers.AnyAsync() && !await _context.ProductCategories.AnyAsync())
            {
                _logger.LogInformation("Seeding initial data");

                Concessionary cons_1 = new Concessionary
                {
                    Name = "AUSA",
                    Detail = "contact@ebenmonney.com",
                    MainForm = "MAINFORM",
                    Uri = "https://cliente.ausa.com.ar/fael/servlet/hlogin?6,0",
                };

                Concessionary cons_2 = new Concessionary
                {
                    Name = "AUSOL",
                    Detail = "contact@ebenmonney.com",
                    MainForm = "form1",
                    Uri = "https://www.ausol.com.ar:91/WebPages/EstadoCuenta/Login.aspx",
                };

                Concessionary cons_3 = new Concessionary
                {
                    Name = "AUBASA",
                    Detail = "contact@ebenmonney.com",
                };

                Concessionary cons_4 = new Concessionary
                {
                    Name = "AUSUR",
                    Detail = "contact@ebenmonney.com",
                };

                Concessionary cons_5 = new Concessionary
                {
                    Name = "AUOESTE",
                    Detail = "contact@ebenmonney.com",
                };

                Concessionary cons_6 = new Concessionary
                {
                    Name = "CEAMSE",
                    Detail = "contact@ebenmonney.com",
                };

                Customer cust_1 = new Customer
                {
                    Name = "Ebenezer Monney",
                    Email = "contact@ebenmonney.com",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Customer cust_2 = new Customer
                {
                    Name = "Itachi Uchiha",
                    Email = "uchiha@narutoverse.com",
                    PhoneNumber = "+81123456789",
                    Address = "Some fictional Address, Street 123, Konoha",
                    City = "Konoha",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Customer cust_3 = new Customer
                {
                    Name = "John Doe",
                    Email = "johndoe@anonymous.com",
                    PhoneNumber = "+18585858",
                    Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                    Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet",
                    City = "Lorem Ipsum",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Customer cust_4 = new Customer
                {
                    Name = "Jane Doe",
                    Email = "Janedoe@anonymous.com",
                    PhoneNumber = "+18585858",
                    Address = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio.
                    Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet",
                    City = "Lorem Ipsum",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };



                ProductCategory prodCat_1 = new ProductCategory
                {
                    Name = "None",
                    Description = "Default category. Products that have not been assigned a category",
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };



                Product prod_1 = new Product
                {
                    Name = "BMW M6",
                    Description = "Yet another masterpiece from the world's best car manufacturer",
                    BuyingPrice = 109775,
                    SellingPrice = 114234,
                    UnitsInStock = 12,
                    IsActive = true,
                    ProductCategory = prodCat_1,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                Product prod_2 = new Product
                {
                    Name = "Nissan Patrol",
                    Description = "A true man's choice",
                    BuyingPrice = 78990,
                    SellingPrice = 86990,
                    UnitsInStock = 4,
                    IsActive = true,
                    ProductCategory = prodCat_1,
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };



                Order ordr_1 = new Order
                {
                    Discount = 500,
                    Cashier = await _context.Users.FirstAsync(),
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail() {UnitPrice = prod_1.SellingPrice, Quantity=1, Product = prod_1 },
                        new OrderDetail() {UnitPrice = prod_2.SellingPrice, Quantity=1, Product = prod_2 },
                    }
                };

                Order ordr_2 = new Order
                {
                    Cashier = await _context.Users.FirstAsync(),
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail() {UnitPrice = prod_2.SellingPrice, Quantity=1, Product = prod_2 },
                    }
                };
                _context.Concessionaries.Add(cons_1);
                _context.Concessionaries.Add(cons_2);
                _context.Concessionaries.Add(cons_3);
                _context.Concessionaries.Add(cons_4);
                _context.Concessionaries.Add(cons_5);
                _context.Concessionaries.Add(cons_6);

                _context.Customers.Add(cust_1);
                _context.Customers.Add(cust_2);
                _context.Customers.Add(cust_3);
                _context.Customers.Add(cust_4);

                _context.Products.Add(prod_1);
                _context.Products.Add(prod_2);

                _context.Orders.Add(ordr_1);
                _context.Orders.Add(ordr_2);

                await _context.SaveChangesAsync();

                _logger.LogInformation("Seeding initial data completed");
            }
        }



        private async Task EnsureRoleAsync(string roleName, string description, string[] claims)
        {
            if ((await _accountManager.GetRoleByNameAsync(roleName)) == null)
            {
                ApplicationRole applicationRole = new ApplicationRole(roleName, description);

                var result = await this._accountManager.CreateRoleAsync(applicationRole, claims);

                if (!result.Succeeded)
                    throw new Exception($"Seeding \"{description}\" role failed. Errors: {string.Join(Environment.NewLine, result.Errors)}");
            }
        }

        private async Task<ApplicationUser> CreateUserAsync(string userName, string password, string fullName, string email, string phoneNumber, string[] roles)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = userName,
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                EmailConfirmed = true,
                IsEnabled = true
            };

            var result = await _accountManager.CreateUserAsync(applicationUser, roles, password);

            if (!result.Succeeded)
                throw new Exception($"Seeding \"{userName}\" user failed. Errors: {string.Join(Environment.NewLine, result.Errors)}");


            return applicationUser;
        }
    }
}
