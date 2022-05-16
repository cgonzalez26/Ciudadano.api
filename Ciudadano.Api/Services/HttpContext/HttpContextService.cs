using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ciudadano.Api.Services.HttpContext
{
    public class HttpContextService
    {
        private readonly IHttpContextAccessor _context;

        public HttpContextService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetUserId()
        {
            return _context.HttpContext.User?.Identity?.Name;
        }

        public string GetUserName()
        {
            return _context.HttpContext.User?.FindFirst(c => c.Type.Equals("UserName"))?.Value;
        }

        public string GetFullName()
        {
            return _context.HttpContext.User?.FindFirst(c => c.Type.Equals("FullName"))?.Value;
        }
    }
}
