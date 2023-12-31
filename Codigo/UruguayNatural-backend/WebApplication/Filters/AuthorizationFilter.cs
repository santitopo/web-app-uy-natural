﻿using LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private ISessionLogic logic;
        public AuthorizationFilter(ISessionLogic logic)
        {
            this.logic = logic;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["token"];
            if (token == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Error. No existe la sesión."
                };
                return;
            }
            if (!logic.IsLogued(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "Error. No estas logueado."
                };
                return;
            }
        }
    }
}
