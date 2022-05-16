using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models;
using Ciudadano.Api.Models.Permisos;
using Ciudadano.Api.Models.Permisos.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]
    public class PermisosController : BaseController<Permiso>
    {
        private readonly IRepository<Permiso> _repository;
        private readonly ILogger<PermisosController> _logger;
        private readonly IPermisoRepository _permissionRepository;

        public PermisosController(
            IRepository<Permiso> repository,
            ILogger<PermisosController> logger,
            IPermisoRepository permissionRepository) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _permissionRepository = permissionRepository;
            BaseControllerOptions.GetAll = true;
        }

        [HttpGet, Route("name/{name}")]
        public ICollection<Permiso> Get(string name)
        {
            return _repository.Get(e => e.Nombre.Contains(name));
        }

        [HttpGet, Route("async/name/{name}")]
        public async Task<ICollection<Permiso>> GetAsync(string name)
        {
            return await _repository.GetAsync(e => e.Nombre.Contains(name));
        }
        [AllowAnonymous]
        [HttpGet, Route("GetByRolId/{roleId}")]
        public ICollection<PermisoWebDto> GetByRolId(string roleId)
        {
            return _permissionRepository.GetByRolId(roleId);
        }

        /// <summary>
        /// Ejemplo:
        /// {
        ///     "Page": {
        ///         "PageNumber": 1,
        ///         "Top": 5
        ///     },
        ///     "Order": {
        ///         "By": "Nombre",
        ///         "Direction": 2
        ///     },
        ///     "Filter": {
        ///         "Value": "Computadora"
        ///     }
        /// }
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        [HttpGet, Route("query")]
        public ICollection<Permiso> GetByQuery(QueryDto<Permiso> queryDto)
        {
            var query = new Query<Permiso>(queryDto.Page.PageNumber, queryDto.Page.Top);

            if (!string.IsNullOrEmpty(queryDto.Order?.By))
            {
                Func<Permiso, object> orderBy;
                switch (queryDto.Order.By)
                {
                    case "Nombre":
                        orderBy = e => e.Nombre;
                        break;
                    case "Descripcion":
                        orderBy = e => e.Descripcion;
                        break;
                    default:
                        orderBy = e => e.Id;
                        break;
                }
                switch (queryDto.Order.Direction)
                {
                    case Direction.Ascending:
                        query.OrderBy = orderBy;
                        break;
                    case Direction.Descending:
                        query.OrderByDescending = orderBy;
                        break;
                }
            }

            if (!string.IsNullOrEmpty(queryDto.Filter?.Value))
            {
                switch (queryDto.Filter.By)
                {
                    case "Nombre":
                        query.Where = e => e.Nombre.Contains(queryDto.Filter.Value);
                        break;
                    case "Descripcion":
                        query.Where = e => e.Descripcion.Contains(queryDto.Filter.Value);
                        break;
                    default:
                        query.Where = e => e.Nombre.Contains(queryDto.Filter.Value) || e.Descripcion.Contains(queryDto.Filter.Value);
                        break;
                }
            }
            return _repository.GetByQuery(query);
        }
    }
}
