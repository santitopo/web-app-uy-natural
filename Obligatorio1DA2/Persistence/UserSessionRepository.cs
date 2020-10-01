﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Persistence
{
    public class UserSessionRepository : Repository<Administrator>, IUserRepository
    {
        private readonly DbSet<Person> DbSet;
        private readonly DbContext context;
        public UserSessionRepository(DbContext context) : base(context)
        {
            this.DbSet = context.Set<Person>();
            this.context = context;
        }

        public Administrator GetAdminByMailAndPassword(string mail, string password)
        {
            Person a = DbSet.Where(x => x is Administrator && x.Mail == mail).FirstOrDefault();
            if (a!=null && ((Administrator)a).Password.Equals(password))
            {
                return a as Administrator;
            }
            else
            {
                return null;
            }
        }

    }
}
