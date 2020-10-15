using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceTest
{
    [TestClass]
    public class AdminRepositoryTest
    {
        [TestMethod]
        public void GetAdminByMailAndPassword()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new AdminRepository(context);
                Administrator admin1 = new Administrator()
                {
                    Name = "admin1",
                    Surname = "admin1",
                    Mail = "admin1",
                    Password = "admin1"
                };

                Administrator admin2 = new Administrator()
                {
                    Name = "admin2",
                    Surname = "admin2",
                    Mail = "admin2",
                    Password = "admin2"
                };

                context.Set<Person>().Add(admin1);
                context.Set<Person>().Add(admin2);
                context.SaveChanges();

                string[] strlst = { };
                Administrator ret = repository.GetAdminByMailAndPassword(admin1.Mail, admin1.Password);
                Assert.AreEqual(admin1, ret);

                context.Set<Person>().Remove(admin1);
                context.Set<Person>().Remove(admin2);
                context.SaveChanges();
            }

        }

        [TestMethod]
        public void GetNullAdminByMailAndPassword()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new AdminRepository(context);
                Administrator admin1 = new Administrator()
                {
                    Name = "admin1",
                    Surname = "admin1",
                    Mail = "admin1",
                    Password = "admin1"
                };

                context.Set<Person>().Add(admin1);
                context.SaveChanges();

                string[] strlst = { };
                Administrator ret = repository.GetAdminByMailAndPassword("admin2", "admin1");
                Assert.IsNull(ret);

                context.Set<Person>().Remove(admin1);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void GetAdminByMail()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new AdminRepository(context);
                Administrator admin1 = new Administrator()
                {
                    Name = "admin1",
                    Surname = "admin1",
                    Mail = "admin1",
                    Password = "admin1"
                };

                Administrator admin2 = new Administrator()
                {
                    Name = "admin2",
                    Surname = "admin2",
                    Mail = "admin2",
                    Password = "admin2"
                };

                context.Set<Person>().Add(admin1);
                context.Set<Person>().Add(admin2);
                context.SaveChanges();

                string[] strlst = { };
                Administrator ret = repository.GetAdminByMail(admin1.Mail);
                Assert.AreEqual(admin1, ret);

                context.Set<Person>().Remove(admin1);
                context.Set<Person>().Remove(admin2);
                context.SaveChanges();
            }

        }

        [TestMethod]
        public void GetNullAdminByMail()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new AdminRepository(context);
                Administrator admin1 = null;

                string[] strlst = { };
                Administrator ret = repository.GetAdminByMail("test");
                Assert.IsNull(ret);
            }

        }

        [TestMethod]
        public void GetClientByAttributes()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new AdminRepository(context);
                Client client1 = new Client()
                {
                    Name = "client1",
                    Surname = "client1",
                    Mail = "cli1@gmail.com",
                };
                Client client2 = new Client()
                {
                    Name = "client2",
                    Surname = "client2",
                    Mail = "cli2@gmail.com",
                };


                context.Set<Person>().Add(client1);
                context.Set<Person>().Add(client2);
                context.SaveChanges();

                string[] strlst = { };
                Client ret = repository.GetClientbyAttributes(client1.Mail, client1.Name, client1.Surname);
                Assert.AreEqual(client1, ret);

                context.Set<Person>().Remove(client2);
                context.Set<Person>().Remove(client2);
                context.SaveChanges();
            }

        }

        [TestMethod]
        public void GetNullClientByAttributes()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new AdminRepository(context);
                
                Client ret = repository.GetClientbyAttributes("mail", "Name", "Surname");
                Assert.IsNull(ret);
            }
        }

    }
}
