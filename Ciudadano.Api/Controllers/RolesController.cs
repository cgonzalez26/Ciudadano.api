using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models;
using Ciudadano.Api.Models.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : BaseController<Rol>
    {
        private readonly IRepository<Rol> _repository;
        private readonly ILogger<RolesController> _logger;
        private readonly IRolRepository _rolRepository;

        public RolesController(
            IRepository<Rol> repository,
            ILogger<RolesController> logger,
            IRolRepository rolRepository) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _rolRepository = rolRepository;
            BaseControllerOptions.GetAll = true;
        }

        [HttpGet, Route("name/{name}")]
        public ICollection<Rol> Get(string name)
        {
            return _repository.Get(e => e.Nombre.Contains(name));
        }

        [HttpGet, Route("async/name/{name}")]
        public async Task<ICollection<Rol>> GetAsync(string name)
        {
            return await _repository.GetAsync(e => e.Nombre.Contains(name));
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
        public ICollection<Rol> GetByQuery(QueryDto<Rol> queryDto)
        {
            var query = new Query<Rol>(queryDto.Page.PageNumber, queryDto.Page.Top);

            if (!string.IsNullOrEmpty(queryDto.Order?.By))
            {
                Func<Rol, object> orderBy;
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

        [AllowAnonymous]
        [HttpPost, Route("add2")]
        public IActionResult Add2(Rol rol)
        {
            Repository.InsertAndSave(rol);
            return Ok();
        }
    }
}
