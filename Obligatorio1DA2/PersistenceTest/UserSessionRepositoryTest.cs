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
    public class UserSessionRepositoryTest
    {
        [TestMethod]
        public void GetAdminByMailAndPassword()
        {
            var options = new DbContextOptionsBuilder<UyNaturalContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new UyNaturalContext(options))
            {
                var repository = new UserSessionRepository(context);
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
                var repository = new UserSessionRepository(context);
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
            }
        }
    }
}
