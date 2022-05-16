using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.ImpuestosInm.Dtos;

namespace Ciudadano.Api.Models.ImpuestosInm
{
    public class ImpuestoInmRepository : Repository<ImpuestoInm>, IImpuestoInmRepository
    {
        public ImpuestoInmRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<ImpuestoInmWebDto> getByNroDocumento(string NroDocumento)
        {
            var imp_inm = from ii in Context.ImpuestosInm
                          join i in Context.Inmuebles on ii.InmuebleId equals i.Id
                          join it in Context.InmueblesTitulares on i.Id equals it.InmuebleId
                          join t in Context.Titulares on it.TitularId equals t.Id
                          where (t.sNroDocumento.Equals(NroDocumento) || NroDocumento.Equals("admin"))
                          orderby ii.sCatastro, ii.iAnio, ii.iPeriodo
                          select new ImpuestoInmWebDto
                          {
                              Id = ii.Id,
                              dFecha_Pago = ii.dFecha_Pago,
                              iAnio = ii.iAnio,
                              iPeriodo = ii.iPeriodo,
                              nMonto_Pagar = ii.nMonto_Pagar,
                              sCatastro = ii.sCatastro,
                              nPago = ii.nPago,
                              nSaldo = ii.nSaldo,
                              InmuebleId = ii.InmuebleId
                          };
            /*if (NroDocumento.Equals("admin"))
            {
                imp_inm = from ii in Context.ImpuestosInm
                          join i in Context.Inmuebles on ii.InmuebleId equals i.Id
                          join it in Context.InmueblesTitulares on i.Id equals it.InmuebleId
                          join t in Context.Titulares on it.TitularId equals t.Id
                          orderby ii.sCatastro, ii.iAnio, ii.iPeriodo
                          select new ImpuestoInmWebDto
                          {
                              Id = ii.Id,
                              dFecha_Pago = ii.dFecha_Pago,
                              iAnio = ii.iAnio,
                              iPeriodo = ii.iPeriodo,
                              nMonto_Pagar = ii.nMonto_Pagar,
                              sCatastro = ii.sCatastro,
                              nPago = ii.nPago,
                              nSaldo = ii.nSaldo,
                              InmuebleId = ii.InmuebleId
                          };
            }*/
            return imp_inm.ToList();

        }

        public int getCountDeudaByNroDocumento(string NroDocumento)
        {
            var imp_inm = from ii in Context.ImpuestosInm
                          join i in Context.Inmuebles on ii.InmuebleId equals i.Id
                          join it in Context.InmueblesTitulares on i.Id equals it.InmuebleId
                          join t in Context.Titulares on it.TitularId equals t.Id
                          where (t.sNroDocumento.Equals(NroDocumento) || NroDocumento.Equals("admin"))
                          && ii.nPago < ii.nMonto_Pagar
                          select new ImpuestoInmWebDto
                          {
                              Id = ii.Id,
                              dFecha_Pago = ii.dFecha_Pago,
                              iAnio = ii.iAnio,
                              iPeriodo = ii.iPeriodo,
                              nMonto_Pagar = ii.nMonto_Pagar,                              
                              nPago = ii.nPago,
                              nSaldo = ii.nSaldo,
                              InmuebleId = ii.InmuebleId,
                              sCatastro = ii.sCatastro
                          };
            return imp_inm.Count();
        }
    }
}
