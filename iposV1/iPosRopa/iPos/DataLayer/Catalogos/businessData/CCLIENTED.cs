using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
namespace iPosData
{
    public class CCLIENTED: CPERSONAD
    {


        public bool CambiarCLIENTED(CPERSONABE oCPERSONANuevo, CPERSONABE oCPERSONAAnterior,  FbTransaction st)
        {

            return CambiarCLIENTED( oCPERSONANuevo, oCPERSONAAnterior,  null, st);
        }

        public bool CambiarCLIENTED(CPERSONABE oCPERSONANuevo, CPERSONABE oCPERSONAAnterior, DateTime? replmodificado, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPERSONANuevo.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPERSONANuevo.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPERSONANuevo.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPERSONANuevo.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCPERSONANuevo.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MEMO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IMEMO"])
                {
                    auxPar.Value = oCPERSONANuevo.IMEMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALUDOID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ISALUDOID"])
                {
                    auxPar.Value = oCPERSONANuevo.ISALUDOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NOMBRES", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["INOMBRES"])
                {
                    auxPar.Value = oCPERSONANuevo.INOMBRES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@APELLIDOS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IAPELLIDOS"])
                {
                    auxPar.Value = oCPERSONANuevo.IAPELLIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RAZONSOCIAL", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IRAZONSOCIAL"])
                {
                    auxPar.Value = oCPERSONANuevo.IRAZONSOCIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@RFC", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IRFC"])
                {
                    auxPar.Value = oCPERSONANuevo.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONTACTO1", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICONTACTO1"])
                {
                    auxPar.Value = oCPERSONANuevo.ICONTACTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CONTACTO2", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCPERSONANuevo.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOMICILIO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IDOMICILIO"])
                {
                    auxPar.Value = oCPERSONANuevo.IDOMICILIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@COLONIA", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCPERSONANuevo.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CIUDAD", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCPERSONANuevo.ICIUDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@MUNICIPIO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IMUNICIPIO"])
                {
                    auxPar.Value = oCPERSONANuevo.IMUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESTADO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IESTADO"])
                {
                    auxPar.Value = oCPERSONANuevo.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAIS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IPAIS"])
                {
                    auxPar.Value = oCPERSONANuevo.IPAIS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CODIGOPOSTAL", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICODIGOPOSTAL"])
                {
                    auxPar.Value = oCPERSONANuevo.ICODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELEFONO1", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ITELEFONO1"])
                {
                    auxPar.Value = oCPERSONANuevo.ITELEFONO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELEFONO2", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ITELEFONO2"])
                {
                    auxPar.Value = oCPERSONANuevo.ITELEFONO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@TELEFONO3", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ITELEFONO3"])
                {
                    auxPar.Value = oCPERSONANuevo.ITELEFONO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CELULAR", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICELULAR"])
                {
                    auxPar.Value = oCPERSONANuevo.ICELULAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NEXTEL", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["INEXTEL"])
                {
                    auxPar.Value = oCPERSONANuevo.INEXTEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMAIL1", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IEMAIL1"])
                {
                    auxPar.Value = oCPERSONANuevo.IEMAIL1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMAIL2", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IEMAIL2"])
                {
                    auxPar.Value = oCPERSONANuevo.IEMAIL2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMPRESAID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IEMPRESAID"])
                {
                    auxPar.Value = oCPERSONANuevo.IEMPRESAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCPERSONANuevo.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ILISTAPRECIOID"])
                {
                    auxPar.Value = oCPERSONANuevo.ILISTAPRECIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@VIGENCIA", FbDbType.Date);
                if (!(bool)oCPERSONANuevo.isnull["IVIGENCIA"])
                {
                    auxPar.Value = oCPERSONANuevo.IVIGENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAB_PAGOTARJETA", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IHAB_PAGOTARJETA"])
                {
                    auxPar.Value = oCPERSONANuevo.IHAB_PAGOTARJETA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAB_PAGOCREDITO", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IHAB_PAGOCREDITO"])
                {
                    auxPar.Value = oCPERSONANuevo.IHAB_PAGOCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAB_PAGOCHEQUE", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IHAB_PAGOCHEQUE"])
                {
                    auxPar.Value = oCPERSONANuevo.IHAB_PAGOCHEQUE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMEROINTERIOR", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["INUMEROINTERIOR"])
                {
                    auxPar.Value = oCPERSONANuevo.INUMEROINTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@NUMEROEXTERIOR", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["INUMEROEXTERIOR"])
                {
                    auxPar.Value = oCPERSONANuevo.INUMEROEXTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@REVISION", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IREVISION"])
                {
                    auxPar.Value = oCPERSONANuevo.IREVISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGOS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IPAGOS"])
                {
                    auxPar.Value = oCPERSONANuevo.IPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BLOQUEADO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCPERSONANuevo.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LIMITECREDITO", FbDbType.Numeric);
                if (!(bool)oCPERSONANuevo.isnull["ILIMITECREDITO"])
                {
                    auxPar.Value = oCPERSONANuevo.ILIMITECREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DIAS", FbDbType.Integer);
                if (!(bool)oCPERSONANuevo.isnull["IDIAS"])
                {
                    auxPar.Value = oCPERSONANuevo.IDIAS;
                }
                else
                {
                    auxPar.Value = "0";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TICKETLARGO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ITICKETLARGO"])
                {
                    auxPar.Value = oCPERSONANuevo.ITICKETLARGO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ENTREGACALLE", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGACALLE"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGACALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGANUMEROINTERIOR", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGANUMEROINTERIOR"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGANUMEROINTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGANUMEROEXTERIOR", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGANUMEROEXTERIOR"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGANUMEROEXTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGACOLONIA", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGACOLONIA"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGACOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGAMUNICIPIO", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGAMUNICIPIO"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGAMUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGAESTADO", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGAESTADO"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGAESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGACODIGOPOSTAL", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGACODIGOPOSTAL"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGACODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@HAB_PAGOTRANSFERENCIA", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IHAB_PAGOTRANSFERENCIA"])
                {
                    auxPar.Value = oCPERSONANuevo.IHAB_PAGOTRANSFERENCIA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREDITOFORMAPAGOABONOS", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ICREDITOFORMAPAGOABONOS"])
                {
                    auxPar.Value = oCPERSONANuevo.ICREDITOFORMAPAGOABONOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREDITOREFERENCIAABONOS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICREDITOREFERENCIAABONOS"])
                {
                    auxPar.Value = oCPERSONANuevo.ICREDITOREFERENCIAABONOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RETIENEISR", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IRETIENEISR"])
                {
                    auxPar.Value = oCPERSONANuevo.IRETIENEISR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RETIENEIVA", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IRETIENEIVA"])
                {
                    auxPar.Value = oCPERSONANuevo.IRETIENEIVA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MONEDAID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IMONEDAID"])
                {
                    auxPar.Value = oCPERSONANuevo.IMONEDAID;
                }
                else
                {
                    auxPar.Value = DBValues._MONEDA_PESOS;
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@DESGLOSEIEPS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IDESGLOSEIEPS"])
                {
                    auxPar.Value = oCPERSONANuevo.IDESGLOSEIEPS;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CUENTAIEPS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICUENTAIEPS"])
                {
                    auxPar.Value = oCPERSONANuevo.ICUENTAIEPS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SUPERLISTAPRECIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ISUPERLISTAPRECIOID"])
                {
                    auxPar.Value = oCPERSONANuevo.ISUPERLISTAPRECIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMAIL3", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IEMAIL3"])
                {
                    auxPar.Value = oCPERSONANuevo.IEMAIL3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@EMAIL4", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IEMAIL4"])
                {
                    auxPar.Value = oCPERSONANuevo.IEMAIL4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTATUSENVIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IESTATUSENVIOID"])
                {
                    auxPar.Value = oCPERSONANuevo.IESTATUSENVIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REPLMODIFICADO", FbDbType.TimeStamp);
                if (replmodificado != null)
                {
                    auxPar.Value = replmodificado.Value;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOPARCIALIDADES", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IPAGOPARCIALIDADES"])
                {
                    auxPar.Value = oCPERSONANuevo.IPAGOPARCIALIDADES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREDITOFORMAPAGOSATABONOS", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ICREDITOFORMAPAGOSATABONOS"])
                {
                    auxPar.Value = oCPERSONANuevo.ICREDITOFORMAPAGOSATABONOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SERVICIOADOMICILIO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ISERVICIOADOMICILIO"])
                {
                    auxPar.Value = oCPERSONANuevo.ISERVICIOADOMICILIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@GENERARRECIBOELECTRONICO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IGENERARRECIBOELECTRONICO"])
                {
                    auxPar.Value = oCPERSONANuevo.IGENERARRECIBOELECTRONICO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);






                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ILOCALIDAD"])
                {
                    auxPar.Value = oCPERSONANuevo.ILOCALIDAD;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFERENCIADOM", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IREFERENCIADOM"])
                {
                    auxPar.Value = oCPERSONANuevo.IREFERENCIADOM;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAB_PAGOEFECTIVO", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IHAB_PAGOEFECTIVO"])
                {
                    auxPar.Value = oCPERSONANuevo.IHAB_PAGOEFECTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SOLICITAORDENCOMPRA", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ISOLICITAORDENCOMPRA"])
                {
                    auxPar.Value = oCPERSONANuevo.ISOLICITAORDENCOMPRA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTACONTPAQ", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICUENTACONTPAQ"])
                {
                    auxPar.Value = oCPERSONANuevo.ICUENTACONTPAQ;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SEPARARPRODXPLAZO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ISEPARARPRODXPLAZO"])
                {
                    auxPar.Value = oCPERSONANuevo.ISEPARARPRODXPLAZO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CARGOXVENTACONTARJETA", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICARGOXVENTACONTARJETA"])
                {
                    auxPar.Value = oCPERSONANuevo.ICARGOXVENTACONTARJETA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOTARJMENORPRECIOLISTA", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IPAGOTARJMENORPRECIOLISTA"])
                {
                    auxPar.Value = oCPERSONANuevo.IPAGOTARJMENORPRECIOLISTA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_CLAVE_PAIS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ISAT_CLAVE_PAIS"])
                {
                    auxPar.Value = oCPERSONANuevo.ISAT_CLAVE_PAIS;
                }
                else
                {
                    auxPar.Value = "MEX";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PROVEECLIENTEID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IPROVEECLIENTEID"])
                {
                    auxPar.Value = oCPERSONANuevo.IPROVEECLIENTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@EXENTOIVA", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IEXENTOIVA"])
                {
                    auxPar.Value = oCPERSONANuevo.IEXENTOIVA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SAT_USOCFDIID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ISAT_USOCFDIID"])
                {
                    auxPar.Value = oCPERSONANuevo.ISAT_USOCFDIID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@POR_COME", FbDbType.Numeric);
                if (!(bool)oCPERSONANuevo.isnull["IPOR_COME"])
                {
                    auxPar.Value = oCPERSONANuevo.IPOR_COME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DIAS_EXTR", FbDbType.Integer);
                if (!(bool)oCPERSONANuevo.isnull["IDIAS_EXTR"])
                {
                    auxPar.Value = oCPERSONANuevo.IDIAS_EXTR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTAEMBARQUEID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IRUTAEMBARQUEID"])
                {
                    auxPar.Value = oCPERSONANuevo.IRUTAEMBARQUEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SUBTIPOCLIENTE", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ISUBTIPOCLIENTE"])
                {
                    auxPar.Value = oCPERSONANuevo.ISUBTIPOCLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PREGUNTARTICKETLARGO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IPREGUNTARTICKETLARGO"])
                {
                    auxPar.Value = oCPERSONANuevo.IPREGUNTARTICKETLARGO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MAYOREOXPRODUCTO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IMAYOREOXPRODUCTO"])
                {
                    auxPar.Value = oCPERSONANuevo.IMAYOREOXPRODUCTO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@GENERACOMPROBTRASL", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IGENERACOMPROBTRASL"])
                {
                    auxPar.Value = oCPERSONANuevo.IGENERACOMPROBTRASL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@GENERACARTAPORTE", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IGENERACARTAPORTE"])
                {
                    auxPar.Value = oCPERSONANuevo.IGENERACARTAPORTE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_COLONIAID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ISAT_COLONIAID"])
                {
                    auxPar.Value = oCPERSONANuevo.ISAT_COLONIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_LOCALIDADID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ISAT_LOCALIDADID"])
                {
                    auxPar.Value = oCPERSONANuevo.ISAT_LOCALIDADID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_MUNICIPIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ISAT_MUNICIPIOID"])
                {
                    auxPar.Value = oCPERSONANuevo.ISAT_MUNICIPIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@DISTANCIA", FbDbType.Numeric);
                if (!(bool)oCPERSONANuevo.isnull["IDISTANCIA"])
                {
                    auxPar.Value = oCPERSONANuevo.IDISTANCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ENTREGA_SAT_COLONIAID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGA_SAT_COLONIAID"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGA_SAT_COLONIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENTREGA_SAT_LOCALIDADID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGA_SAT_LOCALIDADID"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGA_SAT_LOCALIDADID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENTREGA_SAT_MUNICIPIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGA_SAT_MUNICIPIOID"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGA_SAT_MUNICIPIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ENTREGA_DISTANCIA", FbDbType.Numeric);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGA_DISTANCIA"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGA_DISTANCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ENTREGAREFERENCIADOM", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IENTREGAREFERENCIADOM"])
                {
                    auxPar.Value = oCPERSONANuevo.IENTREGAREFERENCIADOM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_REGIMENFISCALID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ISAT_REGIMENFISCALID"])
                {
                    auxPar.Value = oCPERSONANuevo.ISAT_REGIMENFISCALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRMAIMAGEN", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IFIRMAIMAGEN"])
                {
                    auxPar.Value = oCPERSONANuevo.IFIRMAIMAGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LATITUD", FbDbType.Double);
                if (!(bool)oCPERSONANuevo.isnull["ILATITUD"])
                {
                    auxPar.Value = oCPERSONANuevo.ILATITUD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LONGITUD", FbDbType.Double);
                if (!(bool)oCPERSONANuevo.isnull["ILONGITUD"])
                {
                    auxPar.Value = oCPERSONANuevo.ILONGITUD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@IDAnt", FbDbType.BigInt);
                if (!(bool)oCPERSONAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPERSONAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"  
update  PERSONA
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

CLAVE=@CLAVE,

NOMBRE=@NOMBRE,

DESCRIPCION=@DESCRIPCION,

MEMO=@MEMO,

SALUDOID=@SALUDOID,

NOMBRES=@NOMBRES,

APELLIDOS=@APELLIDOS,

RAZONSOCIAL=@RAZONSOCIAL,

RFC=@RFC,

CONTACTO1=@CONTACTO1,

CONTACTO2=@CONTACTO2,

DOMICILIO=@DOMICILIO,

COLONIA=@COLONIA,

CIUDAD=@CIUDAD,

MUNICIPIO=@MUNICIPIO,

ESTADO=@ESTADO,

PAIS=@PAIS,

CODIGOPOSTAL=@CODIGOPOSTAL,

TELEFONO1=@TELEFONO1,

TELEFONO2=@TELEFONO2,

TELEFONO3=@TELEFONO3,

CELULAR=@CELULAR,

NEXTEL=@NEXTEL,

EMAIL1=@EMAIL1,

EMAIL2=@EMAIL2,

EMPRESAID=@EMPRESAID,

VENDEDORID=@VENDEDORID,

LISTAPRECIOID=@LISTAPRECIOID,

VIGENCIA=@VIGENCIA,

HAB_PAGOTARJETA=@HAB_PAGOTARJETA,

HAB_PAGOCREDITO=@HAB_PAGOCREDITO,

HAB_PAGOCHEQUE=@HAB_PAGOCHEQUE,

NUMEROINTERIOR = @NUMEROINTERIOR,

NUMEROEXTERIOR = @NUMEROEXTERIOR,

LIMITECREDITO = @LIMITECREDITO,

DIAS = @DIAS,

REVISION = @REVISION,

PAGOS = @PAGOS,

BLOQUEADO = @BLOQUEADO,

TICKETLARGO = @TICKETLARGO,

ENTREGACALLE  = @ENTREGACALLE ,
ENTREGANUMEROINTERIOR  = @ENTREGANUMEROINTERIOR ,
ENTREGANUMEROEXTERIOR  = @ENTREGANUMEROEXTERIOR ,
ENTREGACOLONIA  = @ENTREGACOLONIA ,
ENTREGAMUNICIPIO  = @ENTREGAMUNICIPIO ,
ENTREGAESTADO  = @ENTREGAESTADO ,
ENTREGACODIGOPOSTAL  = @ENTREGACODIGOPOSTAL,


HAB_PAGOTRANSFERENCIA = @HAB_PAGOTRANSFERENCIA,
CREDITOFORMAPAGOABONOS = @CREDITOFORMAPAGOABONOS ,
CREDITOREFERENCIAABONOS = @CREDITOREFERENCIAABONOS,
RETIENEISR = @RETIENEISR,
RETIENEIVA = @RETIENEIVA,

MONEDAID = @MONEDAID,

DESGLOSEIEPS = @DESGLOSEIEPS,

CUENTAIEPS = @CUENTAIEPS,

SUPERLISTAPRECIOID = @SUPERLISTAPRECIOID,

EMAIL3=@EMAIL3,

EMAIL4=@EMAIL4,

ESTATUSENVIOID = @ESTATUSENVIOID,

REPLMODIFICADO = @REPLMODIFICADO,

MODIFICADO = null,

PAGOPARCIALIDADES = @PAGOPARCIALIDADES,

CREDITOFORMAPAGOSATABONOS = @CREDITOFORMAPAGOSATABONOS ,


SERVICIOADOMICILIO = @SERVICIOADOMICILIO,

GENERARRECIBOELECTRONICO = @GENERARRECIBOELECTRONICO,

LOCALIDAD = @LOCALIDAD,

REFERENCIADOM = @REFERENCIADOM,

HAB_PAGOEFECTIVO = @HAB_PAGOEFECTIVO,

SOLICITAORDENCOMPRA = @SOLICITAORDENCOMPRA,

CUENTACONTPAQ = @CUENTACONTPAQ,

SEPARARPRODXPLAZO = @SEPARARPRODXPLAZO,

CARGOXVENTACONTARJETA = @CARGOXVENTACONTARJETA,

PAGOTARJMENORPRECIOLISTA = @PAGOTARJMENORPRECIOLISTA,

SAT_CLAVE_PAIS = @SAT_CLAVE_PAIS,

PROVEECLIENTEID = @PROVEECLIENTEID,

EXENTOIVA =  @EXENTOIVA, 

SAT_USOCFDIID = @SAT_USOCFDIID,

POR_COME = @POR_COME,

DIAS_EXTR = @DIAS_EXTR,

RUTAEMBARQUEID = @RUTAEMBARQUEID,

SUBTIPOCLIENTE = @SUBTIPOCLIENTE,

PREGUNTARTICKETLARGO = @PREGUNTARTICKETLARGO,

MAYOREOXPRODUCTO = @MAYOREOXPRODUCTO,

GENERACOMPROBTRASL = @GENERACOMPROBTRASL,

GENERACARTAPORTE = @GENERACARTAPORTE,

SAT_COLONIAID=@SAT_COLONIAID,

SAT_LOCALIDADID=@SAT_LOCALIDADID,

SAT_MUNICIPIOID=@SAT_MUNICIPIOID,

DISTANCIA=@DISTANCIA,

ENTREGA_SAT_COLONIAID=@ENTREGA_SAT_COLONIAID,

ENTREGA_SAT_LOCALIDADID=@ENTREGA_SAT_LOCALIDADID,

ENTREGA_SAT_MUNICIPIOID=@ENTREGA_SAT_MUNICIPIOID,

ENTREGA_DISTANCIA=@ENTREGA_DISTANCIA,

ENTREGAREFERENCIADOM = @ENTREGAREFERENCIADOM, 

SAT_REGIMENFISCALID = @SAT_REGIMENFISCALID,

FIRMAIMAGEN = @FIRMAIMAGEN,

LATITUD = @LATITUD,

LONGITUD = @LONGITUD



  where 

ID=@IDAnt
  ;";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }


        public bool BloquearClientesConVentasVencidas(int numDiasVencido, FbTransaction st)
        {

            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                


                auxPar = new FbParameter("@DIASVENCIDO", FbDbType.Integer);
                
                    auxPar.Value = numDiasVencido * -1;
                parts.Add(auxPar);

                




                string commandText = @"  
               update persona set
persona.bloqueado = 'S'
where id in
(
select docto.personaid from docto
where docto.tipodoctoid = 21 and docto.estatusdoctoid = 1 and
docto.saldo > 0 and docto.vence < dateadd( @DIASVENCIDO day to current_date )) 
and id not in 
(
   select persona.id from sucursal inner join persona on persona.clave = sucursal.clienteclave and persona.tipopersonaid = 50
)";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }

            public DataTable getClientesNombres()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.Text, "select nombre, clave from persona where tipopersonaid = 50 order by nombre");

                return retorno.Tables[0];
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }




        public bool esClienteAsignadoASuc(string clienteClave, FbTransaction st)
        {




            bool retorno = false;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select count(*) CONTADOR from SUCURSAL WHERE COALESCE(CLIENTECLAVE,'') = @CLIENTECLAVE ";


                auxPar = new FbParameter("@CLIENTECLAVE", FbDbType.VarChar);
                auxPar.Value = clienteClave;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                int contador = 0;

                if (dr.Read())
                {

                    if (dr["CONTADOR"] != System.DBNull.Value)
                    {
                        contador = (int)(dr["CONTADOR"]);
                    }

                    retorno = contador > 0;
                }
                else
                {
                    retorno = false;
                }


                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);


                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }



        }




    }
}
