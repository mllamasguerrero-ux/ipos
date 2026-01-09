
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
    public class ClienteBindingModel: ClienteBindingModelGenerated
    {


        public ClienteBindingModel():base()
        {
        }
        

        #if PROYECTO_WEB
        
        public ClienteBindingModel(Cliente item):base(item)
        {
        }



        public void FillEntityValuesForUpdate(ref Cliente item)
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


            item.Domicilioid = Domicilioid;


            item.Contacto1id = Contacto1id;


            item.Contacto2id = Contacto2id;


            item.Domicilioentregaid = Domicilioentregaid;


            item.Subtipoclienteid = Subtipoclienteid;


            item.Proveeclienteid = Proveeclienteid;


            item.Vigencia = Vigencia;


            item.Firma = Firma;


            item.Email3 = Email3;


            item.Email4 = Email4;



            item.Nombre = Nombre ?? "";


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


            if (item.Domicilio != null)
                item.Domicilio!.Referencia = Domicilio_Referencia;
            else if (item.Domicilio == null && Domicilio_Referencia != null)
            {
                item.Domicilio = CreateSubEntity<Domicilio>();
                item.Domicilio!.Referencia = Domicilio_Referencia;
            }

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

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Calle = Domicilioentrega_Calle;
            else if (item.Domicilioentrega == null && Domicilioentrega_Calle != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Calle = Domicilioentrega_Calle;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Numeroexterior = Domicilioentrega_Numeroexterior;
            else if (item.Domicilioentrega == null && Domicilioentrega_Numeroexterior != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Numeroexterior = Domicilioentrega_Numeroexterior;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Numerointerior = Domicilioentrega_Numerointerior;
            else if (item.Domicilioentrega == null && Domicilioentrega_Numerointerior != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Numerointerior = Domicilioentrega_Numerointerior;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Colonia = Domicilioentrega_Colonia;
            else if (item.Domicilioentrega == null && Domicilioentrega_Colonia != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Colonia = Domicilioentrega_Colonia;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Ciudad = Domicilioentrega_Ciudad;
            else if (item.Domicilioentrega == null && Domicilioentrega_Ciudad != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Ciudad = Domicilioentrega_Ciudad;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Municipio = Domicilioentrega_Municipio;
            else if (item.Domicilioentrega == null && Domicilioentrega_Municipio != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Municipio = Domicilioentrega_Municipio;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Estado = Domicilioentrega_Estado;
            else if (item.Domicilioentrega == null && Domicilioentrega_Estado != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Estado = Domicilioentrega_Estado;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Pais = Domicilioentrega_Pais;
            else if (item.Domicilioentrega == null && Domicilioentrega_Pais != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Pais = Domicilioentrega_Pais;
            }

            if (item.Domicilioentrega != null)
                item.Domicilioentrega!.Codigopostal = Domicilioentrega_Codigopostal;
            else if (item.Domicilioentrega == null && Domicilioentrega_Codigopostal != null)
            {
                item.Domicilioentrega = CreateSubEntity<Domicilio>();
                item.Domicilioentrega!.Codigopostal = Domicilioentrega_Codigopostal;
            }

            if (item.Cliente_bancomer != null)
                item.Cliente_bancomer!.Bancomerdoctopendid = Cliente_bancomer_Bancomerdoctopendid;
            else if (item.Cliente_bancomer == null && Cliente_bancomer_Bancomerdoctopendid != null)
            {
                item.Cliente_bancomer = CreateSubEntity<Cliente_bancomer>();
                item.Cliente_bancomer!.Bancomerdoctopendid = Cliente_bancomer_Bancomerdoctopendid;
            }

            if (item.Cliente_comision != null)
                item.Cliente_comision!.Vendedorid = Cliente_comision_Vendedorid;
            else if (item.Cliente_comision == null && Cliente_comision_Vendedorid != null)
            {
                item.Cliente_comision = CreateSubEntity<Cliente_comision>();
                item.Cliente_comision!.Vendedorid = Cliente_comision_Vendedorid;
            }


            if (item.Cliente_comision != null)
                item.Cliente_comision!.Por_come = Cliente_comision_Por_come ?? 0;
            else if (item.Cliente_comision == null && Cliente_comision_Por_come != null)
            {
                item.Cliente_comision = CreateSubEntity<Cliente_comision>();
                item.Cliente_comision!.Por_come = Cliente_comision_Por_come ?? 0;
            }

            if (item.Cliente_comision != null)
                item.Cliente_comision!.Servicioadomicilio = Cliente_comision_Servicioadomicilio;
            else if (item.Cliente_comision == null && Cliente_comision_Servicioadomicilio != null)
            {
                item.Cliente_comision = CreateSubEntity<Cliente_comision>();
                item.Cliente_comision!.Servicioadomicilio = Cliente_comision_Servicioadomicilio;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Generarreciboelectronico = Cliente_fact_elect_Generarreciboelectronico;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Generarreciboelectronico != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Generarreciboelectronico = Cliente_fact_elect_Generarreciboelectronico;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Retieneisr = Cliente_fact_elect_Retieneisr ?? BoolCN.N;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Retieneisr != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Retieneisr = Cliente_fact_elect_Retieneisr ?? BoolCN.N;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Retieneiva = Cliente_fact_elect_Retieneiva ?? BoolCN.N;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Retieneiva != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Retieneiva = Cliente_fact_elect_Retieneiva ?? BoolCN.N;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Creditoformapagosatabonos = Cliente_fact_elect_Creditoformapagosatabonos;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Creditoformapagosatabonos != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Creditoformapagosatabonos = Cliente_fact_elect_Creditoformapagosatabonos;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_usocfdiid = Cliente_fact_elect_Sat_usocfdiid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_usocfdiid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_usocfdiid = Cliente_fact_elect_Sat_usocfdiid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_id_pais = Cliente_fact_elect_Sat_id_pais;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_id_pais != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_id_pais = Cliente_fact_elect_Sat_id_pais;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_Coloniaid = Cliente_fact_elect_Sat_Coloniaid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_Coloniaid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_Coloniaid = Cliente_fact_elect_Sat_Coloniaid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_Localidadid = Cliente_fact_elect_Sat_Localidadid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_Localidadid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_Localidadid = Cliente_fact_elect_Sat_Localidadid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_Municipioid = Cliente_fact_elect_Sat_Municipioid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_Municipioid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_Municipioid = Cliente_fact_elect_Sat_Municipioid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Distancia = Cliente_fact_elect_Distancia ?? 0;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Distancia != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Distancia = Cliente_fact_elect_Distancia ?? 0;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Entrega_Sat_Coloniaid = Cliente_fact_elect_Entrega_Sat_Coloniaid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Entrega_Sat_Coloniaid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Entrega_Sat_Coloniaid = Cliente_fact_elect_Entrega_Sat_Coloniaid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Entrega_Sat_Localidadid = Cliente_fact_elect_Entrega_Sat_Localidadid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Entrega_Sat_Localidadid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Entrega_Sat_Localidadid = Cliente_fact_elect_Entrega_Sat_Localidadid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Entrega_Sat_Municipioid = Cliente_fact_elect_Entrega_Sat_Municipioid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Entrega_Sat_Municipioid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Entrega_Sat_Municipioid = Cliente_fact_elect_Entrega_Sat_Municipioid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Entrega_Distancia = Cliente_fact_elect_Entrega_Distancia ?? 0;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Entrega_Distancia != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Entrega_Distancia = Cliente_fact_elect_Entrega_Distancia ?? 0;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Entregareferenciadom = Cliente_fact_elect_Entregareferenciadom;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Entregareferenciadom != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Entregareferenciadom = Cliente_fact_elect_Entregareferenciadom;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Sat_Regimenfiscalid = Cliente_fact_elect_Sat_Regimenfiscalid;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Sat_Regimenfiscalid != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Sat_Regimenfiscalid = Cliente_fact_elect_Sat_Regimenfiscalid;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Generacomprobtrasl = Cliente_fact_elect_Generacomprobtrasl;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Generacomprobtrasl != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Generacomprobtrasl = Cliente_fact_elect_Generacomprobtrasl;
            }

            if (item.Cliente_fact_elect != null)
                item.Cliente_fact_elect!.Generacartaporte = Cliente_fact_elect_Generacartaporte;
            else if (item.Cliente_fact_elect == null && Cliente_fact_elect_Generacartaporte != null)
            {
                item.Cliente_fact_elect = CreateSubEntity<Cliente_fact_elect>();
                item.Cliente_fact_elect!.Generacartaporte = Cliente_fact_elect_Generacartaporte;
            }

            //if (item.Cliente_ordencompra != null)
            //    item.Cliente_ordencompra!.Solicitaordencompra = Cliente_ordencompra_Solicitaordencompra ?? BoolCN.N;
            //else if (item.Cliente_ordencompra == null && Cliente_ordencompra_Solicitaordencompra != null)
            //{
            //    item.Cliente_ordencompra = CreateSubEntity<Cliente_ordencompra>();
            //    item.Cliente_ordencompra!.Solicitaordencompra = Cliente_ordencompra_Solicitaordencompra ?? BoolCN.N;
            //}

            //if (item.Cliente_pago != null)
            //    item.Cliente_pago!.Saldo = Cliente_pago_Saldo ?? 0;
            //else if (item.Cliente_pago == null && Cliente_pago_Saldo != null)
            //{
            //    item.Cliente_pago = CreateSubEntity<Cliente_pago>();
            //    item.Cliente_pago!.Saldo = Cliente_pago_Saldo ?? 0;
            //}

            //if (item.Cliente_pago != null)
            //    item.Cliente_pago!.Saldoapartadonegativo = Cliente_pago_Saldoapartadonegativo ?? 0;
            //else if (item.Cliente_pago == null && Cliente_pago_Saldoapartadonegativo != null)
            //{
            //    item.Cliente_pago = CreateSubEntity<Cliente_pago>();
            //    item.Cliente_pago!.Saldoapartadonegativo = Cliente_pago_Saldoapartadonegativo ?? 0;
            //}

            //if (item.Cliente_pago != null)
            //    item.Cliente_pago!.Saldoapartadopositivo = Cliente_pago_Saldoapartadopositivo ?? 0;
            //else if (item.Cliente_pago == null && Cliente_pago_Saldoapartadopositivo != null)
            //{
            //    item.Cliente_pago = CreateSubEntity<Cliente_pago>();
            //    item.Cliente_pago!.Saldoapartadopositivo = Cliente_pago_Saldoapartadopositivo ?? 0;
            //}

            //if (item.Cliente_pago != null)
            //    item.Cliente_pago!.Saldospositivos = Cliente_pago_Saldospositivos ?? 0;
            //else if (item.Cliente_pago == null && Cliente_pago_Saldospositivos != null)
            //{
            //    item.Cliente_pago = CreateSubEntity<Cliente_pago>();
            //    item.Cliente_pago!.Saldospositivos = Cliente_pago_Saldospositivos ?? 0;
            //}

            //if (item.Cliente_pago != null)
            //    item.Cliente_pago!.Saldosnegativos = Cliente_pago_Saldosnegativos ?? 0;
            //else if (item.Cliente_pago == null && Cliente_pago_Saldosnegativos != null)
            //{
            //    item.Cliente_pago = CreateSubEntity<Cliente_pago>();
            //    item.Cliente_pago!.Saldosnegativos = Cliente_pago_Saldosnegativos ?? 0;
            //}

            //if (item.Cliente_pago != null)
            //    item.Cliente_pago!.Ultimaventa = Cliente_pago_Ultimaventa;
            //else if (item.Cliente_pago == null && Cliente_pago_Ultimaventa != null)
            //{
            //    item.Cliente_pago = CreateSubEntity<Cliente_pago>();
            //    item.Cliente_pago!.Ultimaventa = Cliente_pago_Ultimaventa;
            //}

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Hab_pagotarjeta = Cliente_pago_parametros_Hab_pagotarjeta ?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Hab_pagotarjeta != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Hab_pagotarjeta = Cliente_pago_parametros_Hab_pagotarjeta ?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Hab_pagocredito = Cliente_pago_parametros_Hab_pagocredito ?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Hab_pagocredito != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Hab_pagocredito = Cliente_pago_parametros_Hab_pagocredito ?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Hab_pagocheque = Cliente_pago_parametros_Hab_pagocheque ?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Hab_pagocheque != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Hab_pagocheque = Cliente_pago_parametros_Hab_pagocheque ?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Revision = Cliente_pago_parametros_Revision;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Revision != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Revision = Cliente_pago_parametros_Revision;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Pagos = Cliente_pago_parametros_Pagos;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Pagos != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Pagos = Cliente_pago_parametros_Pagos;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Bloqueado = Cliente_pago_parametros_Bloqueado ?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Bloqueado != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Bloqueado = Cliente_pago_parametros_Bloqueado ?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Hab_pagotransferencia = Cliente_pago_parametros_Hab_pagotransferencia ?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Hab_pagotransferencia != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Hab_pagotransferencia = Cliente_pago_parametros_Hab_pagotransferencia ?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Hab_pagoefectivo = Cliente_pago_parametros_Hab_pagoefectivo ?? BoolCS.S;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Hab_pagoefectivo != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Hab_pagoefectivo = Cliente_pago_parametros_Hab_pagoefectivo ?? BoolCS.S;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Pagoparcialidades = Cliente_pago_parametros_Pagoparcialidades ?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Pagoparcialidades != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Pagoparcialidades = Cliente_pago_parametros_Pagoparcialidades ?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Creditoreferenciaabonos = Cliente_pago_parametros_Creditoreferenciaabonos;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Creditoreferenciaabonos != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Creditoreferenciaabonos = Cliente_pago_parametros_Creditoreferenciaabonos;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Bloqueonot = Cliente_pago_parametros_Bloqueonot;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Bloqueonot != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Bloqueonot = Cliente_pago_parametros_Bloqueonot;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Exentoiva = Cliente_pago_parametros_Exentoiva ?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Exentoiva != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Exentoiva = Cliente_pago_parametros_Exentoiva ?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Cargoxventacontarjeta = Cliente_pago_parametros_Cargoxventacontarjeta ?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Cargoxventacontarjeta != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Cargoxventacontarjeta = Cliente_pago_parametros_Cargoxventacontarjeta ?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Pagotarjmenorpreciolista = Cliente_pago_parametros_Pagotarjmenorpreciolista ?? BoolCN.N;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Pagotarjmenorpreciolista != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Pagotarjmenorpreciolista = Cliente_pago_parametros_Pagotarjmenorpreciolista ?? BoolCN.N;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Limitecredito = Cliente_pago_parametros_Limitecredito ?? 0;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Limitecredito != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Limitecredito = Cliente_pago_parametros_Limitecredito ?? 0;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Dias = Cliente_pago_parametros_Dias;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Dias != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Dias = Cliente_pago_parametros_Dias;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Creditoformapagoabonos = Cliente_pago_parametros_Creditoformapagoabonos;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Creditoformapagoabonos != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Creditoformapagoabonos = Cliente_pago_parametros_Creditoformapagoabonos;
            }

            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Monedaid = Cliente_pago_parametros_Monedaid;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Monedaid != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Monedaid = Cliente_pago_parametros_Monedaid;
            }


            if (item.Cliente_pago_parametros != null)
                item.Cliente_pago_parametros!.Dias_extr = Cliente_pago_parametros_Dias_extr;
            else if (item.Cliente_pago_parametros == null && Cliente_pago_parametros_Dias_extr != null)
            {
                item.Cliente_pago_parametros = CreateSubEntity<Cliente_pago_parametros>();
                item.Cliente_pago_parametros!.Dias_extr = Cliente_pago_parametros_Dias_extr;
            }

            if (item.Cliente_poliza != null)
                item.Cliente_poliza!.Desgloseieps = Cliente_poliza_Desgloseieps ?? BoolCN.N;
            else if (item.Cliente_poliza == null && Cliente_poliza_Desgloseieps != null)
            {
                item.Cliente_poliza = CreateSubEntity<Cliente_poliza>();
                item.Cliente_poliza!.Desgloseieps = Cliente_poliza_Desgloseieps ?? BoolCN.N;
            }

            if (item.Cliente_poliza != null)
                item.Cliente_poliza!.Cuentaieps = Cliente_poliza_Cuentaieps;
            else if (item.Cliente_poliza == null && Cliente_poliza_Cuentaieps != null)
            {
                item.Cliente_poliza = CreateSubEntity<Cliente_poliza>();
                item.Cliente_poliza!.Cuentaieps = Cliente_poliza_Cuentaieps;
            }

            if (item.Cliente_poliza != null)
                item.Cliente_poliza!.Cuentacontpaq = Cliente_poliza_Cuentacontpaq;
            else if (item.Cliente_poliza == null && Cliente_poliza_Cuentacontpaq != null)
            {
                item.Cliente_poliza = CreateSubEntity<Cliente_poliza>();
                item.Cliente_poliza!.Cuentacontpaq = Cliente_poliza_Cuentacontpaq;
            }

            if (item.Cliente_poliza != null)
                item.Cliente_poliza!.Separarprodxplazo = Cliente_poliza_Separarprodxplazo ?? BoolCN.N;
            else if (item.Cliente_poliza == null && Cliente_poliza_Separarprodxplazo != null)
            {
                item.Cliente_poliza = CreateSubEntity<Cliente_poliza>();
                item.Cliente_poliza!.Separarprodxplazo = Cliente_poliza_Separarprodxplazo ?? BoolCN.N;
            }

            if (item.Cliente_precio != null)
                item.Cliente_precio!.Listaprecioid = Cliente_precio_Listaprecioid;
            else if (item.Cliente_precio == null && Cliente_precio_Listaprecioid != null)
            {
                item.Cliente_precio = CreateSubEntity<Cliente_precio>();
                item.Cliente_precio!.Listaprecioid = Cliente_precio_Listaprecioid;
            }

            if (item.Cliente_precio != null)
                item.Cliente_precio!.Superlistaprecioid = Cliente_precio_Superlistaprecioid;
            else if (item.Cliente_precio == null && Cliente_precio_Superlistaprecioid != null)
            {
                item.Cliente_precio = CreateSubEntity<Cliente_precio>();
                item.Cliente_precio!.Superlistaprecioid = Cliente_precio_Superlistaprecioid;
            }

            if (item.Cliente_precio != null)
                item.Cliente_precio!.Mayoreoxproducto = Cliente_precio_Mayoreoxproducto ?? BoolCN.N;
            else if (item.Cliente_precio == null && Cliente_precio_Mayoreoxproducto != null)
            {
                item.Cliente_precio = CreateSubEntity<Cliente_precio>();
                item.Cliente_precio!.Mayoreoxproducto = Cliente_precio_Mayoreoxproducto ?? BoolCN.N;
            }

            if (item.Cliente_rutaembarque != null)
                item.Cliente_rutaembarque!.Rutaembarqueid = Cliente_rutaembarque_Rutaembarqueid;
            else if (item.Cliente_rutaembarque == null && Cliente_rutaembarque_Rutaembarqueid != null)
            {
                item.Cliente_rutaembarque = CreateSubEntity<Cliente_rutaembarque>();
                item.Cliente_rutaembarque!.Rutaembarqueid = Cliente_rutaembarque_Rutaembarqueid;
            }


        }
        #endif




    }
}

