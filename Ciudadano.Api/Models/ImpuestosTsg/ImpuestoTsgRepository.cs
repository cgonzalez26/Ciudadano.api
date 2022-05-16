using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciudadano.Api.Models.ImpuestosTsg.Dtos;

namespace Ciudadano.Api.Models.ImpuestosTsg
{
    public class ImpuestoTsgRepository : Repository<ImpuestoTsg>, IImpuestoTsgRepository
    {
        public ImpuestoTsgRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<ImpuestoTsgWebDto> getByNroDocumento(string NroDocumento)
        {
            var imp_tsg = from itsg in Context.ImpuestosTsg
                          join i in Context.Inmuebles on itsg.InmuebleId equals i.Id
                          join it in Context.InmueblesTitulares on i.Id equals it.InmuebleId
                          join t in Context.Titulares on it.TitularId equals t.Id
                          where (t.sNroDocumento.Equals(NroDocumento) || NroDocumento.Equals("admin"))
                          orderby itsg.sCatastro, itsg.iAnio, itsg.iPeriodo
                          select new ImpuestoTsgWebDto
                          {
                              Id = itsg.Id,
                              dFecha_Pago = itsg.dFecha_Pago,
                              iAnio = itsg.iAnio,
                              iPeriodo = itsg.iPeriodo,
                              nMonto_Pagar = itsg.nMonto_Pagar,
                              sCatastro = itsg.sCatastro,
                              nPago = itsg.nPago,
                              nSaldo = itsg.nSaldo,
                              InmuebleId = itsg.InmuebleId
                          };
            /*if (NroDocumento.Equals("admin"))
            {
                imp_tsg = from itsg in Context.ImpuestosTsg
                          join i in Context.Inmuebles on itsg.InmuebleId equals i.Id
                          join it in Context.InmueblesTitulares on i.Id equals it.InmuebleId
                          join t in Context.Titulares on it.TitularId equals t.Id
                          orderby itsg.sCatastro, itsg.iAnio, itsg.iPeriodo
                          select new ImpuestoTsgWebDto
                          {
                              Id = itsg.Id,
                              dFecha_Pago = itsg.dFecha_Pago,
                              iAnio = itsg.iAnio,
                              iPeriodo = itsg.iPeriodo,
                              nMonto_Pagar = itsg.nMonto_Pagar,
                              sCatastro = itsg.sCatastro,
                              nPago = itsg.nPago,
                              nSaldo = itsg.nSaldo,
                              InmuebleId = itsg.InmuebleId
                          };
            }*/
            return imp_tsg.ToList();
        }

        public int getCountDeudaByNroDocumento(string NroDocumento)
        {
            var imp_tsg = from itsg in Context.ImpuestosTsg
                          join i in Context.Inmuebles on itsg.InmuebleId equals i.Id
                          join it in Context.InmueblesTitulares on i.Id equals it.InmuebleId
                          join t in Context.Titulares on it.TitularId equals t.Id
                          where (t.sNroDocumento.Equals(NroDocumento) || NroDocumento.Equals("admin"))
                          && itsg.nPago < itsg.nMonto_Pagar
                          select new ImpuestoTsgWebDto
                          {
                              Id = itsg.Id,
                              dFecha_Pago = itsg.dFecha_Pago,
                              iAnio = itsg.iAnio,
                              iPeriodo = itsg.iPeriodo,
                              nMonto_Pagar = itsg.nMonto_Pagar,                              
                              nPago = itsg.nPago,
                              nSaldo = itsg.nSaldo,
                              InmuebleId = itsg.InmuebleId,
                              sCatastro = itsg.sCatastro
                          };
            return imp_tsg.Count();
        }
    }
}
