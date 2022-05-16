using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models;
using Ciudadano.Api.Models.TipoDenuncias;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]
    public class TipoDenunciasController : BaseController<TipoDenuncia>
    {
        private readonly IRepository<TipoDenuncia> _repository;
        private readonly ILogger<TipoDenunciasController> _logger;
        private readonly ITipoDenunciaRepository _tipoDenunciasRepository;

        public TipoDenunciasController(
            IRepository<TipoDenuncia> repository,
            ILogger<TipoDenunciasController> logger,
            ITipoDenunciaRepository tipoDenunciasRepository) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _tipoDenunciasRepository = tipoDenunciasRepository;
            BaseControllerOptions.GetAll = true;
        }

        [HttpGet, Route("name/{name}")]
        public ICollection<TipoDenuncia> Get(string name)
        {
            return _repository.Get(e => e.Nombre.Contains(name));
        }

        [HttpGet, Route("async/name/{name}")]
        public async Task<ICollection<TipoDenuncia>> GetAsync(string name)
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
        ///         "By": "Name",
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
        public ICollection<TipoDenuncia> GetByQuery(QueryDto<TipoDenuncia> queryDto)
        {
            var query = new Query<TipoDenuncia>(queryDto.Page.PageNumber, queryDto.Page.Top);

            if (!string.IsNullOrEmpty(queryDto.Order?.By))
            {
                Func<TipoDenuncia, object> orderBy;
                switch (queryDto.Order.By)
                {
                    case "Name":
                        orderBy = e => e.Nombre;
                        break;
                    case "Description":
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
                    case "Name":
                        query.Where = e => e.Nombre.Contains(queryDto.Filter.Value);
                        break;
                    case "Description":
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

