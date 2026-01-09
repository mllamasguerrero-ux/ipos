
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;

namespace BindingModels
{
    [XmlRoot]
    public class ProveedorBindingModel: ProveedorBindingModelGenerated
    {


        public ProveedorBindingModel():base()
        {
        }
        

        #if PROYECTO_WEB
        
        public ProveedorBindingModel(Proveedor item):base(item)
        {
        }


        public void FillEntityValuesForUpdate(ref Proveedor item)
        {


            item.CreadoPorId = CreadoPorId;


            item.ModificadoPorId = ModificadoPorId;


            item.EmpresaId = EmpresaId ?? 0;


            item.SucursalId = SucursalId ?? 0;


            item.Id = Id ?? 0;


            item.Activo = Activo ?? BoolCS.S;


            item.Creado = Creado ?? DateTime.UtcNow;


            item.Modificado = Modificado ?? DateTime.UtcNow;


            item.Clave = Clave ?? "";


            item.Nombres = Nombres;


            item.Apellidos = Apellidos;


            item.Razonsocial = Razonsocial;


            item.Rfc = Rfc;


            item.Telefono1 = Telefono1;


            item.Telefono2 = Telefono2;


            item.Telefono3 = Telefono3;


            item.Celular = Celular;


            item.Nextel = Nextel;


            item.Email1 = Email1;


            item.Email2 = Email2;



            item.Vendedorid = Vendedorid;


            item.Listaprecioid = Listaprecioid;


            item.Saludoid = Saludoid;


            item.Contacto1id = Contacto1id;


            item.Contacto2id = Contacto2id;


            item.Domicilioid = Domicilioid;


            item.Proveeclienteid = Proveeclienteid;


            item.Nombre = Nombre ?? "";


            item.Esimportador = Esimportador ?? BoolCN.N;


            if (item.Contacto1 != null)
                item.Contacto1!.Nombre = Contacto1_Nombre;
            else if (item.Contacto1 == null && Contacto1_Nombre != null)
            {
                item.Contacto1 = CreateSubEntity<Contacto>();
                item.Contacto1!.Nombre = Contacto1_Nombre;
            }

            if (item.Contacto1 != null)
                item.Contacto1!.Email = Contacto1_Email;
            else if (item.Contacto1 == null && Contacto1_Email != null)
            {
                item.Contacto1 = CreateSubEntity<Contacto>();
                item.Contacto1!.Email = Contacto1_Email;
            }

            if (item.Contacto1 != null)
                item.Contacto1!.Telefono1 = Contacto1_Telefono1;
            else if (item.Contacto1 == null && Contacto1_Telefono1 != null)
            {
                item.Contacto1 = CreateSubEntity<Contacto>();
                item.Contacto1!.Telefono1 = Contacto1_Telefono1;
            }

            if (item.Contacto1 != null)
                item.Contacto1!.Domicilioid = Contacto1_Domicilioid;
            else if (item.Contacto1 == null && Contacto1_Domicilioid != null)
            {
                item.Contacto1 = CreateSubEntity<Contacto>();
                item.Contacto1!.Domicilioid = Contacto1_Domicilioid;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Calle = Contacto1_Domicilio_Calle;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Calle != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Calle = Contacto1_Domicilio_Calle;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Numeroexterior = Contacto1_Domicilio_Numeroexterior;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Numeroexterior != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Numeroexterior = Contacto1_Domicilio_Numeroexterior;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Numerointerior = Contacto1_Domicilio_Numerointerior;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Numerointerior != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Numerointerior = Contacto1_Domicilio_Numerointerior;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Colonia = Contacto1_Domicilio_Colonia;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Colonia != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Colonia = Contacto1_Domicilio_Colonia;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Ciudad = Contacto1_Domicilio_Ciudad;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Ciudad != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Ciudad = Contacto1_Domicilio_Ciudad;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Municipio = Contacto1_Domicilio_Municipio;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Municipio != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Municipio = Contacto1_Domicilio_Municipio;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Estado = Contacto1_Domicilio_Estado;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Estado != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Estado = Contacto1_Domicilio_Estado;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Pais = Contacto1_Domicilio_Pais;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Pais != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Pais = Contacto1_Domicilio_Pais;
            }

            if (item.Contacto1?.Domicilio != null)
                item.Contacto1!.Domicilio!.Codigopostal = Contacto1_Domicilio_Codigopostal;
            else if (item.Contacto1?.Domicilio == null && Contacto1_Domicilio_Codigopostal != null)
            {
                item.Contacto1!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto1!.Domicilio!.Codigopostal = Contacto1_Domicilio_Codigopostal;
            }

            if (item.Contacto2 != null)
                item.Contacto2!.Nombre = Contacto2_Nombre;
            else if (item.Contacto2 == null && Contacto2_Nombre != null)
            {
                item.Contacto2 = CreateSubEntity<Contacto>();
                item.Contacto2!.Nombre = Contacto2_Nombre;
            }

            if (item.Contacto2 != null)
                item.Contacto2!.Email = Contacto2_Email;
            else if (item.Contacto2 == null && Contacto2_Email != null)
            {
                item.Contacto2 = CreateSubEntity<Contacto>();
                item.Contacto2!.Email = Contacto2_Email;
            }

            if (item.Contacto2 != null)
                item.Contacto2!.Telefono1 = Contacto2_Telefono1;
            else if (item.Contacto2 == null && Contacto2_Telefono1 != null)
            {
                item.Contacto2 = CreateSubEntity<Contacto>();
                item.Contacto2!.Telefono1 = Contacto2_Telefono1;
            }

            if (item.Contacto2 != null)
                item.Contacto2!.Domicilioid = Contacto2_Domicilioid;
            else if (item.Contacto2 == null && Contacto2_Domicilioid != null)
            {
                item.Contacto2 = CreateSubEntity<Contacto>();
                item.Contacto2!.Domicilioid = Contacto2_Domicilioid;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Calle = Contacto2_Domicilio_Calle;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Calle != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Calle = Contacto2_Domicilio_Calle;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Numeroexterior = Contacto2_Domicilio_Numeroexterior;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Numeroexterior != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Numeroexterior = Contacto2_Domicilio_Numeroexterior;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Numerointerior = Contacto2_Domicilio_Numerointerior;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Numerointerior != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Numerointerior = Contacto2_Domicilio_Numerointerior;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Colonia = Contacto2_Domicilio_Colonia;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Colonia != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Colonia = Contacto2_Domicilio_Colonia;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Ciudad = Contacto2_Domicilio_Ciudad;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Ciudad != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Ciudad = Contacto2_Domicilio_Ciudad;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Municipio = Contacto2_Domicilio_Municipio;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Municipio != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Municipio = Contacto2_Domicilio_Municipio;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Estado = Contacto2_Domicilio_Estado;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Estado != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Estado = Contacto2_Domicilio_Estado;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Pais = Contacto2_Domicilio_Pais;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Pais != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Pais = Contacto2_Domicilio_Pais;
            }

            if (item.Contacto2?.Domicilio != null)
                item.Contacto2!.Domicilio!.Codigopostal = Contacto2_Domicilio_Codigopostal;
            else if (item.Contacto2?.Domicilio == null && Contacto2_Domicilio_Codigopostal != null)
            {
                item.Contacto2!.Domicilio = CreateSubEntity<Domicilio>();
                item.Contacto2!.Domicilio!.Codigopostal = Contacto2_Domicilio_Codigopostal;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Calle = Domicilio_Calle;
            else if (item.Domicilio == null && Domicilio_Calle != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Calle = Domicilio_Calle;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Numeroexterior = Domicilio_Numeroexterior;
            else if (item.Domicilio == null && Domicilio_Numeroexterior != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Numeroexterior = Domicilio_Numeroexterior;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Numerointerior = Domicilio_Numerointerior;
            else if (item.Domicilio == null && Domicilio_Numerointerior != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Numerointerior = Domicilio_Numerointerior;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Colonia = Domicilio_Colonia;
            else if (item.Domicilio == null && Domicilio_Colonia != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Colonia = Domicilio_Colonia;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Ciudad = Domicilio_Ciudad;
            else if (item.Domicilio == null && Domicilio_Ciudad != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Ciudad = Domicilio_Ciudad;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Municipio = Domicilio_Municipio;
            else if (item.Domicilio == null && Domicilio_Municipio != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Municipio = Domicilio_Municipio;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Estado = Domicilio_Estado;
            else if (item.Domicilio == null && Domicilio_Estado != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Estado = Domicilio_Estado;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Pais = Domicilio_Pais;
            else if (item.Domicilio == null && Domicilio_Pais != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Pais = Domicilio_Pais;
            }

            if (item.Domicilio != null)
                item.Domicilio!.Codigopostal = Domicilio_Codigopostal;
            else if (item.Domicilio == null && Domicilio_Codigopostal != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Codigopostal = Domicilio_Codigopostal;
            }

            //if (item.Proveedor_pago != null)
            //    item.Proveedor_pago!.Saldo = Proveedor_pago_Saldo ?? 0;
            //else if (item.Proveedor_pago == null && Proveedor_pago_Saldo != null)
            //{
            //    item.Proveedor_pago = CreateSubEntity<Proveedor_pago>();
            //    item.Proveedor_pago!.Saldo = Proveedor_pago_Saldo ?? 0;
            //}

            //if (item.Proveedor_pago != null)
            //    item.Proveedor_pago!.Saldospositivos = Proveedor_pago_Saldospositivos ?? 0;
            //else if (item.Proveedor_pago == null && Proveedor_pago_Saldospositivos != null)
            //{
            //    item.Proveedor_pago = CreateSubEntity<Proveedor_pago>();
            //    item.Proveedor_pago!.Saldospositivos = Proveedor_pago_Saldospositivos ?? 0;
            //}

            //if (item.Proveedor_pago != null)
            //    item.Proveedor_pago!.Saldosnegativos = Proveedor_pago_Saldosnegativos ?? 0;
            //else if (item.Proveedor_pago == null && Proveedor_pago_Saldosnegativos != null)
            //{
            //    item.Proveedor_pago = CreateSubEntity<Proveedor_pago>();
            //    item.Proveedor_pago!.Saldosnegativos = Proveedor_pago_Saldosnegativos ?? 0;
            //}

            if (item.Proveedor_pago_parametros != null)
                item.Proveedor_pago_parametros!.Revision = Proveedor_pago_parametros_Revision;
            else if (item.Proveedor_pago_parametros == null && Proveedor_pago_parametros_Revision != null)
            {
                item.Proveedor_pago_parametros = CreateSubEntity<Proveedor_pago_parametros>();
                item.Proveedor_pago_parametros!.Revision = Proveedor_pago_parametros_Revision;
            }

            if (item.Proveedor_pago_parametros != null)
                item.Proveedor_pago_parametros!.Pagos = Proveedor_pago_parametros_Pagos;
            else if (item.Proveedor_pago_parametros == null && Proveedor_pago_parametros_Pagos != null)
            {
                item.Proveedor_pago_parametros = CreateSubEntity<Proveedor_pago_parametros>();
                item.Proveedor_pago_parametros!.Pagos = Proveedor_pago_parametros_Pagos;
            }

            if (item.Proveedor_pago_parametros != null)
                item.Proveedor_pago_parametros!.Dias = Proveedor_pago_parametros_Dias;
            else if (item.Proveedor_pago_parametros == null && Proveedor_pago_parametros_Dias != null)
            {
                item.Proveedor_pago_parametros = CreateSubEntity<Proveedor_pago_parametros>();
                item.Proveedor_pago_parametros!.Dias = Proveedor_pago_parametros_Dias;
            }

            if (item.Proveedor_pago_parametros != null)
                item.Proveedor_pago_parametros!.Adescpes = Proveedor_pago_parametros_Adescpes ?? 0;
            else if (item.Proveedor_pago_parametros == null && Proveedor_pago_parametros_Adescpes != null)
            {
                item.Proveedor_pago_parametros = CreateSubEntity<Proveedor_pago_parametros>();
                item.Proveedor_pago_parametros!.Adescpes = Proveedor_pago_parametros_Adescpes ?? 0;
            }


        }
        #endif




    }
}

