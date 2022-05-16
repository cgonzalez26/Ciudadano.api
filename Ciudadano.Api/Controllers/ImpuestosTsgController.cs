using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models;
using Ciudadano.Api.Models.ImpuestosTsg;
using Ciudadano.Api.Models.ImpuestosTsg.Dtos;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]
    public class ImpuestosTsgController : BaseController<ImpuestoTsg>
    {
        private readonly IRepository<ImpuestoTsg> _repository;
        private readonly ILogger<ImpuestosTsgController> _logger;
        private readonly IImpuestoTsgRepository _impuestos_tsgRepository;
        private readonly IMapper _mapper;

        public ImpuestosTsgController(
            IRepository<ImpuestoTsg> repository,
            ILogger<ImpuestosTsgController> logger,
            IImpuestoTsgRepository impuestos_tsgRepository,
            IMapper mapper) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _impuestos_tsgRepository = impuestos_tsgRepository;
            BaseControllerOptions.GetAll = true;
            _mapper = mapper;
        }

        [HttpGet, Route("getByNroDocumento/{NroDocumento}")]
        public ICollection<ImpuestoTsgWebDto> getByNroDocumento(string NroDocumento)
        {
            return _impuestos_tsgRepository.getByNroDocumento(NroDocumento);
        }

        [HttpGet, Route("getCountDeudaByNroDocumento/{NroDocumento}")]
        public int getCountDeudaByNroDocumento(string NroDocumento)
        {
            return _impuestos_tsgRepository.getCountDeudaByNroDocumento(NroDocumento);
        }
    }
}
