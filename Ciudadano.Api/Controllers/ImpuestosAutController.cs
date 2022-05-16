using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models;
using Ciudadano.Api.Models.ImpuestosAut;
using Ciudadano.Api.Models.ImpuestosAut.Dtos;

namespace Ciudadano.Api.Controllers
{
    [Route("api/[controller]")]
    public class ImpuestosAutController : BaseController<ImpuestoAut>
    {
        private readonly IRepository<ImpuestoAut> _repository;
        private readonly ILogger<ImpuestosAutController> _logger;
        private readonly IImpuestoAutRepository _impuestos_autRepository;
        private readonly IMapper _mapper;

        public ImpuestosAutController(
            IRepository<ImpuestoAut> repository,
            ILogger<ImpuestosAutController> logger,
            IImpuestoAutRepository impuestos_autRepository,
            IMapper mapper) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger;
            _impuestos_autRepository = impuestos_autRepository;
            BaseControllerOptions.GetAll = true;
            _mapper = mapper;
        }

        [HttpGet, Route("getByNroDocumento/{NroDocumento}")]
        public ICollection<ImpuestoAutWebDto> getByNroDocumento(string NroDocumento) 
        {
            return _impuestos_autRepository.getByNroDocumento(NroDocumento);
        }

        [HttpGet, Route("getCountDeudaByNroDocumento/{NroDocumento}")]
        public int getCountDeudaByNroDocumento(string NroDocumento)
        {
            return _impuestos_autRepository.getCountDeudaByNroDocumento(NroDocumento);
        }
    }
}
