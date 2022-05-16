using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ciudadano.Api.Models;
using Ciudadano.Api.Models.Establecimientos;
using Ciudadano.Api.Models.Establecimientos.Dtos;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]
    public class EstablecimientosController : BaseController<Establecimiento>
    {
        private readonly IRepository<Establecimiento> _repository;
        private readonly ILogger<EstablecimientosController> _logger;
        private readonly IEstablecimientoRepository _establecimientoRepository;
        private readonly IMapper _mapper;

        public EstablecimientosController(
            IRepository<Establecimiento> repository,
            ILogger<EstablecimientosController> logger,
            IEstablecimientoRepository establecimientoRepository,
            IMapper mapper) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _establecimientoRepository = establecimientoRepository;
            BaseControllerOptions.GetAll = true;
            _mapper = mapper;
        }

        [HttpGet, Route("custom/all")]
        public IActionResult CustomGetAll()
        {
            var result = _establecimientoRepository.CustomGetAll();
            return Ok(result);
        }

        [HttpGet, Route("name/{name}")]
        public ICollection<Establecimiento> Get(string name)
        {
            return _establecimientoRepository.Get(e => e.Nombre.Contains(name));
        }

        [HttpGet, Route("async/name/{name}")]
        public async Task<ICollection<Establecimiento>> GetAsync(string name)
        {
            return await _establecimientoRepository.GetAsync(e => e.Nombre.Contains(name));
        }

        [HttpPost, Route("count-where")]
        public int CountWhere(Filter filter)
        {
            Expression<Func<Establecimiento, bool>> where = e => true;
            if (!string.IsNullOrEmpty(filter?.Value))
            {
                switch (filter.By)
                {
                    case "Nombre":
                        where = e => e.Nombre.Contains(filter.Value);
                        break;
                    case "Codigo":
                        where = e => e.Codigo.Contains(filter.Value);
                        break;
                    default:
                        where = e => e.Nombre.Contains(filter.Value) || e.Codigo.Contains(filter.Value);
                        break;
                }
            }
            return _establecimientoRepository.Count(where);
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
        [HttpPost, Route("query")]
        public QueryDto<Establecimiento> GetByQuery(QueryDto<Establecimiento> queryDto)
        {
            var query = new Query<Establecimiento>(queryDto.Page.PageNumber, queryDto.Page.Top);

            if (!string.IsNullOrEmpty(queryDto.Order?.By))
            {
                Func<Establecimiento, object> orderBy;
                switch (queryDto.Order.By)
                {
                    case "Nombre":
                        orderBy = e => e.Nombre;
                        break;
                    case "Codigo":
                        orderBy = e => e.Codigo;
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
                    case "Codigo":
                        query.Where = e => e.Codigo.Contains(queryDto.Filter.Value);
                        break;
                    default:
                        query.Where = e => e.Nombre.Contains(queryDto.Filter.Value) || e.Codigo.Contains(queryDto.Filter.Value);
                        break;
                }
            }
            var results = _establecimientoRepository.GetByQuery(query).ToList();
            queryDto.Results = results;
            return queryDto;
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
        [HttpPost, Route("custom/query")]
        public EstablecimientoQueryDto CustomGetByQuery(EstablecimientoQueryDto queryDto)
        {
            var query = new EstablecimientoQuery(queryDto.Page.PageNumber, queryDto.Page.Top);

            if (!string.IsNullOrEmpty(queryDto.Order?.By))
            {
                Func<EstablecimientoWebDto, object> orderBy;
                switch (queryDto.Order.By)
                {
                    case "Nombre":
                        orderBy = e => e.Nombre;
                        break;
                    case "Codigo":
                        orderBy = e => e.Codigo;
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
                    case "Codigo":
                        query.Where = e => e.Codigo.Contains(queryDto.Filter.Value);
                        break;
                    default:
                        query.Where = e => e.Nombre.Contains(queryDto.Filter.Value) || e.Codigo.Contains(queryDto.Filter.Value);
                        break;
                }
            }
            var results = _establecimientoRepository.CustomGetByQuery(query).ToList();
            queryDto.Results = results;
            return queryDto;
        }

        [HttpPost, Route("custom/add")]
        public IActionResult CustomAdd(EstablecimientoWebDto input)
        {
            var estab = _establecimientoRepository.GetById(input.Id);
            if (estab != null) return BadRequest("Ya existe un registro con el mismo ID proporcionado.");
            estab = _mapper.Map<Establecimiento>(input);
            _establecimientoRepository.InsertAndSave(estab);
            return Ok(estab);
        }
    }
}
