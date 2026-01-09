using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services
{

    public class Pago_transaccion
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long Id { get; set; }
        public BoolCS Activo { get; set; }
        public DateTimeOffset Creado { get; set; }
        public long? Creadopor_userid { get; set; }
        public long? Formapagoid { get; set; }
        public DateTimeOffset? Fecha { get; set; }
        public DateTimeOffset? Fechahora { get; set; }
        public long? Corteid { get; set; }
        public decimal Importe { get; set; }
        public decimal Importerecibido { get; set; }
        public decimal Importecambio { get; set; }
        public long? Tipopagoid { get; set; }
        public long? Bancoid { get; set; }
        public string? Referenciabancaria { get; set; }
        public string? Notas { get; set; }
        public DateTimeOffset? Fechaelaboracion { get; set; }
        public DateTimeOffset? Fecharecepcion { get; set; }
        public BoolCN? Aplicado { get; set; }
        public long? Pagoparentid { get; set; }
        public long? Formapagosatid { get; set; }
        public long? Clienteid { get; set; }
        public long? Proveedorid { get; set; }
        public int Sentidopago { get; set; }
        public DateTimeOffset? Fechaaplicado { get; set; }
        public decimal Comision { get; set; }
        public string? Cuentapagocredito { get; set; }
        public long? Cuentabancoempresaid { get; set; }
        public long? Reciboelectronicoid { get; set; }

        public BoolCN? Revertido { get; set; } = BoolCN.N;
    }

    public class DoctoPago_transaccion
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long Id { get; set; }
        public BoolCS Activo { get; set; }
        public DateTimeOffset Creado { get; set; }
        public long? Creadopor_userid { get; set; }
        public long? Doctoid { get; set; }
        public DateTimeOffset? Fecha { get; set; }
        public DateTimeOffset? Fechahora { get; set; }
        public long? Corteid { get; set; }
        public decimal Importe { get; set; }
        public long? Tipopagoid { get; set; }
        public long? Tipoabonoid { get; set; }
        public int Sentidopago { get; set; }
        public long? Formapagoid { get; set; }
        public long? Formapagosatid { get; set; }
        public long? Pagoid { get; set; }
        public BoolCN Esapartado { get; set; }
        public long? Tipoaplicacioncreditoid { get; set; }
        public BoolCN Espagoinicial { get; set; }

        public long? Doctopagoparentid { get; set; }


    }

    public class TmpDoctoPagoItem : TransitionClass
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long Id { get; }
        public long? Pagoid { get; }
        public DateTimeOffset? Fecha { get; }
        public DateTimeOffset? Fechahora { get; }
        public string? Formapago { get; }
        public decimal? Monto { get; }
        public string? Formapagoclave { get; }
        public string? Formapagonombre { get; }
        public string? Formapagosatclave { get; }
        public string? Formapagosatnombre { get; }
        public string? Referenciabancaria { get; }
        public string? Tipopagoclave { get; }
        public string? Tipopagonombre { get; }
        public string? Bancoclave { get; }
        public string? Banconombre { get; }
        public DateTimeOffset? Fechaelaboracion { get; }
        public DateTimeOffset? Fecharecepcion { get; }
        public long? Reciboelectronicoid { get; }
        public BoolCN? Esconpinpadbancomer { get; }
        public long? Bancomerparamid { get; }
        public decimal? Comision { get; }
        public string? Notas { get; }
        public BoolCN? Aplicado { get; }
        public DateTimeOffset? Fechaaplicado { get; }
        public decimal? Montopagocompuesto { get; }
        public string? Refinterno { get; }
        public string? Tipoabononombre { get; }



        public long? Formapagoid { get; }
        public long? Formapagosatid { get; }

        public long? Clienteid { get; }


        public long? Proveedorid { get; }

        public long? Bancoid { get; }

        public long? Tipopagoid { get; }


        public long? Cuentabancoempresaid { get; }

        public string? Cuentapagocredito { get; }

        public int? Sentidopago { get; }


        public long? Pagoparentid { get; }



        public string? Cuentabancoempresaclave { get; }
        public string? Cuentabancoempresanombre { get; }


        public string? Clienteclave { get; }
        public string? Clientenombre { get; }

        public string? Proveedorclave { get; }
        public string? Proveedornombre { get; }

        public BoolCN Revertido { get; } = BoolCN.N;

        public bool Espagocompuesto { get; } = false;




        public TmpDoctoPagoItem()
        {
            EmpresaId = 0;
            SucursalId = 0;
            Id = 0;
        }

        public TmpDoctoPagoItem(long empresaId, long sucursalId, long id, long? pagoid,
                                DateTimeOffset? fecha, DateTimeOffset? fechahora, string? formapago,
                                decimal? monto, string? formapagoclave, string? formapagonombre,
                                string? formapagosatclave, string? formapagosatnombre,
                                string? referenciabancaria, string? tipopagoclave, string? tipopagonombre,
                                string? bancoclave, string? banconombre,
                                DateTimeOffset? fechaelaboracion, DateTimeOffset? fecharecepcion,
                                long? reciboelectronicoid, BoolCN? esconpinpadbancomer,
                                long? bancomerparamid, decimal? comision, string? notas, BoolCN? aplicado,
                                DateTimeOffset? fechaaplicado, decimal? montopagocompuesto, string? refinterno,
                                string? tipoabononombre, long? formapagoid, long? formapagosatid,
                                long? clienteid, long? proveedorid,
                                long? bancoid, long? tipopagoid, long? cuentabancoempresaid,
                                string? cuentapagocredito, int? sentidopago, long? pagoparentid,
                                string? cuentabancoempresaclave, string? cuentabancoempresanombre,
                                string? clienteclave, string? clientenombre,
                                string? proveedorclave, string? proveedornombre,
                                BoolCN revertido, bool espagocompuesto

        )
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Id = id;
            Pagoid = pagoid;
            Fecha = fecha;
            Fechahora = fechahora;
            Formapago = formapago;
            Monto = monto;
            Formapagoclave = formapagoclave;
            Formapagonombre = formapagonombre;
            Formapagosatclave = formapagosatclave;
            Formapagosatnombre = formapagosatnombre;
            Referenciabancaria = referenciabancaria;
            Tipopagoclave = tipopagoclave;
            Tipopagonombre = tipopagonombre;
            Bancoclave = bancoclave;
            Banconombre = banconombre;
            Fechaelaboracion = fechaelaboracion;
            Fecharecepcion = fecharecepcion;
            Reciboelectronicoid = reciboelectronicoid;
            Esconpinpadbancomer = esconpinpadbancomer;
            Bancomerparamid = bancomerparamid;
            Comision = comision;
            Notas = notas;
            Aplicado = aplicado;
            Fechaaplicado = fechaaplicado;
            Montopagocompuesto = montopagocompuesto;
            Refinterno = refinterno;
            Tipoabononombre = tipoabononombre;


            Formapagoid = formapagoid;
            Formapagosatid = formapagosatid;
            Clienteid = clienteid;
            Proveedorid = proveedorid;
            Bancoid = bancoid;
            Tipopagoid = tipopagoid;
            Cuentabancoempresaid = cuentabancoempresaid;
            Cuentapagocredito = cuentapagocredito;
            Sentidopago = sentidopago;
            Pagoparentid = pagoparentid;

            Cuentabancoempresaclave = cuentabancoempresaclave;
            Cuentabancoempresanombre = cuentabancoempresanombre;
            Clienteclave = clienteclave;
            Clientenombre = clientenombre;
            Proveedorclave = proveedorclave;
            Proveedornombre = proveedornombre;

            Revertido = revertido;
            Espagocompuesto = espagocompuesto;

        }

        public override bool Equals(object? obj)
        {
            return obj is TmpDoctoPagoItem other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Id == other.Id &&
                   Pagoid == other.Pagoid &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechahora, other.Fechahora) &&
                   Formapago == other.Formapago &&
                   Monto == other.Monto &&
                   Formapagoclave == other.Formapagoclave &&
                   Formapagonombre == other.Formapagonombre &&
                   Formapagosatclave == other.Formapagosatclave &&
                   Formapagosatnombre == other.Formapagosatnombre &&
                   Referenciabancaria == other.Referenciabancaria &&
                   Tipopagoclave == other.Tipopagoclave &&
                   Tipopagonombre == other.Tipopagonombre &&
                   Bancoclave == other.Bancoclave &&
                   Banconombre == other.Banconombre &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechaelaboracion, other.Fechaelaboracion) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecharecepcion, other.Fecharecepcion) &&
                   Reciboelectronicoid == other.Reciboelectronicoid &&
                   Esconpinpadbancomer == other.Esconpinpadbancomer &&
                   Bancomerparamid == other.Bancomerparamid &&
                   Comision == other.Comision &&
                   Notas == other.Notas &&
                   Aplicado == other.Aplicado &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechaaplicado, other.Fechaaplicado) &&
                   Montopagocompuesto == other.Montopagocompuesto &&
                   Refinterno == other.Refinterno &&
                   Tipoabononombre == other.Tipoabononombre;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Id);
            hash.Add(Pagoid);
            hash.Add(Fecha);
            hash.Add(Fechahora);
            hash.Add(Formapago);
            hash.Add(Monto);
            hash.Add(Formapagoclave);
            hash.Add(Formapagonombre);
            hash.Add(Formapagosatclave);
            hash.Add(Formapagosatnombre);
            hash.Add(Referenciabancaria);
            hash.Add(Tipopagoclave);
            hash.Add(Tipopagonombre);
            hash.Add(Bancoclave);
            hash.Add(Banconombre);
            hash.Add(Fechaelaboracion);
            hash.Add(Fecharecepcion);
            hash.Add(Reciboelectronicoid);
            hash.Add(Esconpinpadbancomer);
            hash.Add(Bancomerparamid);
            hash.Add(Comision);
            hash.Add(Notas);
            hash.Add(Aplicado);
            hash.Add(Fechaaplicado);
            hash.Add(Montopagocompuesto);
            hash.Add(Refinterno);
            hash.Add(Tipoabononombre);
            return hash.ToHashCode();
        }
    }

    public class TmpDoctosConSaldo_Selector : TransitionClass
    {

        public long EmpresaId { get; set; }
        public long SucursalId { get; set; }
        public long? TipodoctoId { get; set; }
        public string? TipodoctoClave { get; set; }
        public string? TipodoctoNombre { get; set; }
        public long? EstatusDoctoId { get; set; }
        public string? EstatusDoctoClave { get; set; }
        public string? EstatusDoctoNombre { get; set; }
        public long? ClienteId { get; set; }
        public string? ClienteClave { get; set; }
        public string? ClienteNombre { get; set; }
        public long? ProveedorId { get; set; }
        public string? ProveedorClave { get; set; }
        public string? ProveedorNombre { get; set; }
        public bool SoloTimbrados { get; set; }
        public long? UsuarioId { get; set; }
        public string? UsuarioClave { get; set; }
        public string? UsuarioNombre { get; set; }
        public bool CorteActivo { get; set; }
        public string? Referencia { get; set; }
        public DateTimeOffset? FechaInicial { get; set; }
        public DateTimeOffset? FechaFinal { get; set; }

        public TmpDoctosConSaldo_Selector()
        {
            EmpresaId = 0;
            SucursalId = 0;
            SoloTimbrados = false;
        }

    }


    public class DoctoPagoDirect
    {
        public long Empresaid { get; set; }
        public long Sucursalid { get; set; }
        public long Id { get; set; }
        public long? Doctoid { get; set; }
        public long? Formapagoid { get; set; }
        public DateTimeOffset? Fecha { get; set; }
        public DateTimeOffset? Fechahora { get; set; }
        public long? Corteid { get; set; }
        public decimal Importe { get; set; }
        public decimal Importerecibido { get; set; }
        public decimal Importecambio { get; set; }
        public long? Tipopagoid { get; set; }
        public long? Docto2id { get; set; }
        public BoolCN Esapartado { get; set; }
        public long? Tipoaplicacioncreditoid { get; set; }
        public long? Bancoid { get; set; }
        public string? Referenciabancaria { get; set; }
        public string? Notas { get; set; }
        public DateTimeOffset? Fechaelaboracion { get; set; }
        public DateTimeOffset? Fecharecepcion { get; set; }
        public BoolCN Espagoinicial { get; set; }
        public long? Tipoabonoid { get; set; }
        public long? Pagoparentid { get; set; }
        public long? Formapagosatid { get; set; }
        public long? Bancomerparamid { get; set; }
        public decimal Comision { get; set; }
        public string? Cuentapagocredito { get; set; }
        public long? Cuentabancoempresaid { get; set; }
        public BoolCN? Aplicado { get; set; }
        public DateTimeOffset? Fechaaplicado { get; set; }
        public long? Clienteid { get; set; }
        public long? Proveedorid { get; set; }
        public long? Usuarioid { get; set; }
        public int Sentidopago { get; set; }

    }

}
