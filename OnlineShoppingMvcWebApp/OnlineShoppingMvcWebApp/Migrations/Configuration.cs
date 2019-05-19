namespace OnlineShoppingMvcWebApp.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShoppingMvcWebApp.Models.MyAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineShoppingMvcWebApp.Models.MyAppDbContext context)
        {
            context.RegisteredUser.AddOrUpdate(
                new RegisteredUser() { registeredUserId = 1, userName = "Afiqah", password = "123", role = "Admin" },
                new RegisteredUser() { registeredUserId = 2, userName = "Saadah", password = "123", role = "ShipmentAgent" },
                new RegisteredUser() { registeredUserId = 3, userName = "Balqis", password = "123", role = "Customer" });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Book.AddOrUpdate(
                new Book() { BookId = 1, Title = "Learning C++ by Building Games with Unreal Engine 4", Publisher = "Pakct Publishing", Year = "2018", CoverPage = "https://itbook.store/img/books/9781788476249.png", ISBN = "9781788476249", Author = "Sharan Volin", Category = "C#", Price = 44.99 },
                new Book() { BookId = 2, Title = "Modern Algorithms for Image Processing", Publisher = "Apress", Year = "2019", CoverPage = "https://itbook.store/img/books/9781484242360.png", ISBN = "9781484242360", Author = "Vladimir Kovalevsky", Category = "C#", Price = 37.99 },
                new Book() { BookId = 3, Title = "Developing 2D Games with Unity", Publisher = "Apress", Year = "2019", CoverPage = "https://itbook.store/img/books/9781484237717.png", ISBN = "9781484237717", Author = "Jared Halpern", Category = "C#", Price = 22.25 },
                new Book() { BookId = 4, Title = "Building Xamarin.Forms Mobile Apps Using XAML", Publisher = "Cengage", Year = "2014", CoverPage = "https://itbook.store/img/books/9781484240298.png", ISBN = "9781484240298", Author = "Dan Hermes,Nima Mazloumi", Category = "C#", Price = 26.70 },
                new Book() { BookId = 5, Title = "Professional SQL Server Reporting Services", Publisher = "Wrox", Year = "2004", CoverPage = "https://itbook.store/img/books/9780764576942.png", ISBN = "9780764576942", Author = "Paul Turley, Todd Bryant", Category = "C#", Price = 20.99 },
                new Book() { BookId = 6, Title = "Web Services Essentials", Publisher = "O'Reilly Media", Year = "2002", CoverPage = "https://itbook.store/img/books/9780596002244.png", ISBN = "9780596002244", Author = "Ethan Cerami", Category = "C#", Price = 13.99 },
                new Book() { BookId = 7, Title = "Arduino Cookbook, 2nd Edition", Publisher = "O'Reilly Media", Year = "2011", CoverPage = "https://itbook.store/img/books/9781449313876.png", ISBN = "9781449313876", Author = "Michael Margolis", Category = "Arduino", Price = 9.50 },
                new Book() { BookId = 8, Title = "Make a Mind-Controlled Arduino Robot", Publisher = "O'Reilly Media", Year = "2011", CoverPage = "https://itbook.store/img/books/9781449311544.png", ISBN = "9781449311544", Author = "Tero Karvinen", Category = "Arduino", Price = 4.99 },
                new Book() { BookId = 9, Title = "Beginning C for Arduino, 2nd Edition", Publisher = "Apress", Year = "2018", CoverPage = "https://itbook.store/img/books/9781484209417.png", ISBN = "9781484209417", Author = "Jack Purdum", Category = "Arduino", Price = 26.99 },
                new Book() { BookId = 10, Title = "Programming PIC Microcontrollers with XC8", Publisher = "Apress", Year = "2018", CoverPage = "https://itbook.store/img/books/9781484232729.png", ISBN = "9781484232729", Author = "Armstrong Subero", Category = "Arduino", Price = 28.82 },
                new Book() { BookId = 11, Title = "Coding the Arduino", Publisher = "Apress", Year = "2018", CoverPage = "https://itbook.store/img/books/9781484235096.png", ISBN = "9781484235096", Author = "Bob Dukish", Category = "Arduino", Price = 30.99 },
                new Book() { BookId = 12, Title = "Oracle SOA Suite 12c Administrator's Guide", Publisher = "Packt Publishing", Year = "2018", CoverPage = "https://itbook.store/img/books/9781782170860.png", ISBN = "9781782170860", Author = "Arun Pareek", Category = "Administration", Price = 47.99 },
                new Book() { BookId = 13, Title = "MongoDB Cookbook, 2nd Edition", Publisher = "Packt Publishing", Year = "2016", CoverPage = "https://itbook.store/img/books/9781785289989.png", ISBN = "9781785289989", Author = "Cyrus Dasadia", Category = "Administration", Price = 35.99 },
                new Book() { BookId = 14, Title = "The Accidental SysAdmin Handbook, 2nd Edition", Publisher = "Apress", Year = "2018", CoverPage = "https://itbook.store/img/books/9781484218167.png", ISBN = "9781484218167", Author = "Eric Kralicek", Category = "Administration", Price = 33.79 },
                new Book() { BookId = 15, Title = "Moodle 3 Administration, 3rd Edition", Publisher = "Packt Publishing", Year = "2016", CoverPage = "https://itbook.store/img/books/9781783289714.png", ISBN = "9781783289714", Author = "Alex Buchner", Category = "Administration", Price = 39.99 },
                new Book() { BookId = 16, Title = "Exam Ref 70-765 Provisioning SQL Databases", Publisher = "Microsoft Press", Year = "2017", CoverPage = "https://itbook.store/img/books/9781509303816.png", ISBN = "9781509303816", Author = "Joseph D'Antoni", Category = "Administration", Price = 44.99 },
                new Book() { BookId = 17, Title = "Hands-On Linux Administration on Azure", Publisher = "Packt Publishing", Year = "2018", CoverPage = "https://itbook.store/img/books/9781789130966.png", ISBN = "9781789130966", Author = "Frederik Vos", Category = "Administration", Price = 44.99 },
                new Book() { BookId = 18, Title = "Mastering Office 365 Administration", Publisher = "Packt Publishing", Year = "2018", CoverPage = "https://itbook.store/img/books/9781787288638.png", ISBN = "9781787288638", Author = "Thomas Carpe", Category = "Administration", Price = 31.99 });



        }
    }
}
