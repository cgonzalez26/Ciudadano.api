using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Ciudadano.Api.Attributes
{
    public class IdentityServerAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var sub = ClaimsPrincipal.Current.FindAll("sub").Select(c => c.Value).FirstOrDefault();
            //if (!string.IsNullOrEmpty(sub))
            //{
            //    try
            //    {
            //        var identityServerUser = JsonConvert.DeserializeObject<IdentityServerUser>(sub);
            //        if (identityServerUser == null || !identityServerUser.Roles.Any(s => s.CodSistema.Equals(ConfigurationManager.AppSettings["ApplicationCode"])))
            //        {
            //            HttpContext.Current.Response.StatusCode = 403;
            //            httpActionContext.Response = new HttpResponseMessage
            //            {
            //                StatusCode = HttpStatusCode.Forbidden,
            //                Content = new StringContent("No posee autorización para acceder a esta aplicación.")
            //            };
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        HttpContext.Current.Response.StatusCode = 500;
            //        httpActionContext.Response = new HttpResponseMessage
            //        {
            //            StatusCode = HttpStatusCode.InternalServerError,
            //            Content = new StringContent("Ocurrio un error en el atributo de autorización [ServerAuthorize].")
            //        };
            //    }
            //}
        }
    }
}
