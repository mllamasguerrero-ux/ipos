using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Movil.businessEntity.MOVILANDROID
{
    public class CCREPDROIDBE
    {
        private string cobranza;
        private string vendedor;
        private string venta;
        private string empresa;
        private string cliente;
        private string nombre;
        private string factura;
        private string estatus;
        private string obs;
        private DateTime fechaFactura;
        private DateTime fechaPago;
        private decimal dias;
        private decimal total;
        private decimal aCuenta;
        private decimal saldo;
        private decimal intCob;
        private decimal intereses;
        private decimal importeNeto;
        private decimal pago;
        private decimal efectivo;
        private decimal diferencia;
        private decimal impCheque;
        private string banco;
        private decimal numCheq;
        private decimal interes;
        private decimal capital;
        private string olla;
        private string bloqueado;
        private DateTime fecha;
        private string llevar;
        private string id;
        private DateTime idFecha;
        private DateTime idHora;

        public string Cobranza { get => cobranza; set => cobranza = value; }
        public string Vendedor { get => vendedor; set => vendedor = value; }
        public string Venta { get => venta; set => venta = value; }
        public string Empresa { get => empresa; set => empresa = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Factura { get => factura; set => factura = value; }
        public string Estatus { get => estatus; set => estatus = value; }
        public string Obs { get => obs; set => obs = value; }
        public DateTime FechaFactura { get => fechaFactura; set => fechaFactura = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public decimal Dias { get => dias; set => dias = value; }
        public decimal Total { get => total; set => total = value; }
        public decimal ACuenta { get => aCuenta; set => aCuenta = value; }
        public decimal Saldo { get => saldo; set => saldo = value; }
        public decimal IntCob { get => intCob; set => intCob = value; }
        public decimal Intereses { get => intereses; set => intereses = value; }
        public decimal ImporteNeto { get => importeNeto; set => importeNeto = value; }
        public decimal Pago { get => pago; set => pago = value; }
        public decimal Efectivo { get => efectivo; set => efectivo = value; }
        public decimal Diferencia { get => diferencia; set => diferencia = value; }
        public decimal ImpCheque { get => impCheque; set => impCheque = value; }
        public string Banco { get => banco; set => banco = value; }
        public decimal NumCheq { get => numCheq; set => numCheq = value; }
        public decimal Interes { get => interes; set => interes = value; }
        public decimal Capital { get => capital; set => capital = value; }
        public string Olla { get => olla; set => olla = value; }
        public string Bloqueado { get => bloqueado; set => bloqueado = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Llevar { get => llevar; set => llevar = value; }
        public string Id { get => id; set => id = value; }
        public DateTime IdFecha { get => idFecha; set => idFecha = value; }
        public DateTime IdHora { get => idHora; set => idHora = value; }
    }
}
