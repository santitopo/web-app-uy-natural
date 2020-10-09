using Domain;
using System;
using System.Collections.Generic;

namespace PersistenceInterface
{
    public interface IAdminRepository : IRepository<Administrator>
    {
        Administrator GetAdminByMailAndPassword(string mail, string password);
        Administrator GetAdminByMail(string mail);
        Client GetClientbyAttributes(string mail, string name, string surname);
    }
}
