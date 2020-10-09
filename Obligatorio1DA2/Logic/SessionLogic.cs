using Domain;
using LogicInterface;
using PersistenceInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class SessionLogic : ISessionLogic
    {
        private readonly IUserRepository userRepository;
        private readonly IRepository<UserSession> repository;
        public SessionLogic(IUserRepository userRepository, IRepository<UserSession> repository)
        {
            this.userRepository = userRepository;
            this.repository = repository;
        }

        public bool IsLogued(string token)
        {
            string[] param = { };
            UserSession userSession = repository.GetAll(param).Where(x => x.Token == token).FirstOrDefault();
            return userSession != null;
        }

        public string LogIn(string mail, string password)
        {
            Administrator admin = userRepository.GetAdminByMailAndPassword(mail, password);
            if (admin == null) throw new InvalidOperationException("Usuario o contraseña incorrectos");
            string[] param = {"User"};
            UserSession userSession = repository.GetAll(param).Where(x => x.User.Id == admin.Id).FirstOrDefault();
            if (userSession == null)
            {
                Guid token = Guid.NewGuid();
                userSession = new UserSession()
                {
                    User = admin,
                    Token = token.ToString()
                };
                repository.Create(userSession);
                repository.Save();
            }
            return userSession.Token;
        }

        public void LogOut(string token)
        {
            string[] param = { };
            UserSession userSession = repository.GetAll(param).Where(x => x.Token == token).FirstOrDefault();
            if (userSession != null) {
                repository.Delete(userSession);
                repository.Save();
            }
            else
            {
                throw new InvalidOperationException("El token no existe");
            }
        }
    }
}
