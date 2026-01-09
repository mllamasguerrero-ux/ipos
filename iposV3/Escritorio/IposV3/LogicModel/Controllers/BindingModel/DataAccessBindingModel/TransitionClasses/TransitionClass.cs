using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TransitionClass
    {
    }

    public class TestTempClass: TransitionClass
    {
        public long? Estatusmovtoid { get; }
        public long? Productoid { get; }
        public long? Almacenid { get; }
        public long? Tipodoctoid { get; }
        public decimal Cantidad { get; }
        public long? MovtoRefDevolucionId { get; }
        public long? CreadoPorId { get; }


        public TestTempClass()
        {
        }
        public TestTempClass(long? estatusmovtoid, long? productoid, long? almacenid, long? tipodoctoid, decimal cantidad, long? movtoRefDevolucionId, long? creadoPorId)
        {
            Estatusmovtoid = estatusmovtoid;
            Productoid = productoid;
            Almacenid = almacenid;
            Tipodoctoid = tipodoctoid;
            Cantidad = cantidad;
            MovtoRefDevolucionId = movtoRefDevolucionId;
            CreadoPorId = creadoPorId;
        }

        public override bool Equals(object? obj)
        {
            return obj is TestTempClass other &&
                   Estatusmovtoid == other.Estatusmovtoid &&
                   Productoid == other.Productoid &&
                   Almacenid == other.Almacenid &&
                   Tipodoctoid == other.Tipodoctoid &&
                   Cantidad == other.Cantidad &&
                   MovtoRefDevolucionId == other.MovtoRefDevolucionId &&
                   CreadoPorId == other.CreadoPorId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Estatusmovtoid, Productoid, Almacenid, Tipodoctoid, Cantidad, MovtoRefDevolucionId, CreadoPorId);
        }
    }




    //public class V_docto_proveeduria :TransitionClass
    //{
    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long Id { get; }
    //    public BoolCS Activo { get; }
    //    public long? Estatusdoctoid { get; }
    //    public string? Estatusdoctoclave { get; }
    //    public string? Estatusdoctonombre { get; }
    //    public long? Usuarioid { get; }
    //    public string? Usuarionombre { get; }
    //    public DateTimeOffset? Fecha { get; }
    //    public string? Serie { get; }
    //    public int? Folio { get; }
    //    public decimal Importe { get; }
    //    public decimal Descuento { get; }
    //    public decimal Subtotal { get; }
    //    public decimal Iva { get; }
    //    public decimal Ieps { get; }
    //    public decimal Total { get; }
    //    public long? Cajaid { get; }
    //    public string? Cajaclave { get; }
    //    public string? Cajanombre { get; }
    //    public long? Proveedorid { get; }
    //    public string? Proveedorclave { get; }
    //    public string? Proveedornombre { get; }
    //    public long? Tipodoctoid { get; }
    //    public string? Tipodoctoclave { get; }
    //    public string? Tipodoctonombre { get; }
    //    public string? Referencia { get; }
    //    public int? Foliosat { get; }
    //    public string? Seriesat { get; }
    //    public long? Sucursaltid { get; }
    //    public string? Sucursaltclave { get; }
    //    public string? Sucursaltnombre { get; }
    //    public long? Almacentid { get; }
    //    public string? Almacentclave { get; }
    //    public string? Almacentnombre { get; }
    //    public string? Folio_c { get; }
    //    public string? Factura_c { get; }
    //    public DateTimeOffset? Fechafactura_c { get; }
    //    public DateTimeOffset? Fechavence_c { get; }
    //    public long? Origenfiscalid { get; }
    //    public string? Origenfiscalclave { get; }
    //    public string? Origenfiscalnombre { get; }

    //    public V_docto_proveeduria()
    //    {

    //    }

    //    public V_docto_proveeduria(long empresaId, long sucursalId, long id, BoolCS activo, long? estatusdoctoid, string? estatusdoctoclave, string? estatusdoctonombre, long? usuarioid, string? usuarionombre, DateTimeOffset? fecha, string? serie, int? folio, decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total, long? cajaid, string? cajaclave, string? cajanombre, long? proveedorid, string? proveedorclave, string? proveedornombre, long? tipodoctoid, string? tipodoctoclave, string? tipodoctonombre, string? referencia, int? foliosat, string? seriesat, long? sucursaltid, string? sucursaltclave, string? sucursaltnombre, long? almacentid, string? almacentclave, string? almacentnombre, string? folio_c, string? factura_c, DateTimeOffset? fechafactura_c, DateTimeOffset? fechavence_c, long? origenfiscalid, string? origenfiscalclave, string? origenfiscalnombre)
    //    {
    //        EmpresaId = empresaId;
    //        SucursalId = sucursalId;
    //        Id = id;
    //        Activo = activo;
    //        Estatusdoctoid = estatusdoctoid;
    //        Estatusdoctoclave = estatusdoctoclave;
    //        Estatusdoctonombre = estatusdoctonombre;
    //        Usuarioid = usuarioid;
    //        Usuarionombre = usuarionombre;
    //        Fecha = fecha;
    //        Serie = serie;
    //        Folio = folio;
    //        Importe = importe;
    //        Descuento = descuento;
    //        Subtotal = subtotal;
    //        Iva = iva;
    //        Ieps = ieps;
    //        Total = total;
    //        Cajaid = cajaid;
    //        Cajaclave = cajaclave;
    //        Cajanombre = cajanombre;
    //        Proveedorid = proveedorid;
    //        Proveedorclave = proveedorclave;
    //        Proveedornombre = proveedornombre;
    //        Tipodoctoid = tipodoctoid;
    //        Tipodoctoclave = tipodoctoclave;
    //        Tipodoctonombre = tipodoctonombre;
    //        Referencia = referencia;
    //        Foliosat = foliosat;
    //        Seriesat = seriesat;
    //        Sucursaltid = sucursaltid;
    //        Sucursaltclave = sucursaltclave;
    //        Sucursaltnombre = sucursaltnombre;
    //        Almacentid = almacentid;
    //        Almacentclave = almacentclave;
    //        Almacentnombre = almacentnombre;
    //        Folio_c = folio_c;
    //        Factura_c = factura_c;
    //        Fechafactura_c = fechafactura_c;
    //        Fechavence_c = fechavence_c;
    //        Origenfiscalid = origenfiscalid;
    //        Origenfiscalclave = origenfiscalclave;
    //        Origenfiscalnombre = origenfiscalnombre;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        return obj is V_docto_proveeduria other &&
    //               EmpresaId == other.EmpresaId &&
    //               SucursalId == other.SucursalId &&
    //               Id == other.Id &&
    //               Activo == other.Activo &&
    //               Estatusdoctoid == other.Estatusdoctoid &&
    //               Estatusdoctoclave == other.Estatusdoctoclave &&
    //               Estatusdoctonombre == other.Estatusdoctonombre &&
    //               Usuarioid == other.Usuarioid &&
    //               Usuarionombre == other.Usuarionombre &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
    //               Serie == other.Serie &&
    //               Folio == other.Folio &&
    //               Importe == other.Importe &&
    //               Descuento == other.Descuento &&
    //               Subtotal == other.Subtotal &&
    //               Iva == other.Iva &&
    //               Ieps == other.Ieps &&
    //               Total == other.Total &&
    //               Cajaid == other.Cajaid &&
    //               Cajaclave == other.Cajaclave &&
    //               Cajanombre == other.Cajanombre &&
    //               Proveedorid == other.Proveedorid &&
    //               Proveedorclave == other.Proveedorclave &&
    //               Proveedornombre == other.Proveedornombre &&
    //               Tipodoctoid == other.Tipodoctoid &&
    //               Tipodoctoclave == other.Tipodoctoclave &&
    //               Tipodoctonombre == other.Tipodoctonombre &&
    //               Referencia == other.Referencia &&
    //               Foliosat == other.Foliosat &&
    //               Seriesat == other.Seriesat &&
    //               Sucursaltid == other.Sucursaltid &&
    //               Sucursaltclave == other.Sucursaltclave &&
    //               Sucursaltnombre == other.Sucursaltnombre &&
    //               Almacentid == other.Almacentid &&
    //               Almacentclave == other.Almacentclave &&
    //               Almacentnombre == other.Almacentnombre &&
    //               Folio_c == other.Folio_c &&
    //               Factura_c == other.Factura_c &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechafactura_c, other.Fechafactura_c) &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence_c, other.Fechavence_c) &&
    //               Origenfiscalid == other.Origenfiscalid &&
    //               Origenfiscalclave == other.Origenfiscalclave &&
    //               Origenfiscalnombre == other.Origenfiscalnombre;
    //    }

    //    public override int GetHashCode()
    //    {
    //        HashCode hash = new HashCode();
    //        hash.Add(EmpresaId);
    //        hash.Add(SucursalId);
    //        hash.Add(Id);
    //        hash.Add(Activo);
    //        hash.Add(Estatusdoctoid);
    //        hash.Add(Estatusdoctoclave);
    //        hash.Add(Estatusdoctonombre);
    //        hash.Add(Usuarioid);
    //        hash.Add(Usuarionombre);
    //        hash.Add(Fecha);
    //        hash.Add(Serie);
    //        hash.Add(Folio);
    //        hash.Add(Importe);
    //        hash.Add(Descuento);
    //        hash.Add(Subtotal);
    //        hash.Add(Iva);
    //        hash.Add(Ieps);
    //        hash.Add(Total);
    //        hash.Add(Cajaid);
    //        hash.Add(Cajaclave);
    //        hash.Add(Cajanombre);
    //        hash.Add(Proveedorid);
    //        hash.Add(Proveedorclave);
    //        hash.Add(Proveedornombre);
    //        hash.Add(Tipodoctoid);
    //        hash.Add(Tipodoctoclave);
    //        hash.Add(Tipodoctonombre);
    //        hash.Add(Referencia);
    //        hash.Add(Foliosat);
    //        hash.Add(Seriesat);
    //        hash.Add(Sucursaltid);
    //        hash.Add(Sucursaltclave);
    //        hash.Add(Sucursaltnombre);
    //        hash.Add(Almacentid);
    //        hash.Add(Almacentclave);
    //        hash.Add(Almacentnombre);
    //        hash.Add(Folio_c);
    //        hash.Add(Factura_c);
    //        hash.Add(Fechafactura_c);
    //        hash.Add(Fechavence_c);
    //        hash.Add(Origenfiscalid);
    //        hash.Add(Origenfiscalclave);
    //        hash.Add(Origenfiscalnombre);
    //        return hash.ToHashCode();
    //    }
    //}


    //public class V_movto_proveeduria: TransitionClass
    //{
    //    public V_movto_proveeduria()
    //    {

    //    }
    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long Id { get; }
    //    public int Partida { get; }
    //    public long? Productoid { get; }
    //    public string? ProductoClave { get; }
    //    public string? ProductoNombre { get; }
    //    public decimal Cantidad { get; }
    //    public decimal Preciolista { get; }
    //    public decimal Descuentoporcentaje { get; }
    //    public decimal Descuento { get; }
    //    public decimal Precio { get; }
    //    public decimal Importe { get; }
    //    public decimal Subtotal { get; }
    //    public decimal Iva { get; }
    //    public decimal Ieps { get; }
    //    public decimal Tasaiva { get; }
    //    public decimal Tasaieps { get; }
    //    public decimal Total { get; }
    //    public string? Lote { get; }
    //    public DateTimeOffset? Fechavence { get; }
    //    public long? Loteimportado { get; }
    //    public long? Doctoid { get; }
    //    public int Orden { get; }
    //    public decimal Descuentovale { get; }
    //    public decimal Descuentovaleporcentaje { get; }
    //    public BoolCN Ingresopreciomanual { get; }
    //    public decimal Porcentajedescuentomanual { get; }
    //    public string? Descripcion1 { get; }
    //    public string? Descripcion2 { get; }
    //    public string? Descripcion3 { get; }
    //    public decimal Cantidadsurtida { get; }
    //    public decimal Precio1 { get; }
    //    public decimal Existencia { get; }
    //    public decimal Pzacaja { get; }
    //    public string? Texto1 { get; }
    //    public string? Texto2 { get; }
    //    public string? Texto3 { get; }
    //    public string? Texto4 { get; }
    //    public string? Texto5 { get; }
    //    public string? Texto6 { get; }
    //    public decimal? Numero1 { get; }
    //    public decimal? Numero2 { get; }
    //    public decimal? Numero3 { get; }
    //    public decimal? Numero4 { get; }
    //    public DateTimeOffset? Fecha1 { get; }
    //    public DateTimeOffset? Fecha2 { get; }
    //    public long? Unidadid { get; }
    //    public string? UnidadClave { get; }
    //    public string? UnidadNombre { get; }
    //    public string? Alerta3 { get; }
    //    public decimal Preciomostrar { get; }
    //    public decimal Descuentomostrar { get; }

    //}



    //public class V_movto_provdevo : TransitionClass
    //{

    //    public V_movto_provdevo()
    //    {

    //    }
    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long Id { get; }
    //    public int Partida { get; }
    //    public long? Productoid { get; }
    //    public string? ProductoClave { get; }
    //    public string? ProductoNombre { get; }
    //    public decimal Cantidad { get; }
    //    public decimal Preciolista { get; }
    //    public decimal Descuentoporcentaje { get; }
    //    public decimal Descuento { get; }
    //    public decimal Precio { get; }
    //    public decimal Importe { get; }
    //    public decimal Subtotal { get; }
    //    public decimal Iva { get; }
    //    public decimal Ieps { get; }
    //    public decimal Tasaiva { get; }
    //    public decimal Tasaieps { get; }
    //    public decimal Total { get; }
    //    public string? Lote { get; }
    //    public DateTimeOffset? Fechavence { get; }
    //    public long? Loteimportado { get; }
    //    public long? Doctoid { get; }
    //    public int Orden { get; }
    //    public decimal Descuentovale { get; }
    //    public decimal Descuentovaleporcentaje { get; }
    //    public BoolCN Ingresopreciomanual { get; }
    //    public decimal Porcentajedescuentomanual { get; }
    //    public string? Descripcion1 { get; }
    //    public string? Descripcion2 { get; }
    //    public string? Descripcion3 { get; }
    //    public decimal Cantidadsurtida { get; }
    //    public decimal Precio1 { get; }
    //    public decimal Existencia { get; }
    //    public decimal Pzacaja { get; }
    //    public string? Texto1 { get; }
    //    public string? Texto2 { get; }
    //    public string? Texto3 { get; }
    //    public string? Texto4 { get; }
    //    public string? Texto5 { get; }
    //    public string? Texto6 { get; }
    //    public decimal? Numero1 { get; }
    //    public decimal? Numero2 { get; }
    //    public decimal? Numero3 { get; }
    //    public decimal? Numero4 { get; }
    //    public DateTimeOffset? Fecha1 { get; }
    //    public DateTimeOffset? Fecha2 { get; }
    //    public long? Unidadid { get; }
    //    public string? UnidadClave { get; }
    //    public string? UnidadNombre { get; }
    //    public string? Alerta3 { get; }
    //    public decimal Preciomostrar { get; }
    //    public decimal Descuentomostrar { get; }
    //    public long? Devolucionmovtorefid { get; }
    //    public decimal? Devolucionmovtorefcantidad { get; }
    //    public decimal? Devolucionmovtorefprecio { get; }

    //    public V_movto_provdevo(long empresaId, long sucursalId, long id, int partida, long? productoid, string? productoClave, string? productoNombre, decimal cantidad, decimal preciolista, decimal descuentoporcentaje, decimal descuento, decimal precio, decimal importe, decimal subtotal, decimal iva, decimal ieps, decimal tasaiva, decimal tasaieps, decimal total, string? lote, DateTimeOffset? fechavence, long? loteimportado, long? doctoid, int orden, decimal descuentovale, decimal descuentovaleporcentaje, BoolCN ingresopreciomanual, decimal porcentajedescuentomanual, string? descripcion1, string? descripcion2, string? descripcion3, decimal cantidadsurtida, decimal precio1, decimal existencia, decimal pzacaja, string? texto1, string? texto2, string? texto3, string? texto4, string? texto5, string? texto6, decimal? numero1, decimal? numero2, decimal? numero3, decimal? numero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, long? unidadid, string? unidadClave, string? unidadNombre, string alerta3, decimal preciomostrar, decimal descuentomostrar, long? devolucionmovtorefid, decimal? devolucionmovtorefcantidad, decimal? devolucionmovtorefprecio)
    //    {
    //        EmpresaId = empresaId;
    //        SucursalId = sucursalId;
    //        Id = id;
    //        Partida = partida;
    //        Productoid = productoid;
    //        ProductoClave = productoClave;
    //        ProductoNombre = productoNombre;
    //        Cantidad = cantidad;
    //        Preciolista = preciolista;
    //        Descuentoporcentaje = descuentoporcentaje;
    //        Descuento = descuento;
    //        Precio = precio;
    //        Importe = importe;
    //        Subtotal = subtotal;
    //        Iva = iva;
    //        Ieps = ieps;
    //        Tasaiva = tasaiva;
    //        Tasaieps = tasaieps;
    //        Total = total;
    //        Lote = lote;
    //        Fechavence = fechavence;
    //        Loteimportado = loteimportado;
    //        Doctoid = doctoid;
    //        Orden = orden;
    //        Descuentovale = descuentovale;
    //        Descuentovaleporcentaje = descuentovaleporcentaje;
    //        Ingresopreciomanual = ingresopreciomanual;
    //        Porcentajedescuentomanual = porcentajedescuentomanual;
    //        Descripcion1 = descripcion1;
    //        Descripcion2 = descripcion2;
    //        Descripcion3 = descripcion3;
    //        Cantidadsurtida = cantidadsurtida;
    //        Precio1 = precio1;
    //        Existencia = existencia;
    //        Pzacaja = pzacaja;
    //        Texto1 = texto1;
    //        Texto2 = texto2;
    //        Texto3 = texto3;
    //        Texto4 = texto4;
    //        Texto5 = texto5;
    //        Texto6 = texto6;
    //        Numero1 = numero1;
    //        Numero2 = numero2;
    //        Numero3 = numero3;
    //        Numero4 = numero4;
    //        Fecha1 = fecha1;
    //        Fecha2 = fecha2;
    //        Unidadid = unidadid;
    //        UnidadClave = unidadClave;
    //        UnidadNombre = unidadNombre;
    //        Alerta3 = alerta3;
    //        Preciomostrar = preciomostrar;
    //        Descuentomostrar = descuentomostrar;
    //        Devolucionmovtorefid = devolucionmovtorefid;
    //        Devolucionmovtorefcantidad = devolucionmovtorefcantidad;
    //        Devolucionmovtorefprecio = devolucionmovtorefprecio;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        return obj is V_movto_provdevo other &&
    //               EmpresaId == other.EmpresaId &&
    //               SucursalId == other.SucursalId &&
    //               Id == other.Id &&
    //               Partida == other.Partida &&
    //               Productoid == other.Productoid &&
    //               ProductoClave == other.ProductoClave &&
    //               ProductoNombre == other.ProductoNombre &&
    //               Cantidad == other.Cantidad &&
    //               Preciolista == other.Preciolista &&
    //               Descuentoporcentaje == other.Descuentoporcentaje &&
    //               Descuento == other.Descuento &&
    //               Precio == other.Precio &&
    //               Importe == other.Importe &&
    //               Subtotal == other.Subtotal &&
    //               Iva == other.Iva &&
    //               Ieps == other.Ieps &&
    //               Tasaiva == other.Tasaiva &&
    //               Tasaieps == other.Tasaieps &&
    //               Total == other.Total &&
    //               Lote == other.Lote &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
    //               Loteimportado == other.Loteimportado &&
    //               Doctoid == other.Doctoid &&
    //               Orden == other.Orden &&
    //               Descuentovale == other.Descuentovale &&
    //               Descuentovaleporcentaje == other.Descuentovaleporcentaje &&
    //               Ingresopreciomanual == other.Ingresopreciomanual &&
    //               Porcentajedescuentomanual == other.Porcentajedescuentomanual &&
    //               Descripcion1 == other.Descripcion1 &&
    //               Descripcion2 == other.Descripcion2 &&
    //               Descripcion3 == other.Descripcion3 &&
    //               Cantidadsurtida == other.Cantidadsurtida &&
    //               Precio1 == other.Precio1 &&
    //               Existencia == other.Existencia &&
    //               Pzacaja == other.Pzacaja &&
    //               Texto1 == other.Texto1 &&
    //               Texto2 == other.Texto2 &&
    //               Texto3 == other.Texto3 &&
    //               Texto4 == other.Texto4 &&
    //               Texto5 == other.Texto5 &&
    //               Texto6 == other.Texto6 &&
    //               Numero1 == other.Numero1 &&
    //               Numero2 == other.Numero2 &&
    //               Numero3 == other.Numero3 &&
    //               Numero4 == other.Numero4 &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha1, other.Fecha1) &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha2, other.Fecha2) &&
    //               Unidadid == other.Unidadid &&
    //               UnidadClave == other.UnidadClave &&
    //               UnidadNombre == other.UnidadNombre &&
    //               Alerta3 == other.Alerta3 &&
    //               Preciomostrar == other.Preciomostrar &&
    //               Descuentomostrar == other.Descuentomostrar &&
    //               Devolucionmovtorefid == other.Devolucionmovtorefid &&
    //               Devolucionmovtorefcantidad == other.Devolucionmovtorefcantidad &&
    //               Devolucionmovtorefprecio == other.Devolucionmovtorefprecio;
    //    }

    //    public override int GetHashCode()
    //    {
    //        HashCode hash = new HashCode();
    //        hash.Add(EmpresaId);
    //        hash.Add(SucursalId);
    //        hash.Add(Id);
    //        hash.Add(Partida);
    //        hash.Add(Productoid);
    //        hash.Add(ProductoClave);
    //        hash.Add(ProductoNombre);
    //        hash.Add(Cantidad);
    //        hash.Add(Preciolista);
    //        hash.Add(Descuentoporcentaje);
    //        hash.Add(Descuento);
    //        hash.Add(Precio);
    //        hash.Add(Importe);
    //        hash.Add(Subtotal);
    //        hash.Add(Iva);
    //        hash.Add(Ieps);
    //        hash.Add(Tasaiva);
    //        hash.Add(Tasaieps);
    //        hash.Add(Total);
    //        hash.Add(Lote);
    //        hash.Add(Fechavence);
    //        hash.Add(Loteimportado);
    //        hash.Add(Doctoid);
    //        hash.Add(Orden);
    //        hash.Add(Descuentovale);
    //        hash.Add(Descuentovaleporcentaje);
    //        hash.Add(Ingresopreciomanual);
    //        hash.Add(Porcentajedescuentomanual);
    //        hash.Add(Descripcion1);
    //        hash.Add(Descripcion2);
    //        hash.Add(Descripcion3);
    //        hash.Add(Cantidadsurtida);
    //        hash.Add(Precio1);
    //        hash.Add(Existencia);
    //        hash.Add(Pzacaja);
    //        hash.Add(Texto1);
    //        hash.Add(Texto2);
    //        hash.Add(Texto3);
    //        hash.Add(Texto4);
    //        hash.Add(Texto5);
    //        hash.Add(Texto6);
    //        hash.Add(Numero1);
    //        hash.Add(Numero2);
    //        hash.Add(Numero3);
    //        hash.Add(Numero4);
    //        hash.Add(Fecha1);
    //        hash.Add(Fecha2);
    //        hash.Add(Unidadid);
    //        hash.Add(UnidadClave);
    //        hash.Add(UnidadNombre);
    //        hash.Add(Alerta3);
    //        hash.Add(Preciomostrar);
    //        hash.Add(Descuentomostrar);
    //        hash.Add(Devolucionmovtorefid);
    //        hash.Add(Devolucionmovtorefcantidad);
    //        hash.Add(Devolucionmovtorefprecio);
    //        return hash.ToHashCode();
    //    }
    //}

    //public class V_docto_provdevo: TransitionClass
    //{
    //    public V_docto_provdevo()
    //    {

    //    }

    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long Id { get; }
    //    public BoolCS Activo { get; }
    //    public long? Estatusdoctoid { get; }
    //    public string? Estatusdoctoclave { get; }
    //    public string? Estatusdoctonombre { get; }
    //    public long? Usuarioid { get; }
    //    public string? Usuarionombre { get; }
    //    public DateTimeOffset? Fecha { get; }
    //    public string? Serie { get; }
    //    public int? Folio { get; }
    //    public decimal Importe { get; }
    //    public decimal Descuento { get; }
    //    public decimal Subtotal { get; }
    //    public decimal Iva { get; }
    //    public decimal Ieps { get; }
    //    public decimal Total { get; }
    //    public long? Cajaid { get; }
    //    public string? Cajaclave { get; }
    //    public string? Cajanombre { get; }
    //    public long? Proveedorid { get; }
    //    public string? Proveedorclave { get; }
    //    public string? Proveedornombre { get; }
    //    public long? Tipodoctoid { get; }
    //    public string? Tipodoctoclave { get; }
    //    public string? Tipodoctonombre { get; }
    //    public string? Referencia { get; }
    //    public int? Foliosat { get; }
    //    public string? Seriesat { get; }
    //    public long? Sucursaltid { get; }
    //    public string? Sucursaltclave { get; }
    //    public string? Sucursaltnombre { get; }
    //    public long? Almacentid { get; }
    //    public string? Almacentclave { get; }
    //    public string? Almacentnombre { get; }
    //    public string? Folio_c { get; }
    //    public string? Factura_c { get; }
    //    public DateTimeOffset? Fechafactura_c { get; }
    //    public DateTimeOffset? Fechavence_c { get; }
    //    public long? Origenfiscalid { get; }
    //    public string? Origenfiscalclave { get; }
    //    public string? Origenfiscalnombre { get; }
    //    public long? Devolucionrefid { get; }
    //    public int? Devolucionreffolio { get; }
    //    public DateTimeOffset? Devolucionreffechahora { get; }

    //    public V_docto_provdevo(long empresaId, long sucursalId, long id, BoolCS activo, long? estatusdoctoid, string? estatusdoctoclave, string? estatusdoctonombre, long? usuarioid, string? usuarionombre, DateTimeOffset? fecha, string? serie, int? folio, decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total, long? cajaid, string? cajaclave, string? cajanombre, long? proveedorid, string? proveedorclave, string? proveedornombre, long? tipodoctoid, string? tipodoctoclave, string? tipodoctonombre, string? referencia, int? foliosat, string? seriesat, long? sucursaltid, string? sucursaltclave, string? sucursaltnombre, long? almacentid, string? almacentclave, string? almacentnombre, string? folio_c, string? factura_c, DateTimeOffset? fechafactura_c, DateTimeOffset? fechavence_c, long? origenfiscalid, string? origenfiscalclave, string? origenfiscalnombre, long? devolucionrefid, int? devolucionreffolio, DateTimeOffset? devolucionreffechahora)
    //    {
    //        EmpresaId = empresaId;
    //        SucursalId = sucursalId;
    //        Id = id;
    //        Activo = activo;
    //        Estatusdoctoid = estatusdoctoid;
    //        Estatusdoctoclave = estatusdoctoclave;
    //        Estatusdoctonombre = estatusdoctonombre;
    //        Usuarioid = usuarioid;
    //        Usuarionombre = usuarionombre;
    //        Fecha = fecha;
    //        Serie = serie;
    //        Folio = folio;
    //        Importe = importe;
    //        Descuento = descuento;
    //        Subtotal = subtotal;
    //        Iva = iva;
    //        Ieps = ieps;
    //        Total = total;
    //        Cajaid = cajaid;
    //        Cajaclave = cajaclave;
    //        Cajanombre = cajanombre;
    //        Proveedorid = proveedorid;
    //        Proveedorclave = proveedorclave;
    //        Proveedornombre = proveedornombre;
    //        Tipodoctoid = tipodoctoid;
    //        Tipodoctoclave = tipodoctoclave;
    //        Tipodoctonombre = tipodoctonombre;
    //        Referencia = referencia;
    //        Foliosat = foliosat;
    //        Seriesat = seriesat;
    //        Sucursaltid = sucursaltid;
    //        Sucursaltclave = sucursaltclave;
    //        Sucursaltnombre = sucursaltnombre;
    //        Almacentid = almacentid;
    //        Almacentclave = almacentclave;
    //        Almacentnombre = almacentnombre;
    //        Folio_c = folio_c;
    //        Factura_c = factura_c;
    //        Fechafactura_c = fechafactura_c;
    //        Fechavence_c = fechavence_c;
    //        Origenfiscalid = origenfiscalid;
    //        Origenfiscalclave = origenfiscalclave;
    //        Origenfiscalnombre = origenfiscalnombre;
    //        Devolucionrefid = devolucionrefid;
    //        Devolucionreffolio = devolucionreffolio;
    //        Devolucionreffechahora = devolucionreffechahora;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        return obj is V_docto_provdevo other &&
    //               EmpresaId == other.EmpresaId &&
    //               SucursalId == other.SucursalId &&
    //               Id == other.Id &&
    //               Activo == other.Activo &&
    //               Estatusdoctoid == other.Estatusdoctoid &&
    //               Estatusdoctoclave == other.Estatusdoctoclave &&
    //               Estatusdoctonombre == other.Estatusdoctonombre &&
    //               Usuarioid == other.Usuarioid &&
    //               Usuarionombre == other.Usuarionombre &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
    //               Serie == other.Serie &&
    //               Folio == other.Folio &&
    //               Importe == other.Importe &&
    //               Descuento == other.Descuento &&
    //               Subtotal == other.Subtotal &&
    //               Iva == other.Iva &&
    //               Ieps == other.Ieps &&
    //               Total == other.Total &&
    //               Cajaid == other.Cajaid &&
    //               Cajaclave == other.Cajaclave &&
    //               Cajanombre == other.Cajanombre &&
    //               Proveedorid == other.Proveedorid &&
    //               Proveedorclave == other.Proveedorclave &&
    //               Proveedornombre == other.Proveedornombre &&
    //               Tipodoctoid == other.Tipodoctoid &&
    //               Tipodoctoclave == other.Tipodoctoclave &&
    //               Tipodoctonombre == other.Tipodoctonombre &&
    //               Referencia == other.Referencia &&
    //               Foliosat == other.Foliosat &&
    //               Seriesat == other.Seriesat &&
    //               Sucursaltid == other.Sucursaltid &&
    //               Sucursaltclave == other.Sucursaltclave &&
    //               Sucursaltnombre == other.Sucursaltnombre &&
    //               Almacentid == other.Almacentid &&
    //               Almacentclave == other.Almacentclave &&
    //               Almacentnombre == other.Almacentnombre &&
    //               Folio_c == other.Folio_c &&
    //               Factura_c == other.Factura_c &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechafactura_c, other.Fechafactura_c) &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence_c, other.Fechavence_c) &&
    //               Origenfiscalid == other.Origenfiscalid &&
    //               Origenfiscalclave == other.Origenfiscalclave &&
    //               Origenfiscalnombre == other.Origenfiscalnombre &&
    //               Devolucionrefid == other.Devolucionrefid &&
    //               Devolucionreffolio == other.Devolucionreffolio &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Devolucionreffechahora, other.Devolucionreffechahora);
    //    }

    //    public override int GetHashCode()
    //    {
    //        HashCode hash = new HashCode();
    //        hash.Add(EmpresaId);
    //        hash.Add(SucursalId);
    //        hash.Add(Id);
    //        hash.Add(Activo);
    //        hash.Add(Estatusdoctoid);
    //        hash.Add(Estatusdoctoclave);
    //        hash.Add(Estatusdoctonombre);
    //        hash.Add(Usuarioid);
    //        hash.Add(Usuarionombre);
    //        hash.Add(Fecha);
    //        hash.Add(Serie);
    //        hash.Add(Folio);
    //        hash.Add(Importe);
    //        hash.Add(Descuento);
    //        hash.Add(Subtotal);
    //        hash.Add(Iva);
    //        hash.Add(Ieps);
    //        hash.Add(Total);
    //        hash.Add(Cajaid);
    //        hash.Add(Cajaclave);
    //        hash.Add(Cajanombre);
    //        hash.Add(Proveedorid);
    //        hash.Add(Proveedorclave);
    //        hash.Add(Proveedornombre);
    //        hash.Add(Tipodoctoid);
    //        hash.Add(Tipodoctoclave);
    //        hash.Add(Tipodoctonombre);
    //        hash.Add(Referencia);
    //        hash.Add(Foliosat);
    //        hash.Add(Seriesat);
    //        hash.Add(Sucursaltid);
    //        hash.Add(Sucursaltclave);
    //        hash.Add(Sucursaltnombre);
    //        hash.Add(Almacentid);
    //        hash.Add(Almacentclave);
    //        hash.Add(Almacentnombre);
    //        hash.Add(Folio_c);
    //        hash.Add(Factura_c);
    //        hash.Add(Fechafactura_c);
    //        hash.Add(Fechavence_c);
    //        hash.Add(Origenfiscalid);
    //        hash.Add(Origenfiscalclave);
    //        hash.Add(Origenfiscalnombre);
    //        hash.Add(Devolucionrefid);
    //        hash.Add(Devolucionreffolio);
    //        hash.Add(Devolucionreffechahora);
    //        return hash.ToHashCode();
    //    }
    //}




    //public class V_movto_prov_to_devo: TransitionClass
    //{

    //    public V_movto_prov_to_devo()
    //    {

    //    }

    //    public long? DoctoRefId { get; }
    //    public long Movtorefid { get; }
    //    public int Partidaref { get; }
    //    public decimal Cantidadref { get; }
    //    public string? Descripcion { get; }
    //    public decimal Preciounidadref { get; }
    //    public decimal Importeref { get; }
    //    public decimal Descuentoref { get; }
    //    public string? Descripcion2 { get; }
    //    public string? Lote { get; }
    //    public string? Claveproducto { get; }
    //    public decimal Subtotalref { get; }
    //    public decimal Ivaref { get; }
    //    public decimal Cantidad { get; }
    //    public long Movtoid { get; }
    //    public decimal Preciounidad { get; }
    //    public decimal Subtotal { get; }
    //    public decimal Importe { get; }
    //    public int Partida { get; }
    //    public decimal Cantidaddevuelta { get; }
    //    public decimal Cantdisp { get; }
    //    public decimal Cantdispdespues { get; }
    //    public decimal Tasaiva { get; }
    //    public decimal Tasaieps { get; }
    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long? Productoid { get; }
    //    public string? Descripcion1 { get; }
    //    public string? Descripcion3 { get; }
    //    public DateTimeOffset? Fechavence { get; }
    //    public long? Loteimportado { get; }

    //    public V_movto_prov_to_devo(long? doctoRefId, long movtorefid, int partidaref, decimal cantidadref, string descripcion, decimal preciounidadref, decimal importeref, decimal descuentoref, string descripcion2, string lote, string claveproducto, decimal subtotalref, decimal ivaref, decimal cantidad, long movtoid, decimal preciounidad, decimal subtotal, decimal importe, int partida, decimal cantidaddevuelta, decimal cantdisp, decimal cantdispdespues, decimal tasaiva, decimal tasaieps, long empresaId, long sucursalId, long? productoid, string descripcion1, string descripcion3, DateTimeOffset? fechavence, long? loteimportado)
    //    {
    //        DoctoRefId = doctoRefId;
    //        Movtorefid = movtorefid;
    //        Partidaref = partidaref;
    //        Cantidadref = cantidadref;
    //        Descripcion = descripcion;
    //        Preciounidadref = preciounidadref;
    //        Importeref = importeref;
    //        Descuentoref = descuentoref;
    //        Descripcion2 = descripcion2;
    //        Lote = lote;
    //        Claveproducto = claveproducto;
    //        Subtotalref = subtotalref;
    //        Ivaref = ivaref;
    //        Cantidad = cantidad;
    //        Movtoid = movtoid;
    //        Preciounidad = preciounidad;
    //        Subtotal = subtotal;
    //        Importe = importe;
    //        Partida = partida;
    //        Cantidaddevuelta = cantidaddevuelta;
    //        Cantdisp = cantdisp;
    //        Cantdispdespues = cantdispdespues;
    //        Tasaiva = tasaiva;
    //        Tasaieps = tasaieps;
    //        EmpresaId = empresaId;
    //        SucursalId = sucursalId;
    //        Productoid = productoid;
    //        Descripcion1 = descripcion1;
    //        Descripcion3 = descripcion3;
    //        Fechavence = fechavence;
    //        Loteimportado = loteimportado;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        return obj is V_movto_prov_to_devo other &&
    //               DoctoRefId == other.DoctoRefId &&
    //               Movtorefid == other.Movtorefid &&
    //               Partidaref == other.Partidaref &&
    //               Cantidadref == other.Cantidadref &&
    //               Descripcion == other.Descripcion &&
    //               Preciounidadref == other.Preciounidadref &&
    //               Importeref == other.Importeref &&
    //               Descuentoref == other.Descuentoref &&
    //               Descripcion2 == other.Descripcion2 &&
    //               Lote == other.Lote &&
    //               Claveproducto == other.Claveproducto &&
    //               Subtotalref == other.Subtotalref &&
    //               Ivaref == other.Ivaref &&
    //               Cantidad == other.Cantidad &&
    //               Movtoid == other.Movtoid &&
    //               Preciounidad == other.Preciounidad &&
    //               Subtotal == other.Subtotal &&
    //               Importe == other.Importe &&
    //               Partida == other.Partida &&
    //               Cantidaddevuelta == other.Cantidaddevuelta &&
    //               Cantdisp == other.Cantdisp &&
    //               Cantdispdespues == other.Cantdispdespues &&
    //               Tasaiva == other.Tasaiva &&
    //               Tasaieps == other.Tasaieps &&
    //               EmpresaId == other.EmpresaId &&
    //               SucursalId == other.SucursalId &&
    //               Productoid == other.Productoid &&
    //               Descripcion1 == other.Descripcion1 &&
    //               Descripcion3 == other.Descripcion3 &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
    //               Loteimportado == other.Loteimportado;
    //    }

    //    public override int GetHashCode()
    //    {
    //        HashCode hash = new HashCode();
    //        hash.Add(DoctoRefId);
    //        hash.Add(Movtorefid);
    //        hash.Add(Partidaref);
    //        hash.Add(Cantidadref);
    //        hash.Add(Descripcion);
    //        hash.Add(Preciounidadref);
    //        hash.Add(Importeref);
    //        hash.Add(Descuentoref);
    //        hash.Add(Descripcion2);
    //        hash.Add(Lote);
    //        hash.Add(Claveproducto);
    //        hash.Add(Subtotalref);
    //        hash.Add(Ivaref);
    //        hash.Add(Cantidad);
    //        hash.Add(Movtoid);
    //        hash.Add(Preciounidad);
    //        hash.Add(Subtotal);
    //        hash.Add(Importe);
    //        hash.Add(Partida);
    //        hash.Add(Cantidaddevuelta);
    //        hash.Add(Cantdisp);
    //        hash.Add(Cantdispdespues);
    //        hash.Add(Tasaiva);
    //        hash.Add(Tasaieps);
    //        hash.Add(EmpresaId);
    //        hash.Add(SucursalId);
    //        hash.Add(Productoid);
    //        hash.Add(Descripcion1);
    //        hash.Add(Descripcion3);
    //        hash.Add(Fechavence);
    //        hash.Add(Loteimportado);
    //        return hash.ToHashCode();
    //    }
    //}




    //public class V_docto_vendeduria: TransitionClass
    //{

    //    public V_docto_vendeduria()
    //    {

    //    }

    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long Id { get; }
    //    public BoolCS Activo { get; }
    //    public long? Estatusdoctoid { get; }
    //    public string? Estatusdoctoclave { get; }
    //    public string? Estatusdoctonombre { get; }
    //    public long? Usuarioid { get; }
    //    public string? Usuarionombre { get; }
    //    public DateTimeOffset? Fecha { get; }
    //    public string? Serie { get; }
    //    public int? Folio { get; }
    //    public decimal Importe { get; }
    //    public decimal Descuento { get; }
    //    public decimal Subtotal { get; }
    //    public decimal Iva { get; }
    //    public decimal Ieps { get; }
    //    public decimal Total { get; }
    //    public long? Cajaid { get; }
    //    public string? Cajaclave { get; }
    //    public string? Cajanombre { get; }
    //    public long? Clienteid { get; }
    //    public string? Clienteclave { get; }
    //    public string? Clientenombre { get; }
    //    public long? Tipodoctoid { get; }
    //    public string? Tipodoctoclave { get; }
    //    public string? Tipodoctonombre { get; }
    //    public string? Referencia { get; }
    //    public int? Foliosat { get; }
    //    public string? Seriesat { get; }
    //    public long? Sucursaltid { get; }
    //    public string? Sucursaltclave { get; }
    //    public string? Sucursaltnombre { get; }
    //    public long? Almacentid { get; }
    //    public string? Almacentclave { get; }
    //    public string? Almacentnombre { get; }
    //    public DateTimeOffset? Fechahora { get; }
    //    public long? Origenfiscalid { get; }
    //    public string? Origenfiscalclave { get; }
    //    public string? Origenfiscalnombre { get; }

    //    public V_docto_vendeduria(long empresaId, long sucursalId, long id, BoolCS activo, long? estatusdoctoid, string? estatusdoctoclave, string? estatusdoctonombre, long? usuarioid, string? usuarionombre, DateTimeOffset? fecha, string? serie, int? folio, decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total, long? cajaid, string? cajaclave, string? cajanombre, long? clienteid, string? clienteclave, string? clientenombre, long? tipodoctoid, string? tipodoctoclave, string? tipodoctonombre, string? referencia, int? foliosat, string? seriesat, long? sucursaltid, string? sucursaltclave, string? sucursaltnombre, long? almacentid, string? almacentclave, string? almacentnombre, DateTimeOffset? fechahora, long? origenfiscalid, string? origenfiscalclave, string? origenfiscalnombre)
    //    {
    //        EmpresaId = empresaId;
    //        SucursalId = sucursalId;
    //        Id = id;
    //        Activo = activo;
    //        Estatusdoctoid = estatusdoctoid;
    //        Estatusdoctoclave = estatusdoctoclave;
    //        Estatusdoctonombre = estatusdoctonombre;
    //        Usuarioid = usuarioid;
    //        Usuarionombre = usuarionombre;
    //        Fecha = fecha;
    //        Serie = serie;
    //        Folio = folio;
    //        Importe = importe;
    //        Descuento = descuento;
    //        Subtotal = subtotal;
    //        Iva = iva;
    //        Ieps = ieps;
    //        Total = total;
    //        Cajaid = cajaid;
    //        Cajaclave = cajaclave;
    //        Cajanombre = cajanombre;
    //        Clienteid = clienteid;
    //        Clienteclave = clienteclave;
    //        Clientenombre = clientenombre;
    //        Tipodoctoid = tipodoctoid;
    //        Tipodoctoclave = tipodoctoclave;
    //        Tipodoctonombre = tipodoctonombre;
    //        Referencia = referencia;
    //        Foliosat = foliosat;
    //        Seriesat = seriesat;
    //        Sucursaltid = sucursaltid;
    //        Sucursaltclave = sucursaltclave;
    //        Sucursaltnombre = sucursaltnombre;
    //        Almacentid = almacentid;
    //        Almacentclave = almacentclave;
    //        Almacentnombre = almacentnombre;
    //        Fechahora = fechahora;
    //        Origenfiscalid = origenfiscalid;
    //        Origenfiscalclave = origenfiscalclave;
    //        Origenfiscalnombre = origenfiscalnombre;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        return obj is V_docto_vendeduria other &&
    //               EmpresaId == other.EmpresaId &&
    //               SucursalId == other.SucursalId &&
    //               Id == other.Id &&
    //               Activo == other.Activo &&
    //               Estatusdoctoid == other.Estatusdoctoid &&
    //               Estatusdoctoclave == other.Estatusdoctoclave &&
    //               Estatusdoctonombre == other.Estatusdoctonombre &&
    //               Usuarioid == other.Usuarioid &&
    //               Usuarionombre == other.Usuarionombre &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
    //               Serie == other.Serie &&
    //               Folio == other.Folio &&
    //               Importe == other.Importe &&
    //               Descuento == other.Descuento &&
    //               Subtotal == other.Subtotal &&
    //               Iva == other.Iva &&
    //               Ieps == other.Ieps &&
    //               Total == other.Total &&
    //               Cajaid == other.Cajaid &&
    //               Cajaclave == other.Cajaclave &&
    //               Cajanombre == other.Cajanombre &&
    //               Clienteid == other.Clienteid &&
    //               Clienteclave == other.Clienteclave &&
    //               Clientenombre == other.Clientenombre &&
    //               Tipodoctoid == other.Tipodoctoid &&
    //               Tipodoctoclave == other.Tipodoctoclave &&
    //               Tipodoctonombre == other.Tipodoctonombre &&
    //               Referencia == other.Referencia &&
    //               Foliosat == other.Foliosat &&
    //               Seriesat == other.Seriesat &&
    //               Sucursaltid == other.Sucursaltid &&
    //               Sucursaltclave == other.Sucursaltclave &&
    //               Sucursaltnombre == other.Sucursaltnombre &&
    //               Almacentid == other.Almacentid &&
    //               Almacentclave == other.Almacentclave &&
    //               Almacentnombre == other.Almacentnombre &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechahora, other.Fechahora) &&
    //               Origenfiscalid == other.Origenfiscalid &&
    //               Origenfiscalclave == other.Origenfiscalclave &&
    //               Origenfiscalnombre == other.Origenfiscalnombre;
    //    }

    //    public override int GetHashCode()
    //    {
    //        HashCode hash = new HashCode();
    //        hash.Add(EmpresaId);
    //        hash.Add(SucursalId);
    //        hash.Add(Id);
    //        hash.Add(Activo);
    //        hash.Add(Estatusdoctoid);
    //        hash.Add(Estatusdoctoclave);
    //        hash.Add(Estatusdoctonombre);
    //        hash.Add(Usuarioid);
    //        hash.Add(Usuarionombre);
    //        hash.Add(Fecha);
    //        hash.Add(Serie);
    //        hash.Add(Folio);
    //        hash.Add(Importe);
    //        hash.Add(Descuento);
    //        hash.Add(Subtotal);
    //        hash.Add(Iva);
    //        hash.Add(Ieps);
    //        hash.Add(Total);
    //        hash.Add(Cajaid);
    //        hash.Add(Cajaclave);
    //        hash.Add(Cajanombre);
    //        hash.Add(Clienteid);
    //        hash.Add(Clienteclave);
    //        hash.Add(Clientenombre);
    //        hash.Add(Tipodoctoid);
    //        hash.Add(Tipodoctoclave);
    //        hash.Add(Tipodoctonombre);
    //        hash.Add(Referencia);
    //        hash.Add(Foliosat);
    //        hash.Add(Seriesat);
    //        hash.Add(Sucursaltid);
    //        hash.Add(Sucursaltclave);
    //        hash.Add(Sucursaltnombre);
    //        hash.Add(Almacentid);
    //        hash.Add(Almacentclave);
    //        hash.Add(Almacentnombre);
    //        hash.Add(Fechahora);
    //        hash.Add(Origenfiscalid);
    //        hash.Add(Origenfiscalclave);
    //        hash.Add(Origenfiscalnombre);
    //        return hash.ToHashCode();
    //    }
    //}



    //public class V_movto_vendeduria : TransitionClass
    //{
    //    public V_movto_vendeduria()
    //    {

    //    }

    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long Id { get; }
    //    public int Partida { get; }
    //    public long? Productoid { get; }
    //    public string? ProductoClave { get; }
    //    public string? ProductoNombre { get; }
    //    public decimal Cantidad { get; }
    //    public decimal Preciolista { get; }
    //    public decimal Descuentoporcentaje { get; }
    //    public decimal Descuento { get; }
    //    public decimal Precio { get; }
    //    public decimal Importe { get; }
    //    public decimal Subtotal { get; }
    //    public decimal Iva { get; }
    //    public decimal Ieps { get; }
    //    public decimal Tasaiva { get; }
    //    public decimal Tasaieps { get; }
    //    public decimal Total { get; }
    //    public string? Lote { get; }
    //    public DateTimeOffset? Fechavence { get; }
    //    public long? Loteimportado { get; }
    //    public long? Doctoid { get; }
    //    public int Orden { get; }
    //    public decimal Descuentovale { get; }
    //    public decimal Descuentovaleporcentaje { get; }
    //    public BoolCN Ingresopreciomanual { get; }
    //    public decimal Porcentajedescuentomanual { get; }
    //    public string? Descripcion1 { get; }
    //    public string? Descripcion2 { get; }
    //    public string? Descripcion3 { get; }
    //    public decimal Cantidadsurtida { get; }
    //    public decimal Precio1 { get; }
    //    public decimal Existencia { get; }
    //    public decimal Pzacaja { get; }
    //    public string? Texto1 { get; }
    //    public string? Texto2 { get; }
    //    public string? Texto3 { get; }
    //    public string? Texto4 { get; }
    //    public string? Texto5 { get; }
    //    public string? Texto6 { get; }
    //    public decimal? Numero1 { get; }
    //    public decimal? Numero2 { get; }
    //    public decimal? Numero3 { get; }
    //    public decimal? Numero4 { get; }
    //    public DateTimeOffset? Fecha1 { get; }
    //    public DateTimeOffset? Fecha2 { get; }
    //    public long? Unidadid { get; }
    //    public string? UnidadClave { get; }
    //    public string? UnidadNombre { get; }
    //    public string? Alerta3 { get; }
    //    public decimal Preciomostrar { get; }
    //    public decimal Descuentomostrar { get; }

    //    public V_movto_vendeduria(long empresaId, long sucursalId, long id, int partida, long? productoid, string? productoClave, string? productoNombre, decimal cantidad, decimal preciolista, decimal descuentoporcentaje, decimal descuento, decimal precio, decimal importe, decimal subtotal, decimal iva, decimal ieps, decimal tasaiva, decimal tasaieps, decimal total, string? lote, DateTimeOffset? fechavence, long? loteimportado, long? doctoid, int orden, decimal descuentovale, decimal descuentovaleporcentaje, BoolCN ingresopreciomanual, decimal porcentajedescuentomanual, string? descripcion1, string? descripcion2, string? descripcion3, decimal cantidadsurtida, decimal precio1, decimal existencia, decimal pzacaja, string? texto1, string? texto2, string? texto3, string? texto4, string? texto5, string? texto6, decimal? numero1, decimal? numero2, decimal? numero3, decimal? numero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, long? unidadid, string? unidadClave, string? unidadNombre, string alerta3, decimal preciomostrar, decimal descuentomostrar)
    //    {
    //        EmpresaId = empresaId;
    //        SucursalId = sucursalId;
    //        Id = id;
    //        Partida = partida;
    //        Productoid = productoid;
    //        ProductoClave = productoClave;
    //        ProductoNombre = productoNombre;
    //        Cantidad = cantidad;
    //        Preciolista = preciolista;
    //        Descuentoporcentaje = descuentoporcentaje;
    //        Descuento = descuento;
    //        Precio = precio;
    //        Importe = importe;
    //        Subtotal = subtotal;
    //        Iva = iva;
    //        Ieps = ieps;
    //        Tasaiva = tasaiva;
    //        Tasaieps = tasaieps;
    //        Total = total;
    //        Lote = lote;
    //        Fechavence = fechavence;
    //        Loteimportado = loteimportado;
    //        Doctoid = doctoid;
    //        Orden = orden;
    //        Descuentovale = descuentovale;
    //        Descuentovaleporcentaje = descuentovaleporcentaje;
    //        Ingresopreciomanual = ingresopreciomanual;
    //        Porcentajedescuentomanual = porcentajedescuentomanual;
    //        Descripcion1 = descripcion1;
    //        Descripcion2 = descripcion2;
    //        Descripcion3 = descripcion3;
    //        Cantidadsurtida = cantidadsurtida;
    //        Precio1 = precio1;
    //        Existencia = existencia;
    //        Pzacaja = pzacaja;
    //        Texto1 = texto1;
    //        Texto2 = texto2;
    //        Texto3 = texto3;
    //        Texto4 = texto4;
    //        Texto5 = texto5;
    //        Texto6 = texto6;
    //        Numero1 = numero1;
    //        Numero2 = numero2;
    //        Numero3 = numero3;
    //        Numero4 = numero4;
    //        Fecha1 = fecha1;
    //        Fecha2 = fecha2;
    //        Unidadid = unidadid;
    //        UnidadClave = unidadClave;
    //        UnidadNombre = unidadNombre;
    //        Alerta3 = alerta3;
    //        Preciomostrar = preciomostrar;
    //        Descuentomostrar = descuentomostrar;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        return obj is V_movto_vendeduria other &&
    //               EmpresaId == other.EmpresaId &&
    //               SucursalId == other.SucursalId &&
    //               Id == other.Id &&
    //               Partida == other.Partida &&
    //               Productoid == other.Productoid &&
    //               ProductoClave == other.ProductoClave &&
    //               ProductoNombre == other.ProductoNombre &&
    //               Cantidad == other.Cantidad &&
    //               Preciolista == other.Preciolista &&
    //               Descuentoporcentaje == other.Descuentoporcentaje &&
    //               Descuento == other.Descuento &&
    //               Precio == other.Precio &&
    //               Importe == other.Importe &&
    //               Subtotal == other.Subtotal &&
    //               Iva == other.Iva &&
    //               Ieps == other.Ieps &&
    //               Tasaiva == other.Tasaiva &&
    //               Tasaieps == other.Tasaieps &&
    //               Total == other.Total &&
    //               Lote == other.Lote &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
    //               Loteimportado == other.Loteimportado &&
    //               Doctoid == other.Doctoid &&
    //               Orden == other.Orden &&
    //               Descuentovale == other.Descuentovale &&
    //               Descuentovaleporcentaje == other.Descuentovaleporcentaje &&
    //               Ingresopreciomanual == other.Ingresopreciomanual &&
    //               Porcentajedescuentomanual == other.Porcentajedescuentomanual &&
    //               Descripcion1 == other.Descripcion1 &&
    //               Descripcion2 == other.Descripcion2 &&
    //               Descripcion3 == other.Descripcion3 &&
    //               Cantidadsurtida == other.Cantidadsurtida &&
    //               Precio1 == other.Precio1 &&
    //               Existencia == other.Existencia &&
    //               Pzacaja == other.Pzacaja &&
    //               Texto1 == other.Texto1 &&
    //               Texto2 == other.Texto2 &&
    //               Texto3 == other.Texto3 &&
    //               Texto4 == other.Texto4 &&
    //               Texto5 == other.Texto5 &&
    //               Texto6 == other.Texto6 &&
    //               Numero1 == other.Numero1 &&
    //               Numero2 == other.Numero2 &&
    //               Numero3 == other.Numero3 &&
    //               Numero4 == other.Numero4 &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha1, other.Fecha1) &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha2, other.Fecha2) &&
    //               Unidadid == other.Unidadid &&
    //               UnidadClave == other.UnidadClave &&
    //               UnidadNombre == other.UnidadNombre &&
    //               Alerta3 == other.Alerta3 &&
    //               Preciomostrar == other.Preciomostrar &&
    //               Descuentomostrar == other.Descuentomostrar;
    //    }

    //    public override int GetHashCode()
    //    {
    //        HashCode hash = new HashCode();
    //        hash.Add(EmpresaId);
    //        hash.Add(SucursalId);
    //        hash.Add(Id);
    //        hash.Add(Partida);
    //        hash.Add(Productoid);
    //        hash.Add(ProductoClave);
    //        hash.Add(ProductoNombre);
    //        hash.Add(Cantidad);
    //        hash.Add(Preciolista);
    //        hash.Add(Descuentoporcentaje);
    //        hash.Add(Descuento);
    //        hash.Add(Precio);
    //        hash.Add(Importe);
    //        hash.Add(Subtotal);
    //        hash.Add(Iva);
    //        hash.Add(Ieps);
    //        hash.Add(Tasaiva);
    //        hash.Add(Tasaieps);
    //        hash.Add(Total);
    //        hash.Add(Lote);
    //        hash.Add(Fechavence);
    //        hash.Add(Loteimportado);
    //        hash.Add(Doctoid);
    //        hash.Add(Orden);
    //        hash.Add(Descuentovale);
    //        hash.Add(Descuentovaleporcentaje);
    //        hash.Add(Ingresopreciomanual);
    //        hash.Add(Porcentajedescuentomanual);
    //        hash.Add(Descripcion1);
    //        hash.Add(Descripcion2);
    //        hash.Add(Descripcion3);
    //        hash.Add(Cantidadsurtida);
    //        hash.Add(Precio1);
    //        hash.Add(Existencia);
    //        hash.Add(Pzacaja);
    //        hash.Add(Texto1);
    //        hash.Add(Texto2);
    //        hash.Add(Texto3);
    //        hash.Add(Texto4);
    //        hash.Add(Texto5);
    //        hash.Add(Texto6);
    //        hash.Add(Numero1);
    //        hash.Add(Numero2);
    //        hash.Add(Numero3);
    //        hash.Add(Numero4);
    //        hash.Add(Fecha1);
    //        hash.Add(Fecha2);
    //        hash.Add(Unidadid);
    //        hash.Add(UnidadClave);
    //        hash.Add(UnidadNombre);
    //        hash.Add(Alerta3);
    //        hash.Add(Preciomostrar);
    //        hash.Add(Descuentomostrar);
    //        return hash.ToHashCode();
    //    }
    //}


    //public class V_docto_venddevo : TransitionClass
    //{

    //    public V_docto_venddevo()
    //    {

    //    }

    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long Id { get; }
    //    public BoolCS Activo { get; }
    //    public long? Estatusdoctoid { get; }
    //    public string? Estatusdoctoclave { get; }
    //    public string? Estatusdoctonombre { get; }
    //    public long? Usuarioid { get; }
    //    public string? Usuarionombre { get; }
    //    public DateTimeOffset? Fecha { get; }
    //    public string? Serie { get; }
    //    public int? Folio { get; }
    //    public decimal Importe { get; }
    //    public decimal Descuento { get; }
    //    public decimal Subtotal { get; }
    //    public decimal Iva { get; }
    //    public decimal Ieps { get; }
    //    public decimal Total { get; }
    //    public long? Cajaid { get; }
    //    public string? Cajaclave { get; }
    //    public string? Cajanombre { get; }
    //    public long? Clienteid { get; }
    //    public string? Clienteclave { get; }
    //    public string? Clientenombre { get; }
    //    public long? Tipodoctoid { get; }
    //    public string? Tipodoctoclave { get; }
    //    public string? Tipodoctonombre { get; }
    //    public string? Referencia { get; }
    //    public int? Foliosat { get; }
    //    public string? Seriesat { get; }
    //    public long? Sucursaltid { get; }
    //    public string? Sucursaltclave { get; }
    //    public string? Sucursaltnombre { get; }
    //    public long? Almacentid { get; }
    //    public string? Almacentclave { get; }
    //    public string? Almacentnombre { get; }
    //    public DateTimeOffset? Fechahora { get; }
    //    public long? Origenfiscalid { get; }
    //    public string? Origenfiscalclave { get; }
    //    public string? Origenfiscalnombre { get; }
    //    public long? Devolucionrefid { get; }
    //    public int? Devolucionreffolio { get; }
    //    public DateTimeOffset? Devolucionreffechahora { get; }

    //    public V_docto_venddevo(long empresaId, long sucursalId, long id, BoolCS activo, long? estatusdoctoid, string? estatusdoctoclave, string? estatusdoctonombre, long? usuarioid, string? usuarionombre, DateTimeOffset? fecha, string? serie, int? folio, decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total, long? cajaid, string? cajaclave, string? cajanombre, long? clienteid, string? clienteclave, string? clientenombre, long? tipodoctoid, string? tipodoctoclave, string? tipodoctonombre, string? referencia, int? foliosat, string? seriesat, long? sucursaltid, string? sucursaltclave, string? sucursaltnombre, long? almacentid, string? almacentclave, string? almacentnombre, DateTimeOffset? fechahora, long? origenfiscalid, string? origenfiscalclave, string? origenfiscalnombre, long? devolucionrefid, int? devolucionreffolio, DateTimeOffset? devolucionreffechahora)
    //    {
    //        EmpresaId = empresaId;
    //        SucursalId = sucursalId;
    //        Id = id;
    //        Activo = activo;
    //        Estatusdoctoid = estatusdoctoid;
    //        Estatusdoctoclave = estatusdoctoclave;
    //        Estatusdoctonombre = estatusdoctonombre;
    //        Usuarioid = usuarioid;
    //        Usuarionombre = usuarionombre;
    //        Fecha = fecha;
    //        Serie = serie;
    //        Folio = folio;
    //        Importe = importe;
    //        Descuento = descuento;
    //        Subtotal = subtotal;
    //        Iva = iva;
    //        Ieps = ieps;
    //        Total = total;
    //        Cajaid = cajaid;
    //        Cajaclave = cajaclave;
    //        Cajanombre = cajanombre;
    //        Clienteid = clienteid;
    //        Clienteclave = clienteclave;
    //        Clientenombre = clientenombre;
    //        Tipodoctoid = tipodoctoid;
    //        Tipodoctoclave = tipodoctoclave;
    //        Tipodoctonombre = tipodoctonombre;
    //        Referencia = referencia;
    //        Foliosat = foliosat;
    //        Seriesat = seriesat;
    //        Sucursaltid = sucursaltid;
    //        Sucursaltclave = sucursaltclave;
    //        Sucursaltnombre = sucursaltnombre;
    //        Almacentid = almacentid;
    //        Almacentclave = almacentclave;
    //        Almacentnombre = almacentnombre;
    //        Fechahora = fechahora;
    //        Origenfiscalid = origenfiscalid;
    //        Origenfiscalclave = origenfiscalclave;
    //        Origenfiscalnombre = origenfiscalnombre;
    //        Devolucionrefid = devolucionrefid;
    //        Devolucionreffolio = devolucionreffolio;
    //        Devolucionreffechahora = devolucionreffechahora;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        return obj is V_docto_venddevo other &&
    //               EmpresaId == other.EmpresaId &&
    //               SucursalId == other.SucursalId &&
    //               Id == other.Id &&
    //               Activo == other.Activo &&
    //               Estatusdoctoid == other.Estatusdoctoid &&
    //               Estatusdoctoclave == other.Estatusdoctoclave &&
    //               Estatusdoctonombre == other.Estatusdoctonombre &&
    //               Usuarioid == other.Usuarioid &&
    //               Usuarionombre == other.Usuarionombre &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
    //               Serie == other.Serie &&
    //               Folio == other.Folio &&
    //               Importe == other.Importe &&
    //               Descuento == other.Descuento &&
    //               Subtotal == other.Subtotal &&
    //               Iva == other.Iva &&
    //               Ieps == other.Ieps &&
    //               Total == other.Total &&
    //               Cajaid == other.Cajaid &&
    //               Cajaclave == other.Cajaclave &&
    //               Cajanombre == other.Cajanombre &&
    //               Clienteid == other.Clienteid &&
    //               Clienteclave == other.Clienteclave &&
    //               Clientenombre == other.Clientenombre &&
    //               Tipodoctoid == other.Tipodoctoid &&
    //               Tipodoctoclave == other.Tipodoctoclave &&
    //               Tipodoctonombre == other.Tipodoctonombre &&
    //               Referencia == other.Referencia &&
    //               Foliosat == other.Foliosat &&
    //               Seriesat == other.Seriesat &&
    //               Sucursaltid == other.Sucursaltid &&
    //               Sucursaltclave == other.Sucursaltclave &&
    //               Sucursaltnombre == other.Sucursaltnombre &&
    //               Almacentid == other.Almacentid &&
    //               Almacentclave == other.Almacentclave &&
    //               Almacentnombre == other.Almacentnombre &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechahora, other.Fechahora) &&
    //               Origenfiscalid == other.Origenfiscalid &&
    //               Origenfiscalclave == other.Origenfiscalclave &&
    //               Origenfiscalnombre == other.Origenfiscalnombre &&
    //               Devolucionrefid == other.Devolucionrefid &&
    //               Devolucionreffolio == other.Devolucionreffolio &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Devolucionreffechahora, other.Devolucionreffechahora);
    //    }

    //    public override int GetHashCode()
    //    {
    //        HashCode hash = new HashCode();
    //        hash.Add(EmpresaId);
    //        hash.Add(SucursalId);
    //        hash.Add(Id);
    //        hash.Add(Activo);
    //        hash.Add(Estatusdoctoid);
    //        hash.Add(Estatusdoctoclave);
    //        hash.Add(Estatusdoctonombre);
    //        hash.Add(Usuarioid);
    //        hash.Add(Usuarionombre);
    //        hash.Add(Fecha);
    //        hash.Add(Serie);
    //        hash.Add(Folio);
    //        hash.Add(Importe);
    //        hash.Add(Descuento);
    //        hash.Add(Subtotal);
    //        hash.Add(Iva);
    //        hash.Add(Ieps);
    //        hash.Add(Total);
    //        hash.Add(Cajaid);
    //        hash.Add(Cajaclave);
    //        hash.Add(Cajanombre);
    //        hash.Add(Clienteid);
    //        hash.Add(Clienteclave);
    //        hash.Add(Clientenombre);
    //        hash.Add(Tipodoctoid);
    //        hash.Add(Tipodoctoclave);
    //        hash.Add(Tipodoctonombre);
    //        hash.Add(Referencia);
    //        hash.Add(Foliosat);
    //        hash.Add(Seriesat);
    //        hash.Add(Sucursaltid);
    //        hash.Add(Sucursaltclave);
    //        hash.Add(Sucursaltnombre);
    //        hash.Add(Almacentid);
    //        hash.Add(Almacentclave);
    //        hash.Add(Almacentnombre);
    //        hash.Add(Fechahora);
    //        hash.Add(Origenfiscalid);
    //        hash.Add(Origenfiscalclave);
    //        hash.Add(Origenfiscalnombre);
    //        hash.Add(Devolucionrefid);
    //        hash.Add(Devolucionreffolio);
    //        hash.Add(Devolucionreffechahora);
    //        return hash.ToHashCode();
    //    }
    //}


    //public class V_movto_venddevo : TransitionClass
    //{

    //    public V_movto_venddevo()
    //    {

    //    }

    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long Id { get; }
    //    public int Partida { get; }
    //    public long? Productoid { get; }
    //    public string? ProductoClave { get; }
    //    public string? ProductoNombre { get; }
    //    public decimal Cantidad { get; }
    //    public decimal Preciolista { get; }
    //    public decimal Descuentoporcentaje { get; }
    //    public decimal Descuento { get; }
    //    public decimal Precio { get; }
    //    public decimal Importe { get; }
    //    public decimal Subtotal { get; }
    //    public decimal Iva { get; }
    //    public decimal Ieps { get; }
    //    public decimal Tasaiva { get; }
    //    public decimal Tasaieps { get; }
    //    public decimal Total { get; }
    //    public string? Lote { get; }
    //    public DateTimeOffset? Fechavence { get; }
    //    public long? Loteimportado { get; }
    //    public long? Doctoid { get; }
    //    public int Orden { get; }
    //    public decimal Descuentovale { get; }
    //    public decimal Descuentovaleporcentaje { get; }
    //    public BoolCN Ingresopreciomanual { get; }
    //    public decimal Porcentajedescuentomanual { get; }
    //    public string? Descripcion1 { get; }
    //    public string? Descripcion2 { get; }
    //    public string? Descripcion3 { get; }
    //    public decimal Cantidadsurtida { get; }
    //    public decimal Precio1 { get; }
    //    public decimal Existencia { get; }
    //    public decimal Pzacaja { get; }
    //    public string? Texto1 { get; }
    //    public string? Texto2 { get; }
    //    public string? Texto3 { get; }
    //    public string? Texto4 { get; }
    //    public string? Texto5 { get; }
    //    public string? Texto6 { get; }
    //    public decimal? Numero1 { get; }
    //    public decimal? Numero2 { get; }
    //    public decimal? Numero3 { get; }
    //    public decimal? Numero4 { get; }
    //    public DateTimeOffset? Fecha1 { get; }
    //    public DateTimeOffset? Fecha2 { get; }
    //    public long? Unidadid { get; }
    //    public string? UnidadClave { get; }
    //    public string? UnidadNombre { get; }
    //    public string? Alerta3 { get; }
    //    public decimal Preciomostrar { get; }
    //    public decimal Descuentomostrar { get; }
    //    public long? Devolucionmovtorefid { get; }
    //    public decimal? Devolucionmovtorefcantidad { get; }
    //    public decimal? Devolucionmovtorefprecio { get; }

    //    public V_movto_venddevo(long empresaId, long sucursalId, long id, int partida, long? productoid, string? productoClave, string? productoNombre, decimal cantidad, decimal preciolista, decimal descuentoporcentaje, decimal descuento, decimal precio, decimal importe, decimal subtotal, decimal iva, decimal ieps, decimal tasaiva, decimal tasaieps, decimal total, string? lote, DateTimeOffset? fechavence, long? loteimportado, long? doctoid, int orden, decimal descuentovale, decimal descuentovaleporcentaje, BoolCN ingresopreciomanual, decimal porcentajedescuentomanual, string? descripcion1, string? descripcion2, string? descripcion3, decimal cantidadsurtida, decimal precio1, decimal existencia, decimal pzacaja, string? texto1, string? texto2, string? texto3, string? texto4, string? texto5, string? texto6, decimal? numero1, decimal? numero2, decimal? numero3, decimal? numero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, long? unidadid, string? unidadClave, string? unidadNombre, string alerta3, decimal preciomostrar, decimal descuentomostrar, long? devolucionmovtorefid, decimal? devolucionmovtorefcantidad, decimal? devolucionmovtorefprecio)
    //    {
    //        EmpresaId = empresaId;
    //        SucursalId = sucursalId;
    //        Id = id;
    //        Partida = partida;
    //        Productoid = productoid;
    //        ProductoClave = productoClave;
    //        ProductoNombre = productoNombre;
    //        Cantidad = cantidad;
    //        Preciolista = preciolista;
    //        Descuentoporcentaje = descuentoporcentaje;
    //        Descuento = descuento;
    //        Precio = precio;
    //        Importe = importe;
    //        Subtotal = subtotal;
    //        Iva = iva;
    //        Ieps = ieps;
    //        Tasaiva = tasaiva;
    //        Tasaieps = tasaieps;
    //        Total = total;
    //        Lote = lote;
    //        Fechavence = fechavence;
    //        Loteimportado = loteimportado;
    //        Doctoid = doctoid;
    //        Orden = orden;
    //        Descuentovale = descuentovale;
    //        Descuentovaleporcentaje = descuentovaleporcentaje;
    //        Ingresopreciomanual = ingresopreciomanual;
    //        Porcentajedescuentomanual = porcentajedescuentomanual;
    //        Descripcion1 = descripcion1;
    //        Descripcion2 = descripcion2;
    //        Descripcion3 = descripcion3;
    //        Cantidadsurtida = cantidadsurtida;
    //        Precio1 = precio1;
    //        Existencia = existencia;
    //        Pzacaja = pzacaja;
    //        Texto1 = texto1;
    //        Texto2 = texto2;
    //        Texto3 = texto3;
    //        Texto4 = texto4;
    //        Texto5 = texto5;
    //        Texto6 = texto6;
    //        Numero1 = numero1;
    //        Numero2 = numero2;
    //        Numero3 = numero3;
    //        Numero4 = numero4;
    //        Fecha1 = fecha1;
    //        Fecha2 = fecha2;
    //        Unidadid = unidadid;
    //        UnidadClave = unidadClave;
    //        UnidadNombre = unidadNombre;
    //        Alerta3 = alerta3;
    //        Preciomostrar = preciomostrar;
    //        Descuentomostrar = descuentomostrar;
    //        Devolucionmovtorefid = devolucionmovtorefid;
    //        Devolucionmovtorefcantidad = devolucionmovtorefcantidad;
    //        Devolucionmovtorefprecio = devolucionmovtorefprecio;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        return obj is V_movto_venddevo other &&
    //               EmpresaId == other.EmpresaId &&
    //               SucursalId == other.SucursalId &&
    //               Id == other.Id &&
    //               Partida == other.Partida &&
    //               Productoid == other.Productoid &&
    //               ProductoClave == other.ProductoClave &&
    //               ProductoNombre == other.ProductoNombre &&
    //               Cantidad == other.Cantidad &&
    //               Preciolista == other.Preciolista &&
    //               Descuentoporcentaje == other.Descuentoporcentaje &&
    //               Descuento == other.Descuento &&
    //               Precio == other.Precio &&
    //               Importe == other.Importe &&
    //               Subtotal == other.Subtotal &&
    //               Iva == other.Iva &&
    //               Ieps == other.Ieps &&
    //               Tasaiva == other.Tasaiva &&
    //               Tasaieps == other.Tasaieps &&
    //               Total == other.Total &&
    //               Lote == other.Lote &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
    //               Loteimportado == other.Loteimportado &&
    //               Doctoid == other.Doctoid &&
    //               Orden == other.Orden &&
    //               Descuentovale == other.Descuentovale &&
    //               Descuentovaleporcentaje == other.Descuentovaleporcentaje &&
    //               Ingresopreciomanual == other.Ingresopreciomanual &&
    //               Porcentajedescuentomanual == other.Porcentajedescuentomanual &&
    //               Descripcion1 == other.Descripcion1 &&
    //               Descripcion2 == other.Descripcion2 &&
    //               Descripcion3 == other.Descripcion3 &&
    //               Cantidadsurtida == other.Cantidadsurtida &&
    //               Precio1 == other.Precio1 &&
    //               Existencia == other.Existencia &&
    //               Pzacaja == other.Pzacaja &&
    //               Texto1 == other.Texto1 &&
    //               Texto2 == other.Texto2 &&
    //               Texto3 == other.Texto3 &&
    //               Texto4 == other.Texto4 &&
    //               Texto5 == other.Texto5 &&
    //               Texto6 == other.Texto6 &&
    //               Numero1 == other.Numero1 &&
    //               Numero2 == other.Numero2 &&
    //               Numero3 == other.Numero3 &&
    //               Numero4 == other.Numero4 &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha1, other.Fecha1) &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha2, other.Fecha2) &&
    //               Unidadid == other.Unidadid &&
    //               UnidadClave == other.UnidadClave &&
    //               UnidadNombre == other.UnidadNombre &&
    //               Alerta3 == other.Alerta3 &&
    //               Preciomostrar == other.Preciomostrar &&
    //               Descuentomostrar == other.Descuentomostrar &&
    //               Devolucionmovtorefid == other.Devolucionmovtorefid &&
    //               Devolucionmovtorefcantidad == other.Devolucionmovtorefcantidad &&
    //               Devolucionmovtorefprecio == other.Devolucionmovtorefprecio;
    //    }

    //    public override int GetHashCode()
    //    {
    //        HashCode hash = new HashCode();
    //        hash.Add(EmpresaId);
    //        hash.Add(SucursalId);
    //        hash.Add(Id);
    //        hash.Add(Partida);
    //        hash.Add(Productoid);
    //        hash.Add(ProductoClave);
    //        hash.Add(ProductoNombre);
    //        hash.Add(Cantidad);
    //        hash.Add(Preciolista);
    //        hash.Add(Descuentoporcentaje);
    //        hash.Add(Descuento);
    //        hash.Add(Precio);
    //        hash.Add(Importe);
    //        hash.Add(Subtotal);
    //        hash.Add(Iva);
    //        hash.Add(Ieps);
    //        hash.Add(Tasaiva);
    //        hash.Add(Tasaieps);
    //        hash.Add(Total);
    //        hash.Add(Lote);
    //        hash.Add(Fechavence);
    //        hash.Add(Loteimportado);
    //        hash.Add(Doctoid);
    //        hash.Add(Orden);
    //        hash.Add(Descuentovale);
    //        hash.Add(Descuentovaleporcentaje);
    //        hash.Add(Ingresopreciomanual);
    //        hash.Add(Porcentajedescuentomanual);
    //        hash.Add(Descripcion1);
    //        hash.Add(Descripcion2);
    //        hash.Add(Descripcion3);
    //        hash.Add(Cantidadsurtida);
    //        hash.Add(Precio1);
    //        hash.Add(Existencia);
    //        hash.Add(Pzacaja);
    //        hash.Add(Texto1);
    //        hash.Add(Texto2);
    //        hash.Add(Texto3);
    //        hash.Add(Texto4);
    //        hash.Add(Texto5);
    //        hash.Add(Texto6);
    //        hash.Add(Numero1);
    //        hash.Add(Numero2);
    //        hash.Add(Numero3);
    //        hash.Add(Numero4);
    //        hash.Add(Fecha1);
    //        hash.Add(Fecha2);
    //        hash.Add(Unidadid);
    //        hash.Add(UnidadClave);
    //        hash.Add(UnidadNombre);
    //        hash.Add(Alerta3);
    //        hash.Add(Preciomostrar);
    //        hash.Add(Descuentomostrar);
    //        hash.Add(Devolucionmovtorefid);
    //        hash.Add(Devolucionmovtorefcantidad);
    //        hash.Add(Devolucionmovtorefprecio);
    //        return hash.ToHashCode();
    //    }
    //}


    //public class V_movto_vend_to_devo : TransitionClass
    //{
    //    public V_movto_vend_to_devo()
    //    {

    //    }

    //    public long? DoctoRefId { get; }
    //    public long Movtorefid { get; }
    //    public int Partidaref { get; }
    //    public decimal Cantidadref { get; }
    //    public string? Descripcion { get; }
    //    public decimal Preciounidadref { get; }
    //    public decimal Importeref { get; }
    //    public decimal Descuentoref { get; }
    //    public string? Descripcion2 { get; }
    //    public string? Lote { get; }
    //    public string? Claveproducto { get; }
    //    public decimal Subtotalref { get; }
    //    public decimal Ivaref { get; }
    //    public decimal? Cantidad { get; }
    //    public long? Movtoid { get; }
    //    public decimal? Preciounidad { get; }
    //    public decimal? Subtotal { get; }
    //    public decimal? Importe { get; }
    //    public int? Partida { get; }
    //    public decimal Cantidaddevuelta { get; }
    //    public decimal Cantdisp { get; }
    //    public decimal Cantdispdespues { get; }
    //    public decimal Tasaiva { get; }
    //    public decimal Tasaieps { get; }
    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long? Productoid { get; }
    //    public string? Descripcion1 { get; }
    //    public string? Descripcion3 { get; }
    //    public DateTimeOffset? Fechavence { get; }
    //    public long? Loteimportado { get; }

    //    public V_movto_vend_to_devo(long? doctoRefId, long movtorefid, int partidaref, decimal cantidadref, string descripcion, decimal preciounidadref, decimal importeref, decimal descuentoref, string descripcion2, string lote, string claveproducto, decimal subtotalref, decimal ivaref, decimal? cantidad, long? movtoid, decimal? preciounidad, decimal? subtotal, decimal? importe, int? partida, decimal cantidaddevuelta, decimal cantdisp, decimal cantdispdespues, decimal tasaiva, decimal tasaieps, long empresaId, long sucursalId, long? productoid, string descripcion1, string descripcion3, DateTimeOffset? fechavence, long? loteimportado)
    //    {
    //        DoctoRefId = doctoRefId;
    //        Movtorefid = movtorefid;
    //        Partidaref = partidaref;
    //        Cantidadref = cantidadref;
    //        Descripcion = descripcion;
    //        Preciounidadref = preciounidadref;
    //        Importeref = importeref;
    //        Descuentoref = descuentoref;
    //        Descripcion2 = descripcion2;
    //        Lote = lote;
    //        Claveproducto = claveproducto;
    //        Subtotalref = subtotalref;
    //        Ivaref = ivaref;
    //        Cantidad = cantidad;
    //        Movtoid = movtoid;
    //        Preciounidad = preciounidad;
    //        Subtotal = subtotal;
    //        Importe = importe;
    //        Partida = partida;
    //        Cantidaddevuelta = cantidaddevuelta;
    //        Cantdisp = cantdisp;
    //        Cantdispdespues = cantdispdespues;
    //        Tasaiva = tasaiva;
    //        Tasaieps = tasaieps;
    //        EmpresaId = empresaId;
    //        SucursalId = sucursalId;
    //        Productoid = productoid;
    //        Descripcion1 = descripcion1;
    //        Descripcion3 = descripcion3;
    //        Fechavence = fechavence;
    //        Loteimportado = loteimportado;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        return obj is V_movto_vend_to_devo other &&
    //               DoctoRefId == other.DoctoRefId &&
    //               Movtorefid == other.Movtorefid &&
    //               Partidaref == other.Partidaref &&
    //               Cantidadref == other.Cantidadref &&
    //               Descripcion == other.Descripcion &&
    //               Preciounidadref == other.Preciounidadref &&
    //               Importeref == other.Importeref &&
    //               Descuentoref == other.Descuentoref &&
    //               Descripcion2 == other.Descripcion2 &&
    //               Lote == other.Lote &&
    //               Claveproducto == other.Claveproducto &&
    //               Subtotalref == other.Subtotalref &&
    //               Ivaref == other.Ivaref &&
    //               Cantidad == other.Cantidad &&
    //               Movtoid == other.Movtoid &&
    //               Preciounidad == other.Preciounidad &&
    //               Subtotal == other.Subtotal &&
    //               Importe == other.Importe &&
    //               Partida == other.Partida &&
    //               Cantidaddevuelta == other.Cantidaddevuelta &&
    //               Cantdisp == other.Cantdisp &&
    //               Cantdispdespues == other.Cantdispdespues &&
    //               Tasaiva == other.Tasaiva &&
    //               Tasaieps == other.Tasaieps &&
    //               EmpresaId == other.EmpresaId &&
    //               SucursalId == other.SucursalId &&
    //               Productoid == other.Productoid &&
    //               Descripcion1 == other.Descripcion1 &&
    //               Descripcion3 == other.Descripcion3 &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
    //               Loteimportado == other.Loteimportado;
    //    }

    //    public override int GetHashCode()
    //    {
    //        HashCode hash = new HashCode();
    //        hash.Add(DoctoRefId);
    //        hash.Add(Movtorefid);
    //        hash.Add(Partidaref);
    //        hash.Add(Cantidadref);
    //        hash.Add(Descripcion);
    //        hash.Add(Preciounidadref);
    //        hash.Add(Importeref);
    //        hash.Add(Descuentoref);
    //        hash.Add(Descripcion2);
    //        hash.Add(Lote);
    //        hash.Add(Claveproducto);
    //        hash.Add(Subtotalref);
    //        hash.Add(Ivaref);
    //        hash.Add(Cantidad);
    //        hash.Add(Movtoid);
    //        hash.Add(Preciounidad);
    //        hash.Add(Subtotal);
    //        hash.Add(Importe);
    //        hash.Add(Partida);
    //        hash.Add(Cantidaddevuelta);
    //        hash.Add(Cantdisp);
    //        hash.Add(Cantdispdespues);
    //        hash.Add(Tasaiva);
    //        hash.Add(Tasaieps);
    //        hash.Add(EmpresaId);
    //        hash.Add(SucursalId);
    //        hash.Add(Productoid);
    //        hash.Add(Descripcion1);
    //        hash.Add(Descripcion3);
    //        hash.Add(Fechavence);
    //        hash.Add(Loteimportado);
    //        return hash.ToHashCode();
    //    }
    //}


    //public class V_pagomultiple_compra : TransitionClass
    //{
    //    public V_pagomultiple_compra()
    //    {

    //    }

    //    public string? Tipotarjetaclave { get; set; }

    //    public string? Tipotarjetanombre { get; set; }

    //    public string? Bancotarjetaclave { get; set; }

    //    public string? Bancotarjetanombre { get; set; }

    //    public string? Referenciatarjeta { get; set; }

    //    public string? Bancochequeclave { get; set; }

    //    public string? Bancochequenombre { get; set; }

    //    public string? Referenciacheque { get; set; }

    //    public string? Bancotransferenciaclave { get; set; }

    //    public string? Bancotransferencianombre { get; set; }

    //    public string? Referenciatransferencia { get; set; }

    //    public string? Observaciones { get; set; }

    //    public long? P_empresaid { get; set; }

    //    public long? P_sucursalid { get; set; }

    //    public long? P_id { get; set; }

    //    public decimal? Total { get; set; }

    //    public decimal? Montoefectivo { get; set; }

    //    public long? Tipotarjeta { get; set; }

    //    public decimal? Montotarjeta { get; set; }

    //    public long? Bancotarjetaid { get; set; }

    //    public decimal? Montocheque { get; set; }

    //    public long? Bancochequeid { get; set; }

    //    public decimal? Montotransferencia { get; set; }

    //    public long? Bancotransferenciaid { get; set; }
    //}

    //public class V_pagomultiple_venta: TransitionClass
    //{
    //    public V_pagomultiple_venta()
    //    {

    //    }

    //    public string? Tipotarjetaclave { get; set; }

    //    public string? Tipotarjetanombre { get; set; }

    //    public string? Bancotarjetaclave { get; set; }

    //    public string? Bancotarjetanombre { get; set; }

    //    public string? Referenciatarjeta { get; set; }

    //    public string? Bancochequeclave { get; set; }

    //    public string? Bancochequenombre { get; set; }

    //    public string? Referenciacheque { get; set; }

    //    public string? Numeromonedero { get; set; }

    //    public string? Bancotransferenciaclave { get; set; }

    //    public string? Bancotransferencianombre { get; set; }

    //    public string? Referenciatransferencia { get; set; }

    //    public string? Observaciones { get; set; }

    //    public string? Generarfacturaelectronica { get; set; }

    //    public string? Usocfdiclave { get; set; }

    //    public string? Usocfdinombre { get; set; }

    //    public string? Surtidohastaalmacen { get; set; }

    //    public string? Marcarpararevision { get; set; }

    //    public long? P_id { get; set; }

    //    public decimal? Total { get; set; }

    //    public decimal? Montoefectivo { get; set; }

    //    public long? Tipotarjeta { get; set; }

    //    public decimal? Montotarjeta { get; set; }

    //    public long? Bancotarjetaid { get; set; }

    //    public decimal? Montocheque { get; set; }

    //    public long? Bancochequeid { get; set; }

    //    public decimal? Montovale { get; set; }

    //    public decimal? Montocambio { get; set; }

    //    public decimal? Montomonedero { get; set; }

    //    public decimal? Montotransferencia { get; set; }

    //    public long? Bancotransferenciaid { get; set; }

    //    public decimal? Montocreditoautomatico { get; set; }

    //    public decimal? Montocomprarelacionada { get; set; }

    //    public decimal? Montootros { get; set; }

    //    public long? Usocfdiid { get; set; }
    //}



    //public class V_pagomultiple_compradevo : TransitionClass
    //{
    //    public V_pagomultiple_compradevo()
    //    {

    //    }

    //    public string? Observaciones { get; set; }

    //    public string? Aplicarcreditoautomatico { get; set; }

    //    public string? Generarfacturaelectronica { get; set; }

    //    public long? P_id { get; set; }

    //    public decimal? Total { get; set; }

    //    public decimal? Montoefectivo { get; set; }

    //    public decimal? Montocreditoautomatico { get; set; }

    //}




    //public class V_pagomultiple_ventadevo : TransitionClass
    //{

    //    public V_pagomultiple_ventadevo()
    //    {

    //    }


    //    public string? Observaciones { get; set; }

    //    public string? Aplicarcreditoautomatico { get; set; }

    //    public string? Generarfacturaelectronica { get; set; }

    //    public long? P_id { get; set; }

    //    public decimal? Total { get; set; }

    //    public decimal? Montoefectivo { get; set; }

    //    public decimal? Montocreditoautomatico { get; set; }
    //}

    //public class LoteDefinicion:TransitionClass
    //{
    //    public LoteDefinicion()
    //    {

    //    }



    //    public long? P_id { get; set; }

    //    public long? P_empresaid { get; set; }

    //    public long? P_sucursalid { get; set; }

    //    public long? Productoid { get; set; }

    //    public string? Productoclave { get; set; }

    //    public string? Productonombre { get; set; }

    //    public string? Lote { get; set; }

    //    public DateTimeOffset? Fechavence { get; set; }

    //}


    //public class LoteImportadoDefinicion: TransitionClass
    //{
    //    public LoteImportadoDefinicion()
    //    {

    //    }



    //    public long? P_id { get; set; }

    //    public long? P_empresaid { get; set; }

    //    public long? P_sucursalid { get; set; }

    //    public long? Productoid { get; set; }

    //    public string? Productoclave { get; set; }

    //    public string? Productonombre { get; set; }

    //    public string? Pedimento { get; set; }

    //    public long? Sataduanaid { get; set; }

    //    public string? Sataduanaclave { get; set; }

    //    public string? Sataduananombre { get; set; }


    //    public decimal? Tipocambio { get; set; }

    //    public DateTimeOffset? Fechavence { get; set; }
    




    //}



    //public class Motivo_devolucionDefinicion : TransitionClass
    //{
    //    public Motivo_devolucionDefinicion()
    //    {

    //    }



    //    public long? Id { get; set; }

    //    public long? EmpresaId { get; set; }

    //    public long? SucursalId { get; set; }

    //    public long? Motivo_devolucionid { get; set; }

    //    public string? Motivo_devolucionClave { get; set; }

    //    public string? Motivo_devolucionNombre { get; set; }

    //    public string? Otromotivodevolucion { get; set; }


    //}



    //public class V_movto_lote_seleccion : TransitionClass
    //{
    //    public V_movto_lote_seleccion()
    //    {

    //    }


    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long? Productoid { get; }
    //    public string? Productoclave { get; }
    //    public string? Productonombre { get; }
    //    public string? Lote { get; }
    //    public DateTimeOffset? Fechavence { get; }
    //    public long? Almacenid { get; }
    //    public string? Almacenclave { get; }
    //    public string? Almacennombre { get; }
    //    public decimal Cantidad { get; }
    //    public bool Caducado { get; }
    //    public bool Porcaducar { get; }
    //    public decimal Cantidadendocto { get; }
    //}

    //public class V_param_movto_lote_seleccion : TransitionClass
    //{
    //    public V_param_movto_lote_seleccion()
    //    {

    //    }


    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long? Productoid { get; }
    //    public string? Productoclave { get; }
    //    public string? Productonombre { get; }

    //    public long? Almacenid { get; }
    //    public string? Almacenclave { get; }
    //    public string? Almacennombre { get; }

    //    public string? Busqueda { get; }
    //}


    //public class V_pagos_compuestos_list_seleccion : TransitionClass
    //{
    //    public V_pagos_compuestos_list_seleccion()
    //    {

    //    }


    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long? Formapagoid { get; }
    //    public string? Formapagoclave { get; }
    //    public string? Formapagonombre { get; }

    //    public long? Clienteid { get; }
    //    public string? Clienteclave { get; }
    //    public string? Clientenombre { get; }


    //    public long? Proveedorid { get; }
    //    public string? Proveedorclave { get; }
    //    public string? Proveedornombre { get; }

    //    public DateTimeOffset Fechainicial { get; }
    //    public DateTimeOffset Fechafinal { get; }

    //    public bool Solofiscales { get; } = false;

    //    public bool Incluircancelaciones { get; } = false;

    //    public string? Aplicados { get; }

    //    public string? Timbrados { get; }

    //    public string? Busqueda { get; }
    //}



    //public class V_pago_compuesto : TransitionClass
    //{
    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long Id { get; }
    //    public DateTimeOffset? Fecha { get; }
    //    public DateTimeOffset? Fechahora { get; }
    //    public decimal Importe { get; }
    //    public string? Formapagoclave { get; }
    //    public string? Formapagonombre { get; }
    //    public string? Formapagosatclave { get; }
    //    public string? Formapagosatnombre { get; }
    //    public string? Bancoclave { get; }
    //    public string? Banconombre { get; }
    //    public string? Referenciabancaria { get; }
    //    public string? Tipopagoclave { get; }
    //    public string? Tipopagonombre { get; }
    //    public string? Timbrado { get; }
    //    public BoolCN? Aplicado { get; }
    //    public string? ClienteClave { get; }
    //    public string? ClienteNombre { get; }
    //    public string? ProveedorClave { get; }
    //    public string? ProveedorNombre { get; }

    //}


    //public class V_docto_con_saldo : TransitionClass
    //{
    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long Id { get; }
    //    public long? Sucursal_info_id { get; }
    //    public string? Sucursal_info_clave { get; }
    //    public string? Sucursal_info_nombre { get; }
    //    public long? Cajaid { get; }
    //    public string? Cajaclave { get; }
    //    public string? Cajanombre { get; }
    //    public DateTimeOffset? Fecha { get; }
    //    public string? Serie { get; }
    //    public decimal Total { get; }
    //    public long? Estatusdoctoid { get; }
    //    public string? Estatusdoctoclave { get; }
    //    public string? Estatusdoctonombre { get; }
    //    public long? Tipodoctoid { get; }
    //    public string? Tipodoctoclave { get; }
    //    public string? Tipodoctonombre { get; }
    //    public string? Referencia { get; }
    //    public long? SucursalDestinoid { get; }
    //    public string? SucursalDestinoclave { get; }
    //    public string? SucursalDestinonombre { get; }
    //    public int? Folio { get; }
    //    public string? ClienteClave { get; }
    //    public string? ClienteNombre { get; }
    //    public string? ProveedorClave { get; }
    //    public string? ProveedorNombre { get; }
    //    public string? UsuarioClave { get; }
    //    public string? UsuarioNombre { get; }
    //    public decimal Saldo { get; }
    //    public decimal MontoAplicar { get; }
    //    public BoolCN EsFacturaEletronica { get; }
    //    public string? EstaTimbrado { get; }
    //    public string? SerieFolioSat { get; }


    //}

    //public class V_doctopago_aplicado:TransitionClass
    //{
    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public long Id { get; }
    //    public decimal Importe { get; }
    //    public int? Docto_Folio { get; }
    //    public string? Docto_SerieFolioSat { get; }
    //    public BoolCN Esfacturaelectronica { get; }
    //    public string? Estatimbrado { get; }

    //}




    //public class V_inventario_docto: TransitionClass
    //{
    //    public long Empresaid { get; }
    //    public long Sucursalid { get; }
    //    public string? Sucursalclave { get; }
    //    public string? Sucursalnombre { get; }
    //    public long? Cajaid { get; }
    //    public string? Cajaclave { get; }
    //    public string? Cajanombre { get; }
    //    public DateTimeOffset? Fecha { get; }
    //    public string? Serie { get; }
    //    public long Consecutivo { get; }
    //    public decimal Total { get; }
    //    public long? Estatusdoctoid { get; }
    //    public string? Estatusdoctoclave { get; }
    //    public string? Estatusdoctonombre { get; }
    //    public long? Tipodoctoid { get; }
    //    public string? Tipodoctoclave { get; }
    //    public string? Tipodoctonombre { get; }
    //    public string? Referencia { get; }
    //    public int? Folio { get; }
    //    public long? Usuarioid { get; }
    //    public string? Usuarioclave { get; }
    //    public string? Usuarionombre { get; }

    //    public V_inventario_docto()
    //    { }
        

    //    public V_inventario_docto(long empresaid, long sucursalid, string sucursalclave, string sucursalnombre, long? cajaid, string cajaclave, string cajanombre, DateTimeOffset? fecha, string? serie, long consecutivo, decimal total, long? estatusdoctoid, string estatusdoctoclave, string estatusdoctonombre, long? tipodoctoid, string tipodoctoclave, string tipodoctonombre, string? referencia, int? folio, long? usuarioid, string? usuarioclave, string usuarionombre)
    //    {
    //        Empresaid = empresaid;
    //        Sucursalid = sucursalid;
    //        Sucursalclave = sucursalclave;
    //        Sucursalnombre = sucursalnombre;
    //        Cajaid = cajaid;
    //        Cajaclave = cajaclave;
    //        Cajanombre = cajanombre;
    //        Fecha = fecha;
    //        Serie = serie;
    //        Consecutivo = consecutivo;
    //        Total = total;
    //        Estatusdoctoid = estatusdoctoid;
    //        Estatusdoctoclave = estatusdoctoclave;
    //        Estatusdoctonombre = estatusdoctonombre;
    //        Tipodoctoid = tipodoctoid;
    //        Tipodoctoclave = tipodoctoclave;
    //        Tipodoctonombre = tipodoctonombre;
    //        Referencia = referencia;
    //        Folio = folio;
    //        Usuarioid = usuarioid;
    //        Usuarioclave = usuarioclave;
    //        Usuarionombre = usuarionombre;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        return obj is V_inventario_docto other &&
    //               Empresaid == other.Empresaid &&
    //               Sucursalid == other.Sucursalid &&
    //               Sucursalclave == other.Sucursalclave &&
    //               Sucursalnombre == other.Sucursalnombre &&
    //               Cajaid == other.Cajaid &&
    //               Cajaclave == other.Cajaclave &&
    //               Cajanombre == other.Cajanombre &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
    //               Serie == other.Serie &&
    //               Consecutivo == other.Consecutivo &&
    //               Total == other.Total &&
    //               Estatusdoctoid == other.Estatusdoctoid &&
    //               Estatusdoctoclave == other.Estatusdoctoclave &&
    //               Estatusdoctonombre == other.Estatusdoctonombre &&
    //               Tipodoctoid == other.Tipodoctoid &&
    //               Tipodoctoclave == other.Tipodoctoclave &&
    //               Tipodoctonombre == other.Tipodoctonombre &&
    //               Referencia == other.Referencia &&
    //               Folio == other.Folio &&
    //               Usuarioid == other.Usuarioid &&
    //               Usuarioclave == other.Usuarioclave &&
    //               Usuarionombre == other.Usuarionombre;
    //    }

    //    public override int GetHashCode()
    //    {
    //        HashCode hash = new HashCode();
    //        hash.Add(Empresaid);
    //        hash.Add(Sucursalid);
    //        hash.Add(Sucursalclave);
    //        hash.Add(Sucursalnombre);
    //        hash.Add(Cajaid);
    //        hash.Add(Cajaclave);
    //        hash.Add(Cajanombre);
    //        hash.Add(Fecha);
    //        hash.Add(Serie);
    //        hash.Add(Consecutivo);
    //        hash.Add(Total);
    //        hash.Add(Estatusdoctoid);
    //        hash.Add(Estatusdoctoclave);
    //        hash.Add(Estatusdoctonombre);
    //        hash.Add(Tipodoctoid);
    //        hash.Add(Tipodoctoclave);
    //        hash.Add(Tipodoctonombre);
    //        hash.Add(Referencia);
    //        hash.Add(Folio);
    //        hash.Add(Usuarioid);
    //        hash.Add(Usuarioclave);
    //        hash.Add(Usuarionombre);
    //        return hash.ToHashCode();
    //    }
    //}



    //public class V_inventario_movto_detalle: TransitionClass
    //{
    //    public long EmpresaId { get; }
    //    public long SucursalId { get; }
    //    public string? Sucursalclave { get; }
    //    public string? Sucursalnombre { get; }
    //    public long ProductoId { get; }
    //    public string? Productoclave { get; }
    //    public string? Productonombre { get; }
    //    public string? Productodescripcion { get; }
    //    public string? Productotexto1 { get; }
    //    public string? Productotexto2 { get; }
    //    public string? Productotexto3 { get; }
    //    public string? Productotexto4 { get; }
    //    public string? Productotexto5 { get; }
    //    public string? Productotexto6 { get; }
    //    public decimal? Productonumero1 { get; }
    //    public decimal? Productonumero2 { get; }
    //    public decimal? Productonumero3 { get; }
    //    public decimal? Productonumero4 { get; }
    //    public DateTimeOffset? Fecha1 { get; }
    //    public DateTimeOffset? Fecha2 { get; }
    //    public decimal Pzacaja { get; }
    //    public long? Almacenid { get; }
    //    public string? Almacenclave { get; }
    //    public string? Almacennombre { get; }
    //    public string? Lote { get; }
    //    public DateTimeOffset? Fechavence { get; }
    //    public long? Loteimportado { get; }
    //    public decimal CantidadTeorica { get; }
    //    public decimal CantidadSurtida { get; }
    //    public long Movtoid { get; }
    //    public decimal Cajas { get; }
    //    public decimal Piezas { get; }
    //    public decimal CajasTeorica { get; }
    //    public decimal PiezasTeorica { get; }


    //    public V_inventario_movto_detalle()
    //    {

    //    }
    //    public V_inventario_movto_detalle(long empresaId, long sucursalId, string sucursalclave, string sucursalnombre, long productoId, string productoclave, string productonombre, string productodescripcion, string productotexto1, string productotexto2, string productotexto3, string productotexto4, string productotexto5, string productotexto6, decimal? productonumero1, decimal? productonumero2, decimal? productonumero3, decimal? productonumero4, DateTimeOffset? fecha1, DateTimeOffset? fecha2, decimal pzacaja, long? almacenid, string almacenclave, string almacennombre, string lote, DateTimeOffset? fechavence, long? loteimportado, decimal cantidadTeorica, decimal cantidadSurtida, long movtoid, decimal cajas, decimal piezas, decimal cajasTeorica, decimal piezasTeorica)
    //    {
    //        EmpresaId = empresaId;
    //        SucursalId = sucursalId;
    //        Sucursalclave = sucursalclave;
    //        Sucursalnombre = sucursalnombre;
    //        ProductoId = productoId;
    //        Productoclave = productoclave;
    //        Productonombre = productonombre;
    //        Productodescripcion = productodescripcion;
    //        Productotexto1 = productotexto1;
    //        Productotexto2 = productotexto2;
    //        Productotexto3 = productotexto3;
    //        Productotexto4 = productotexto4;
    //        Productotexto5 = productotexto5;
    //        Productotexto6 = productotexto6;
    //        Productonumero1 = productonumero1;
    //        Productonumero2 = productonumero2;
    //        Productonumero3 = productonumero3;
    //        Productonumero4 = productonumero4;
    //        Fecha1 = fecha1;
    //        Fecha2 = fecha2;
    //        Pzacaja = pzacaja;
    //        Almacenid = almacenid;
    //        Almacenclave = almacenclave;
    //        Almacennombre = almacennombre;
    //        Lote = lote;
    //        Fechavence = fechavence;
    //        Loteimportado = loteimportado;
    //        CantidadTeorica = cantidadTeorica;
    //        CantidadSurtida = cantidadSurtida;
    //        Movtoid = movtoid;
    //        Cajas = cajas;
    //        Piezas = piezas;
    //        CajasTeorica = cajasTeorica;
    //        PiezasTeorica = piezasTeorica;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        return obj is V_inventario_movto_detalle other &&
    //               EmpresaId == other.EmpresaId &&
    //               SucursalId == other.SucursalId &&
    //               Sucursalclave == other.Sucursalclave &&
    //               Sucursalnombre == other.Sucursalnombre &&
    //               ProductoId == other.ProductoId &&
    //               Productoclave == other.Productoclave &&
    //               Productonombre == other.Productonombre &&
    //               Productodescripcion == other.Productodescripcion &&
    //               Productotexto1 == other.Productotexto1 &&
    //               Productotexto2 == other.Productotexto2 &&
    //               Productotexto3 == other.Productotexto3 &&
    //               Productotexto4 == other.Productotexto4 &&
    //               Productotexto5 == other.Productotexto5 &&
    //               Productotexto6 == other.Productotexto6 &&
    //               Productonumero1 == other.Productonumero1 &&
    //               Productonumero2 == other.Productonumero2 &&
    //               Productonumero3 == other.Productonumero3 &&
    //               Productonumero4 == other.Productonumero4 &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha1, other.Fecha1) &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha2, other.Fecha2) &&
    //               Pzacaja == other.Pzacaja &&
    //               Almacenid == other.Almacenid &&
    //               Almacenclave == other.Almacenclave &&
    //               Almacennombre == other.Almacennombre &&
    //               Lote == other.Lote &&
    //               EqualityComparer<DateTimeOffset?>.Default.Equals(Fechavence, other.Fechavence) &&
    //               Loteimportado == other.Loteimportado &&
    //               CantidadTeorica == other.CantidadTeorica &&
    //               CantidadSurtida == other.CantidadSurtida &&
    //               Movtoid == other.Movtoid &&
    //               Cajas == other.Cajas &&
    //               Piezas == other.Piezas &&
    //               CajasTeorica == other.CajasTeorica &&
    //               PiezasTeorica == other.PiezasTeorica;
    //    }

    //    public override int GetHashCode()
    //    {
    //        HashCode hash = new HashCode();
    //        hash.Add(EmpresaId);
    //        hash.Add(SucursalId);
    //        hash.Add(Sucursalclave);
    //        hash.Add(Sucursalnombre);
    //        hash.Add(ProductoId);
    //        hash.Add(Productoclave);
    //        hash.Add(Productonombre);
    //        hash.Add(Productodescripcion);
    //        hash.Add(Productotexto1);
    //        hash.Add(Productotexto2);
    //        hash.Add(Productotexto3);
    //        hash.Add(Productotexto4);
    //        hash.Add(Productotexto5);
    //        hash.Add(Productotexto6);
    //        hash.Add(Productonumero1);
    //        hash.Add(Productonumero2);
    //        hash.Add(Productonumero3);
    //        hash.Add(Productonumero4);
    //        hash.Add(Fecha1);
    //        hash.Add(Fecha2);
    //        hash.Add(Pzacaja);
    //        hash.Add(Almacenid);
    //        hash.Add(Almacenclave);
    //        hash.Add(Almacennombre);
    //        hash.Add(Lote);
    //        hash.Add(Fechavence);
    //        hash.Add(Loteimportado);
    //        hash.Add(CantidadTeorica);
    //        hash.Add(CantidadSurtida);
    //        hash.Add(Movtoid);
    //        hash.Add(Cajas);
    //        hash.Add(Piezas);
    //        hash.Add(CajasTeorica);
    //        hash.Add(PiezasTeorica);
    //        return hash.ToHashCode();
    //    }
    //}


    //public class V_inventario_movto_insert: TransitionClass
    //{




    //    public long? EmpresaId { get; set; }

    //    public long? SucursalId { get; set; }

    //    public long? Id { get; set; }

    //    public long? Doctoid { get; set; }

    //    public long? Estatusmovtoid { get; set; }

    //    public string? Lote { get; set; }

    //    public string? Localidad { get; set; }

    //    public long? Productoid { get; set; }

    //    public string? Productoclave { get; set; }

    //    public string? Productonombre { get; set; }

    //    public long? Almacenid { get; set; }

    //    public string? Almacenclave { get; set; }

    //    public string? Almacennombre { get; set; }

    //    public long? Anaquelid { get; set; }

    //    public string? Anaquelclave { get; set; }

    //    public string? Anaquelnombre { get; set; }

    //    public decimal? Cantidad { get; set; }

    //    public DateTime? Fechavence { get; set; }

    //    public long? Usuarioid { get; set; }


    //    public long? Productolocationsid { get; set; }


    //    public string? DescripcionProductoMovto { get; set; }


    //    public string? DescripcionCantidades { get; set; }



    //    public string? LoteFechavenceConcatenado { get; set; }
    //}

    //public class V_inventario_movto_getInfoParam: TransitionClass
    //{
    //    public long? EmpresaId { get; set; }

    //    public long? SucursalId { get; set; }

    //    public long? Productoid { get; set; }

    //    public string? Lote { get; set; }

    //    public DateTime? Fechavence { get; set; }

    //    public long? Doctoid { get; set; }

    //    public long? Almacenid { get; set; }

    //    public bool Kitdesglosado { get; set; }

    //    public bool Mododetalle { get; set; }

    //    public V_inventario_movto_getInfoParam()
    //    { }
    //}

    //public class V_inventario_movto_getInfo : TransitionClass
    //{
        
    //   public string? Productonombre{ get; set; }
    //    public string? Productodescripcion { get; set; }
    //    public string? Productolote { get; set; }
    //    public string? Cantidadteorica { get; set; }
    //    public string? Cantidadfisica { get; set; }
    //    public string? Cantidaddiferencia { get; set; }
    //    public string? Apartados { get; set; }
    //    public string? Pzacaja { get; set; }

    //    public V_inventario_movto_getInfo()
    //    { }

    //}




    //public class V_inventario_genCompletoParam : TransitionClass
    //{




    //    public long? EmpresaId { get; set; }

    //    public long? SucursalId { get; set; }

    //    public long? Doctoid { get; set; }

    //    public long? Almacenid { get; set; }

    //    public string? Almacenclave { get; set; }

    //    public string? Almacennombre { get; set; }

    //    public long? Usuarioid { get; set; }


    //    public long? Subtipodoctoid { get; set; }

    //    public string? Subtipodoctoclave { get; set; }

    //    public string? Subtipodoctonombre { get; set; }


    //}


    //public class V_inventario_aplicarParam : TransitionClass
    //{




    //    public long? EmpresaId { get; set; }

    //    public long? SucursalId { get; set; }

    //    public long? Doctoid { get; set; }

    //    public long? Usuarioid { get; set; }


    //}


    //public class Docto_traslado_rec_lstParam : TransitionClass
    //{


    //    public Docto_traslado_rec_lstParam()
    //    { }


    //    public long? EmpresaId { get; set; }

    //    public long? SucursalId { get; set; }

    //    public long? TipoDoctoId { get; set; }
    //    public long? EstatusDoctoId { get; set; }

    //    public long? Usuarioid { get; set; }

    //    public DateTimeOffset? FechaIni { get; set; }

    //    public DateTimeOffset? FechaFin { get; set; }


    //}


    //public class Movto_traslado_rec_lstParam : TransitionClass
    //{


    //    public Movto_traslado_rec_lstParam()
    //    { }


    //    public long? EmpresaId { get; set; }

    //    public long? SucursalId { get; set; }

    //    public long? DoctoId { get; set; }


    //}

    //public class Recibir_traslado_Param : TransitionClass
    //{


    //    public Recibir_traslado_Param()
    //    { }

    //    public long EmpresaId { get; set; }
    //    public long SucursalId { get; set; }
    //    public long DoctoARecibirId { get; set; }
    //    public long UsuarioId { get; set; }
    //    public long? AlmacenId { get; set; }
    //    public string? AlmacenClave { get; set; }
    //    public string? AlmacenNombre { get; set; }
    //    public string? Referencias { get; set; }
    //}



    //public class Docto_solicitud_merc_lstParam : TransitionClass
    //{


    //    public Docto_solicitud_merc_lstParam()
    //    { }


    //    public long? EmpresaId { get; set; }

    //    public long? SucursalId { get; set; }

    //    public long? TipoDoctoId { get; set; }
    //    public long? SubTipoDoctoId { get; set; }

    //    public long? Usuarioid { get; set; }

    //    public DateTimeOffset? FechaIni { get; set; }

    //    public DateTimeOffset? FechaFin { get; set; }

    //    public BoolCS SoloPendientes { get; set; } = BoolCS.S;


    //}


    //public class Movto_solicitud_merc_lstParam : TransitionClass
    //{


    //    public Movto_solicitud_merc_lstParam()
    //    { }


    //    public long? EmpresaId { get; set; }

    //    public long? SucursalId { get; set; }

    //    public long? DoctoId { get; set; }


    //}



    //public class Docto_ped_entr_lstParam : TransitionClass
    //{


    //    public Docto_ped_entr_lstParam()
    //    { }


    //    public long? EmpresaId { get; set; }

    //    public long? SucursalId { get; set; }

    //    public long? TipoDoctoId { get; set; }
    //    public long? SubTipoDoctoId { get; set; }

    //    public long? Usuarioid { get; set; }

    //    public DateTimeOffset? FechaIni { get; set; }

    //    public DateTimeOffset? FechaFin { get; set; }

    //    public BoolCS SoloPendientes { get; set; } = BoolCS.S;


    //}


    //public class Movto_ped_entr_lstParam : TransitionClass
    //{


    //    public Movto_ped_entr_lstParam()
    //    { }


    //    public long? EmpresaId { get; set; }

    //    public long? SucursalId { get; set; }

    //    public long? DoctoId { get; set; }


    //}



}
