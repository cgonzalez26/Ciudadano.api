using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models;
using Ciudadano.Api.Models.RolPermisos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]
    public class RolPermisosController : BaseController<RolPermiso>
    {
        private readonly IRepository<RolPermiso> _repository;
        private readonly ILogger<RolPermisosController> _logger;
        private readonly IRolPermisoRepository _rolPermisoRepository;

        public RolPermisosController(
            IRepository<RolPermiso> repository,
            ILogger<RolPermisosController> logger,
            IRolPermisoRepository rolPermisoRepository) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _rolPermisoRepository = rolPermisoRepository;
        }
    }
}
