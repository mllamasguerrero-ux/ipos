using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services
{

    public class Tmp_docto_traslado_recepcion : TransitionClass
    {
        public long EmpresaId { get; }
        public long SucursalId { get; }
        public long Id { get; }
        public BoolCS Activo { get; }
        public long? Estatusdoctoid { get; }
        public string? Estatusdoctoclave { get; }
        public string? Estatusdoctonombre { get; }
        public long? Usuarioid { get; }
        public string? Usuarionombre { get; }
        public DateTimeOffset? Fecha { get; }
        public string? Serie { get; }
        public int? Folio { get; }
        public decimal Importe { get; }
        public decimal Descuento { get; }
        public decimal Subtotal { get; }
        public decimal Iva { get; }
        public decimal Ieps { get; }
        public decimal Total { get; }
        public long? Cajaid { get; }
        public string? Cajaclave { get; }
        public string? Cajanombre { get; }
        public long? Proveedorid { get; }
        public string? Proveedorclave { get; }
        public string? Proveedornombre { get; }
        public long? Tipodoctoid { get; }
        public string? Tipodoctoclave { get; }
        public string? Tipodoctonombre { get; }
        public string? Referencia { get; }
        public int? Foliosat { get; }
        public string? Seriesat { get; }
        public long? Sucursaltid { get; }
        public string? Sucursaltclave { get; }
        public string? Sucursaltnombre { get; }
        public long? Almacentid { get; }
        public string? Almacentclave { get; }
        public string? Almacentnombre { get; }
        public string? Folio_c { get; }
        public string? Factura_c { get; }
        public DateTimeOffset? Fechafactura_c { get; }
        public DateTimeOffset? Fechavence_c { get; }
        public long? Origenfiscalid { get; }
        public string? Origenfiscalclave { get; }
        public string? Origenfiscalnombre { get; }


        public BoolCN? Estraslado { get; }
        public BoolCN? Esdevolucion { get; }
        public string? Foliodevolucion { get; }
        public string? Essurtimientomerca { get; }
        public string? Foliosolicitudmercancia { get; }
        public string? Foliotrasladooriginal { get; }
        public long? Idsolicitudmercancia { get; }
        public long? Idtrasladooriginal { get; }
        public long? Iddevolucion { get; }


        public Tmp_docto_traslado_recepcion()
        {

        }
        public Tmp_docto_traslado_recepcion(long empresaId, long sucursalId, long id, BoolCS activo, long? estatusdoctoid, string? estatusdoctoclave, string? estatusdoctonombre, long? usuarioid, string? usuarionombre, DateTimeOffset? fecha, string? serie, int? folio, decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total, long? cajaid, string? cajaclave, string? cajanombre, long? proveedorid, string? proveedorclave, string? proveedornombre, long? tipodoctoid, string? tipodoctoclave, string? tipodoctonombre, string? referencia, int? foliosat, string? seriesat, long? sucursaltid, string? sucursaltclave, string? sucursaltnombre, long? almacentid, string? almacentclave, string? almacentnombre, string? folio_c, string? factura_c, DateTimeOffset? fechafactura_c, DateTimeOffset? fechavence_c, long? origenfiscalid, string? origenfiscalclave, string? origenfiscalnombre,
            BoolCN? estraslado, BoolCN? esdevolucion, string? foliodevolucion, string? essurtimientomerca, string? foliosolicitudmercancia, string? foliotrasladooriginal, long? idsolicitudmercancia, long? idtrasladooriginal, long? iddevolucion)
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Id = id;
            Activo = activo;
            Estatusdoctoid = estatusdoctoid;
            Estatusdoctoclave = estatusdoctoclave;
            Estatusdoctonombre = estatusdoctonombre;
            Usuarioid = usuarioid;
            Usuarionombre = usuarionombre;
            Fecha = fecha;
            Serie = serie;
            Folio = folio;
            Importe = importe;
            Descuento = descuento;
            Subtotal = subtotal;
            Iva = iva;
            Ieps = ieps;
            Total = total;
            Cajaid = cajaid;
            Cajaclave = cajaclave;
            Cajanombre = cajanombre;
            Proveedorid = proveedorid;
            Proveedorclave = proveedorclave;
            Proveedornombre = proveedornombre;
            Tipodoctoid = tipodoctoid;
            Tipodoctoclave = tipodoctoclave;
            Tipodoctonombre = tipodoctonombre;
            Referencia = referencia;
            Foliosat = foliosat;
            Seriesat = seriesat;
            Sucursaltid = sucursaltid;
            Sucursaltclave = sucursaltclave;
            Sucursaltnombre = sucursaltnombre;
            Almacentid = almacentid;
            Almacentclave = almacentclave;
            Almacentnombre = almacentnombre;
            Folio_c = folio_c;
            Factura_c = factura_c;
            Fechafactura_c = fechafactura_c;
            Fechavence_c = fechavence_c;
            Origenfiscalid = origenfiscalid;
            Origenfiscalclave = origenfiscalclave;
            Origenfiscalnombre = origenfiscalnombre;

            Estraslado = estraslado;
            Esdevolucion = esdevolucion;
            Foliodevolucion = foliodevolucion;
            Essurtimientomerca = essurtimientomerca;
            Foliosolicitudmercancia = foliosolicitudmercancia;
            Foliotrasladooriginal = foliotrasladooriginal;
            Idsolicitudmercancia = idsolicitudmercancia;
            Idtrasladooriginal = idtrasladooriginal;
            Iddevolucion = iddevolucion;


        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_docto_traslado_recepcion other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Id == other.Id &&
                   Activo == other.Activo &&
                   Estatusdoctoid == other.Estatusdoctoid &&
                   Estatusdoctoclave == other.Estatusdoctoclave &&
                   Estatusdoctonombre == other.Estatusdoctonombre &&
                   Usuarioid == other.Usuarioid &&
                   Usuarionombre == other.Usuarionombre &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
                   Serie == other.Serie &&
                   Folio == other.Folio &&
                   Importe == other.Importe &&
                   Descuento == other.Descuento &&
                   Subtotal == other.Subtotal &&
                   Iva == other.Iva &&
                   Ieps == other.Ieps &&
                   Total == other.Total &&
                   Cajaid == other.Cajaid &&
                   Cajaclave == other.Cajaclave &&
                   Cajanombre == other.Cajanombre &&
                   Proveedorid == other.Proveedorid &&
                   Proveedorclave == other.Proveedorclave &&
                   Proveedornombre == other.Proveedornombre &&
                   Tipodoctoid == other.Tipodoctoid &&
                   Tipodoctoclave == other.Tipodoctoclave &&
                   Tipodoctonombre == other.Tipodoctonombre &&
                   Referencia == other.Referencia &&
                   Foliosat == other.Foliosat &&
                   Seriesat == other.Seriesat &&
                   Sucursaltid == other.Sucursaltid &&
                   Sucursaltclave == other.Sucursaltclave &&
                   Sucursaltnombre == other.Sucursaltnombre &&
                   Almacentid == other.Almacentid &&
                   Almacentclave == other.Almacentclave &&
                   Almacentnombre == other.Almacentnombre &&
                   Folio_c == other.Folio_c &&
                   Factura_c == other.Factura_c &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechafactura_c, other.Fechafactura_c) &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence_c, other.Fechavence_c) &&
                   Origenfiscalid == other.Origenfiscalid &&
                   Origenfiscalclave == other.Origenfiscalclave &&
                   Origenfiscalnombre == other.Origenfiscalnombre;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Id);
            hash.Add(Activo);
            hash.Add(Estatusdoctoid);
            hash.Add(Estatusdoctoclave);
            hash.Add(Estatusdoctonombre);
            hash.Add(Usuarioid);
            hash.Add(Usuarionombre);
            hash.Add(Fecha);
            hash.Add(Serie);
            hash.Add(Folio);
            hash.Add(Importe);
            hash.Add(Descuento);
            hash.Add(Subtotal);
            hash.Add(Iva);
            hash.Add(Ieps);
            hash.Add(Total);
            hash.Add(Cajaid);
            hash.Add(Cajaclave);
            hash.Add(Cajanombre);
            hash.Add(Proveedorid);
            hash.Add(Proveedorclave);
            hash.Add(Proveedornombre);
            hash.Add(Tipodoctoid);
            hash.Add(Tipodoctoclave);
            hash.Add(Tipodoctonombre);
            hash.Add(Referencia);
            hash.Add(Foliosat);
            hash.Add(Seriesat);
            hash.Add(Sucursaltid);
            hash.Add(Sucursaltclave);
            hash.Add(Sucursaltnombre);
            hash.Add(Almacentid);
            hash.Add(Almacentclave);
            hash.Add(Almacentnombre);
            hash.Add(Folio_c);
            hash.Add(Factura_c);
            hash.Add(Fechafactura_c);
            hash.Add(Fechavence_c);
            hash.Add(Origenfiscalid);
            hash.Add(Origenfiscalclave);
            hash.Add(Origenfiscalnombre);
            return hash.ToHashCode();
        }
    }

    public class Recepcion_movto_traslado_impo
    {
        public long EmpresaId { get; set; }
        public long SucursalId { get; set; }
        public long Id { get; set; }
        public long? Productoid { get; set; }
        public string? Lote { get; set; }
        public DateTimeOffset? Fechavence { get; set; }
        public long? Loteimportado { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Cantidadsurtida { get; set; }
        public decimal Cantidadfaltante { get; set; }
        public decimal Cantidaddevuelta { get; set; }
        public decimal Cantidadsaldo { get; set; }
        public long? Motivodevolucionid { get; set; }
        public string? Motivodevolucionclave { get; set; }
        public string? Motivodevolucionnombre { get; set; }
        public string? Motivodevoluciondescripcion { get; set; }
        public string? Otromotivodevolucion { get; set; }
    }

}
