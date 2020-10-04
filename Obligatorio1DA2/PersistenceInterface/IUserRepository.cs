using Domain;
using System;
using System.Collections.Generic;

namespace PersistenceInterface
{
    public interface IUserRepository : IRepository<Administrator>
    {
        Administrator GetAdminByMailAndPassword(string mail, string password);
        Administrator GetAdminByMail(string mail);
    }
}
