using System;
using System.Collections.Generic;
using Domain;

namespace LogicInterface
{
    public interface ISessionLogic
    {
        string LogIn(string nickname, string password);
        void LogOut(string token);
        bool IsLogued(string token);
    }
}
