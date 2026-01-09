using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services
{

    public class Tmp_config_porconsolidar : TransitionClass
    {

        public long? EmpresaId { get; set; }
        public long? SucursalId { get; set; }

        public DateTimeOffset? FechaIni { get; set; }
        public DateTimeOffset? FechaFin { get; set; }

        public BoolCN? OmitirVentasFranquicias { get; set; }
        public BoolCN? IncluirGastos { get; set; }
        public decimal? MaximoMonto { get; set; }
        public BoolCN? OmitirVales { get; set; }
        public BoolCN? SumaCompletaVentas { get; set; }
        public long? GrupoUsuarioId { get; set; }
        public BoolCN? OmitirClientesRfc { get; set; }
        public decimal? MaximoPorcentaje { get; set; }
        public BoolCN? OmitirPagoTarjeta { get; set; }
        public long? UsuarioId { get; set; }


        public BoolCN? AplicaMontoMaximoPorDia { get; set; }

        public decimal? MontoMaximoPorDia { get; set; }


        public Tmp_config_porconsolidar()
        {

        }


    }


    public class Tmp_docto_porconsolidar : TransitionClass
    {
        public long EmpresaId { get; set; }
        public long SucursalId { get; set; }
        public long Id { get; set; }
        public DateTimeOffset? Fecha { get; set; }
        public string? Serie { get; set; }
        public int? Folio { get; set; }
        public decimal Importe { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Ieps { get; set; }



        public decimal Total { get; set; }
        public long? Tipodoctoid { get; set; }


        public decimal Ivaretenido { get; set; }
        public decimal Isrretenido { get; set; }
        public decimal Saldo { get; set; }
        public decimal Abonoconvale { get; set; }
        public decimal Abonocontarjeta { get; set; }
        public decimal Montodevoluciones { get; set; }

        public long? Tipoaplicacionid { get; set; }
        public long? Doctopagoid { get; set; }

        public BoolCS Aplicado { get; set; }

        public long? Doctorefid { get; set; }

        public BoolCN Montosajustados { get; set; }



        public Tmp_docto_porconsolidar() :
            this(0, 0, 0,
            null, null, null,
            0, 0, 0, 0, 0, 0,
            null, 0, 0, 0, 0, 0,
            0, null, null, BoolCS.S, null, BoolCN.N
           )
        {
        }

        public Tmp_docto_porconsolidar(long empresaId, long sucursalId, long id,
        DateTimeOffset? fecha, string? serie, int? folio,
        decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total,
        long? tipodoctoid, decimal ivaretenido, decimal isrretenido, decimal saldo, decimal abonoconvale, decimal abonocontarjeta,
        decimal montodevoluciones, long? tipoaplicacionid, long? doctopagoid, BoolCS aplicado, long? doctorefid, BoolCN montosAjustados
        )
        {
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Id = id;
            Fecha = fecha;
            Serie = serie;
            Folio = folio;
            Importe = importe;
            Descuento = descuento;
            Subtotal = subtotal;
            Iva = iva;
            Ieps = ieps;
            Total = total;
            Tipodoctoid = tipodoctoid;
            Ivaretenido = ivaretenido;
            Isrretenido = isrretenido;
            Saldo = saldo;
            Abonoconvale = abonoconvale;
            Abonocontarjeta = abonocontarjeta;
            Montodevoluciones = montodevoluciones;
            Tipoaplicacionid = tipoaplicacionid;
            Doctopagoid = doctopagoid;
            Aplicado = aplicado;
            Doctorefid = doctorefid;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_docto_porconsolidar other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Id == other.Id &&
                   EqualityComparer<DateTimeOffset?>.Default.Equals(Fecha, other.Fecha) &&
                   Serie == other.Serie &&
                   Folio == other.Folio &&
                   Importe == other.Importe &&
                   Descuento == other.Descuento &&
                   Subtotal == other.Subtotal &&
                   Iva == other.Iva &&
                   Ieps == other.Ieps &&
                   Total == other.Total &&
                   Tipodoctoid == other.Tipodoctoid;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Id);
            hash.Add(Fecha);
            hash.Add(Serie);
            hash.Add(Folio);
            hash.Add(Importe);
            hash.Add(Descuento);
            hash.Add(Subtotal);
            hash.Add(Iva);
            hash.Add(Ieps);
            hash.Add(Total);
            hash.Add(Tipodoctoid);
            return hash.ToHashCode();
        }
    }

    public class Tmp_suma_docto_porconsolidar : TransitionClass
    {
        public long EmpresaId { get; set; }
        public long SucursalId { get; set; }

        public int Cuenta { get; set; }
        public decimal Importe { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Ieps { get; set; }

        public decimal Total { get; set; }
        public decimal Ivaretenido { get; set; }
        public decimal Isrretenido { get; set; }
        public decimal Saldo { get; set; }


        public Tmp_suma_docto_porconsolidar()
        {
            Cuenta = 0;
            EmpresaId = 0;
            SucursalId = 0;
            Importe = 0;
            Descuento = 0;
            Subtotal = 0;
            Iva = 0;
            Ieps = 0;
            Total = 0;
            Ivaretenido = 0;
            Isrretenido = 0;
            Saldo = 0;
        }

        public Tmp_suma_docto_porconsolidar(long empresaId, long sucursalId, int cuenta,
        decimal importe, decimal descuento, decimal subtotal, decimal iva, decimal ieps, decimal total,
        decimal ivaretenido, decimal isrretenido, decimal saldo
        )
        {
            Cuenta = cuenta;
            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Importe = importe;
            Descuento = descuento;
            Subtotal = subtotal;
            Iva = iva;
            Ieps = ieps;
            Total = total;
            Ivaretenido = ivaretenido;
            Isrretenido = isrretenido;
            Saldo = saldo;
        }


        public Tmp_suma_docto_porconsolidar(long empresaId, long sucursalId,
                                        List<Tmp_docto_porconsolidar>? lstDoctosPorConsolidar
            )
        {

            EmpresaId = empresaId;
            SucursalId = sucursalId;
            Cuenta = lstDoctosPorConsolidar == null ? 0 : lstDoctosPorConsolidar.Count();

            var sumas = lstDoctosPorConsolidar?.GroupBy(x => x.EmpresaId)
                    .Select(x =>
                                new
                                {
                                    Importe = x.Sum(s => s.Importe),
                                    Descuento = x.Sum(s => s.Descuento),
                                    Subtotal = x.Sum(s => s.Subtotal),
                                    Iva = x.Sum(s => s.Iva),
                                    Ieps = x.Sum(s => s.Ieps),
                                    Total = x.Sum(s => s.Total),
                                    Ivaretenido = x.Sum(s => s.Ivaretenido),
                                    Isrretenido = x.Sum(s => s.Isrretenido),
                                    Saldo = x.Sum(s => s.Saldo)

                                }
                            ).FirstOrDefault();

            if (sumas != null)
            {

                Importe = sumas.Importe;
                Descuento = sumas.Descuento;
                Subtotal = sumas.Subtotal;
                Iva = sumas.Iva;
                Ieps = sumas.Ieps;
                Total = sumas.Total;
                Ivaretenido = sumas.Ivaretenido;
                Isrretenido = sumas.Isrretenido;
                Saldo = sumas.Saldo;
            }

        }

        public override bool Equals(object? obj)
        {
            return obj is Tmp_suma_docto_porconsolidar other &&
                   EmpresaId == other.EmpresaId &&
                   SucursalId == other.SucursalId &&
                   Importe == other.Importe &&
                   Descuento == other.Descuento &&
                   Subtotal == other.Subtotal &&
                   Iva == other.Iva &&
                   Ieps == other.Ieps &&
                   Total == other.Total;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(EmpresaId);
            hash.Add(SucursalId);
            hash.Add(Importe);
            hash.Add(Descuento);
            hash.Add(Subtotal);
            hash.Add(Iva);
            hash.Add(Ieps);
            hash.Add(Total);
            return hash.ToHashCode();
        }
    }


    public class Tmp_dia_monto_porconsolidar : TransitionClass
    {


        public DateTimeOffset? Fecha { get; set; }

        public BoolCN? Aplicamontomaximo { get; set; }
        public decimal? Monto { get; set; }

        public Tmp_dia_monto_porconsolidar()
        {

        }

        public Tmp_dia_monto_porconsolidar(BoolCN aplicaMontoMaximo, decimal montoMaximo, DateTime fecha,
                                        List<Tmp_docto_porconsolidar>? lstDoctosPorConsolidar)
        {
            Fecha = fecha;
            Aplicamontomaximo = BoolCN.N;
            Monto = 0m;

            var sumas = lstDoctosPorConsolidar?
                    .Where(l => l.Fecha!.Value.ToLocalTime().Date == fecha)
                    .GroupBy(x => x.EmpresaId)
                    .Select(x =>
                                new
                                {
                                    Total = aplicaMontoMaximo == BoolCN.S && montoMaximo < x.Sum(s => s.Total) ? montoMaximo : x.Sum(s => s.Total),
                                    Aplicamontomaximo = aplicaMontoMaximo == BoolCN.S && montoMaximo < x.Sum(s => s.Total) ? BoolCN.S : BoolCN.N

                                }
                            ).FirstOrDefault();

            if (sumas != null)
            {

                Aplicamontomaximo = sumas.Aplicamontomaximo;
                Monto = sumas.Total;
            }
        }
    }


}
