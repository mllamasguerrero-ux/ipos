


using System;
using Microsoft.ApplicationBlocks.Data;
using iPosBusinessEntity;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Collections;
using ConexionesBD;
using System.Collections.Generic;
namespace iPosData
{


    public class CPERSONAD
    {
       public string sCadenaConexion;

        public string iComentario;
        public string IComentario
        {
            get
            {
                return this.iComentario;
            }
            set
            {
                this.iComentario = value;
            }
        }

        protected string iComentarioAdicional;
        public string IComentarioAdicional
        {
            get
            {
                return this.iComentarioAdicional;
            }
            set
            {
                this.iComentarioAdicional = value;
            }
        }


        public CPERSONABE AgregarPERSONAD(CPERSONABE oCPERSONA, FbTransaction st)
        {


            try
            {



                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IID"])
                {
                    auxPar.Value = oCPERSONA.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ACTIVO", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IACTIVO"])
                {
                    auxPar.Value = oCPERSONA.IACTIVO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ICREADOPOR_USERID"])
                {
                    auxPar.Value = oCPERSONA.ICREADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MODIFICADOPOR_USERID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IMODIFICADOPOR_USERID"])
                {
                    auxPar.Value = oCPERSONA.IMODIFICADOPOR_USERID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TIPOPERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ITIPOPERSONAID"])
                {
                    auxPar.Value = oCPERSONA.ITIPOPERSONAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPERSONA.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPERSONA.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DESCRIPCION", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IDESCRIPCION"])
                {
                    auxPar.Value = oCPERSONA.IDESCRIPCION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MEMO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IMEMO"])
                {
                    auxPar.Value = oCPERSONA.IMEMO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALUDOID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ISALUDOID"])
                {
                    auxPar.Value = oCPERSONA.ISALUDOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRES", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["INOMBRES"])
                {
                    auxPar.Value = oCPERSONA.INOMBRES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@APELLIDOS", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IAPELLIDOS"])
                {
                    auxPar.Value = oCPERSONA.IAPELLIDOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RAZONSOCIAL", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IRAZONSOCIAL"])
                {
                    auxPar.Value = oCPERSONA.IRAZONSOCIAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RFC", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IRFC"])
                {
                    auxPar.Value = oCPERSONA.IRFC;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTACTO1", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICONTACTO1"])
                {
                    auxPar.Value = oCPERSONA.ICONTACTO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CONTACTO2", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICONTACTO2"])
                {
                    auxPar.Value = oCPERSONA.ICONTACTO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@USERNAME", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IUSERNAME"])
                {
                    auxPar.Value = oCPERSONA.IUSERNAME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVEACCESO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICLAVEACCESO"])
                {
                    auxPar.Value = oCPERSONA.ICLAVEACCESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DOMICILIO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IDOMICILIO"])
                {
                    auxPar.Value = oCPERSONA.IDOMICILIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@COLONIA", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICOLONIA"])
                {
                    auxPar.Value = oCPERSONA.ICOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CIUDAD", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICIUDAD"])
                {
                    auxPar.Value = oCPERSONA.ICIUDAD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MUNICIPIO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IMUNICIPIO"])
                {
                    auxPar.Value = oCPERSONA.IMUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESTADO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IESTADO"])
                {
                    auxPar.Value = oCPERSONA.IESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAIS", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IPAIS"])
                {
                    auxPar.Value = oCPERSONA.IPAIS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGOPOSTAL", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICODIGOPOSTAL"])
                {
                    auxPar.Value = oCPERSONA.ICODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TELEFONO1", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ITELEFONO1"])
                {
                    auxPar.Value = oCPERSONA.ITELEFONO1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TELEFONO2", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ITELEFONO2"])
                {
                    auxPar.Value = oCPERSONA.ITELEFONO2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TELEFONO3", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ITELEFONO3"])
                {
                    auxPar.Value = oCPERSONA.ITELEFONO3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CELULAR", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICELULAR"])
                {
                    auxPar.Value = oCPERSONA.ICELULAR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NEXTEL", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["INEXTEL"])
                {
                    auxPar.Value = oCPERSONA.INEXTEL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMAIL1", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IEMAIL1"])
                {
                    auxPar.Value = oCPERSONA.IEMAIL1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMAIL2", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IEMAIL2"])
                {
                    auxPar.Value = oCPERSONA.IEMAIL2;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMPRESAID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IEMPRESAID"])
                {
                    auxPar.Value = oCPERSONA.IEMPRESAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCPERSONA.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESCLIENTE", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IESCLIENTE"])
                {
                    auxPar.Value = oCPERSONA.IESCLIENTE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESCLIENTEGENERAL", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IESCLIENTEGENERAL"])
                {
                    auxPar.Value = oCPERSONA.IESCLIENTEGENERAL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESPROVEEDOR", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IESPROVEEDOR"])
                {
                    auxPar.Value = oCPERSONA.IESPROVEEDOR;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESUSUARIO", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IESUSUARIO"])
                {
                    auxPar.Value = oCPERSONA.IESUSUARIO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ILISTAPRECIOID"])
                {
                    auxPar.Value = oCPERSONA.ILISTAPRECIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VIGENCIA", FbDbType.Date);
                if (!(bool)oCPERSONA.isnull["IVIGENCIA"])
                {
                    auxPar.Value = oCPERSONA.IVIGENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESET_PASS", FbDbType.SmallInt);
                if (!(bool)oCPERSONA.isnull["IRESET_PASS"])
                {
                    auxPar.Value = oCPERSONA.IRESET_PASS;
                }
                else
                {
                    auxPar.Value = "0";
                }
                parts.Add(auxPar);





                auxPar = new FbParameter("@HAB_PAGOTARJETA", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IHAB_PAGOTARJETA"])
                {
                    auxPar.Value = oCPERSONA.IHAB_PAGOTARJETA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@HAB_PAGOCREDITO", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IHAB_PAGOCREDITO"])
                {
                    auxPar.Value = oCPERSONA.IHAB_PAGOCREDITO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HAB_PAGOCHEQUE", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IHAB_PAGOCHEQUE"])
                {
                    auxPar.Value = oCPERSONA.IHAB_PAGOCHEQUE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@NUMEROINTERIOR", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["INUMEROINTERIOR"])
                {
                    auxPar.Value = oCPERSONA.INUMEROINTERIOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NUMEROEXTERIOR", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["INUMEROEXTERIOR"])
                {
                    auxPar.Value = oCPERSONA.INUMEROEXTERIOR;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GAFFETE", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IGAFFETE"])
                {
                    auxPar.Value = oCPERSONA.IGAFFETE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@REVISION", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IREVISION"])
                {
                    auxPar.Value = oCPERSONA.IREVISION;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@PAGOS", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IPAGOS"])
                {
                    auxPar.Value = oCPERSONA.IPAGOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BLOQUEADO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IBLOQUEADO"])
                {
                    auxPar.Value = oCPERSONA.IBLOQUEADO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@LIMITECREDITO", FbDbType.Numeric);
                if (!(bool)oCPERSONA.isnull["ILIMITECREDITO"])
                {
                    auxPar.Value = oCPERSONA.ILIMITECREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DIAS", FbDbType.Integer);
                if (!(bool)oCPERSONA.isnull["IDIAS"])
                {
                    auxPar.Value = oCPERSONA.IDIAS;
                }
                else
                {
                    auxPar.Value = "0";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TICKETLARGO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ITICKETLARGO"])
                {
                    auxPar.Value = oCPERSONA.ITICKETLARGO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ENTREGACALLE", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IENTREGACALLE"])
                {
                    auxPar.Value = oCPERSONA.IENTREGACALLE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGANUMEROINTERIOR", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IENTREGANUMEROINTERIOR"])
                {
                    auxPar.Value = oCPERSONA.IENTREGANUMEROINTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGANUMEROEXTERIOR", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IENTREGANUMEROEXTERIOR"])
                {
                    auxPar.Value = oCPERSONA.IENTREGANUMEROEXTERIOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGACOLONIA", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IENTREGACOLONIA"])
                {
                    auxPar.Value = oCPERSONA.IENTREGACOLONIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGAMUNICIPIO", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IENTREGAMUNICIPIO"])
                {
                    auxPar.Value = oCPERSONA.IENTREGAMUNICIPIO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGAESTADO", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IENTREGAESTADO"])
                {
                    auxPar.Value = oCPERSONA.IENTREGAESTADO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);
                auxPar = new FbParameter("@ENTREGACODIGOPOSTAL", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IENTREGACODIGOPOSTAL"])
                {
                    auxPar.Value = oCPERSONA.IENTREGACODIGOPOSTAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@HAB_PAGOTRANSFERENCIA", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IHAB_PAGOTRANSFERENCIA"])
                {
                    auxPar.Value = oCPERSONA.IHAB_PAGOTRANSFERENCIA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREDITOFORMAPAGOABONOS", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ICREDITOFORMAPAGOABONOS"])
                {
                    auxPar.Value = oCPERSONA.ICREDITOFORMAPAGOABONOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CREDITOREFERENCIAABONOS", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICREDITOREFERENCIAABONOS"])
                {
                    auxPar.Value = oCPERSONA.ICREDITOREFERENCIAABONOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RETIENEISR", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IRETIENEISR"])
                {
                    auxPar.Value = oCPERSONA.IRETIENEISR;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@RETIENEIVA", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IRETIENEIVA"])
                {
                    auxPar.Value = oCPERSONA.IRETIENEIVA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@MONEDAID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IMONEDAID"])
                {
                    auxPar.Value = oCPERSONA.IMONEDAID;
                }
                else
                {
                    auxPar.Value = DBValues._MONEDA_PESOS;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DESGLOSEIEPS", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IDESGLOSEIEPS"])
                {
                    auxPar.Value = oCPERSONA.IDESGLOSEIEPS;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CUENTAIEPS", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICUENTAIEPS"])
                {
                    auxPar.Value = oCPERSONA.ICUENTAIEPS;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUPERLISTAPRECIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ISUPERLISTAPRECIOID"])
                {
                    auxPar.Value = oCPERSONA.ISUPERLISTAPRECIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCPERSONA.isnull["ISALDO"])
                {
                    auxPar.Value = oCPERSONA.ISALDO;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@BLOQUEONOT", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCPERSONA.IBLOQUEONOT;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@EMAIL3", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IEMAIL3"])
                {
                    auxPar.Value = oCPERSONA.IEMAIL3;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMAIL4", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IEMAIL4"])
                {
                    auxPar.Value = oCPERSONA.IEMAIL4;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAJASBOTELLAS", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICAJASBOTELLAS"] && oCPERSONA.ICAJASBOTELLAS.Trim().Length > 0)
                {
                    auxPar.Value = oCPERSONA.ICAJASBOTELLAS;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ESTATUSENVIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IESTATUSENVIOID"])
                {
                    auxPar.Value = oCPERSONA.IESTATUSENVIOID;
                }
                else
                {
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@REPLMODIFICADO", FbDbType.TimeStamp);
                if (!(bool)oCPERSONA.isnull["IREPLMODIFICADO"])
                {
                    auxPar.Value = oCPERSONA.IREPLMODIFICADO;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@REPLCREADO", FbDbType.TimeStamp);
                if (!(bool)oCPERSONA.isnull["IREPLCREADO"])
                {
                    auxPar.Value = oCPERSONA.IREPLCREADO;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PAGOPARCIALIDADES", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IPAGOPARCIALIDADES"])
                {
                    auxPar.Value = oCPERSONA.IPAGOPARCIALIDADES;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@SALDOMOVIL", FbDbType.Numeric);
                if (!(bool)oCPERSONA.isnull["ISALDOMOVIL"])
                {
                    auxPar.Value = oCPERSONA.ISALDOMOVIL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDOVENCIDOMOVIL", FbDbType.Numeric);
                if (!(bool)oCPERSONA.isnull["ISALDOVENCIDOMOVIL"])
                {
                    auxPar.Value = oCPERSONA.ISALDOVENCIDOMOVIL;
                }
                else
                {
                    auxPar.Value = 0;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@GRUPOUSUARIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IGRUPOUSUARIOID"])
                {
                    auxPar.Value = oCPERSONA.IGRUPOUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CREDITOFORMAPAGOSATABONOS", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ICREDITOFORMAPAGOSATABONOS"])
                {
                    auxPar.Value = oCPERSONA.ICREDITOFORMAPAGOSATABONOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SERVICIOADOMICILIO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ISERVICIOADOMICILIO"])
                {
                    auxPar.Value = oCPERSONA.ISERVICIOADOMICILIO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@REFERENCIAMOVIL", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IREFERENCIAMOVIL"])
                {
                    auxPar.Value = oCPERSONA.IREFERENCIAMOVIL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GENERARRECIBOELECTRONICO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IGENERARRECIBOELECTRONICO"])
                {
                    auxPar.Value = oCPERSONA.IGENERARRECIBOELECTRONICO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@LOCALIDAD", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ILOCALIDAD"])
                {
                    auxPar.Value = oCPERSONA.ILOCALIDAD;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFERENCIADOM", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IREFERENCIADOM"])
                {
                    auxPar.Value = oCPERSONA.IREFERENCIADOM;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@HAB_PAGOEFECTIVO", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IHAB_PAGOEFECTIVO"])
                {
                    auxPar.Value = oCPERSONA.IHAB_PAGOEFECTIVO;
                }
                else
                {
                    auxPar.Value = "S";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLERKPAGOSERVICIOSID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ICLERKPAGOSERVICIOSID"])
                {
                    auxPar.Value = oCPERSONA.ICLERKPAGOSERVICIOSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLERKSERVICIOS", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ICLERKSERVICIOS"])
                {
                    auxPar.Value = oCPERSONA.ICLERKSERVICIOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SOLICITAORDENCOMPRA", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ISOLICITAORDENCOMPRA"])
                {
                    auxPar.Value = oCPERSONA.ISOLICITAORDENCOMPRA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CUENTACONTPAQ", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICUENTACONTPAQ"])
                {
                    auxPar.Value = oCPERSONA.ICUENTACONTPAQ;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ESIMPORTADOR", FbDbType.Char);
                if (!(bool)oCPERSONA.isnull["IESIMPORTADOR"])
                {
                    auxPar.Value = oCPERSONA.IESIMPORTADOR;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SEPARARPRODXPLAZO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ISEPARARPRODXPLAZO"])
                {
                    auxPar.Value = oCPERSONA.ISEPARARPRODXPLAZO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CARGOXVENTACONTARJETA", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICARGOXVENTACONTARJETA"])
                {
                    auxPar.Value = oCPERSONA.ICARGOXVENTACONTARJETA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PAGOTARJMENORPRECIOLISTA", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IPAGOTARJMENORPRECIOLISTA"])
                {
                    auxPar.Value = oCPERSONA.IPAGOTARJMENORPRECIOLISTA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SAT_CLAVE_PAIS", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ISAT_CLAVE_PAIS"])
                {
                    auxPar.Value = oCPERSONA.ISAT_CLAVE_PAIS;
                }
                else
                {
                    auxPar.Value = "MEX";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PROVEECLIENTEID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IPROVEECLIENTEID"])
                {
                    auxPar.Value = oCPERSONA.IPROVEECLIENTEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@EXENTOIVA", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IEXENTOIVA"])
                {
                    auxPar.Value = oCPERSONA.IEXENTOIVA;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_USOCFDIID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ISAT_USOCFDIID"])
                {
                    auxPar.Value = oCPERSONA.ISAT_USOCFDIID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@POR_COME", FbDbType.Numeric);
                if (!(bool)oCPERSONA.isnull["IPOR_COME"])
                {
                    auxPar.Value = oCPERSONA.IPOR_COME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@DIAS_EXTR", FbDbType.Integer);
                if (!(bool)oCPERSONA.isnull["IDIAS_EXTR"])
                {
                    auxPar.Value = oCPERSONA.IDIAS_EXTR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ADESCPES", FbDbType.Numeric);
                if (!(bool)oCPERSONA.isnull["IADESCPES"])
                {
                    auxPar.Value = oCPERSONA.IADESCPES;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RUTAEMBARQUEID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IRUTAEMBARQUEID"])
                {
                    auxPar.Value = oCPERSONA.IRUTAEMBARQUEID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@SUBTIPOCLIENTE", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ISUBTIPOCLIENTE"])
                {
                    auxPar.Value = oCPERSONA.ISUBTIPOCLIENTE;
                }
                else
                {
                    auxPar.Value = DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@PREGUNTARTICKETLARGO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IPREGUNTARTICKETLARGO"])
                {
                    auxPar.Value = oCPERSONA.IPREGUNTARTICKETLARGO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@MAYOREOXPRODUCTO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IMAYOREOXPRODUCTO"])
                {
                    auxPar.Value = oCPERSONA.IMAYOREOXPRODUCTO;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@GENERACOMPROBTRASL", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IGENERACOMPROBTRASL"])
                {
                    auxPar.Value = oCPERSONA.IGENERACOMPROBTRASL;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@GENERACARTAPORTE", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IGENERACARTAPORTE"])
                {
                    auxPar.Value = oCPERSONA.IGENERACARTAPORTE;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SAT_COLONIAID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ISAT_COLONIAID"])
                {
                    auxPar.Value = oCPERSONA.ISAT_COLONIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_LOCALIDADID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ISAT_LOCALIDADID"])
                {
                    auxPar.Value = oCPERSONA.ISAT_LOCALIDADID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@SAT_MUNICIPIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ISAT_MUNICIPIOID"])
                {
                    auxPar.Value = oCPERSONA.ISAT_MUNICIPIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@DISTANCIA", FbDbType.Numeric);
                if (!(bool)oCPERSONA.isnull["IDISTANCIA"])
                {
                    auxPar.Value = oCPERSONA.IDISTANCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@ENTREGA_SAT_COLONIAID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IENTREGA_SAT_COLONIAID"])
                {
                    auxPar.Value = oCPERSONA.IENTREGA_SAT_COLONIAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENTREGA_SAT_LOCALIDADID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IENTREGA_SAT_LOCALIDADID"])
                {
                    auxPar.Value = oCPERSONA.IENTREGA_SAT_LOCALIDADID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENTREGA_SAT_MUNICIPIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IENTREGA_SAT_MUNICIPIOID"])
                {
                    auxPar.Value = oCPERSONA.IENTREGA_SAT_MUNICIPIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ENTREGA_DISTANCIA", FbDbType.Numeric);
                if (!(bool)oCPERSONA.isnull["IENTREGA_DISTANCIA"])
                {
                    auxPar.Value = oCPERSONA.IENTREGA_DISTANCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                

                auxPar = new FbParameter("@ENTREGAREFERENCIADOM", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IENTREGAREFERENCIADOM"])
                {
                    auxPar.Value = oCPERSONA.IENTREGAREFERENCIADOM;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@SAT_REGIMENFISCALID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ISAT_REGIMENFISCALID"])
                {
                    auxPar.Value = oCPERSONA.ISAT_REGIMENFISCALID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@NOMBREIMPRESORA", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["INOMBREIMPRESORA"])
                {
                    auxPar.Value = oCPERSONA.INOMBREIMPRESORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@FIRMAIMAGEN", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IFIRMAIMAGEN"])
                {
                    auxPar.Value = oCPERSONA.IFIRMAIMAGEN;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LATITUD", FbDbType.Double);
                if (!(bool)oCPERSONA.isnull["ILATITUD"])
                {
                    auxPar.Value = oCPERSONA.ILATITUD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LONGITUD", FbDbType.Double);
                if (!(bool)oCPERSONA.isnull["ILONGITUD"])
                {
                    auxPar.Value = oCPERSONA.ILONGITUD;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                string commandText = @"
        INSERT INTO PERSONA
      (
    
ID,

ACTIVO,

CREADOPOR_USERID,

MODIFICADOPOR_USERID,

TIPOPERSONAID,

CLAVE,

NOMBRE,

DESCRIPCION,

MEMO,

SALUDOID,

NOMBRES,

APELLIDOS,

RAZONSOCIAL,

RFC,

CONTACTO1,

CONTACTO2,

USERNAME,

CLAVEACCESO,

DOMICILIO,

COLONIA,

CIUDAD,

MUNICIPIO,

ESTADO,

PAIS,

CODIGOPOSTAL,

TELEFONO1,

TELEFONO2,

TELEFONO3,

CELULAR,

NEXTEL,

EMAIL1,

EMAIL2,

EMPRESAID,

VENDEDORID,

ESCLIENTE,

ESCLIENTEGENERAL,

ESPROVEEDOR,

ESUSUARIO,

LISTAPRECIOID,

VIGENCIA,

RESET_PASS,

HAB_PAGOTARJETA,

HAB_PAGOCREDITO,

HAB_PAGOCHEQUE,

NUMEROINTERIOR,

NUMEROEXTERIOR,

GAFFETE,

LIMITECREDITO,

DIAS,

REVISION,

PAGOS,

BLOQUEADO,

TICKETLARGO,

ENTREGACALLE,
ENTREGANUMEROINTERIOR,
ENTREGANUMEROEXTERIOR,
ENTREGACOLONIA,
ENTREGAMUNICIPIO,
ENTREGAESTADO,
ENTREGACODIGOPOSTAL,

HAB_PAGOTRANSFERENCIA,
CREDITOFORMAPAGOABONOS,
CREDITOREFERENCIAABONOS,
RETIENEISR,

RETIENEIVA,

MONEDAID,

DESGLOSEIEPS,

CUENTAIEPS,

SUPERLISTAPRECIOID,

SALDO,

BLOQUEONOT,

EMAIL3,

EMAIL4,

CAJASBOTELLAS,

ESTATUSENVIOID,

REPLMODIFICADO,

REPLCREADO,

PAGOPARCIALIDADES,

SALDOMOVIL,

SALDOVENCIDOMOVIL,

GRUPOUSUARIOID,

CREDITOFORMAPAGOSATABONOS,

SERVICIOADOMICILIO,

REFERENCIAMOVIL,

GENERARRECIBOELECTRONICO,

LOCALIDAD,

REFERENCIADOM,

HAB_PAGOEFECTIVO,

CLERKPAGOSERVICIOSID,

CLERKSERVICIOS,

SOLICITAORDENCOMPRA,

CUENTACONTPAQ ,

ESIMPORTADOR,

SEPARARPRODXPLAZO,

CARGOXVENTACONTARJETA,

PAGOTARJMENORPRECIOLISTA,

SAT_CLAVE_PAIS,

PROVEECLIENTEID,

EXENTOIVA,

POR_COME,

DIAS_EXTR,

ADESCPES,

RUTAEMBARQUEID,

SUBTIPOCLIENTE,

PREGUNTARTICKETLARGO,

MAYOREOXPRODUCTO,

GENERACOMPROBTRASL,

GENERACARTAPORTE,

SAT_COLONIAID,

SAT_LOCALIDADID,

SAT_MUNICIPIOID,

DISTANCIA,

ENTREGA_SAT_COLONIAID,

ENTREGA_SAT_LOCALIDADID,

ENTREGA_SAT_MUNICIPIOID,

ENTREGA_DISTANCIA,

ENTREGAREFERENCIADOM,

SAT_USOCFDIID,

SAT_REGIMENFISCALID,

NOMBREIMPRESORA,

FIRMAIMAGEN,

LATITUD,

LONGITUD

         )

Values (

@ID,

@ACTIVO,

@CREADOPOR_USERID,

@MODIFICADOPOR_USERID,

@TIPOPERSONAID,

@CLAVE,

@NOMBRE,

@DESCRIPCION,

@MEMO,

@SALUDOID,

@NOMBRES,

@APELLIDOS,

@RAZONSOCIAL,

@RFC,

@CONTACTO1,

@CONTACTO2,

@USERNAME,

@CLAVEACCESO,

@DOMICILIO,

@COLONIA,

@CIUDAD,

@MUNICIPIO,

@ESTADO,

@PAIS,

@CODIGOPOSTAL,

@TELEFONO1,

@TELEFONO2,

@TELEFONO3,

@CELULAR,

@NEXTEL,

@EMAIL1,

@EMAIL2,

@EMPRESAID,

@VENDEDORID,

@ESCLIENTE,

@ESCLIENTEGENERAL,

@ESPROVEEDOR,

@ESUSUARIO,

@LISTAPRECIOID,

@VIGENCIA,

@RESET_PASS,

@HAB_PAGOTARJETA,

@HAB_PAGOCREDITO,

@HAB_PAGOCHEQUE,

@NUMEROINTERIOR,

@NUMEROEXTERIOR,

@GAFFETE,

@LIMITECREDITO,

@DIAS,

@REVISION,

@PAGOS,

@BLOQUEADO,

@TICKETLARGO,
@ENTREGACALLE,
@ENTREGANUMEROINTERIOR,
@ENTREGANUMEROEXTERIOR,
@ENTREGACOLONIA,
@ENTREGAMUNICIPIO,
@ENTREGAESTADO,
@ENTREGACODIGOPOSTAL,

@HAB_PAGOTRANSFERENCIA,
@CREDITOFORMAPAGOABONOS,
@CREDITOREFERENCIAABONOS,
@RETIENEISR,

@RETIENEIVA,

@MONEDAID,

@DESGLOSEIEPS,

@CUENTAIEPS,

@SUPERLISTAPRECIOID,

@SALDO,

@BLOQUEONOT,

@EMAIL3,

@EMAIL4,

@CAJASBOTELLAS,

@ESTATUSENVIOID,

@REPLMODIFICADO,

@REPLCREADO,

@PAGOPARCIALIDADES,

@SALDOMOVIL,

@SALDOVENCIDOMOVIL,

@GRUPOUSUARIOID,

@CREDITOFORMAPAGOSATABONOS,

@SERVICIOADOMICILIO,

@REFERENCIAMOVIL,

@GENERARRECIBOELECTRONICO,

@LOCALIDAD,

@REFERENCIADOM,

@HAB_PAGOEFECTIVO,

@CLERKPAGOSERVICIOSID,

@CLERKSERVICIOS,

@SOLICITAORDENCOMPRA,

@CUENTACONTPAQ ,

@ESIMPORTADOR, 

@SEPARARPRODXPLAZO,

@CARGOXVENTACONTARJETA,

@PAGOTARJMENORPRECIOLISTA,

@SAT_CLAVE_PAIS,

@PROVEECLIENTEID,

@EXENTOIVA,

@POR_COME,

@DIAS_EXTR,

@ADESCPES,

@RUTAEMBARQUEID,

@SUBTIPOCLIENTE,

@PREGUNTARTICKETLARGO,

@MAYOREOXPRODUCTO,

@GENERACOMPROBTRASL,

@GENERACARTAPORTE,

@SAT_COLONIAID,

@SAT_LOCALIDADID,

@SAT_MUNICIPIOID,

@DISTANCIA,

@ENTREGA_SAT_COLONIAID,

@ENTREGA_SAT_LOCALIDADID,

@ENTREGA_SAT_MUNICIPIOID,

@ENTREGA_DISTANCIA,

@ENTREGAREFERENCIADOM,

@SAT_USOCFDIID,

@SAT_REGIMENFISCALID,

@NOMBREIMPRESORA,

@FIRMAIMAGEN,

@LATITUD,

@LONGITUD
       
); ";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.Text, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.Text, commandText, arParms);






                return oCPERSONA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        
        public bool BorrarPERSONAD(CPERSONABE oCPERSONA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONA.IID;
                parts.Add(auxPar);



                string commandText = @"  Delete from PERSONA
  where

  ID=@ID
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


        
        public bool CambiarPERSONAD(CPERSONABE oCPERSONANuevo, CPERSONABE oCPERSONAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                //auxPar = new FbParameter("@ID", FbDbType.BigInt);
                //if (!(bool)oCPERSONANuevo.isnull["IID"])
                //{
                //    auxPar.Value = oCPERSONANuevo.IID;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}
                //parts.Add(auxPar);

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

                //auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                //if (!(bool)oCPERSONANuevo.isnull["ICREADOPOR_USERID"])
                //{
                //    auxPar.Value = oCPERSONANuevo.ICREADOPOR_USERID;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}
                //parts.Add(auxPar);

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

                auxPar = new FbParameter("@TIPOPERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ITIPOPERSONAID"])
                {
                    auxPar.Value = oCPERSONANuevo.ITIPOPERSONAID;
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

                auxPar = new FbParameter("@USERNAME", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IUSERNAME"])
                {
                    auxPar.Value = oCPERSONANuevo.IUSERNAME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVEACCESO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICLAVEACCESO"])
                {
                    auxPar.Value = oCPERSONANuevo.ICLAVEACCESO;
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

                auxPar = new FbParameter("@ESCLIENTE", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IESCLIENTE"])
                {
                    auxPar.Value = oCPERSONANuevo.IESCLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESCLIENTEGENERAL", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IESCLIENTEGENERAL"])
                {
                    auxPar.Value = oCPERSONANuevo.IESCLIENTEGENERAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESPROVEEDOR", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IESPROVEEDOR"])
                {
                    auxPar.Value = oCPERSONANuevo.IESPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESUSUARIO", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IESUSUARIO"])
                {
                    auxPar.Value = oCPERSONANuevo.IESUSUARIO;
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

                auxPar = new FbParameter("@RESET_PASS", FbDbType.SmallInt);
                if (!(bool)oCPERSONANuevo.isnull["IRESET_PASS"])
                {
                    auxPar.Value = oCPERSONANuevo.IRESET_PASS;
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


                auxPar = new FbParameter("@GAFFETE", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IGAFFETE"])
                {
                    auxPar.Value = oCPERSONANuevo.IGAFFETE;
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


                auxPar = new FbParameter("SUPERLISTAPRECIOID", FbDbType.BigInt);
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
                    auxPar.Value = 1;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PAGOPARCIALIDADES", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IPAGOPARCIALIDADES"])
                {
                    auxPar.Value = oCPERSONANuevo.IPAGOPARCIALIDADES;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@GRUPOUSUARIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IGRUPOUSUARIOID"])
                {
                    auxPar.Value = oCPERSONANuevo.IGRUPOUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CLERKPAGOSERVICIOSID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ICLERKPAGOSERVICIOSID"])
                {
                    auxPar.Value = oCPERSONANuevo.ICLERKPAGOSERVICIOSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CLERKSERVICIOS", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ICLERKSERVICIOS"])
                {
                    auxPar.Value = oCPERSONANuevo.ICLERKSERVICIOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
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


                auxPar = new FbParameter("@ESIMPORTADOR", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IESIMPORTADOR"])
                {
                    auxPar.Value = oCPERSONANuevo.IESIMPORTADOR;
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


                auxPar = new FbParameter("@ADESCPES", FbDbType.Numeric);
                if (!(bool)oCPERSONANuevo.isnull["IADESCPES"])
                {
                    auxPar.Value = oCPERSONANuevo.IADESCPES;
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


                auxPar = new FbParameter("@SUBTIPOCLIENTE", FbDbType.VarChar);
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



                auxPar = new FbParameter("@NOMBREIMPRESORA", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["INOMBREIMPRESORA"])
                {
                    auxPar.Value = oCPERSONANuevo.INOMBREIMPRESORA;
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

TIPOPERSONAID = @TIPOPERSONAID,

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

USERNAME=@USERNAME,

CLAVEACCESO=@CLAVEACCESO,

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

ESCLIENTE=@ESCLIENTE,

ESCLIENTEGENERAL=@ESCLIENTEGENERAL,

ESPROVEEDOR=@ESPROVEEDOR,

ESUSUARIO=@ESUSUARIO,

LISTAPRECIOID=@LISTAPRECIOID,

VIGENCIA=@VIGENCIA,

RESET_PASS=@RESET_PASS,

HAB_PAGOTARJETA=@HAB_PAGOTARJETA,

HAB_PAGOCREDITO=@HAB_PAGOCREDITO,

HAB_PAGOCHEQUE=@HAB_PAGOCHEQUE,

NUMEROINTERIOR = @NUMEROINTERIOR,

NUMEROEXTERIOR = @NUMEROEXTERIOR,

GAFFETE = @GAFFETE,

MONEDAID = @MONEDAID,

DESGLOSEIEPS = @DESGLOSEIEPS,

CUENTAIEPS = @CUENTAIEPS,

SUPERLISTAPRECIOID = @SUPERLISTAPRECIOID,

EMAIL3=@EMAIL3,

EMAIL4=@EMAIL4,

ESTATUSENVIOID = @ESTATUSENVIOID,

PAGOPARCIALIDADES = @PAGOPARCIALIDADES,

GRUPOUSUARIOID = @GRUPOUSUARIOID,

HAB_PAGOEFECTIVO = @HAB_PAGOEFECTIVO,

CLERKPAGOSERVICIOSID = @CLERKPAGOSERVICIOSID,

CLERKSERVICIOS = @CLERKSERVICIOS,

SOLICITAORDENCOMPRA = @SOLICITAORDENCOMPRA, 

CUENTACONTPAQ = @CUENTACONTPAQ,

ESIMPORTADOR = @ESIMPORTADOR,

SEPARARPRODXPLAZO = @SEPARARPRODXPLAZO,

CARGOXVENTACONTARJETA = @CARGOXVENTACONTARJETA,

PAGOTARJMENORPRECIOLISTA = @PAGOTARJMENORPRECIOLISTA,

SAT_CLAVE_PAIS = @SAT_CLAVE_PAIS,

PROVEECLIENTEID = @PROVEECLIENTEID,

EXENTOIVA = @EXENTOIVA, 

SAT_USOCFDIID = @SAT_USOCFDIID,

ADESCPES = @ADESCPES,

RUTAEMBARQUEID = @RUTAEMBARQUEID,

SUBTIPOCLIENTE = @SUBTIPOCLIENTE,

PREGUNTARTICKETLARGO = @PREGUNTARTICKETLARGO,

MAYOREOXPRODUCTO = @MAYOREOXPRODUCTO,

GENERACOMPROBTRASL = @GENERACOMPROBTRASL,

GENERACARTAPORTE = GENERACARTAPORTE,

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

NOMBREIMPRESORA = @NOMBREIMPRESORA,

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





        public bool CambiarPERSONADMovil(CPERSONABE oCPERSONANuevo, CPERSONABE oCPERSONAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                //auxPar = new FbParameter("@ID", FbDbType.BigInt);
                //if (!(bool)oCPERSONANuevo.isnull["IID"])
                //{
                //    auxPar.Value = oCPERSONANuevo.IID;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}
                //parts.Add(auxPar);

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

                //auxPar = new FbParameter("@CREADOPOR_USERID", FbDbType.BigInt);
                //if (!(bool)oCPERSONANuevo.isnull["ICREADOPOR_USERID"])
                //{
                //    auxPar.Value = oCPERSONANuevo.ICREADOPOR_USERID;
                //}
                //else
                //{
                //    auxPar.Value = System.DBNull.Value;
                //}
                //parts.Add(auxPar);

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

                auxPar = new FbParameter("@TIPOPERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ITIPOPERSONAID"])
                {
                    auxPar.Value = oCPERSONANuevo.ITIPOPERSONAID;
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

                auxPar = new FbParameter("@USERNAME", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IUSERNAME"])
                {
                    auxPar.Value = oCPERSONANuevo.IUSERNAME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLAVEACCESO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICLAVEACCESO"])
                {
                    auxPar.Value = oCPERSONANuevo.ICLAVEACCESO;
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

                auxPar = new FbParameter("@ESCLIENTE", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IESCLIENTE"])
                {
                    auxPar.Value = oCPERSONANuevo.IESCLIENTE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESCLIENTEGENERAL", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IESCLIENTEGENERAL"])
                {
                    auxPar.Value = oCPERSONANuevo.IESCLIENTEGENERAL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESPROVEEDOR", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IESPROVEEDOR"])
                {
                    auxPar.Value = oCPERSONANuevo.IESPROVEEDOR;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@ESUSUARIO", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IESUSUARIO"])
                {
                    auxPar.Value = oCPERSONANuevo.IESUSUARIO;
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

                auxPar = new FbParameter("@RESET_PASS", FbDbType.SmallInt);
                if (!(bool)oCPERSONANuevo.isnull["IRESET_PASS"])
                {
                    auxPar.Value = oCPERSONANuevo.IRESET_PASS;
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


                auxPar = new FbParameter("@GAFFETE", FbDbType.Char);
                if (!(bool)oCPERSONANuevo.isnull["IGAFFETE"])
                {
                    auxPar.Value = oCPERSONANuevo.IGAFFETE;
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


                auxPar = new FbParameter("SUPERLISTAPRECIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ISUPERLISTAPRECIOID"])
                {
                    auxPar.Value = oCPERSONANuevo.ISUPERLISTAPRECIOID;
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


                auxPar = new FbParameter("@SALDO", FbDbType.Numeric);
                if (!(bool)oCPERSONANuevo.isnull["ISALDO"])
                {
                    auxPar.Value = oCPERSONANuevo.ISALDO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@BLOQUEONOT", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IBLOQUEONOT"])
                {
                    auxPar.Value = oCPERSONANuevo.IBLOQUEONOT;
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



                auxPar = new FbParameter("@SALDOMOVIL", FbDbType.Numeric);
                if (!(bool)oCPERSONANuevo.isnull["ISALDOMOVIL"])
                {
                    auxPar.Value = oCPERSONANuevo.ISALDOMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@SALDOVENCIDOMOVIL", FbDbType.Numeric);
                if (!(bool)oCPERSONANuevo.isnull["ISALDOVENCIDOMOVIL"])
                {
                    auxPar.Value = oCPERSONANuevo.ISALDOVENCIDOMOVIL;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@REFERENCIAMOVIL", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IREFERENCIAMOVIL"])
                {
                    auxPar.Value = oCPERSONANuevo.IREFERENCIAMOVIL;
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




                auxPar = new FbParameter("@ADESCPES", FbDbType.Numeric);
                if (!(bool)oCPERSONANuevo.isnull["IADESCPES"])
                {
                    auxPar.Value = oCPERSONANuevo.IADESCPES;
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


                string commandText = @"  
update  PERSONA
  set

ACTIVO=@ACTIVO,

MODIFICADOPOR_USERID=@MODIFICADOPOR_USERID,

TIPOPERSONAID = @TIPOPERSONAID,

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

USERNAME=@USERNAME,

CLAVEACCESO=@CLAVEACCESO,

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

ESCLIENTE=@ESCLIENTE,

ESCLIENTEGENERAL=@ESCLIENTEGENERAL,

ESPROVEEDOR=@ESPROVEEDOR,

ESUSUARIO=@ESUSUARIO,

LISTAPRECIOID=@LISTAPRECIOID,

VIGENCIA=@VIGENCIA,

RESET_PASS=@RESET_PASS,

HAB_PAGOTARJETA=@HAB_PAGOTARJETA,

HAB_PAGOCREDITO=@HAB_PAGOCREDITO,

HAB_PAGOCHEQUE=@HAB_PAGOCHEQUE,

NUMEROINTERIOR = @NUMEROINTERIOR,

NUMEROEXTERIOR = @NUMEROEXTERIOR,

GAFFETE = @GAFFETE,

MONEDAID = @MONEDAID,

DESGLOSEIEPS = @DESGLOSEIEPS,

CUENTAIEPS = @CUENTAIEPS,

SUPERLISTAPRECIOID = @SUPERLISTAPRECIOID,

PAGOS = @PAGOS,

BLOQUEADO = @BLOQUEADO,

LIMITECREDITO = @LIMITECREDITO,

DIAS = @DIAS,

SALDO = @SALDO,
BLOQUEONOT = @BLOQUEONOT,

EMAIL3=@EMAIL3,

EMAIL4=@EMAIL4,

SALDOMOVIL = @SALDOMOVIL,

SALDOVENCIDOMOVIL = @SALDOVENCIDOMOVIL,

REFERENCIAMOVIL = @REFERENCIAMOVIL,

HAB_PAGOEFECTIVO = @HAB_PAGOEFECTIVO,

POR_COME = @POR_COME,

DIAS_EXTR = @DIAS_EXTR,

ADESCPES = @ADESCPES

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



        [AutoComplete]
        public CPERSONABE seleccionarPERSONA(CPERSONABE oCPERSONA, FbTransaction st)
        {




            CPERSONABE retorno = new CPERSONABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONA where
 ID=@ID  ";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONA.IID;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["TIPOPERSONAID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPERSONAID = (long)(dr["TIPOPERSONAID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        retorno.IMEMO = (string)(dr["MEMO"]);
                    }

                    if (dr["SALUDOID"] != System.DBNull.Value)
                    {
                        retorno.ISALUDOID = (long)(dr["SALUDOID"]);
                    }

                    if (dr["NOMBRES"] != System.DBNull.Value)
                    {
                        retorno.INOMBRES = (string)(dr["NOMBRES"]);
                    }

                    if (dr["APELLIDOS"] != System.DBNull.Value)
                    {
                        retorno.IAPELLIDOS = (string)(dr["APELLIDOS"]);
                    }

                    if (dr["RAZONSOCIAL"] != System.DBNull.Value)
                    {
                        retorno.IRAZONSOCIAL = (string)(dr["RAZONSOCIAL"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["CONTACTO1"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO1 = (string)(dr["CONTACTO1"]);
                    }

                    if (dr["CONTACTO2"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO2 = (string)(dr["CONTACTO2"]);
                    }

                    if (dr["USERNAME"] != System.DBNull.Value)
                    {
                        retorno.IUSERNAME = (string)(dr["USERNAME"]);
                    }

                    if (dr["CLAVEACCESO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEACCESO = (string)(dr["CLAVEACCESO"]);
                    }

                    if (dr["DOMICILIO"] != System.DBNull.Value)
                    {
                        retorno.IDOMICILIO = (string)(dr["DOMICILIO"]);
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        retorno.ICIUDAD = (string)(dr["CIUDAD"]);
                    }

                    if (dr["MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IMUNICIPIO = (string)(dr["MUNICIPIO"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }

                    if (dr["PAIS"] != System.DBNull.Value)
                    {
                        retorno.IPAIS = (string)(dr["PAIS"]);
                    }

                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = (string)(dr["CODIGOPOSTAL"]);
                    }

                    if (dr["TELEFONO1"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO1 = (string)(dr["TELEFONO1"]);
                    }

                    if (dr["TELEFONO2"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO2 = (string)(dr["TELEFONO2"]);
                    }

                    if (dr["TELEFONO3"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO3 = (string)(dr["TELEFONO3"]);
                    }

                    if (dr["CELULAR"] != System.DBNull.Value)
                    {
                        retorno.ICELULAR = (string)(dr["CELULAR"]);
                    }

                    if (dr["NEXTEL"] != System.DBNull.Value)
                    {
                        retorno.INEXTEL = (string)(dr["NEXTEL"]);
                    }

                    if (dr["EMAIL1"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL1 = (string)(dr["EMAIL1"]);
                    }

                    if (dr["EMAIL2"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL2 = (string)(dr["EMAIL2"]);
                    }

                    if (dr["EMPRESAID"] != System.DBNull.Value)
                    {
                        retorno.IEMPRESAID = (long)(dr["EMPRESAID"]);
                    }

                    if (dr["VENDEDORID"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORID = (long)(dr["VENDEDORID"]);
                    }

                    if (dr["ESCLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IESCLIENTE = (string)(dr["ESCLIENTE"]);
                    }

                    if (dr["ESCLIENTEGENERAL"] != System.DBNull.Value)
                    {
                        retorno.IESCLIENTEGENERAL = (string)(dr["ESCLIENTEGENERAL"]);
                    }

                    if (dr["ESPROVEEDOR"] != System.DBNull.Value)
                    {
                        retorno.IESPROVEEDOR = (string)(dr["ESPROVEEDOR"]);
                    }

                    if (dr["ESUSUARIO"] != System.DBNull.Value)
                    {
                        retorno.IESUSUARIO = (string)(dr["ESUSUARIO"]);
                    }

                    if (dr["LISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOID = (long)(dr["LISTAPRECIOID"]);
                    }

                    if (dr["VIGENCIA"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIA = (DateTime)(dr["VIGENCIA"]);
                    }

                    if (dr["RESET_PASS"] != System.DBNull.Value)
                    {
                        retorno.IRESET_PASS = short.Parse(dr["RESET_PASS"].ToString());
                    }


                    if (dr["HAB_PAGOTARJETA"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOTARJETA = (string)(dr["HAB_PAGOTARJETA"]);
                    }

                    if (dr["HAB_PAGOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOCREDITO = (string)(dr["HAB_PAGOCREDITO"]);
                    }

                    if (dr["HAB_PAGOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOCHEQUE = (string)(dr["HAB_PAGOCHEQUE"]);
                    }

                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }
                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }


                    if (dr["SALDOAPARTADO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADO = (decimal)(dr["SALDOAPARTADO"]);
                    }
                    if (dr["SALDOSPOSITIVOS"] != System.DBNull.Value)
                    {
                        retorno.ISALDOSPOSITIVOS = (decimal)(dr["SALDOSPOSITIVOS"]);
                    }
                    if (dr["SALDOSNEGATIVOS"] != System.DBNull.Value)
                    {
                        retorno.ISALDOSNEGATIVOS = (decimal)(dr["SALDOSNEGATIVOS"]);
                    }

                    if (dr["SALDOAPARTADOPOSITIVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADOPOSITIVO = (decimal)(dr["SALDOAPARTADOPOSITIVO"]);
                    }

                    if (dr["SALDOAPARTADONEGATIVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADONEGATIVO = (decimal)(dr["SALDOAPARTADONEGATIVO"]);
                    }
                    if (dr["NUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROINTERIOR = (string)(dr["NUMEROINTERIOR"]);
                    }

                    if (dr["NUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROEXTERIOR = (string)(dr["NUMEROEXTERIOR"]);
                    }

                    if (dr["GAFFETE"] != System.DBNull.Value)
                    {
                        retorno.IGAFFETE = (string)(dr["GAFFETE"]);
                    }


                    if (dr["LIMITECREDITO"] != System.DBNull.Value)
                    {
                        retorno.ILIMITECREDITO = (decimal)(dr["LIMITECREDITO"]);
                    }

                    if (dr["DIAS"] != System.DBNull.Value)
                    {
                        retorno.IDIAS = (int)(dr["DIAS"]);
                    }

                    if (dr["REVISION"] != System.DBNull.Value)
                    {
                        retorno.IREVISION = (string)(dr["REVISION"]);
                    }

                    if (dr["PAGOS"] != System.DBNull.Value)
                    {
                        retorno.IPAGOS = (string)(dr["PAGOS"]);
                    }

                    if (dr["BLOQUEADO"] != System.DBNull.Value)
                    {
                        retorno.IBLOQUEADO = (string)(dr["BLOQUEADO"]);
                    }

                    if (dr["TICKETLARGO"] != System.DBNull.Value)
                    {
                        retorno.ITICKETLARGO = (string)(dr["TICKETLARGO"]);
                    }

                    if (dr["ENTREGACALLE"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
                    }
                    if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
                    }
                    if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
                    }
                    if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
                    }
                    if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
                    }
                    if (dr["ENTREGAESTADO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
                    }
                    if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
                    }


                    if (dr["HAB_PAGOTRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOTRANSFERENCIA = (string)(dr["HAB_PAGOTRANSFERENCIA"]);
                    }


                    if (dr["CREDITOFORMAPAGOABONOS"] != System.DBNull.Value)
                    {
                        retorno.ICREDITOFORMAPAGOABONOS = (long)(dr["CREDITOFORMAPAGOABONOS"]);
                    }


                    if (dr["CREDITOREFERENCIAABONOS"] != System.DBNull.Value)
                    {
                        retorno.ICREDITOREFERENCIAABONOS = (string)(dr["CREDITOREFERENCIAABONOS"]);
                    }

                    if (dr["RETIENEISR"] != System.DBNull.Value)
                    {
                        retorno.IRETIENEISR = (string)(dr["RETIENEISR"]);
                    }

                    if (dr["RETIENEIVA"] != System.DBNull.Value)
                    {
                        retorno.IRETIENEIVA = (string)(dr["RETIENEIVA"]);
                    }

                    if (dr["MONEDAID"] != System.DBNull.Value)
                    {
                        retorno.IMONEDAID = (long)(dr["MONEDAID"]);
                    }


                    if (dr["DESGLOSEIEPS"] != System.DBNull.Value)
                    {
                        retorno.IDESGLOSEIEPS = (string)(dr["DESGLOSEIEPS"]);
                    }

                    if (dr["CUENTAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAIEPS = (string)(dr["CUENTAIEPS"]);
                    }

                    if (dr["SUPERLISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.ISUPERLISTAPRECIOID = (long)(dr["SUPERLISTAPRECIOID"]);
                    }

                    if (dr["ALMACENID"] != System.DBNull.Value)
                    {
                        retorno.IALMACENID = (long)(dr["ALMACENID"]);
                    }


                    if (dr["BLOQUEONOT"] != System.DBNull.Value)
                    {
                        retorno.IBLOQUEONOT = (string)(dr["BLOQUEONOT"]);
                    }



                    if (dr["EMAIL3"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL3 = (string)(dr["EMAIL3"]);
                    }

                    if (dr["EMAIL4"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL4 = (string)(dr["EMAIL4"]);
                    }

                    if (dr["CAJASBOTELLAS"] != System.DBNull.Value)
                    {
                        retorno.ICAJASBOTELLAS = (string)(dr["CAJASBOTELLAS"]);
                    }

                    if (dr["ESTATUSENVIOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSENVIOID = (long)(dr["ESTATUSENVIOID"]);
                    }


                    if (dr["REPLCREADO"] != System.DBNull.Value)
                    {
                        retorno.IREPLCREADO = (DateTime)(dr["REPLCREADO"]);
                    }
                    if (dr["REPLMODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IREPLMODIFICADO = (DateTime)(dr["REPLMODIFICADO"]);
                    }


                    if (dr["TICKETLARGOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.ITICKETLARGOCREDITO = (string)(dr["TICKETLARGOCREDITO"]);
                    }

                    if (dr["PENDMAXDIAS"] != System.DBNull.Value)
                    {
                        retorno.IPENDMAXDIAS = (int)(dr["PENDMAXDIAS"]);
                    }

                    if (dr["PAGOPARCIALIDADES"] != System.DBNull.Value)
                    {
                        retorno.IPAGOPARCIALIDADES = (string)(dr["PAGOPARCIALIDADES"]);
                    }

                    if (dr["SALDOVENCIDOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOVENCIDOMOVIL = (decimal)(dr["SALDOVENCIDOMOVIL"]);
                    }


                    if (dr["SALDOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOMOVIL = (decimal)(dr["SALDOMOVIL"]);
                    }

                    if (dr["GRUPOUSUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IGRUPOUSUARIOID = (long)(dr["GRUPOUSUARIOID"]);
                    }


                    if (dr["CREDITOFORMAPAGOSATABONOS"] != System.DBNull.Value)
                    {
                        retorno.ICREDITOFORMAPAGOSATABONOS = (long)(dr["CREDITOFORMAPAGOSATABONOS"]);
                    }


                    if (dr["SERVICIOADOMICILIO"] != System.DBNull.Value)
                    {
                        retorno.ISERVICIOADOMICILIO = (string)(dr["SERVICIOADOMICILIO"]);
                    }


                    if (dr["ULTIMAVENTA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAVENTA = (DateTime)(dr["ULTIMAVENTA"]);
                    }

                    if (dr["GENERARRECIBOELECTRONICO"] != System.DBNull.Value)
                    {
                        retorno.IGENERARRECIBOELECTRONICO = (string)(dr["GENERARRECIBOELECTRONICO"]);
                    }

                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }

                    if (dr["REFERENCIADOM"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIADOM = (string)(dr["REFERENCIADOM"]);
                    }

                    if (dr["HAB_PAGOEFECTIVO"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOEFECTIVO = (string)(dr["HAB_PAGOEFECTIVO"]);
                    }


                    if (dr["CLERKPAGOSERVICIOSID"] != System.DBNull.Value)
                    {
                        retorno.ICLERKPAGOSERVICIOSID = (long)(dr["CLERKPAGOSERVICIOSID"]);
                    }

                    if (dr["CLERKSERVICIOS"] != System.DBNull.Value)
                    {
                        retorno.ICLERKSERVICIOS = (long)(dr["CLERKSERVICIOS"]);
                    }

                    if (dr["BANCOMERDOCTOPENDID"] != System.DBNull.Value)
                    {
                        retorno.IBANCOMERDOCTOPENDID = (long)(dr["BANCOMERDOCTOPENDID"]);
                    }


                    if (dr["SOLICITAORDENCOMPRA"] != System.DBNull.Value)
                    {
                        retorno.ISOLICITAORDENCOMPRA = (string)(dr["SOLICITAORDENCOMPRA"]);
                    }


                    if (dr["CUENTACONTPAQ"] != System.DBNull.Value)
                    {
                        retorno.ICUENTACONTPAQ = (string)(dr["CUENTACONTPAQ"]);
                    }


                    if (dr["ESIMPORTADOR"] != System.DBNull.Value)
                    {
                        retorno.IESIMPORTADOR = (string)(dr["ESIMPORTADOR"]);
                    }

                    if (dr["SEPARARPRODXPLAZO"] != System.DBNull.Value)
                    {
                        retorno.ISEPARARPRODXPLAZO = (string)(dr["SEPARARPRODXPLAZO"]);
                    }

                    if (dr["CARGOXVENTACONTARJETA"] != System.DBNull.Value)
                    {
                        retorno.ICARGOXVENTACONTARJETA = (string)(dr["CARGOXVENTACONTARJETA"]);
                    }


                    if (dr["PAGOTARJMENORPRECIOLISTA"] != System.DBNull.Value)
                    {
                        retorno.IPAGOTARJMENORPRECIOLISTA = (string)(dr["PAGOTARJMENORPRECIOLISTA"]);
                    }



                    if (dr["SAT_CLAVE_PAIS"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE_PAIS = (string)(dr["SAT_CLAVE_PAIS"]);
                    }


                    if (dr["PROVEECLIENTEID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEECLIENTEID = (long)(dr["PROVEECLIENTEID"]);
                    }


                    if (dr["EXENTOIVA"] != System.DBNull.Value)
                    {
                        retorno.IEXENTOIVA = (string)(dr["EXENTOIVA"]);
                    }


                    if (dr["TICKETLARGOCOTIZACION"] != System.DBNull.Value)
                    {
                        retorno.ITICKETLARGOCOTIZACION = (string)(dr["TICKETLARGOCOTIZACION"]);
                    }

                    if (dr["CODIGOAUTORIZACION"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOAUTORIZACION= (string)(dr["CODIGOAUTORIZACION"]);
                    }

                    if (dr["SAT_USOCFDIID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_USOCFDIID = (long)(dr["SAT_USOCFDIID"]);
                    }


                    if (dr["CLIEFORMASPAGODEF"] != System.DBNull.Value)
                    {
                        retorno.ICLIEFORMASPAGODEF = (string)(dr["CLIEFORMASPAGODEF"]);
                    }


                    if (dr["RUTAEMBARQUEID"] != System.DBNull.Value)
                    {
                        retorno.IRUTAEMBARQUEID = (long)(dr["RUTAEMBARQUEID"]);
                    }


                    if (dr["SUBTIPOCLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ISUBTIPOCLIENTE = (string)(dr["SUBTIPOCLIENTE"]);
                    }

                    if (dr["PREGUNTARTICKETLARGO"] != System.DBNull.Value)
                    {
                        retorno.IPREGUNTARTICKETLARGO = (string)(dr["PREGUNTARTICKETLARGO"]);
                    }

                    if (dr["MAYOREOXPRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IMAYOREOXPRODUCTO = (string)(dr["MAYOREOXPRODUCTO"]);
                    }

                    if (dr["GENERACOMPROBTRASL"] != System.DBNull.Value)
                    {
                        retorno.IGENERACOMPROBTRASL = (string)(dr["GENERACOMPROBTRASL"]);
                    }

                    if (dr["GENERACARTAPORTE"] != System.DBNull.Value)
                    {
                        retorno.IGENERACARTAPORTE = (string)(dr["GENERACARTAPORTE"]);
                    }

                    if (dr["SAT_COLONIAID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_COLONIAID = (long)(dr["SAT_COLONIAID"]);
                    }

                    if (dr["SAT_LOCALIDADID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_LOCALIDADID = (long)(dr["SAT_LOCALIDADID"]);
                    }

                    if (dr["SAT_MUNICIPIOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_MUNICIPIOID = (long)(dr["SAT_MUNICIPIOID"]);
                    }

                    if (dr["DISTANCIA"] != System.DBNull.Value)
                    {
                        retorno.IDISTANCIA = (decimal)(dr["DISTANCIA"]);
                    }



                    if (dr["ENTREGA_SAT_COLONIAID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_COLONIAID = (long)(dr["ENTREGA_SAT_COLONIAID"]);
                    }

                    if (dr["ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_LOCALIDADID = (long)(dr["ENTREGA_SAT_LOCALIDADID"]);
                    }

                    if (dr["ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_MUNICIPIOID = (long)(dr["ENTREGA_SAT_MUNICIPIOID"]);
                    }

                    if (dr["ENTREGA_DISTANCIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_DISTANCIA = (decimal)(dr["ENTREGA_DISTANCIA"]);
                    }


                    if (dr["ENTREGAREFERENCIADOM"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAREFERENCIADOM = (string)(dr["ENTREGAREFERENCIADOM"]);
                    }

                    if (dr["SAT_REGIMENFISCALID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_REGIMENFISCALID = (long)(dr["SAT_REGIMENFISCALID"]);
                    }
                    
                    if (dr["NOMBREIMPRESORA"] != System.DBNull.Value)
                    {
                        retorno.INOMBREIMPRESORA = (string)(dr["NOMBREIMPRESORA"]);
                    }

                    if (dr["FIRMAIMAGEN"] != System.DBNull.Value)
                    {
                        retorno.IFIRMAIMAGEN = (string)(dr["FIRMAIMAGEN"]);
                    }

                    if (dr["LATITUD"] != System.DBNull.Value)
                    {
                        retorno.ILATITUD = (double)(dr["LATITUD"]);
                    }

                    if (dr["LONGITUD"] != System.DBNull.Value)
                    {
                        retorno.ILONGITUD = (double)(dr["LONGITUD"]);
                    }
                }
                else
                {
                    retorno = null;
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);



                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }









        [AutoComplete]
        public DataSet enlistarPERSONA()
        {

            DataSet retorno;
            try
            {
                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERSONA_enlistar");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        [AutoComplete]
        public DataSet enlistarCortoPERSONA()
        {
            DataSet retorno;
            try
            {

                retorno = SqlHelper.ExecuteDataset(this.sCadenaConexion, CommandType.StoredProcedure, "SisGen_PERSONA_enlistarCorto");

                return retorno;
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        [AutoComplete]
        public int ExistePERSONA(CPERSONABE oCPERSONA, FbTransaction st)
        {
            //1-EXISTE 0-NO EXISTE -1 ERROR
            int retorno;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;



                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = oCPERSONA.IID;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                string commandText = @"select 1 EXISTE
  from RDB$DATABASE
  where exists(
  select * from PERSONA where

  ID=@ID  
  );";






                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, commandText, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, commandText, arParms);



                if (dr.Read())
                {
                    retorno = 1;
                }
                else
                {
                    retorno = 0;
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return -1;
            }
        }




        public CPERSONABE AgregarPERSONA(CPERSONABE oCPERSONA, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONA(oCPERSONA, st);
                if (iRes == 1)
                {
                    this.IComentario = "El PERSONA ya existe";
                    return null;
                }
                else if (iRes == -1)
                {
                    return null;
                }
                return AgregarPERSONAD(oCPERSONA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }


        public bool BorrarPERSONA(CPERSONABE oCPERSONA, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONA(oCPERSONA, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERSONA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return BorrarPERSONAD(oCPERSONA, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }


        public bool CambiarPERSONA(CPERSONABE oCPERSONANuevo, CPERSONABE oCPERSONAAnterior, FbTransaction st)
        {
            try
            {
                int iRes = ExistePERSONA(oCPERSONAAnterior, st);
                if (iRes == 0)
                {
                    this.IComentario = "El PERSONA no existe";
                    return false;
                }
                else if (iRes == -1)
                {
                    return false;
                }
                return CambiarPERSONAD(oCPERSONANuevo, oCPERSONAAnterior, st);
            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }

        }




        public CPERSONABE AgregarPERSONAUSUARIOD(CPERSONABE oCPERSONA,  FbTransaction st)
        {
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICLAVE"])
                {
                    auxPar.Value = oCPERSONA.ICLAVE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBRE", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["INOMBRE"])
                {
                    auxPar.Value = oCPERSONA.INOMBRE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@USERNAME", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IUSERNAME"])
                {
                    auxPar.Value = oCPERSONA.IUSERNAME;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLAVEACCESO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICLAVEACCESO"])
                {
                    auxPar.Value = oCPERSONA.ICLAVEACCESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@EMPRESAID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IEMPRESAID"])
                {
                    auxPar.Value = oCPERSONA.IEMPRESAID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@VIGENCIA", FbDbType.Date);
                if (!(bool)oCPERSONA.isnull["IVIGENCIA"])
                {
                    auxPar.Value = oCPERSONA.IVIGENCIA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESET_PASS", FbDbType.SmallInt);
                if (!(bool)oCPERSONA.isnull["IRESET_PASS"])
                {
                    auxPar.Value = oCPERSONA.IRESET_PASS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@GAFFETE", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IGAFFETE"])
                {
                    auxPar.Value = oCPERSONA.IGAFFETE;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ILISTAPRECIOID"])
                {
                    auxPar.Value = oCPERSONA.ILISTAPRECIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@TICKETLARGO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ITICKETLARGO"])
                {
                    auxPar.Value = oCPERSONA.ITICKETLARGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IALMACENID"])
                {
                    auxPar.Value = oCPERSONA.IALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAJASBOTELLAS", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICAJASBOTELLAS"] && oCPERSONA.ICAJASBOTELLAS.Trim().Length > 0)
                {
                    auxPar.Value = oCPERSONA.ICAJASBOTELLAS;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@TICKETLARGOCREDITO", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ITICKETLARGOCREDITO"])
                {
                    auxPar.Value = oCPERSONA.ITICKETLARGOCREDITO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IVENDEDORID"])
                {
                    auxPar.Value = oCPERSONA.IVENDEDORID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@PENDMAXDIAS", FbDbType.Integer);
                if (!(bool)oCPERSONA.isnull["IPENDMAXDIAS"])
                {
                    auxPar.Value = oCPERSONA.IPENDMAXDIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@GRUPOUSUARIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IGRUPOUSUARIOID"])
                {
                    auxPar.Value = oCPERSONA.IGRUPOUSUARIOID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@EMAIL1", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["IEMAIL1"])
                {
                    auxPar.Value = oCPERSONA.IEMAIL1;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);

                auxPar = new FbParameter("@CLERKPAGOSERVICIOSID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ICLERKPAGOSERVICIOSID"])
                {
                    auxPar.Value = oCPERSONA.ICLERKPAGOSERVICIOSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CLERKSERVICIOS", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["ICLERKSERVICIOS"])
                {
                    auxPar.Value = oCPERSONA.ICLERKSERVICIOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TICKETLARGOCOTIZACION", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ITICKETLARGOCOTIZACION"])
                {
                    auxPar.Value = oCPERSONA.ITICKETLARGOCOTIZACION;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CODIGOAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICODIGOAUTORIZACION"])
                {
                    auxPar.Value = oCPERSONA.ICODIGOAUTORIZACION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLIEFORMASPAGODEF", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["ICLIEFORMASPAGODEF"])
                {
                    auxPar.Value = oCPERSONA.ICLIEFORMASPAGODEF;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBREIMPRESORA", FbDbType.VarChar);
                if (!(bool)oCPERSONA.isnull["INOMBREIMPRESORA"])
                {
                    auxPar.Value = oCPERSONA.INOMBREIMPRESORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);

                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);




                string commandText = @"PERSONA_USUARIO_INSERT";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {
                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.sCadenaConexion, st);
                        this.iComentario = "ERROR : " + strMensajeErr;
                        return null;
                    }
                }

                oCPERSONA.IID = (long)arParms[arParms.Length - 2].Value;


                return oCPERSONA;

            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }




        public bool CambiarPERSONAUSUARIOD(CPERSONABE oCPERSONANuevo, CPERSONABE oCPERSONAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPERSONAAnterior.IID;
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



                auxPar = new FbParameter("@USERNAME", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IUSERNAME"])
                {
                    auxPar.Value = oCPERSONANuevo.IUSERNAME;
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



                auxPar = new FbParameter("@GAFFETE", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["IGAFFETE"])
                {
                    auxPar.Value = oCPERSONANuevo.IGAFFETE;
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


                auxPar = new FbParameter("@TICKETLARGO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ITICKETLARGO"])
                {
                    auxPar.Value = oCPERSONANuevo.ITICKETLARGO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@ALMACENID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IALMACENID"])
                {
                    auxPar.Value = oCPERSONANuevo.IALMACENID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CAJASBOTELLAS", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICAJASBOTELLAS"] && oCPERSONANuevo.ICAJASBOTELLAS.Trim().Length > 0)
                {
                    auxPar.Value = oCPERSONANuevo.ICAJASBOTELLAS;
                }
                else
                {

                    auxPar.Value = "N";
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TICKETLARGOCREDITO", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ITICKETLARGOCREDITO"])
                {
                    auxPar.Value = oCPERSONANuevo.ITICKETLARGOCREDITO;
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


                auxPar = new FbParameter("@PENDMAXDIAS", FbDbType.Integer);
                if (!(bool)oCPERSONANuevo.isnull["IPENDMAXDIAS"])
                {
                    auxPar.Value = oCPERSONANuevo.IPENDMAXDIAS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@GRUPOUSUARIOID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["IGRUPOUSUARIOID"])
                {
                    auxPar.Value = oCPERSONANuevo.IGRUPOUSUARIOID;
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


                auxPar = new FbParameter("@CLERKPAGOSERVICIOSID", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ICLERKPAGOSERVICIOSID"])
                {
                    auxPar.Value = oCPERSONANuevo.ICLERKPAGOSERVICIOSID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@CLERKSERVICIOS", FbDbType.BigInt);
                if (!(bool)oCPERSONANuevo.isnull["ICLERKSERVICIOS"])
                {
                    auxPar.Value = oCPERSONANuevo.ICLERKSERVICIOS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);



                auxPar = new FbParameter("@TICKETLARGOCOTIZACION", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ITICKETLARGOCOTIZACION"])
                {
                    auxPar.Value = oCPERSONANuevo.ITICKETLARGOCOTIZACION;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CODIGOAUTORIZACION", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICODIGOAUTORIZACION"])
                {
                    auxPar.Value = oCPERSONANuevo.ICODIGOAUTORIZACION;
                }
                else
                {
                    auxPar.Value = "";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@CLIEFORMASPAGODEF", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ICLIEFORMASPAGODEF"])
                {
                    auxPar.Value = oCPERSONANuevo.ICLIEFORMASPAGODEF;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@NOMBREIMPRESORA", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["INOMBREIMPRESORA"])
                {
                    auxPar.Value = oCPERSONANuevo.INOMBREIMPRESORA;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"PERSONA_USUARIO_UPDATE";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);


                if (st == null)
                    SqlHelper.ExecuteNonQuery(this.sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);
                else
                    SqlHelper.ExecuteNonQuery(st, CommandType.StoredProcedure, commandText, arParms);


                return true;


            }
            catch (Exception e)
            {
                this.iComentario = e.Message + e.StackTrace;
                return false;
            }
        }



        public bool CambiarPERSONAUSUARIO_PASS_D(CPERSONABE oCPERSONANuevo, CPERSONABE oCPERSONAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPERSONAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                auxPar = new FbParameter("@CLAVEACCESO", FbDbType.VarChar,255);
                if (!(bool)oCPERSONANuevo.isnull["ICLAVEACCESO"])
                {
                    auxPar.Value = oCPERSONANuevo.ICLAVEACCESO;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);


                auxPar = new FbParameter("@RESET_PASS", FbDbType.SmallInt);
                if (!(bool)oCPERSONANuevo.isnull["IRESET_PASS"])
                {
                    auxPar.Value = oCPERSONANuevo.IRESET_PASS;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);





                string commandText = @"UPDATE PERSONA SET CLAVEACCESO = @CLAVEACCESO, RESET_PASS = @RESET_PASS WHERE ID = @PERSONAID";

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








        public bool CambiarBANCOMERDOCTOPENDID(CPERSONABE oCPERSONA, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@BANCOMERDOCTOPENDID", FbDbType.BigInt);
                if (!(bool)oCPERSONA.isnull["IBANCOMERDOCTOPENDID"])
                {
                    auxPar.Value = oCPERSONA.IBANCOMERDOCTOPENDID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
                }
                parts.Add(auxPar);




                string commandText = @"UPDATE PERSONA SET BANCOMERDOCTOPENDID = @BANCOMERDOCTOPENDID WHERE ID = @PERSONAID";

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


        public bool CambiarPERSONATIPOTICKET(CPERSONABE oCPERSONANuevo, CPERSONABE oCPERSONAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPERSONAAnterior.IID;
                }
                else
                {
                    auxPar.Value = System.DBNull.Value;
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


                auxPar = new FbParameter("@TICKETLARGOCOTIZACION", FbDbType.VarChar);
                if (!(bool)oCPERSONANuevo.isnull["ITICKETLARGOCOTIZACION"])
                {
                    auxPar.Value = oCPERSONANuevo.ITICKETLARGOCOTIZACION;
                }
                else
                {
                    auxPar.Value = "N";
                }
                parts.Add(auxPar);







                string commandText = @"UPDATE PERSONA SET TICKETLARGO = @TICKETLARGO , TICKETLARGOCOTIZACION = @TICKETLARGOCOTIZACION WHERE ID = @PERSONAID";

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




        public bool CambiarESTATUSENVIO(CPERSONABE oCPERSONANuevo, CPERSONABE oCPERSONAAnterior, FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                if (!(bool)oCPERSONAAnterior.isnull["IID"])
                {
                    auxPar.Value = oCPERSONAAnterior.IID;
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







                string commandText = @"UPDATE PERSONA SET ESTATUSENVIOID = @ESTATUSENVIOID  WHERE ID = @PERSONAID";

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


        public bool UsuarioEsAdmin(long lPersonaId, FbTransaction st)
        {
            int iPerfilAdm = 0;
            bool retorno = false;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "select count(*) perfilAdm from usuario_perfil where up_perfil = 11 and up_personaid = @UP_PERSONAID  ";
                auxPar = new FbParameter("@UP_PERSONAID", FbDbType.BigInt);
                auxPar.Value = lPersonaId;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["perfilAdm"] != System.DBNull.Value)
                    {
                        iPerfilAdm = (int)(dr["perfilAdm"]);
                        if (iPerfilAdm > 0)
                            retorno = true;
                    }
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





        public bool UsuarioEsSupervisor(long lPersonaId, FbTransaction st)
        {
            int iPerfilAdm = 0;
            bool retorno = false;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;
                String CmdTxt = "select count(*) perfilAdm from usuario_perfil where up_perfil = 12 and up_personaid = @UP_PERSONAID  ";
                auxPar = new FbParameter("@UP_PERSONAID", FbDbType.BigInt);
                auxPar.Value = lPersonaId;
                parts.Add(auxPar);
                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["perfilAdm"] != System.DBNull.Value)
                    {
                        iPerfilAdm = (int)(dr["perfilAdm"]);
                        if (iPerfilAdm > 0)
                            retorno = true;
                    }
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



        public CPERSONABE seleccionarPERSONAxNOMBRE(CPERSONABE oCPERSONA, FbTransaction st)
        {

            CPERSONABE retorno = new CPERSONABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONA where USERNAME=@USERNAME  ";


                auxPar = new FbParameter("@USERNAME", FbDbType.VarChar);
                auxPar.Value = oCPERSONA.IUSERNAME;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["TIPOPERSONAID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPERSONAID = (long)(dr["TIPOPERSONAID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        retorno.IMEMO = (string)(dr["MEMO"]);
                    }

                    if (dr["SALUDOID"] != System.DBNull.Value)
                    {
                        retorno.ISALUDOID = (long)(dr["SALUDOID"]);
                    }

                    if (dr["NOMBRES"] != System.DBNull.Value)
                    {
                        retorno.INOMBRES = (string)(dr["NOMBRES"]);
                    }

                    if (dr["APELLIDOS"] != System.DBNull.Value)
                    {
                        retorno.IAPELLIDOS = (string)(dr["APELLIDOS"]);
                    }

                    if (dr["RAZONSOCIAL"] != System.DBNull.Value)
                    {
                        retorno.IRAZONSOCIAL = (string)(dr["RAZONSOCIAL"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["CONTACTO1"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO1 = (string)(dr["CONTACTO1"]);
                    }

                    if (dr["CONTACTO2"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO2 = (string)(dr["CONTACTO2"]);
                    }

                    if (dr["USERNAME"] != System.DBNull.Value)
                    {
                        retorno.IUSERNAME = (string)(dr["USERNAME"]);
                    }

                    if (dr["CLAVEACCESO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEACCESO = (string)(dr["CLAVEACCESO"]);
                    }

                    if (dr["DOMICILIO"] != System.DBNull.Value)
                    {
                        retorno.IDOMICILIO = (string)(dr["DOMICILIO"]);
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        retorno.ICIUDAD = (string)(dr["CIUDAD"]);
                    }

                    if (dr["MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IMUNICIPIO = (string)(dr["MUNICIPIO"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }

                    if (dr["PAIS"] != System.DBNull.Value)
                    {
                        retorno.IPAIS = (string)(dr["PAIS"]);
                    }

                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = (string)(dr["CODIGOPOSTAL"]);
                    }

                    if (dr["TELEFONO1"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO1 = (string)(dr["TELEFONO1"]);
                    }

                    if (dr["TELEFONO2"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO2 = (string)(dr["TELEFONO2"]);
                    }

                    if (dr["TELEFONO3"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO3 = (string)(dr["TELEFONO3"]);
                    }

                    if (dr["CELULAR"] != System.DBNull.Value)
                    {
                        retorno.ICELULAR = (string)(dr["CELULAR"]);
                    }

                    if (dr["NEXTEL"] != System.DBNull.Value)
                    {
                        retorno.INEXTEL = (string)(dr["NEXTEL"]);
                    }

                    if (dr["EMAIL1"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL1 = (string)(dr["EMAIL1"]);
                    }

                    if (dr["EMAIL2"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL2 = (string)(dr["EMAIL2"]);
                    }

                    if (dr["EMPRESAID"] != System.DBNull.Value)
                    {
                        retorno.IEMPRESAID = (long)(dr["EMPRESAID"]);
                    }

                    if (dr["VENDEDORID"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORID = (long)(dr["VENDEDORID"]);
                    }

                    if (dr["ESCLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IESCLIENTE = (string)(dr["ESCLIENTE"]);
                    }

                    if (dr["ESCLIENTEGENERAL"] != System.DBNull.Value)
                    {
                        retorno.IESCLIENTEGENERAL = (string)(dr["ESCLIENTEGENERAL"]);
                    }

                    if (dr["ESPROVEEDOR"] != System.DBNull.Value)
                    {
                        retorno.IESPROVEEDOR = (string)(dr["ESPROVEEDOR"]);
                    }

                    if (dr["ESUSUARIO"] != System.DBNull.Value)
                    {
                        retorno.IESUSUARIO = (string)(dr["ESUSUARIO"]);
                    }

                    if (dr["LISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOID = (long)(dr["LISTAPRECIOID"]);
                    }

                    if (dr["VIGENCIA"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIA = (DateTime)(dr["VIGENCIA"]);
                    }

                    if (dr["RESET_PASS"] != System.DBNull.Value)
                    {
                        retorno.IRESET_PASS = short.Parse(dr["RESET_PASS"].ToString());
                    }

                    if (dr["HAB_PAGOTARJETA"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOTARJETA = (string)(dr["HAB_PAGOTARJETA"]);
                    }

                    if (dr["HAB_PAGOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOCREDITO = (string)(dr["HAB_PAGOCREDITO"]);
                    }

                    if (dr["HAB_PAGOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOCHEQUE = (string)(dr["HAB_PAGOCHEQUE"]);
                    }
                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }
                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }


                    if (dr["SALDOAPARTADO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADO = (decimal)(dr["SALDOAPARTADO"]);
                    }
                    if (dr["SALDOSPOSITIVOS"] != System.DBNull.Value)
                    {
                        retorno.ISALDOSPOSITIVOS = (decimal)(dr["SALDOSPOSITIVOS"]);
                    }
                    if (dr["SALDOSNEGATIVOS"] != System.DBNull.Value)
                    {
                        retorno.ISALDOSNEGATIVOS = (decimal)(dr["SALDOSNEGATIVOS"]);
                    }

                    if (dr["SALDOAPARTADOPOSITIVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADOPOSITIVO = (decimal)(dr["SALDOAPARTADOPOSITIVO"]);
                    }

                    if (dr["SALDOAPARTADONEGATIVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADONEGATIVO = (decimal)(dr["SALDOAPARTADONEGATIVO"]);
                    }

                    if (dr["NUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROINTERIOR = (string)(dr["NUMEROINTERIOR"]);
                    }

                    if (dr["NUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROEXTERIOR = (string)(dr["NUMEROEXTERIOR"]);
                    }
                    if (dr["GAFFETE"] != System.DBNull.Value)
                    {
                        retorno.IGAFFETE = (string)(dr["GAFFETE"]);
                    }

                    try
                    {
                        if (dr["LIMITECREDITO"] != System.DBNull.Value)
                        {
                            retorno.ILIMITECREDITO = (decimal)(dr["LIMITECREDITO"]);
                        }

                        if (dr["DIAS"] != System.DBNull.Value)
                        {
                            retorno.IDIAS = (int)(dr["DIAS"]);
                        }

                        if (dr["REVISION"] != System.DBNull.Value)
                        {
                            retorno.IREVISION = (string)(dr["REVISION"]);
                        }

                        if (dr["PAGOS"] != System.DBNull.Value)
                        {
                            retorno.IPAGOS = (string)(dr["PAGOS"]);
                        }

                        if (dr["BLOQUEADO"] != System.DBNull.Value)
                        {
                            retorno.IBLOQUEADO = (string)(dr["BLOQUEADO"]);
                        }

                        if (dr["TICKETLARGO"] != System.DBNull.Value)
                        {
                            retorno.ITICKETLARGO = (string)(dr["TICKETLARGO"]);
                        }


                    }
                    catch
                    {
                    }

                    try
                    {


                        if (dr["ENTREGACALLE"] != System.DBNull.Value)
                        {
                            retorno.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
                        }
                        if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
                        {
                            retorno.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
                        }
                        if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
                        {
                            retorno.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
                        }
                        if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
                        {
                            retorno.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
                        }
                        if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
                        {
                            retorno.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
                        }
                        if (dr["ENTREGAESTADO"] != System.DBNull.Value)
                        {
                            retorno.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
                        }
                        if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
                        {
                            retorno.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
                        }

                        if (dr["HAB_PAGOTRANSFERENCIA"] != System.DBNull.Value)
                        {
                            retorno.IHAB_PAGOTRANSFERENCIA = (string)(dr["HAB_PAGOTRANSFERENCIA"]);
                        }


                        if (dr["CREDITOFORMAPAGOABONOS"] != System.DBNull.Value)
                        {
                            retorno.ICREDITOFORMAPAGOABONOS = (long)(dr["CREDITOFORMAPAGOABONOS"]);
                        }


                        if (dr["CREDITOREFERENCIAABONOS"] != System.DBNull.Value)
                        {
                            retorno.ICREDITOREFERENCIAABONOS = (string)(dr["CREDITOREFERENCIAABONOS"]);
                        }

                        if (dr["RETIENEISR"] != System.DBNull.Value)
                        {
                            retorno.IRETIENEISR = (string)(dr["RETIENEISR"]);
                        }

                        if (dr["RETIENEIVA"] != System.DBNull.Value)
                        {
                            retorno.IRETIENEIVA = (string)(dr["RETIENEIVA"]);
                        }

                        if (dr["MONEDAID"] != System.DBNull.Value)
                        {
                            retorno.IMONEDAID = (long)(dr["MONEDAID"]);
                        }

                        if (dr["DESGLOSEIEPS"] != System.DBNull.Value)
                        {
                            retorno.IDESGLOSEIEPS = (string)(dr["DESGLOSEIEPS"]);
                        }

                        if (dr["CUENTAIEPS"] != System.DBNull.Value)
                        {
                            retorno.ICUENTAIEPS = (string)(dr["CUENTAIEPS"]);
                        }

                        if (dr["SUPERLISTAPRECIOID"] != System.DBNull.Value)
                        {
                            retorno.ISUPERLISTAPRECIOID = (long)(dr["SUPERLISTAPRECIOID"]);
                        }
                        if (dr["ALMACENID"] != System.DBNull.Value)
                        {
                            retorno.IALMACENID = (long)(dr["ALMACENID"]);
                        }
                        if (dr["BLOQUEONOT"] != System.DBNull.Value)
                        {
                            retorno.IBLOQUEONOT = (string)(dr["BLOQUEONOT"]);
                        }

                        if (dr["EMAIL3"] != System.DBNull.Value)
                        {
                            retorno.IEMAIL3 = (string)(dr["EMAIL3"]);
                        }

                        if (dr["EMAIL4"] != System.DBNull.Value)
                        {
                            retorno.IEMAIL4 = (string)(dr["EMAIL4"]);
                        }

                        if (dr["CAJASBOTELLAS"] != System.DBNull.Value)
                        {
                            retorno.ICAJASBOTELLAS = (string)(dr["CAJASBOTELLAS"]);
                        }
                        if (dr["ESTATUSENVIOID"] != System.DBNull.Value)
                        {
                            retorno.IESTATUSENVIOID = (long)(dr["ESTATUSENVIOID"]);
                        }

                        if (dr["REPLCREADO"] != System.DBNull.Value)
                        {
                            retorno.IREPLCREADO = (DateTime)(dr["REPLCREADO"]);
                        }
                        if (dr["REPLMODIFICADO"] != System.DBNull.Value)
                        {
                            retorno.IREPLMODIFICADO = (DateTime)(dr["REPLMODIFICADO"]);
                        }


                        if (dr["TICKETLARGOCREDITO"] != System.DBNull.Value)
                        {
                            retorno.ITICKETLARGOCREDITO = (string)(dr["TICKETLARGOCREDITO"]);
                        }

                        if (dr["PENDMAXDIAS"] != System.DBNull.Value)
                        {
                            retorno.IPENDMAXDIAS = (int)(dr["PENDMAXDIAS"]);
                        }


                        if (dr["PAGOPARCIALIDADES"] != System.DBNull.Value)
                        {
                            retorno.IPAGOPARCIALIDADES = (string)(dr["PAGOPARCIALIDADES"]);
                        }

                        if (dr["SALDOVENCIDOMOVIL"] != System.DBNull.Value)
                        {
                            retorno.ISALDOVENCIDOMOVIL = (decimal)(dr["SALDOVENCIDOMOVIL"]);
                        }


                        if (dr["SALDOMOVIL"] != System.DBNull.Value)
                        {
                            retorno.ISALDOMOVIL = (decimal)(dr["SALDOMOVIL"]);
                        }

                        if (dr["GRUPOUSUARIOID"] != System.DBNull.Value)
                        {
                            retorno.IGRUPOUSUARIOID = (long)(dr["GRUPOUSUARIOID"]);
                        }

                        if (dr["CREDITOFORMAPAGOSATABONOS"] != System.DBNull.Value)
                        {
                            retorno.ICREDITOFORMAPAGOSATABONOS = (long)(dr["CREDITOFORMAPAGOSATABONOS"]);
                        }

                        if (dr["SERVICIOADOMICILIO"] != System.DBNull.Value)
                        {
                            retorno.ISERVICIOADOMICILIO = (string)(dr["SERVICIOADOMICILIO"]);
                        }

                        if (dr["ULTIMAVENTA"] != System.DBNull.Value)
                        {
                            retorno.IULTIMAVENTA = (DateTime)(dr["ULTIMAVENTA"]);
                        }
                        if (dr["GENERARRECIBOELECTRONICO"] != System.DBNull.Value)
                        {
                            retorno.IGENERARRECIBOELECTRONICO = (string)(dr["GENERARRECIBOELECTRONICO"]);
                        }

                        if (dr["LOCALIDAD"] != System.DBNull.Value)
                        {
                            retorno.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                        }

                        if (dr["REFERENCIADOM"] != System.DBNull.Value)
                        {
                            retorno.IREFERENCIADOM = (string)(dr["REFERENCIADOM"]);
                        }

                        if (dr["HAB_PAGOEFECTIVO"] != System.DBNull.Value)
                        {
                            retorno.IHAB_PAGOEFECTIVO = (string)(dr["HAB_PAGOEFECTIVO"]);
                        }

                        if (dr["CLERKPAGOSERVICIOSID"] != System.DBNull.Value)
                        {
                            retorno.ICLERKPAGOSERVICIOSID = (long)(dr["CLERKPAGOSERVICIOSID"]);
                        }

                        if (dr["CLERKSERVICIOS"] != System.DBNull.Value)
                        {
                            retorno.ICLERKSERVICIOS = (long)(dr["CLERKSERVICIOS"]);
                        }


                        if (dr["BANCOMERDOCTOPENDID"] != System.DBNull.Value)
                        {
                            retorno.IBANCOMERDOCTOPENDID = (long)(dr["BANCOMERDOCTOPENDID"]);
                        }


                        if (dr["SOLICITAORDENCOMPRA"] != System.DBNull.Value)
                        {
                            retorno.ISOLICITAORDENCOMPRA = (string)(dr["SOLICITAORDENCOMPRA"]);
                        }


                        if (dr["CUENTACONTPAQ"] != System.DBNull.Value)
                        {
                            retorno.ICUENTACONTPAQ = (string)(dr["CUENTACONTPAQ"]);
                        }

                        if (dr["ESIMPORTADOR"] != System.DBNull.Value)
                        {
                            retorno.IESIMPORTADOR = (string)(dr["ESIMPORTADOR"]);
                        }

                        if (dr["SEPARARPRODXPLAZO"] != System.DBNull.Value)
                        {
                            retorno.ISEPARARPRODXPLAZO = (string)(dr["SEPARARPRODXPLAZO"]);
                        }

                        if (dr["CARGOXVENTACONTARJETA"] != System.DBNull.Value)
                        {
                            retorno.ICARGOXVENTACONTARJETA = (string)(dr["CARGOXVENTACONTARJETA"]);
                        }

                        if (dr["PAGOTARJMENORPRECIOLISTA"] != System.DBNull.Value)
                        {
                            retorno.IPAGOTARJMENORPRECIOLISTA = (string)(dr["PAGOTARJMENORPRECIOLISTA"]);
                        }

                        if (dr["SAT_CLAVE_PAIS"] != System.DBNull.Value)
                        {
                            retorno.ISAT_CLAVE_PAIS = (string)(dr["SAT_CLAVE_PAIS"]);
                        }


                        if (dr["PROVEECLIENTEID"] != System.DBNull.Value)
                        {
                            retorno.IPROVEECLIENTEID = (long)(dr["PROVEECLIENTEID"]);
                        }


                        if (dr["EXENTOIVA"] != System.DBNull.Value)
                        {
                            retorno.IEXENTOIVA = (string)(dr["EXENTOIVA"]);
                        }


                        if (dr["TICKETLARGOCOTIZACION"] != System.DBNull.Value)
                        {
                            retorno.ITICKETLARGOCOTIZACION = (string)(dr["TICKETLARGOCOTIZACION"]);
                        }

                        if (dr["CODIGOAUTORIZACION"] != System.DBNull.Value)
                        {
                            retorno.ICODIGOAUTORIZACION = (string)(dr["CODIGOAUTORIZACION"]);
                        }

                        if (dr["SAT_USOCFDIID"] != System.DBNull.Value)
                        {
                            retorno.ISAT_USOCFDIID = (long)(dr["SAT_USOCFDIID"]);
                        }

                        if (dr["CLIEFORMASPAGODEF"] != System.DBNull.Value)
                        {
                            retorno.ICLIEFORMASPAGODEF = (string)(dr["CLIEFORMASPAGODEF"]);
                        }


                        if (dr["POR_COME"] != System.DBNull.Value)
                        {
                            retorno.IPOR_COME = (decimal)(dr["POR_COME"]);
                        }

                        if (dr["DIAS_EXTR"] != System.DBNull.Value)
                        {
                            retorno.IDIAS_EXTR = (int)(dr["DIAS_EXTR"]);
                        }


                        if (dr["ADESCPES"] != System.DBNull.Value)
                        {
                            retorno.IADESCPES = (decimal)(dr["ADESCPES"]);
                        }


                        if (dr["RUTAEMBARQUEID"] != System.DBNull.Value)
                        {
                            retorno.IRUTAEMBARQUEID = (long)(dr["RUTAEMBARQUEID"]);
                        }

                        if (dr["SUBTIPOCLIENTE"] != System.DBNull.Value)
                        {
                            retorno.ISUBTIPOCLIENTE = (string)(dr["SUBTIPOCLIENTE"]);
                        }

                        if (dr["PREGUNTARTICKETLARGO"] != System.DBNull.Value)
                        {
                            retorno.IPREGUNTARTICKETLARGO = (string)(dr["PREGUNTARTICKETLARGO"]);
                        }

                        if (dr["MAYOREOXPRODUCTO"] != System.DBNull.Value)
                        {
                            retorno.IMAYOREOXPRODUCTO = (string)(dr["MAYOREOXPRODUCTO"]);
                        }

                        if (dr["GENERACOMPROBTRASL"] != System.DBNull.Value)
                        {
                            retorno.IGENERACOMPROBTRASL = (string)(dr["GENERACOMPROBTRASL"]);
                        }

                        if (dr["GENERACARTAPORTE"] != System.DBNull.Value)
                        {
                            retorno.IGENERACARTAPORTE = (string)(dr["GENERACARTAPORTE"]);
                        }

                        if (dr["SAT_COLONIAID"] != System.DBNull.Value)
                        {
                            retorno.ISAT_COLONIAID = (long)(dr["SAT_COLONIAID"]);
                        }

                        if (dr["SAT_LOCALIDADID"] != System.DBNull.Value)
                        {
                            retorno.ISAT_LOCALIDADID = (long)(dr["SAT_LOCALIDADID"]);
                        }

                        if (dr["SAT_MUNICIPIOID"] != System.DBNull.Value)
                        {
                            retorno.ISAT_MUNICIPIOID = (long)(dr["SAT_MUNICIPIOID"]);
                        }

                        if (dr["DISTANCIA"] != System.DBNull.Value)
                        {
                            retorno.IDISTANCIA = (decimal)(dr["DISTANCIA"]);
                        }


                        if (dr["ENTREGA_SAT_COLONIAID"] != System.DBNull.Value)
                        {
                            retorno.IENTREGA_SAT_COLONIAID = (long)(dr["ENTREGA_SAT_COLONIAID"]);
                        }

                        if (dr["ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value)
                        {
                            retorno.IENTREGA_SAT_LOCALIDADID = (long)(dr["ENTREGA_SAT_LOCALIDADID"]);
                        }

                        if (dr["ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value)
                        {
                            retorno.IENTREGA_SAT_MUNICIPIOID = (long)(dr["ENTREGA_SAT_MUNICIPIOID"]);
                        }

                        if (dr["ENTREGA_DISTANCIA"] != System.DBNull.Value)
                        {
                            retorno.IENTREGA_DISTANCIA = (decimal)(dr["ENTREGA_DISTANCIA"]);
                        }

                        if (dr["ENTREGAREFERENCIADOM"] != System.DBNull.Value)
                        {
                            retorno.IENTREGAREFERENCIADOM = (string)(dr["ENTREGAREFERENCIADOM"]);
                        }

                        if (dr["SAT_REGIMENFISCALID"] != System.DBNull.Value)
                        {
                            retorno.ISAT_REGIMENFISCALID = (long)(dr["SAT_REGIMENFISCALID"]);
                        }

                        if (dr["NOMBREIMPRESORA"] != System.DBNull.Value)
                        {
                            retorno.INOMBREIMPRESORA = (string)(dr["NOMBREIMPRESORA"]);
                        }

                        if (dr["FIRMAIMAGEN"] != System.DBNull.Value)
                        {
                            retorno.IFIRMAIMAGEN = (string)(dr["FIRMAIMAGEN"]);
                        }

                        if (dr["LATITUD"] != System.DBNull.Value)
                        {
                            retorno.ILATITUD = (double)(dr["LATITUD"]);
                        }

                        if (dr["LONGITUD"] != System.DBNull.Value)
                        {
                            retorno.ILONGITUD = (double)(dr["LONGITUD"]);
                        }

                    }
                    catch
                    {
                    }

                
                }
                else
                {
                    retorno = null;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }

        }


        public decimal selectSumaPagoMovil(long lPersonaId, FbTransaction st)
        {

            decimal retorno = 0;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = "select sum(importerecibido) IMPORTERECIBIDO from pagomovil where personaid = @PERSONAID ";
                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = lPersonaId;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["IMPORTERECIBIDO"] != System.DBNull.Value)
                    {
                        retorno = (decimal)(dr["IMPORTERECIBIDO"]);
                    }
                }
                else
                {
                    retorno = 0;
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return 0;
            }
        }

        public bool UsuarioTieneDerechoAMenu(long lPersonaId, int iMenu,FbTransaction st)
        {
            int iTienePermiso = 0;
            bool retorno = false;
            /**/FbDataReader dr = null;
            FbConnection pcn = null;
            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = "select count(*) TIENEPERMISO from MENUITEMS inner join PERFIL_DER on mn_derecho=pd_derecho inner join USUARIO_PERFIL on up_perfil = pd_perfil  where  MN_ID=@MN_ID and up_personaid=@US_PERSONAID";
                auxPar = new FbParameter("@US_PERSONAID", FbDbType.BigInt);
                auxPar.Value = lPersonaId;
                parts.Add(auxPar);

                auxPar = new FbParameter("@MN_ID", FbDbType.Integer);
                auxPar.Value = iMenu;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);
                if (dr.Read())
                {
                    if (dr["TIENEPERMISO"] != System.DBNull.Value)
                    {
                        iTienePermiso = (int)(dr["TIENEPERMISO"]);
                        if (iTienePermiso > 0)
                            retorno = true;
                    }
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




        public CPERSONAD()
        {
            this.sCadenaConexion = ConexionBD.ConexionString();
            //this.sCadenaConexion="server=(servidor);database=(base de datos);uid=(usuario);pwd=(password);";


            //
            // TODO: Add constructor logic here
            //
        }





        public CPERSONABE seleccionarPERSONAxCLAVE(CPERSONABE oCPERSONA, FbTransaction st)
        {

            CPERSONABE retorno = new CPERSONABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONA where CLAVE=@CLAVE and TIPOPERSONAID = @TIPOPERSONAID ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCPERSONA.ICLAVE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOPERSONAID", FbDbType.VarChar);
                auxPar.Value = oCPERSONA.ITIPOPERSONAID;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["TIPOPERSONAID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPERSONAID = (long)(dr["TIPOPERSONAID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        retorno.IMEMO = (string)(dr["MEMO"]);
                    }

                    if (dr["SALUDOID"] != System.DBNull.Value)
                    {
                        retorno.ISALUDOID = (long)(dr["SALUDOID"]);
                    }

                    if (dr["NOMBRES"] != System.DBNull.Value)
                    {
                        retorno.INOMBRES = (string)(dr["NOMBRES"]);
                    }

                    if (dr["APELLIDOS"] != System.DBNull.Value)
                    {
                        retorno.IAPELLIDOS = (string)(dr["APELLIDOS"]);
                    }

                    if (dr["RAZONSOCIAL"] != System.DBNull.Value)
                    {
                        retorno.IRAZONSOCIAL = (string)(dr["RAZONSOCIAL"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["CONTACTO1"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO1 = (string)(dr["CONTACTO1"]);
                    }

                    if (dr["CONTACTO2"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO2 = (string)(dr["CONTACTO2"]);
                    }

                    if (dr["USERNAME"] != System.DBNull.Value)
                    {
                        retorno.IUSERNAME = (string)(dr["USERNAME"]);
                    }

                    if (dr["CLAVEACCESO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEACCESO = (string)(dr["CLAVEACCESO"]);
                    }

                    if (dr["DOMICILIO"] != System.DBNull.Value)
                    {
                        retorno.IDOMICILIO = (string)(dr["DOMICILIO"]);
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        retorno.ICIUDAD = (string)(dr["CIUDAD"]);
                    }

                    if (dr["MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IMUNICIPIO = (string)(dr["MUNICIPIO"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }

                    if (dr["PAIS"] != System.DBNull.Value)
                    {
                        retorno.IPAIS = (string)(dr["PAIS"]);
                    }

                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = (string)(dr["CODIGOPOSTAL"]);
                    }

                    if (dr["TELEFONO1"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO1 = (string)(dr["TELEFONO1"]);
                    }

                    if (dr["TELEFONO2"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO2 = (string)(dr["TELEFONO2"]);
                    }

                    if (dr["TELEFONO3"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO3 = (string)(dr["TELEFONO3"]);
                    }

                    if (dr["CELULAR"] != System.DBNull.Value)
                    {
                        retorno.ICELULAR = (string)(dr["CELULAR"]);
                    }

                    if (dr["NEXTEL"] != System.DBNull.Value)
                    {
                        retorno.INEXTEL = (string)(dr["NEXTEL"]);
                    }

                    if (dr["EMAIL1"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL1 = (string)(dr["EMAIL1"]);
                    }

                    if (dr["EMAIL2"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL2 = (string)(dr["EMAIL2"]);
                    }

                    if (dr["EMPRESAID"] != System.DBNull.Value)
                    {
                        retorno.IEMPRESAID = (long)(dr["EMPRESAID"]);
                    }

                    if (dr["VENDEDORID"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORID = (long)(dr["VENDEDORID"]);
                    }

                    if (dr["ESCLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IESCLIENTE = (string)(dr["ESCLIENTE"]);
                    }

                    if (dr["ESCLIENTEGENERAL"] != System.DBNull.Value)
                    {
                        retorno.IESCLIENTEGENERAL = (string)(dr["ESCLIENTEGENERAL"]);
                    }

                    if (dr["ESPROVEEDOR"] != System.DBNull.Value)
                    {
                        retorno.IESPROVEEDOR = (string)(dr["ESPROVEEDOR"]);
                    }

                    if (dr["ESUSUARIO"] != System.DBNull.Value)
                    {
                        retorno.IESUSUARIO = (string)(dr["ESUSUARIO"]);
                    }

                    if (dr["LISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOID = (long)(dr["LISTAPRECIOID"]);
                    }

                    if (dr["VIGENCIA"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIA = (DateTime)(dr["VIGENCIA"]);
                    }

                    if (dr["RESET_PASS"] != System.DBNull.Value)
                    {
                        retorno.IRESET_PASS = short.Parse(dr["RESET_PASS"].ToString());
                    }
                    if (dr["HAB_PAGOTARJETA"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOTARJETA = (string)(dr["HAB_PAGOTARJETA"]);
                    }

                    if (dr["HAB_PAGOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOCREDITO = (string)(dr["HAB_PAGOCREDITO"]);
                    }

                    if (dr["HAB_PAGOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOCHEQUE = (string)(dr["HAB_PAGOCHEQUE"]);
                    }

                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }
                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["SALDOAPARTADO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADO = (decimal)(dr["SALDOAPARTADO"]);
                    }
                    if (dr["SALDOSPOSITIVOS"] != System.DBNull.Value)
                    {
                        retorno.ISALDOSPOSITIVOS = (decimal)(dr["SALDOSPOSITIVOS"]);
                    }
                    if (dr["SALDOSNEGATIVOS"] != System.DBNull.Value)
                    {
                        retorno.ISALDOSNEGATIVOS = (decimal)(dr["SALDOSNEGATIVOS"]);
                    }

                    if (dr["SALDOAPARTADOPOSITIVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADOPOSITIVO = (decimal)(dr["SALDOAPARTADOPOSITIVO"]);
                    }

                    if (dr["SALDOAPARTADONEGATIVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADONEGATIVO = (decimal)(dr["SALDOAPARTADONEGATIVO"]);
                    }
                    if (dr["NUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROINTERIOR = (string)(dr["NUMEROINTERIOR"]);
                    }

                    if (dr["NUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.INUMEROEXTERIOR = (string)(dr["NUMEROEXTERIOR"]);
                    }
                    if (dr["GAFFETE"] != System.DBNull.Value)
                    {
                        retorno.IGAFFETE = (string)(dr["GAFFETE"]);
                    }


                    if (dr["LIMITECREDITO"] != System.DBNull.Value)
                    {
                        retorno.ILIMITECREDITO = (decimal)(dr["LIMITECREDITO"]);
                    }

                    if (dr["DIAS"] != System.DBNull.Value)
                    {
                        retorno.IDIAS = (int)(dr["DIAS"]);
                    }

                    if (dr["REVISION"] != System.DBNull.Value)
                    {
                        retorno.IREVISION = (string)(dr["REVISION"]);
                    }

                    if (dr["PAGOS"] != System.DBNull.Value)
                    {
                        retorno.IPAGOS = (string)(dr["PAGOS"]);
                    }

                    if (dr["BLOQUEADO"] != System.DBNull.Value)
                    {
                        retorno.IBLOQUEADO = (string)(dr["BLOQUEADO"]);
                    }

                    if (dr["TICKETLARGO"] != System.DBNull.Value)
                    {
                        retorno.ITICKETLARGO = (string)(dr["TICKETLARGO"]);
                    }

                    if (dr["ENTREGACALLE"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
                    }
                    if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
                    }
                    if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
                    }
                    if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
                    }
                    if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
                    }
                    if (dr["ENTREGAESTADO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
                    }
                    if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
                    }

                    if (dr["HAB_PAGOTRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOTRANSFERENCIA = (string)(dr["HAB_PAGOTRANSFERENCIA"]);
                    }


                    if (dr["CREDITOFORMAPAGOABONOS"] != System.DBNull.Value)
                    {
                        retorno.ICREDITOFORMAPAGOABONOS = (long)(dr["CREDITOFORMAPAGOABONOS"]);
                    }


                    if (dr["CREDITOREFERENCIAABONOS"] != System.DBNull.Value)
                    {
                        retorno.ICREDITOREFERENCIAABONOS = (string)(dr["CREDITOREFERENCIAABONOS"]);
                    }

                    if (dr["RETIENEISR"] != System.DBNull.Value)
                    {
                        retorno.IRETIENEISR = (string)(dr["RETIENEISR"]);
                    }


                    if (dr["RETIENEIVA"] != System.DBNull.Value)
                    {
                        retorno.IRETIENEIVA = (string)(dr["RETIENEIVA"]);
                    }


                    if (dr["MONEDAID"] != System.DBNull.Value)
                    {
                        retorno.IMONEDAID = (long)(dr["MONEDAID"]);
                    }

                    if (dr["DESGLOSEIEPS"] != System.DBNull.Value)
                    {
                        retorno.IDESGLOSEIEPS = (string)(dr["DESGLOSEIEPS"]);
                    }

                    if (dr["CUENTAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAIEPS = (string)(dr["CUENTAIEPS"]);
                    }
                    if (dr["SUPERLISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.ISUPERLISTAPRECIOID = (long)(dr["SUPERLISTAPRECIOID"]);
                    }
                    if (dr["ALMACENID"] != System.DBNull.Value)
                    {
                        retorno.IALMACENID = (long)(dr["ALMACENID"]);
                    }
                    if (dr["BLOQUEONOT"] != System.DBNull.Value)
                    {
                        retorno.IBLOQUEONOT = (string)(dr["BLOQUEONOT"]);
                    }

                    if (dr["EMAIL3"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL3 = (string)(dr["EMAIL3"]);
                    }

                    if (dr["EMAIL4"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL4 = (string)(dr["EMAIL4"]);
                    }
                    if (dr["CAJASBOTELLAS"] != System.DBNull.Value)
                    {
                        retorno.ICAJASBOTELLAS = (string)(dr["CAJASBOTELLAS"]);
                    }
                    if (dr["ESTATUSENVIOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSENVIOID = (long)(dr["ESTATUSENVIOID"]);
                    }

                    if (dr["REPLCREADO"] != System.DBNull.Value)
                    {
                        retorno.IREPLCREADO = (DateTime)(dr["REPLCREADO"]);
                    }
                    if (dr["REPLMODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IREPLMODIFICADO = (DateTime)(dr["REPLMODIFICADO"]);
                    }

                    if (dr["TICKETLARGOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.ITICKETLARGOCREDITO = (string)(dr["TICKETLARGOCREDITO"]);
                    }

                    if (dr["PENDMAXDIAS"] != System.DBNull.Value)
                    {
                        retorno.IPENDMAXDIAS = (int)(dr["PENDMAXDIAS"]);
                    }

                    if (dr["PAGOPARCIALIDADES"] != System.DBNull.Value)
                    {
                        retorno.IPAGOPARCIALIDADES = (string)(dr["PAGOPARCIALIDADES"]);
                    }

                    if (dr["SALDOVENCIDOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOVENCIDOMOVIL = (decimal)(dr["SALDOVENCIDOMOVIL"]);
                    }


                    if (dr["SALDOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOMOVIL = (decimal)(dr["SALDOMOVIL"]);
                    }

                    if (dr["GRUPOUSUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IGRUPOUSUARIOID = (long)(dr["GRUPOUSUARIOID"]);
                    }

                    if (dr["CREDITOFORMAPAGOSATABONOS"] != System.DBNull.Value)
                    {
                        retorno.ICREDITOFORMAPAGOSATABONOS = (long)(dr["CREDITOFORMAPAGOSATABONOS"]);
                    }

                    if (dr["SERVICIOADOMICILIO"] != System.DBNull.Value)
                    {
                        retorno.ISERVICIOADOMICILIO = (string)(dr["SERVICIOADOMICILIO"]);
                    }

                    if (dr["ULTIMAVENTA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAVENTA = (DateTime)(dr["ULTIMAVENTA"]);
                    }

                    if (dr["GENERARRECIBOELECTRONICO"] != System.DBNull.Value)
                    {
                        retorno.IGENERARRECIBOELECTRONICO = (string)(dr["GENERARRECIBOELECTRONICO"]);
                    }

                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }

                    if (dr["REFERENCIADOM"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIADOM = (string)(dr["REFERENCIADOM"]);
                    }

                    if (dr["HAB_PAGOEFECTIVO"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOEFECTIVO = (string)(dr["HAB_PAGOEFECTIVO"]);
                    }

                    if (dr["CLERKPAGOSERVICIOSID"] != System.DBNull.Value)
                    {
                        retorno.ICLERKPAGOSERVICIOSID = (long)(dr["CLERKPAGOSERVICIOSID"]);
                    }

                    if (dr["CLERKSERVICIOS"] != System.DBNull.Value)
                    {
                        retorno.ICLERKSERVICIOS = (long)(dr["CLERKSERVICIOS"]);
                    }

                    if (dr["BANCOMERDOCTOPENDID"] != System.DBNull.Value)
                    {
                        retorno.IBANCOMERDOCTOPENDID = (long)(dr["BANCOMERDOCTOPENDID"]);
                    }


                    if (dr["SOLICITAORDENCOMPRA"] != System.DBNull.Value)
                    {
                        retorno.ISOLICITAORDENCOMPRA = (string)(dr["SOLICITAORDENCOMPRA"]);
                    }


                    if (dr["CUENTACONTPAQ"] != System.DBNull.Value)
                    {
                        retorno.ICUENTACONTPAQ = (string)(dr["CUENTACONTPAQ"]);
                    }

                    if (dr["ESIMPORTADOR"] != System.DBNull.Value)
                    {
                        retorno.IESIMPORTADOR = (string)(dr["ESIMPORTADOR"]);
                    }

                    if (dr["SEPARARPRODXPLAZO"] != System.DBNull.Value)
                    {
                        retorno.ISEPARARPRODXPLAZO = (string)(dr["SEPARARPRODXPLAZO"]);
                    }

                    if (dr["CARGOXVENTACONTARJETA"] != System.DBNull.Value)
                    {
                        retorno.ICARGOXVENTACONTARJETA = (string)(dr["CARGOXVENTACONTARJETA"]);
                    }


                    if (dr["PAGOTARJMENORPRECIOLISTA"] != System.DBNull.Value)
                    {
                        retorno.IPAGOTARJMENORPRECIOLISTA = (string)(dr["PAGOTARJMENORPRECIOLISTA"]);
                    }

                    if (dr["SAT_CLAVE_PAIS"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE_PAIS = (string)(dr["SAT_CLAVE_PAIS"]);
                    }


                    if (dr["PROVEECLIENTEID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEECLIENTEID = (long)(dr["PROVEECLIENTEID"]);
                    }

                    if (dr["EXENTOIVA"] != System.DBNull.Value)
                    {
                        retorno.IEXENTOIVA = (string)(dr["EXENTOIVA"]);
                    }

                    if (dr["TICKETLARGOCOTIZACION"] != System.DBNull.Value)
                    {
                        retorno.ITICKETLARGOCOTIZACION = (string)(dr["TICKETLARGOCOTIZACION"]);
                    }

                    if (dr["CODIGOAUTORIZACION"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOAUTORIZACION = (string)(dr["CODIGOAUTORIZACION"]);
                    }

                    if (dr["SAT_USOCFDIID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_USOCFDIID = (long)(dr["SAT_USOCFDIID"]);
                    }

                    if (dr["CLIEFORMASPAGODEF"] != System.DBNull.Value)
                    {
                        retorno.ICLIEFORMASPAGODEF = (string)(dr["CLIEFORMASPAGODEF"]);
                    }

                    if (dr["POR_COME"] != System.DBNull.Value)
                    {
                        retorno.IPOR_COME = (decimal)(dr["POR_COME"]);
                    }

                    if (dr["DIAS_EXTR"] != System.DBNull.Value)
                    {
                        retorno.IDIAS_EXTR = (int)(dr["DIAS_EXTR"]);
                    }


                    if (dr["ADESCPES"] != System.DBNull.Value)
                    {
                        retorno.IADESCPES = (decimal)(dr["ADESCPES"]);
                    }

                    if (dr["RUTAEMBARQUEID"] != System.DBNull.Value)
                    {
                        retorno.IRUTAEMBARQUEID = (long)(dr["RUTAEMBARQUEID"]);
                    }

                    if (dr["SUBTIPOCLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ISUBTIPOCLIENTE = (string)(dr["SUBTIPOCLIENTE"]);
                    }

                    if (dr["PREGUNTARTICKETLARGO"] != System.DBNull.Value)
                    {
                        retorno.IPREGUNTARTICKETLARGO = (string)(dr["PREGUNTARTICKETLARGO"]);
                    }

                    if (dr["MAYOREOXPRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IMAYOREOXPRODUCTO = (string)(dr["MAYOREOXPRODUCTO"]);
                    }

                    if (dr["GENERACOMPROBTRASL"] != System.DBNull.Value)
                    {
                        retorno.IGENERACOMPROBTRASL = (string)(dr["GENERACOMPROBTRASL"]);
                    }

                    if (dr["GENERACARTAPORTE"] != System.DBNull.Value)
                    {
                        retorno.IGENERACARTAPORTE = (string)(dr["GENERACARTAPORTE"]);
                    }

                    if (dr["SAT_COLONIAID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_COLONIAID = (long)(dr["SAT_COLONIAID"]);
                    }

                    if (dr["SAT_LOCALIDADID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_LOCALIDADID = (long)(dr["SAT_LOCALIDADID"]);
                    }

                    if (dr["SAT_MUNICIPIOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_MUNICIPIOID = (long)(dr["SAT_MUNICIPIOID"]);
                    }

                    if (dr["DISTANCIA"] != System.DBNull.Value)
                    {
                        retorno.IDISTANCIA = (decimal)(dr["DISTANCIA"]);
                    }


                    if (dr["ENTREGA_SAT_COLONIAID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_COLONIAID = (long)(dr["ENTREGA_SAT_COLONIAID"]);
                    }

                    if (dr["ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_LOCALIDADID = (long)(dr["ENTREGA_SAT_LOCALIDADID"]);
                    }

                    if (dr["ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_MUNICIPIOID = (long)(dr["ENTREGA_SAT_MUNICIPIOID"]);
                    }

                    if (dr["ENTREGA_DISTANCIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_DISTANCIA = (decimal)(dr["ENTREGA_DISTANCIA"]);
                    }

                    if (dr["ENTREGAREFERENCIADOM"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAREFERENCIADOM = (string)(dr["ENTREGAREFERENCIADOM"]);
                    }

                    if (dr["SAT_REGIMENFISCALID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_REGIMENFISCALID = (long)(dr["SAT_REGIMENFISCALID"]);
                    }

                    if (dr["NOMBREIMPRESORA"] != System.DBNull.Value)
                    {
                        retorno.INOMBREIMPRESORA = (string)(dr["NOMBREIMPRESORA"]);
                    }

                    if (dr["FIRMAIMAGEN"] != System.DBNull.Value)
                    {
                        retorno.IFIRMAIMAGEN = (string)(dr["FIRMAIMAGEN"]);
                    }

                    if (dr["LATITUD"] != System.DBNull.Value)
                    {
                        retorno.ILATITUD = (double)(dr["LATITUD"]);
                    }

                    if (dr["LONGITUD"] != System.DBNull.Value)
                    {
                        retorno.ILONGITUD = (double)(dr["LONGITUD"]);
                    }
                }
                else
                {
                    retorno = null;
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }




        public CPERSONABE seleccionarPERSONAxCODIGOAUTORIZACION(CPERSONABE oCPERSONA, FbTransaction st)
        {

            CPERSONABE retorno = new CPERSONABE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONA where CODIGOAUTORIZACION=@CODIGOAUTORIZACION ";


                auxPar = new FbParameter("@CODIGOAUTORIZACION", FbDbType.VarChar);
                auxPar.Value = oCPERSONA.ICODIGOAUTORIZACION;
                parts.Add(auxPar);
                


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    retorno = this.getItemDeReader(dr);
                }
                else
                {
                    retorno = null;
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }


        public List<CPERSONABE> seleccionarPERSONAS()
        {

            List<CPERSONABE> retorno = new List<CPERSONABE>();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();

                String CmdTxt = @"select * from PERSONA WHERE TIPOPERSONAID = 20 ";


                /*auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCSUCURSAL.ICLAVE;
                parts.Add(auxPar);




                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);*/



                dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt);


                while (dr.Read())
                {
                    CPERSONABE auxUser = new CPERSONABE();

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        auxUser.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        auxUser.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        auxUser.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        auxUser.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        auxUser.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        auxUser.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["TIPOPERSONAID"] != System.DBNull.Value)
                    {
                        auxUser.ITIPOPERSONAID = (long)(dr["TIPOPERSONAID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        auxUser.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        auxUser.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        auxUser.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        auxUser.IMEMO = (string)(dr["MEMO"]);
                    }

                    if (dr["SALUDOID"] != System.DBNull.Value)
                    {
                        auxUser.ISALUDOID = (long)(dr["SALUDOID"]);
                    }

                    if (dr["NOMBRES"] != System.DBNull.Value)
                    {
                        auxUser.INOMBRES = (string)(dr["NOMBRES"]);
                    }

                    if (dr["APELLIDOS"] != System.DBNull.Value)
                    {
                        auxUser.IAPELLIDOS = (string)(dr["APELLIDOS"]);
                    }

                    if (dr["RAZONSOCIAL"] != System.DBNull.Value)
                    {
                        auxUser.IRAZONSOCIAL = (string)(dr["RAZONSOCIAL"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        auxUser.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["CONTACTO1"] != System.DBNull.Value)
                    {
                        auxUser.ICONTACTO1 = (string)(dr["CONTACTO1"]);
                    }

                    if (dr["CONTACTO2"] != System.DBNull.Value)
                    {
                        auxUser.ICONTACTO2 = (string)(dr["CONTACTO2"]);
                    }

                    if (dr["USERNAME"] != System.DBNull.Value)
                    {
                        auxUser.IUSERNAME = (string)(dr["USERNAME"]);
                    }

                    if (dr["CLAVEACCESO"] != System.DBNull.Value)
                    {
                        auxUser.ICLAVEACCESO = (string)(dr["CLAVEACCESO"]);
                    }

                    if (dr["DOMICILIO"] != System.DBNull.Value)
                    {
                        auxUser.IDOMICILIO = (string)(dr["DOMICILIO"]);
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        auxUser.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        auxUser.ICIUDAD = (string)(dr["CIUDAD"]);
                    }

                    if (dr["MUNICIPIO"] != System.DBNull.Value)
                    {
                        auxUser.IMUNICIPIO = (string)(dr["MUNICIPIO"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        auxUser.IESTADO = (string)(dr["ESTADO"]);
                    }

                    if (dr["PAIS"] != System.DBNull.Value)
                    {
                        auxUser.IPAIS = (string)(dr["PAIS"]);
                    }

                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        auxUser.ICODIGOPOSTAL = (string)(dr["CODIGOPOSTAL"]);
                    }

                    if (dr["TELEFONO1"] != System.DBNull.Value)
                    {
                        auxUser.ITELEFONO1 = (string)(dr["TELEFONO1"]);
                    }

                    if (dr["TELEFONO2"] != System.DBNull.Value)
                    {
                        auxUser.ITELEFONO2 = (string)(dr["TELEFONO2"]);
                    }

                    if (dr["TELEFONO3"] != System.DBNull.Value)
                    {
                        auxUser.ITELEFONO3 = (string)(dr["TELEFONO3"]);
                    }

                    if (dr["CELULAR"] != System.DBNull.Value)
                    {
                        auxUser.ICELULAR = (string)(dr["CELULAR"]);
                    }

                    if (dr["NEXTEL"] != System.DBNull.Value)
                    {
                        auxUser.INEXTEL = (string)(dr["NEXTEL"]);
                    }

                    if (dr["EMAIL1"] != System.DBNull.Value)
                    {
                        auxUser.IEMAIL1 = (string)(dr["EMAIL1"]);
                    }

                    if (dr["EMAIL2"] != System.DBNull.Value)
                    {
                        auxUser.IEMAIL2 = (string)(dr["EMAIL2"]);
                    }

                    if (dr["EMPRESAID"] != System.DBNull.Value)
                    {
                        auxUser.IEMPRESAID = (long)(dr["EMPRESAID"]);
                    }

                    if (dr["VENDEDORID"] != System.DBNull.Value)
                    {
                        auxUser.IVENDEDORID = (long)(dr["VENDEDORID"]);
                    }

                    if (dr["ESCLIENTE"] != System.DBNull.Value)
                    {
                        auxUser.IESCLIENTE = (string)(dr["ESCLIENTE"]);
                    }

                    if (dr["ESCLIENTEGENERAL"] != System.DBNull.Value)
                    {
                        auxUser.IESCLIENTEGENERAL = (string)(dr["ESCLIENTEGENERAL"]);
                    }

                    if (dr["ESPROVEEDOR"] != System.DBNull.Value)
                    {
                        auxUser.IESPROVEEDOR = (string)(dr["ESPROVEEDOR"]);
                    }

                    if (dr["ESUSUARIO"] != System.DBNull.Value)
                    {
                        auxUser.IESUSUARIO = (string)(dr["ESUSUARIO"]);
                    }

                    if (dr["LISTAPRECIOID"] != System.DBNull.Value)
                    {
                        auxUser.ILISTAPRECIOID = (long)(dr["LISTAPRECIOID"]);
                    }

                    if (dr["VIGENCIA"] != System.DBNull.Value)
                    {
                        auxUser.IVIGENCIA = (DateTime)(dr["VIGENCIA"]);
                    }

                    if (dr["RESET_PASS"] != System.DBNull.Value)
                    {
                        auxUser.IRESET_PASS = short.Parse(dr["RESET_PASS"].ToString());
                    }
                    if (dr["HAB_PAGOTARJETA"] != System.DBNull.Value)
                    {
                        auxUser.IHAB_PAGOTARJETA = (string)(dr["HAB_PAGOTARJETA"]);
                    }

                    if (dr["HAB_PAGOCREDITO"] != System.DBNull.Value)
                    {
                        auxUser.IHAB_PAGOCREDITO = (string)(dr["HAB_PAGOCREDITO"]);
                    }

                    if (dr["HAB_PAGOCHEQUE"] != System.DBNull.Value)
                    {
                        auxUser.IHAB_PAGOCHEQUE = (string)(dr["HAB_PAGOCHEQUE"]);
                    }

                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        auxUser.ICORTEID = (long)(dr["CORTEID"]);
                    }
                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        auxUser.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["SALDOAPARTADO"] != System.DBNull.Value)
                    {
                        auxUser.ISALDOAPARTADO = (decimal)(dr["SALDOAPARTADO"]);
                    }
                    if (dr["SALDOSPOSITIVOS"] != System.DBNull.Value)
                    {
                        auxUser.ISALDOSPOSITIVOS = (decimal)(dr["SALDOSPOSITIVOS"]);
                    }
                    if (dr["SALDOSNEGATIVOS"] != System.DBNull.Value)
                    {
                        auxUser.ISALDOSNEGATIVOS = (decimal)(dr["SALDOSNEGATIVOS"]);
                    }

                    if (dr["SALDOAPARTADOPOSITIVO"] != System.DBNull.Value)
                    {
                        auxUser.ISALDOAPARTADOPOSITIVO = (decimal)(dr["SALDOAPARTADOPOSITIVO"]);
                    }

                    if (dr["SALDOAPARTADONEGATIVO"] != System.DBNull.Value)
                    {
                        auxUser.ISALDOAPARTADONEGATIVO = (decimal)(dr["SALDOAPARTADONEGATIVO"]);
                    }
                    if (dr["NUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        auxUser.INUMEROINTERIOR = (string)(dr["NUMEROINTERIOR"]);
                    }

                    if (dr["NUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        auxUser.INUMEROEXTERIOR = (string)(dr["NUMEROEXTERIOR"]);
                    }
                    if (dr["GAFFETE"] != System.DBNull.Value)
                    {
                        auxUser.IGAFFETE = (string)(dr["GAFFETE"]);
                    }


                    if (dr["LIMITECREDITO"] != System.DBNull.Value)
                    {
                        auxUser.ILIMITECREDITO = (decimal)(dr["LIMITECREDITO"]);
                    }

                    if (dr["DIAS"] != System.DBNull.Value)
                    {
                        auxUser.IDIAS = (int)(dr["DIAS"]);
                    }

                    if (dr["REVISION"] != System.DBNull.Value)
                    {
                        auxUser.IREVISION = (string)(dr["REVISION"]);
                    }

                    if (dr["PAGOS"] != System.DBNull.Value)
                    {
                        auxUser.IPAGOS = (string)(dr["PAGOS"]);
                    }

                    if (dr["BLOQUEADO"] != System.DBNull.Value)
                    {
                        auxUser.IBLOQUEADO = (string)(dr["BLOQUEADO"]);
                    }

                    if (dr["TICKETLARGO"] != System.DBNull.Value)
                    {
                        auxUser.ITICKETLARGO = (string)(dr["TICKETLARGO"]);
                    }

                    if (dr["ENTREGACALLE"] != System.DBNull.Value)
                    {
                        auxUser.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
                    }
                    if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        auxUser.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
                    }
                    if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        auxUser.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
                    }
                    if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
                    {
                        auxUser.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
                    }
                    if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
                    {
                        auxUser.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
                    }
                    if (dr["ENTREGAESTADO"] != System.DBNull.Value)
                    {
                        auxUser.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
                    }
                    if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        auxUser.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
                    }

                    if (dr["HAB_PAGOTRANSFERENCIA"] != System.DBNull.Value)
                    {
                        auxUser.IHAB_PAGOTRANSFERENCIA = (string)(dr["HAB_PAGOTRANSFERENCIA"]);
                    }


                    if (dr["CREDITOFORMAPAGOABONOS"] != System.DBNull.Value)
                    {
                        auxUser.ICREDITOFORMAPAGOABONOS = (long)(dr["CREDITOFORMAPAGOABONOS"]);
                    }


                    if (dr["CREDITOREFERENCIAABONOS"] != System.DBNull.Value)
                    {
                        auxUser.ICREDITOREFERENCIAABONOS = (string)(dr["CREDITOREFERENCIAABONOS"]);
                    }

                    if (dr["RETIENEISR"] != System.DBNull.Value)
                    {
                        auxUser.IRETIENEISR = (string)(dr["RETIENEISR"]);
                    }


                    if (dr["RETIENEIVA"] != System.DBNull.Value)
                    {
                        auxUser.IRETIENEIVA = (string)(dr["RETIENEIVA"]);
                    }


                    if (dr["MONEDAID"] != System.DBNull.Value)
                    {
                        auxUser.IMONEDAID = (long)(dr["MONEDAID"]);
                    }

                    if (dr["DESGLOSEIEPS"] != System.DBNull.Value)
                    {
                        auxUser.IDESGLOSEIEPS = (string)(dr["DESGLOSEIEPS"]);
                    }

                    if (dr["CUENTAIEPS"] != System.DBNull.Value)
                    {
                        auxUser.ICUENTAIEPS = (string)(dr["CUENTAIEPS"]);
                    }
                    if (dr["SUPERLISTAPRECIOID"] != System.DBNull.Value)
                    {
                        auxUser.ISUPERLISTAPRECIOID = (long)(dr["SUPERLISTAPRECIOID"]);
                    }
                    if (dr["ALMACENID"] != System.DBNull.Value)
                    {
                        auxUser.IALMACENID = (long)(dr["ALMACENID"]);
                    }
                    if (dr["BLOQUEONOT"] != System.DBNull.Value)
                    {
                        auxUser.IBLOQUEONOT = (string)(dr["BLOQUEONOT"]);
                    }

                    if (dr["EMAIL3"] != System.DBNull.Value)
                    {
                        auxUser.IEMAIL3 = (string)(dr["EMAIL3"]);
                    }

                    if (dr["EMAIL4"] != System.DBNull.Value)
                    {
                        auxUser.IEMAIL4 = (string)(dr["EMAIL4"]);
                    }
                    if (dr["CAJASBOTELLAS"] != System.DBNull.Value)
                    {
                        auxUser.ICAJASBOTELLAS = (string)(dr["CAJASBOTELLAS"]);
                    }
                    if (dr["ESTATUSENVIOID"] != System.DBNull.Value)
                    {
                        auxUser.IESTATUSENVIOID = (long)(dr["ESTATUSENVIOID"]);
                    }

                    if (dr["REPLCREADO"] != System.DBNull.Value)
                    {
                        auxUser.IREPLCREADO = (DateTime)(dr["REPLCREADO"]);
                    }
                    if (dr["REPLMODIFICADO"] != System.DBNull.Value)
                    {
                        auxUser.IREPLMODIFICADO = (DateTime)(dr["REPLMODIFICADO"]);
                    }

                    if (dr["TICKETLARGOCREDITO"] != System.DBNull.Value)
                    {
                        auxUser.ITICKETLARGOCREDITO = (string)(dr["TICKETLARGOCREDITO"]);
                    }

                    if (dr["PENDMAXDIAS"] != System.DBNull.Value)
                    {
                        auxUser.IPENDMAXDIAS = (int)(dr["PENDMAXDIAS"]);
                    }

                    if (dr["PAGOPARCIALIDADES"] != System.DBNull.Value)
                    {
                        auxUser.IPAGOPARCIALIDADES = (string)(dr["PAGOPARCIALIDADES"]);
                    }

                    if (dr["SALDOVENCIDOMOVIL"] != System.DBNull.Value)
                    {
                        auxUser.ISALDOVENCIDOMOVIL = (decimal)(dr["SALDOVENCIDOMOVIL"]);
                    }


                    if (dr["SALDOMOVIL"] != System.DBNull.Value)
                    {
                        auxUser.ISALDOMOVIL = (decimal)(dr["SALDOMOVIL"]);
                    }

                    if (dr["GRUPOUSUARIOID"] != System.DBNull.Value)
                    {
                        auxUser.IGRUPOUSUARIOID = (long)(dr["GRUPOUSUARIOID"]);
                    }

                    if (dr["CREDITOFORMAPAGOSATABONOS"] != System.DBNull.Value)
                    {
                        auxUser.ICREDITOFORMAPAGOSATABONOS = (long)(dr["CREDITOFORMAPAGOSATABONOS"]);
                    }

                    if (dr["SERVICIOADOMICILIO"] != System.DBNull.Value)
                    {
                        auxUser.ISERVICIOADOMICILIO = (string)(dr["SERVICIOADOMICILIO"]);
                    }

                    if (dr["ULTIMAVENTA"] != System.DBNull.Value)
                    {
                        auxUser.IULTIMAVENTA = (DateTime)(dr["ULTIMAVENTA"]);
                    }

                    if (dr["GENERARRECIBOELECTRONICO"] != System.DBNull.Value)
                    {
                        auxUser.IGENERARRECIBOELECTRONICO = (string)(dr["GENERARRECIBOELECTRONICO"]);
                    }

                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        auxUser.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }

                    if (dr["REFERENCIADOM"] != System.DBNull.Value)
                    {
                        auxUser.IREFERENCIADOM = (string)(dr["REFERENCIADOM"]);
                    }

                    if (dr["HAB_PAGOEFECTIVO"] != System.DBNull.Value)
                    {
                        auxUser.IHAB_PAGOEFECTIVO = (string)(dr["HAB_PAGOEFECTIVO"]);
                    }

                    if (dr["CLERKPAGOSERVICIOSID"] != System.DBNull.Value)
                    {
                        auxUser.ICLERKPAGOSERVICIOSID = (long)(dr["CLERKPAGOSERVICIOSID"]);
                    }

                    if (dr["CLERKSERVICIOS"] != System.DBNull.Value)
                    {
                        auxUser.ICLERKSERVICIOS = (long)(dr["CLERKSERVICIOS"]);
                    }

                    if (dr["BANCOMERDOCTOPENDID"] != System.DBNull.Value)
                    {
                        auxUser.IBANCOMERDOCTOPENDID = (long)(dr["BANCOMERDOCTOPENDID"]);
                    }


                    if (dr["SOLICITAORDENCOMPRA"] != System.DBNull.Value)
                    {
                        auxUser.ISOLICITAORDENCOMPRA = (string)(dr["SOLICITAORDENCOMPRA"]);
                    }


                    if (dr["CUENTACONTPAQ"] != System.DBNull.Value)
                    {
                        auxUser.ICUENTACONTPAQ = (string)(dr["CUENTACONTPAQ"]);
                    }

                    if (dr["ESIMPORTADOR"] != System.DBNull.Value)
                    {
                        auxUser.IESIMPORTADOR = (string)(dr["ESIMPORTADOR"]);
                    }

                    try
                    {
                        if (dr["SEPARARPRODXPLAZO"] != System.DBNull.Value)
                        {
                            auxUser.ISEPARARPRODXPLAZO = (string)(dr["SEPARARPRODXPLAZO"]);
                        }


                        //agregar aqui los demas campos que se agreguen, por lo de los passwords


                    }
                    catch(Exception ex)
                    {

                    }

                    try
                    {

                        if (dr["CARGOXVENTACONTARJETA"] != System.DBNull.Value)
                        {
                            auxUser.ICARGOXVENTACONTARJETA = (string)(dr["CARGOXVENTACONTARJETA"]);
                        }
                    }
                    catch(Exception ex)
                    {

                    }



                    try
                    {


                        if (dr["PAGOTARJMENORPRECIOLISTA"] != System.DBNull.Value)
                        {
                            auxUser.IPAGOTARJMENORPRECIOLISTA = (string)(dr["PAGOTARJMENORPRECIOLISTA"]);
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    

                    try
                    {

                        if (dr["SAT_CLAVE_PAIS"] != System.DBNull.Value)
                        {
                            auxUser.ISAT_CLAVE_PAIS = (string)(dr["SAT_CLAVE_PAIS"]);
                        }


                    }
                    catch
                    {

                    }

                    try
                    {

                        if (dr["PROVEECLIENTEID"] != System.DBNull.Value)
                        {
                            auxUser.IPROVEECLIENTEID = (long)(dr["PROVEECLIENTEID"]);
                        }
                    }
                    catch
                    {

                    }

                    try
                    {

                        if (dr["EXENTOIVA"] != System.DBNull.Value)
                        {
                            auxUser.IEXENTOIVA = (string)(dr["EXENTOIVA"]);
                        }

                    }
                    catch
                    {

                    }


                    try
                    {

                        if (dr["TICKETLARGOCOTIZACION"] != System.DBNull.Value)
                        {
                            auxUser.ITICKETLARGOCOTIZACION = (string)(dr["TICKETLARGOCOTIZACION"]);
                        }


                    }
                    catch
                    {

                    }


                    try
                    {


                        if (dr["CODIGOAUTORIZACION"] != System.DBNull.Value)
                        {
                            auxUser.ICODIGOAUTORIZACION = (string)(dr["CODIGOAUTORIZACION"]);
                        }

                    }
                    catch
                    {

                    }

                    try
                    {
                        if (dr["CLIEFORMASPAGODEF"] != System.DBNull.Value)
                        {
                            auxUser.ICLIEFORMASPAGODEF = (string)(dr["CLIEFORMASPAGODEF"]);
                        }

                    }
                    catch
                    {

                    }





                    try
                    {
                        if (dr["POR_COME"] != System.DBNull.Value)
                        {
                            auxUser.IPOR_COME = (decimal)(dr["POR_COME"]);
                        }
                    }
                    catch { }


                    try
                    {
                        if (dr["DIAS_EXTR"] != System.DBNull.Value)
                        {
                            auxUser.IDIAS_EXTR = (int)(dr["DIAS_EXTR"]);
                        }
                    }
                    catch { }


                    try
                    {
                        if (dr["ADESCPES"] != System.DBNull.Value)
                        {
                            auxUser.IADESCPES = (decimal)(dr["ADESCPES"]);
                        }
                    }
                    catch { }


                    try
                    {
                        if (dr["MAYOREOXPRODUCTO"] != System.DBNull.Value)
                        {
                            auxUser.IMAYOREOXPRODUCTO = (string)(dr["MAYOREOXPRODUCTO"]);
                        }
                    }
                    catch { }


                    try
                    {

                        if (dr["GENERACOMPROBTRASL"] != System.DBNull.Value)
                        {
                            auxUser.IGENERACOMPROBTRASL = (string)(dr["GENERACOMPROBTRASL"]);
                        }

                        if (dr["GENERACARTAPORTE"] != System.DBNull.Value)
                        {
                            auxUser.IGENERACARTAPORTE = (string)(dr["GENERACARTAPORTE"]);
                        }
                    }
                    catch { }

                    try
                    {
                        if (dr["SAT_COLONIAID"] != System.DBNull.Value)
                        {
                            auxUser.ISAT_COLONIAID = (long)(dr["SAT_COLONIAID"]);
                        }

                        if (dr["SAT_LOCALIDADID"] != System.DBNull.Value)
                        {
                            auxUser.ISAT_LOCALIDADID = (long)(dr["SAT_LOCALIDADID"]);
                        }

                        if (dr["SAT_MUNICIPIOID"] != System.DBNull.Value)
                        {
                            auxUser.ISAT_MUNICIPIOID = (long)(dr["SAT_MUNICIPIOID"]);
                        }

                        if (dr["DISTANCIA"] != System.DBNull.Value)
                        {
                            auxUser.IDISTANCIA = (decimal)(dr["DISTANCIA"]);
                        }
                    }
                    catch { }
                    try
                    {
                        if (dr["ENTREGA_SAT_COLONIAID"] != System.DBNull.Value)
                        {
                            auxUser.IENTREGA_SAT_COLONIAID = (long)(dr["ENTREGA_SAT_COLONIAID"]);
                        }

                        if (dr["ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value)
                        {
                            auxUser.IENTREGA_SAT_LOCALIDADID = (long)(dr["ENTREGA_SAT_LOCALIDADID"]);
                        }

                        if (dr["ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value)
                        {
                            auxUser.IENTREGA_SAT_MUNICIPIOID = (long)(dr["ENTREGA_SAT_MUNICIPIOID"]);
                        }

                        if (dr["ENTREGA_DISTANCIA"] != System.DBNull.Value)
                        {
                            auxUser.IENTREGA_DISTANCIA = (decimal)(dr["ENTREGA_DISTANCIA"]);
                        }

                        if (dr["ENTREGAREFERENCIADOM"] != System.DBNull.Value)
                        {
                            auxUser.IENTREGAREFERENCIADOM = (string)(dr["ENTREGAREFERENCIADOM"]);
                        }

                        if (dr["FIRMAIMAGEN"] != System.DBNull.Value)
                        {
                            auxUser.IFIRMAIMAGEN = (string)(dr["FIRMAIMAGEN"]);
                        }

                        if (dr["LATITUD"] != System.DBNull.Value)
                        {
                            auxUser.ILATITUD = (double)(dr["LATITUD"]);
                        }

                        if (dr["LONGITUD"] != System.DBNull.Value)
                        {
                            auxUser.ILONGITUD = (double)(dr["LONGITUD"]);
                        }

                    }
                    catch { }


                    retorno.Add(auxUser);

                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public CPERSONABE seleccionarPERSONAxCLAVEyTIPO(CPERSONABE oCPERSONA, FbTransaction st)
        {

            CPERSONABE retorno = new CPERSONABE();
            /**/FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONA where CLAVE=@CLAVE and TIPOPERSONAID = @TIPOPERSONAID  ";


                auxPar = new FbParameter("@CLAVE", FbDbType.VarChar);
                auxPar.Value = oCPERSONA.ICLAVE;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOPERSONAID", FbDbType.BigInt);
                auxPar.Value = oCPERSONA.ITIPOPERSONAID;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {

                    if (dr["ID"] != System.DBNull.Value)
                    {
                        retorno.IID = (long)(dr["ID"]);
                    }

                    if (dr["ACTIVO"] != System.DBNull.Value)
                    {
                        retorno.IACTIVO = (string)(dr["ACTIVO"]);
                    }

                    if (dr["CREADO"] != System.DBNull.Value)
                    {
                        retorno.ICREADO = (object)(dr["CREADO"]);
                    }

                    if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
                    }

                    if (dr["MODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADO = (object)(dr["MODIFICADO"]);
                    }

                    if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
                    {
                        retorno.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
                    }

                    if (dr["TIPOPERSONAID"] != System.DBNull.Value)
                    {
                        retorno.ITIPOPERSONAID = (long)(dr["TIPOPERSONAID"]);
                    }

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        retorno.ICLAVE = (string)(dr["CLAVE"]);
                    }

                    if (dr["NOMBRE"] != System.DBNull.Value)
                    {
                        retorno.INOMBRE = (string)(dr["NOMBRE"]);
                    }

                    if (dr["DESCRIPCION"] != System.DBNull.Value)
                    {
                        retorno.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
                    }

                    if (dr["MEMO"] != System.DBNull.Value)
                    {
                        retorno.IMEMO = (string)(dr["MEMO"]);
                    }

                    if (dr["SALUDOID"] != System.DBNull.Value)
                    {
                        retorno.ISALUDOID = (long)(dr["SALUDOID"]);
                    }

                    if (dr["NOMBRES"] != System.DBNull.Value)
                    {
                        retorno.INOMBRES = (string)(dr["NOMBRES"]);
                    }

                    if (dr["APELLIDOS"] != System.DBNull.Value)
                    {
                        retorno.IAPELLIDOS = (string)(dr["APELLIDOS"]);
                    }

                    if (dr["RAZONSOCIAL"] != System.DBNull.Value)
                    {
                        retorno.IRAZONSOCIAL = (string)(dr["RAZONSOCIAL"]);
                    }

                    if (dr["RFC"] != System.DBNull.Value)
                    {
                        retorno.IRFC = (string)(dr["RFC"]);
                    }

                    if (dr["CONTACTO1"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO1 = (string)(dr["CONTACTO1"]);
                    }

                    if (dr["CONTACTO2"] != System.DBNull.Value)
                    {
                        retorno.ICONTACTO2 = (string)(dr["CONTACTO2"]);
                    }

                    if (dr["USERNAME"] != System.DBNull.Value)
                    {
                        retorno.IUSERNAME = (string)(dr["USERNAME"]);
                    }

                    if (dr["CLAVEACCESO"] != System.DBNull.Value)
                    {
                        retorno.ICLAVEACCESO = (string)(dr["CLAVEACCESO"]);
                    }

                    if (dr["DOMICILIO"] != System.DBNull.Value)
                    {
                        retorno.IDOMICILIO = (string)(dr["DOMICILIO"]);
                    }

                    if (dr["COLONIA"] != System.DBNull.Value)
                    {
                        retorno.ICOLONIA = (string)(dr["COLONIA"]);
                    }

                    if (dr["CIUDAD"] != System.DBNull.Value)
                    {
                        retorno.ICIUDAD = (string)(dr["CIUDAD"]);
                    }

                    if (dr["MUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IMUNICIPIO = (string)(dr["MUNICIPIO"]);
                    }

                    if (dr["ESTADO"] != System.DBNull.Value)
                    {
                        retorno.IESTADO = (string)(dr["ESTADO"]);
                    }

                    if (dr["PAIS"] != System.DBNull.Value)
                    {
                        retorno.IPAIS = (string)(dr["PAIS"]);
                    }

                    if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.ICODIGOPOSTAL = (string)(dr["CODIGOPOSTAL"]);
                    }

                    if (dr["TELEFONO1"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO1 = (string)(dr["TELEFONO1"]);
                    }

                    if (dr["TELEFONO2"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO2 = (string)(dr["TELEFONO2"]);
                    }

                    if (dr["TELEFONO3"] != System.DBNull.Value)
                    {
                        retorno.ITELEFONO3 = (string)(dr["TELEFONO3"]);
                    }

                    if (dr["CELULAR"] != System.DBNull.Value)
                    {
                        retorno.ICELULAR = (string)(dr["CELULAR"]);
                    }

                    if (dr["NEXTEL"] != System.DBNull.Value)
                    {
                        retorno.INEXTEL = (string)(dr["NEXTEL"]);
                    }

                    if (dr["EMAIL1"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL1 = (string)(dr["EMAIL1"]);
                    }

                    if (dr["EMAIL2"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL2 = (string)(dr["EMAIL2"]);
                    }

                    if (dr["EMPRESAID"] != System.DBNull.Value)
                    {
                        retorno.IEMPRESAID = (long)(dr["EMPRESAID"]);
                    }

                    if (dr["VENDEDORID"] != System.DBNull.Value)
                    {
                        retorno.IVENDEDORID = (long)(dr["VENDEDORID"]);
                    }

                    if (dr["ESCLIENTE"] != System.DBNull.Value)
                    {
                        retorno.IESCLIENTE = (string)(dr["ESCLIENTE"]);
                    }

                    if (dr["ESCLIENTEGENERAL"] != System.DBNull.Value)
                    {
                        retorno.IESCLIENTEGENERAL = (string)(dr["ESCLIENTEGENERAL"]);
                    }

                    if (dr["ESPROVEEDOR"] != System.DBNull.Value)
                    {
                        retorno.IESPROVEEDOR = (string)(dr["ESPROVEEDOR"]);
                    }

                    if (dr["ESUSUARIO"] != System.DBNull.Value)
                    {
                        retorno.IESUSUARIO = (string)(dr["ESUSUARIO"]);
                    }

                    if (dr["LISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.ILISTAPRECIOID = (long)(dr["LISTAPRECIOID"]);
                    }

                    if (dr["VIGENCIA"] != System.DBNull.Value)
                    {
                        retorno.IVIGENCIA = (DateTime)(dr["VIGENCIA"]);
                    }

                    if (dr["RESET_PASS"] != System.DBNull.Value)
                    {
                        retorno.IRESET_PASS = short.Parse(dr["RESET_PASS"].ToString());
                    }
                    if (dr["HAB_PAGOTARJETA"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOTARJETA = (string)(dr["HAB_PAGOTARJETA"]);
                    }

                    if (dr["HAB_PAGOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOCREDITO = (string)(dr["HAB_PAGOCREDITO"]);
                    }

                    if (dr["HAB_PAGOCHEQUE"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOCHEQUE = (string)(dr["HAB_PAGOCHEQUE"]);
                    }
                    if (dr["CORTEID"] != System.DBNull.Value)
                    {
                        retorno.ICORTEID = (long)(dr["CORTEID"]);
                    }
                    if (dr["SALDO"] != System.DBNull.Value)
                    {
                        retorno.ISALDO = (decimal)(dr["SALDO"]);
                    }

                    if (dr["SALDOAPARTADO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADO = (decimal)(dr["SALDOAPARTADO"]);
                    }
                    if (dr["SALDOSPOSITIVOS"] != System.DBNull.Value)
                    {
                        retorno.ISALDOSPOSITIVOS = (decimal)(dr["SALDOSPOSITIVOS"]);
                    }
                    if (dr["SALDOSNEGATIVOS"] != System.DBNull.Value)
                    {
                        retorno.ISALDOSNEGATIVOS = (decimal)(dr["SALDOSNEGATIVOS"]);
                    }

                    if (dr["SALDOAPARTADOPOSITIVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADOPOSITIVO = (decimal)(dr["SALDOAPARTADOPOSITIVO"]);
                    }

                    if (dr["SALDOAPARTADONEGATIVO"] != System.DBNull.Value)
                    {
                        retorno.ISALDOAPARTADONEGATIVO = (decimal)(dr["SALDOAPARTADONEGATIVO"]);
                    }

                    if (dr["ENTREGACALLE"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
                    }
                    if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
                    }
                    if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
                    {
                        retorno.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
                    }
                    if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
                    }
                    if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
                    }
                    if (dr["ENTREGAESTADO"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
                    }
                    if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
                    {
                        retorno.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
                    }

                    if (dr["HAB_PAGOTRANSFERENCIA"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOTRANSFERENCIA = (string)(dr["HAB_PAGOTRANSFERENCIA"]);
                    }


                    if (dr["CREDITOFORMAPAGOABONOS"] != System.DBNull.Value)
                    {
                        retorno.ICREDITOFORMAPAGOABONOS = (long)(dr["CREDITOFORMAPAGOABONOS"]);
                    }


                    if (dr["CREDITOREFERENCIAABONOS"] != System.DBNull.Value)
                    {
                        retorno.ICREDITOREFERENCIAABONOS = (string)(dr["CREDITOREFERENCIAABONOS"]);
                    }

                    if (dr["RETIENEISR"] != System.DBNull.Value)
                    {
                        retorno.IRETIENEISR = (string)(dr["RETIENEISR"]);
                    }


                    if (dr["RETIENEIVA"] != System.DBNull.Value)
                    {
                        retorno.IRETIENEIVA = (string)(dr["RETIENEIVA"]);
                    }

                    if (dr["MONEDAID"] != System.DBNull.Value)
                    {
                        retorno.IMONEDAID = (long)(dr["MONEDAID"]);
                    }

                    if (dr["DESGLOSEIEPS"] != System.DBNull.Value)
                    {
                        retorno.IDESGLOSEIEPS = (string)(dr["DESGLOSEIEPS"]);
                    }

                    if (dr["CUENTAIEPS"] != System.DBNull.Value)
                    {
                        retorno.ICUENTAIEPS = (string)(dr["CUENTAIEPS"]);
                    }
                    if (dr["SUPERLISTAPRECIOID"] != System.DBNull.Value)
                    {
                        retorno.ISUPERLISTAPRECIOID = (long)(dr["SUPERLISTAPRECIOID"]);
                    }
                    if (dr["ALMACENID"] != System.DBNull.Value)
                    {
                        retorno.IALMACENID = (long)(dr["ALMACENID"]);
                    }
                    if (dr["BLOQUEONOT"] != System.DBNull.Value)
                    {
                        retorno.IBLOQUEONOT = (string)(dr["BLOQUEONOT"]);
                    }
                    if (dr["EMAIL3"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL3 = (string)(dr["EMAIL3"]);
                    }

                    if (dr["EMAIL4"] != System.DBNull.Value)
                    {
                        retorno.IEMAIL4 = (string)(dr["EMAIL4"]);
                    }
                    if (dr["ESTATUSENVIOID"] != System.DBNull.Value)
                    {
                        retorno.IESTATUSENVIOID = (long)(dr["ESTATUSENVIOID"]);
                    }

                    if (dr["REPLCREADO"] != System.DBNull.Value)
                    {
                        retorno.IREPLCREADO = (DateTime)(dr["REPLCREADO"]);
                    }
                    if (dr["REPLMODIFICADO"] != System.DBNull.Value)
                    {
                        retorno.IREPLMODIFICADO = (DateTime)(dr["REPLMODIFICADO"]);
                    }


                    if (dr["TICKETLARGO"] != System.DBNull.Value)
                    {
                        retorno.ITICKETLARGO = (string)(dr["TICKETLARGO"]);
                    }

                    if (dr["TICKETLARGOCREDITO"] != System.DBNull.Value)
                    {
                        retorno.ITICKETLARGOCREDITO = (string)(dr["TICKETLARGOCREDITO"]);
                    }

                    if (dr["PENDMAXDIAS"] != System.DBNull.Value)
                    {
                        retorno.IPENDMAXDIAS = (int)(dr["PENDMAXDIAS"]);
                    }

                    if (dr["DIAS"] != System.DBNull.Value)
                    {
                        retorno.IDIAS = (int)(dr["DIAS"]);
                    }

                    if (dr["PAGOPARCIALIDADES"] != System.DBNull.Value)
                    {
                        retorno.IPAGOPARCIALIDADES = (string)(dr["PAGOPARCIALIDADES"]);
                    }
                    if (dr["SALDOVENCIDOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOVENCIDOMOVIL = (decimal)(dr["SALDOVENCIDOMOVIL"]);
                    }


                    if (dr["SALDOMOVIL"] != System.DBNull.Value)
                    {
                        retorno.ISALDOMOVIL = (decimal)(dr["SALDOMOVIL"]);
                    }

                    if (dr["GRUPOUSUARIOID"] != System.DBNull.Value)
                    {
                        retorno.IGRUPOUSUARIOID = (long)(dr["GRUPOUSUARIOID"]);
                    }

                    if (dr["CREDITOFORMAPAGOSATABONOS"] != System.DBNull.Value)
                    {
                        retorno.ICREDITOFORMAPAGOSATABONOS = (long)(dr["CREDITOFORMAPAGOSATABONOS"]);
                    }

                    if (dr["SERVICIOADOMICILIO"] != System.DBNull.Value)
                    {
                        retorno.ISERVICIOADOMICILIO = (string)(dr["SERVICIOADOMICILIO"]);
                    }

                    if (dr["ULTIMAVENTA"] != System.DBNull.Value)
                    {
                        retorno.IULTIMAVENTA = (DateTime)(dr["ULTIMAVENTA"]);
                    }

                    if (dr["GENERARRECIBOELECTRONICO"] != System.DBNull.Value)
                    {
                        retorno.IGENERARRECIBOELECTRONICO = (string)(dr["GENERARRECIBOELECTRONICO"]);
                    }


                    if (dr["LOCALIDAD"] != System.DBNull.Value)
                    {
                        retorno.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
                    }

                    if (dr["REFERENCIADOM"] != System.DBNull.Value)
                    {
                        retorno.IREFERENCIADOM = (string)(dr["REFERENCIADOM"]);
                    }

                    if (dr["HAB_PAGOEFECTIVO"] != System.DBNull.Value)
                    {
                        retorno.IHAB_PAGOEFECTIVO = (string)(dr["HAB_PAGOEFECTIVO"]);
                    }

                    if (dr["CLERKPAGOSERVICIOSID"] != System.DBNull.Value)
                    {
                        retorno.ICLERKPAGOSERVICIOSID = (long)(dr["CLERKPAGOSERVICIOSID"]);
                    }

                    if (dr["CLERKSERVICIOS"] != System.DBNull.Value)
                    {
                        retorno.ICLERKSERVICIOS = (long)(dr["CLERKSERVICIOS"]);
                    }

                    if (dr["BANCOMERDOCTOPENDID"] != System.DBNull.Value)
                    {
                        retorno.IBANCOMERDOCTOPENDID = (long)(dr["BANCOMERDOCTOPENDID"]);
                    }


                    if (dr["SOLICITAORDENCOMPRA"] != System.DBNull.Value)
                    {
                        retorno.ISOLICITAORDENCOMPRA = (string)(dr["SOLICITAORDENCOMPRA"]);
                    }


                    if (dr["CUENTACONTPAQ"] != System.DBNull.Value)
                    {
                        retorno.ICUENTACONTPAQ = (string)(dr["CUENTACONTPAQ"]);
                    }

                    if (dr["ESIMPORTADOR"] != System.DBNull.Value)
                    {
                        retorno.IESIMPORTADOR = (string)(dr["ESIMPORTADOR"]);
                    }

                    if (dr["SEPARARPRODXPLAZO"] != System.DBNull.Value)
                    {
                        retorno.ISEPARARPRODXPLAZO = (string)(dr["SEPARARPRODXPLAZO"]);
                    }

                    if (dr["CARGOXVENTACONTARJETA"] != System.DBNull.Value)
                    {
                        retorno.ICARGOXVENTACONTARJETA = (string)(dr["CARGOXVENTACONTARJETA"]);
                    }

                    if (dr["PAGOTARJMENORPRECIOLISTA"] != System.DBNull.Value)
                    {
                        retorno.IPAGOTARJMENORPRECIOLISTA = (string)(dr["PAGOTARJMENORPRECIOLISTA"]);
                    }




                    if (dr["SAT_CLAVE_PAIS"] != System.DBNull.Value)
                    {
                        retorno.ISAT_CLAVE_PAIS = (string)(dr["SAT_CLAVE_PAIS"]);
                    }


                    if (dr["PROVEECLIENTEID"] != System.DBNull.Value)
                    {
                        retorno.IPROVEECLIENTEID = (long)(dr["PROVEECLIENTEID"]);
                    }


                    if (dr["EXENTOIVA"] != System.DBNull.Value)
                    {
                        retorno.IEXENTOIVA = (string)(dr["EXENTOIVA"]);
                    }

                    if (dr["TICKETLARGOCOTIZACION"] != System.DBNull.Value)
                    {
                        retorno.ITICKETLARGOCOTIZACION = (string)(dr["TICKETLARGOCOTIZACION"]);
                    }

                    if (dr["SAT_USOCFDIID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_USOCFDIID = (long)(dr["SAT_USOCFDIID"]);
                    }

                    if (dr["CLIEFORMASPAGODEF"] != System.DBNull.Value)
                    {
                        retorno.ICLIEFORMASPAGODEF = (string)(dr["CLIEFORMASPAGODEF"]);
                    }

                    if (dr["RUTAEMBARQUEID"] != System.DBNull.Value)
                    {
                        retorno.IRUTAEMBARQUEID = (long)(dr["RUTAEMBARQUEID"]);
                    }

                    if (dr["SUBTIPOCLIENTE"] != System.DBNull.Value)
                    {
                        retorno.ISUBTIPOCLIENTE = (string)(dr["SUBTIPOCLIENTE"]);
                    }

                    if (dr["PREGUNTARTICKETLARGO"] != System.DBNull.Value)
                    {
                        retorno.IPREGUNTARTICKETLARGO = (string)(dr["PREGUNTARTICKETLARGO"]);
                    }


                    if (dr["MAYOREOXPRODUCTO"] != System.DBNull.Value)
                    {
                        retorno.IMAYOREOXPRODUCTO = (string)(dr["MAYOREOXPRODUCTO"]);
                    }

                    if (dr["GENERACOMPROBTRASL"] != System.DBNull.Value)
                    {
                        retorno.IGENERACOMPROBTRASL = (string)(dr["GENERACOMPROBTRASL"]);
                    }

                    if (dr["GENERACARTAPORTE"] != System.DBNull.Value)
                    {
                        retorno.IGENERACARTAPORTE = (string)(dr["GENERACARTAPORTE"]);
                    }

                    if (dr["SAT_COLONIAID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_COLONIAID = (long)(dr["SAT_COLONIAID"]);
                    }

                    if (dr["SAT_LOCALIDADID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_LOCALIDADID = (long)(dr["SAT_LOCALIDADID"]);
                    }

                    if (dr["SAT_MUNICIPIOID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_MUNICIPIOID = (long)(dr["SAT_MUNICIPIOID"]);
                    }

                    if (dr["DISTANCIA"] != System.DBNull.Value)
                    {
                        retorno.IDISTANCIA = (decimal)(dr["DISTANCIA"]);
                    }

                    if (dr["ENTREGA_SAT_COLONIAID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_COLONIAID = (long)(dr["ENTREGA_SAT_COLONIAID"]);
                    }

                    if (dr["ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_LOCALIDADID = (long)(dr["ENTREGA_SAT_LOCALIDADID"]);
                    }

                    if (dr["ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_SAT_MUNICIPIOID = (long)(dr["ENTREGA_SAT_MUNICIPIOID"]);
                    }

                    if (dr["ENTREGA_DISTANCIA"] != System.DBNull.Value)
                    {
                        retorno.IENTREGA_DISTANCIA = (decimal)(dr["ENTREGA_DISTANCIA"]);
                    }

                    if (dr["ENTREGAREFERENCIADOM"] != System.DBNull.Value)
                    {
                        retorno.IENTREGAREFERENCIADOM = (string)(dr["ENTREGAREFERENCIADOM"]);
                    }

                    if (dr["SAT_REGIMENFISCALID"] != System.DBNull.Value)
                    {
                        retorno.ISAT_REGIMENFISCALID = (long)(dr["SAT_REGIMENFISCALID"]);
                    }

                    if (dr["NOMBREIMPRESORA"] != System.DBNull.Value)
                    {
                        retorno.INOMBREIMPRESORA = (string)(dr["NOMBREIMPRESORA"]);
                    }

                    if (dr["FIRMAIMAGEN"] != System.DBNull.Value)
                    {
                        retorno.IFIRMAIMAGEN = (string)(dr["FIRMAIMAGEN"]);
                    }
                }
                else
                {
                    retorno = null;
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }

        public CPERSONABE SeleccionarPersonaPorId(long id, FbTransaction fbTrans)
        {
            CPERSONABE retorno = new CPERSONABE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONA where ID=@ID";


                auxPar = new FbParameter("@ID", FbDbType.BigInt);
                auxPar.Value = id;
                parts.Add(auxPar);

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (fbTrans == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(fbTrans, CommandType.Text, CmdTxt, arParms);


                if (dr.Read())
                {
                    retorno = getItemDeReader(dr);
                }
                else
                {
                    retorno = null;
                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);

                return retorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }
        }

        public List<CPERSONABE> seleccionarPERSONASxVENDEDOR(CPERSONABE oCPERSONA, FbTransaction st)
        {

            CPERSONABE retorno = new CPERSONABE();
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            List<CPERSONABE> listRetorno = new List<CPERSONABE>();

            try
            {

                System.Collections.ArrayList parts = new ArrayList();
                FbParameter auxPar;

                String CmdTxt = @"select * from PERSONA where VENDEDORID = @VENDEDORID and TIPOPERSONAID = @TIPOPERSONAID  ";


                auxPar = new FbParameter("@VENDEDORID", FbDbType.BigInt);
                auxPar.Value = oCPERSONA.IVENDEDORID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@TIPOPERSONAID", FbDbType.BigInt);
                auxPar.Value = oCPERSONA.ITIPOPERSONAID;
                parts.Add(auxPar);


                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);



                if (st == null)
                    dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
                else
                    dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


                while (dr.Read())
                {
                    
                    retorno = this.getItemDeReader(dr);
                    listRetorno.Add(retorno);
                }

                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return listRetorno;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                this.iComentario = e.Message + e.StackTrace;
                return null;
            }



        }



        public bool limpiarClientesInactivos(FbTransaction st)
        {


            try
            {
                System.Collections.ArrayList parts = new ArrayList();
                //FbParameter auxPar;

                string commandText = @"delete from persona where activo = 'N' and tipopersonaid = 50;";

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

        

        //public CPERSONABE SeleccionarDatosEntregaXDocto(long ldoctoId, FbTransaction st)
        //{

        //    CPERSONABE retorno = new CPERSONABE();
        //    /**/FbDataReader dr = null;
        //    FbConnection pcn = null;

        //    try
        //    {

        //        System.Collections.ArrayList parts = new ArrayList();
        //        FbParameter auxPar;

        //        String CmdTxt = @"select p.* from DOCTO d inner join PERSONA p on d.personaid = p.id where d.id = @DOCTOID  ";


        //        auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
        //        auxPar.Value = ldoctoId;
        //        parts.Add(auxPar);

        //        FbParameter[] arParms = new FbParameter[parts.Count];
        //        parts.CopyTo(arParms, 0);



        //        if (st == null)
        //            dr = SqlHelper.ExecuteReader(this.sCadenaConexion, CommandType.Text, CmdTxt, out pcn, arParms);
        //        else
        //            dr = SqlHelper.ExecuteReader(st, CommandType.Text, CmdTxt, arParms);


        //        if (dr.Read())
        //        {

        //            if (dr["ENTREGACALLE"] != System.DBNull.Value)
        //            {
        //                retorno.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
        //            }
        //            if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
        //            {
        //                retorno.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
        //            }
        //            if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
        //            {
        //                retorno.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
        //            }
        //            if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
        //            {
        //                retorno.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
        //            }
        //            if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
        //            {
        //                retorno.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
        //            }
        //            if (dr["ENTREGAESTADO"] != System.DBNull.Value)
        //            {
        //                retorno.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
        //            }
        //            if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
        //            {
        //                retorno.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
        //            }

        //        }
        //        else
        //        {
        //            retorno = null;
        //        }

        //        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
        //        return retorno;
        //    }
        //    catch (Exception e)
        //    {
        //        Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
        //        this.iComentario = e.Message + e.StackTrace;
        //        return null;
        //    }
        //}




        public CPERSONABE getItemDeReader(FbDataReader dr)
        {

            CPERSONABE auxUser = new CPERSONABE();

            if (dr["ID"] != System.DBNull.Value)
            {
                auxUser.IID = (long)(dr["ID"]);
            }

            if (dr["ACTIVO"] != System.DBNull.Value)
            {
                auxUser.IACTIVO = (string)(dr["ACTIVO"]);
            }

            if (dr["CREADO"] != System.DBNull.Value)
            {
                auxUser.ICREADO = (object)(dr["CREADO"]);
            }

            if (dr["CREADOPOR_USERID"] != System.DBNull.Value)
            {
                auxUser.ICREADOPOR_USERID = (long)(dr["CREADOPOR_USERID"]);
            }

            if (dr["MODIFICADO"] != System.DBNull.Value)
            {
                auxUser.IMODIFICADO = (object)(dr["MODIFICADO"]);
            }

            if (dr["MODIFICADOPOR_USERID"] != System.DBNull.Value)
            {
                auxUser.IMODIFICADOPOR_USERID = (long)(dr["MODIFICADOPOR_USERID"]);
            }

            if (dr["TIPOPERSONAID"] != System.DBNull.Value)
            {
                auxUser.ITIPOPERSONAID = (long)(dr["TIPOPERSONAID"]);
            }

            if (dr["CLAVE"] != System.DBNull.Value)
            {
                auxUser.ICLAVE = (string)(dr["CLAVE"]);
            }

            if (dr["NOMBRE"] != System.DBNull.Value)
            {
                auxUser.INOMBRE = (string)(dr["NOMBRE"]);
            }

            if (dr["DESCRIPCION"] != System.DBNull.Value)
            {
                auxUser.IDESCRIPCION = (string)(dr["DESCRIPCION"]);
            }

            if (dr["MEMO"] != System.DBNull.Value)
            {
                auxUser.IMEMO = (string)(dr["MEMO"]);
            }

            if (dr["SALUDOID"] != System.DBNull.Value)
            {
                auxUser.ISALUDOID = (long)(dr["SALUDOID"]);
            }

            if (dr["NOMBRES"] != System.DBNull.Value)
            {
                auxUser.INOMBRES = (string)(dr["NOMBRES"]);
            }

            if (dr["APELLIDOS"] != System.DBNull.Value)
            {
                auxUser.IAPELLIDOS = (string)(dr["APELLIDOS"]);
            }

            if (dr["RAZONSOCIAL"] != System.DBNull.Value)
            {
                auxUser.IRAZONSOCIAL = (string)(dr["RAZONSOCIAL"]);
            }

            if (dr["RFC"] != System.DBNull.Value)
            {
                auxUser.IRFC = (string)(dr["RFC"]);
            }

            if (dr["CONTACTO1"] != System.DBNull.Value)
            {
                auxUser.ICONTACTO1 = (string)(dr["CONTACTO1"]);
            }

            if (dr["CONTACTO2"] != System.DBNull.Value)
            {
                auxUser.ICONTACTO2 = (string)(dr["CONTACTO2"]);
            }

            if (dr["USERNAME"] != System.DBNull.Value)
            {
                auxUser.IUSERNAME = (string)(dr["USERNAME"]);
            }

            if (dr["CLAVEACCESO"] != System.DBNull.Value)
            {
                auxUser.ICLAVEACCESO = (string)(dr["CLAVEACCESO"]);
            }

            if (dr["DOMICILIO"] != System.DBNull.Value)
            {
                auxUser.IDOMICILIO = (string)(dr["DOMICILIO"]);
            }

            if (dr["COLONIA"] != System.DBNull.Value)
            {
                auxUser.ICOLONIA = (string)(dr["COLONIA"]);
            }

            if (dr["CIUDAD"] != System.DBNull.Value)
            {
                auxUser.ICIUDAD = (string)(dr["CIUDAD"]);
            }

            if (dr["MUNICIPIO"] != System.DBNull.Value)
            {
                auxUser.IMUNICIPIO = (string)(dr["MUNICIPIO"]);
            }

            if (dr["ESTADO"] != System.DBNull.Value)
            {
                auxUser.IESTADO = (string)(dr["ESTADO"]);
            }

            if (dr["PAIS"] != System.DBNull.Value)
            {
                auxUser.IPAIS = (string)(dr["PAIS"]);
            }

            if (dr["CODIGOPOSTAL"] != System.DBNull.Value)
            {
                auxUser.ICODIGOPOSTAL = (string)(dr["CODIGOPOSTAL"]);
            }

            if (dr["TELEFONO1"] != System.DBNull.Value)
            {
                auxUser.ITELEFONO1 = (string)(dr["TELEFONO1"]);
            }

            if (dr["TELEFONO2"] != System.DBNull.Value)
            {
                auxUser.ITELEFONO2 = (string)(dr["TELEFONO2"]);
            }

            if (dr["TELEFONO3"] != System.DBNull.Value)
            {
                auxUser.ITELEFONO3 = (string)(dr["TELEFONO3"]);
            }

            if (dr["CELULAR"] != System.DBNull.Value)
            {
                auxUser.ICELULAR = (string)(dr["CELULAR"]);
            }

            if (dr["NEXTEL"] != System.DBNull.Value)
            {
                auxUser.INEXTEL = (string)(dr["NEXTEL"]);
            }

            if (dr["EMAIL1"] != System.DBNull.Value)
            {
                auxUser.IEMAIL1 = (string)(dr["EMAIL1"]);
            }

            if (dr["EMAIL2"] != System.DBNull.Value)
            {
                auxUser.IEMAIL2 = (string)(dr["EMAIL2"]);
            }

            if (dr["EMPRESAID"] != System.DBNull.Value)
            {
                auxUser.IEMPRESAID = (long)(dr["EMPRESAID"]);
            }

            if (dr["VENDEDORID"] != System.DBNull.Value)
            {
                auxUser.IVENDEDORID = (long)(dr["VENDEDORID"]);
            }

            if (dr["ESCLIENTE"] != System.DBNull.Value)
            {
                auxUser.IESCLIENTE = (string)(dr["ESCLIENTE"]);
            }

            if (dr["ESCLIENTEGENERAL"] != System.DBNull.Value)
            {
                auxUser.IESCLIENTEGENERAL = (string)(dr["ESCLIENTEGENERAL"]);
            }

            if (dr["ESPROVEEDOR"] != System.DBNull.Value)
            {
                auxUser.IESPROVEEDOR = (string)(dr["ESPROVEEDOR"]);
            }

            if (dr["ESUSUARIO"] != System.DBNull.Value)
            {
                auxUser.IESUSUARIO = (string)(dr["ESUSUARIO"]);
            }

            if (dr["LISTAPRECIOID"] != System.DBNull.Value)
            {
                auxUser.ILISTAPRECIOID = (long)(dr["LISTAPRECIOID"]);
            }

            if (dr["VIGENCIA"] != System.DBNull.Value)
            {
                auxUser.IVIGENCIA = (DateTime)(dr["VIGENCIA"]);
            }

            if (dr["RESET_PASS"] != System.DBNull.Value)
            {
                auxUser.IRESET_PASS = short.Parse(dr["RESET_PASS"].ToString());
            }
            if (dr["HAB_PAGOTARJETA"] != System.DBNull.Value)
            {
                auxUser.IHAB_PAGOTARJETA = (string)(dr["HAB_PAGOTARJETA"]);
            }

            if (dr["HAB_PAGOCREDITO"] != System.DBNull.Value)
            {
                auxUser.IHAB_PAGOCREDITO = (string)(dr["HAB_PAGOCREDITO"]);
            }

            if (dr["HAB_PAGOCHEQUE"] != System.DBNull.Value)
            {
                auxUser.IHAB_PAGOCHEQUE = (string)(dr["HAB_PAGOCHEQUE"]);
            }

            if (dr["CORTEID"] != System.DBNull.Value)
            {
                auxUser.ICORTEID = (long)(dr["CORTEID"]);
            }
            if (dr["SALDO"] != System.DBNull.Value)
            {
                auxUser.ISALDO = (decimal)(dr["SALDO"]);
            }

            if (dr["SALDOAPARTADO"] != System.DBNull.Value)
            {
                auxUser.ISALDOAPARTADO = (decimal)(dr["SALDOAPARTADO"]);
            }
            if (dr["SALDOSPOSITIVOS"] != System.DBNull.Value)
            {
                auxUser.ISALDOSPOSITIVOS = (decimal)(dr["SALDOSPOSITIVOS"]);
            }
            if (dr["SALDOSNEGATIVOS"] != System.DBNull.Value)
            {
                auxUser.ISALDOSNEGATIVOS = (decimal)(dr["SALDOSNEGATIVOS"]);
            }

            if (dr["SALDOAPARTADOPOSITIVO"] != System.DBNull.Value)
            {
                auxUser.ISALDOAPARTADOPOSITIVO = (decimal)(dr["SALDOAPARTADOPOSITIVO"]);
            }

            if (dr["SALDOAPARTADONEGATIVO"] != System.DBNull.Value)
            {
                auxUser.ISALDOAPARTADONEGATIVO = (decimal)(dr["SALDOAPARTADONEGATIVO"]);
            }
            if (dr["NUMEROINTERIOR"] != System.DBNull.Value)
            {
                auxUser.INUMEROINTERIOR = (string)(dr["NUMEROINTERIOR"]);
            }

            if (dr["NUMEROEXTERIOR"] != System.DBNull.Value)
            {
                auxUser.INUMEROEXTERIOR = (string)(dr["NUMEROEXTERIOR"]);
            }
            if (dr["GAFFETE"] != System.DBNull.Value)
            {
                auxUser.IGAFFETE = (string)(dr["GAFFETE"]);
            }


            if (dr["LIMITECREDITO"] != System.DBNull.Value)
            {
                auxUser.ILIMITECREDITO = (decimal)(dr["LIMITECREDITO"]);
            }

            if (dr["DIAS"] != System.DBNull.Value)
            {
                auxUser.IDIAS = (int)(dr["DIAS"]);
            }

            if (dr["REVISION"] != System.DBNull.Value)
            {
                auxUser.IREVISION = (string)(dr["REVISION"]);
            }

            if (dr["PAGOS"] != System.DBNull.Value)
            {
                auxUser.IPAGOS = (string)(dr["PAGOS"]);
            }

            if (dr["BLOQUEADO"] != System.DBNull.Value)
            {
                auxUser.IBLOQUEADO = (string)(dr["BLOQUEADO"]);
            }

            if (dr["TICKETLARGO"] != System.DBNull.Value)
            {
                auxUser.ITICKETLARGO = (string)(dr["TICKETLARGO"]);
            }

            if (dr["ENTREGACALLE"] != System.DBNull.Value)
            {
                auxUser.IENTREGACALLE = (string)(dr["ENTREGACALLE"]);
            }
            if (dr["ENTREGANUMEROINTERIOR"] != System.DBNull.Value)
            {
                auxUser.IENTREGANUMEROINTERIOR = (string)(dr["ENTREGANUMEROINTERIOR"]);
            }
            if (dr["ENTREGANUMEROEXTERIOR"] != System.DBNull.Value)
            {
                auxUser.IENTREGANUMEROEXTERIOR = (string)(dr["ENTREGANUMEROEXTERIOR"]);
            }
            if (dr["ENTREGACOLONIA"] != System.DBNull.Value)
            {
                auxUser.IENTREGACOLONIA = (string)(dr["ENTREGACOLONIA"]);
            }
            if (dr["ENTREGAMUNICIPIO"] != System.DBNull.Value)
            {
                auxUser.IENTREGAMUNICIPIO = (string)(dr["ENTREGAMUNICIPIO"]);
            }
            if (dr["ENTREGAESTADO"] != System.DBNull.Value)
            {
                auxUser.IENTREGAESTADO = (string)(dr["ENTREGAESTADO"]);
            }
            if (dr["ENTREGACODIGOPOSTAL"] != System.DBNull.Value)
            {
                auxUser.IENTREGACODIGOPOSTAL = (string)(dr["ENTREGACODIGOPOSTAL"]);
            }

            if (dr["HAB_PAGOTRANSFERENCIA"] != System.DBNull.Value)
            {
                auxUser.IHAB_PAGOTRANSFERENCIA = (string)(dr["HAB_PAGOTRANSFERENCIA"]);
            }


            if (dr["CREDITOFORMAPAGOABONOS"] != System.DBNull.Value)
            {
                auxUser.ICREDITOFORMAPAGOABONOS = (long)(dr["CREDITOFORMAPAGOABONOS"]);
            }


            if (dr["CREDITOREFERENCIAABONOS"] != System.DBNull.Value)
            {
                auxUser.ICREDITOREFERENCIAABONOS = (string)(dr["CREDITOREFERENCIAABONOS"]);
            }

            if (dr["RETIENEISR"] != System.DBNull.Value)
            {
                auxUser.IRETIENEISR = (string)(dr["RETIENEISR"]);
            }


            if (dr["RETIENEIVA"] != System.DBNull.Value)
            {
                auxUser.IRETIENEIVA = (string)(dr["RETIENEIVA"]);
            }


            if (dr["MONEDAID"] != System.DBNull.Value)
            {
                auxUser.IMONEDAID = (long)(dr["MONEDAID"]);
            }

            if (dr["DESGLOSEIEPS"] != System.DBNull.Value)
            {
                auxUser.IDESGLOSEIEPS = (string)(dr["DESGLOSEIEPS"]);
            }

            if (dr["CUENTAIEPS"] != System.DBNull.Value)
            {
                auxUser.ICUENTAIEPS = (string)(dr["CUENTAIEPS"]);
            }
            if (dr["SUPERLISTAPRECIOID"] != System.DBNull.Value)
            {
                auxUser.ISUPERLISTAPRECIOID = (long)(dr["SUPERLISTAPRECIOID"]);
            }
            if (dr["ALMACENID"] != System.DBNull.Value)
            {
                auxUser.IALMACENID = (long)(dr["ALMACENID"]);
            }
            if (dr["BLOQUEONOT"] != System.DBNull.Value)
            {
                auxUser.IBLOQUEONOT = (string)(dr["BLOQUEONOT"]);
            }

            if (dr["EMAIL3"] != System.DBNull.Value)
            {
                auxUser.IEMAIL3 = (string)(dr["EMAIL3"]);
            }

            if (dr["EMAIL4"] != System.DBNull.Value)
            {
                auxUser.IEMAIL4 = (string)(dr["EMAIL4"]);
            }
            if (dr["CAJASBOTELLAS"] != System.DBNull.Value)
            {
                auxUser.ICAJASBOTELLAS = (string)(dr["CAJASBOTELLAS"]);
            }
            if (dr["ESTATUSENVIOID"] != System.DBNull.Value)
            {
                auxUser.IESTATUSENVIOID = (long)(dr["ESTATUSENVIOID"]);
            }

            if (dr["REPLCREADO"] != System.DBNull.Value)
            {
                auxUser.IREPLCREADO = (DateTime)(dr["REPLCREADO"]);
            }
            if (dr["REPLMODIFICADO"] != System.DBNull.Value)
            {
                auxUser.IREPLMODIFICADO = (DateTime)(dr["REPLMODIFICADO"]);
            }

            if (dr["TICKETLARGOCREDITO"] != System.DBNull.Value)
            {
                auxUser.ITICKETLARGOCREDITO = (string)(dr["TICKETLARGOCREDITO"]);
            }

            if (dr["PENDMAXDIAS"] != System.DBNull.Value)
            {
                auxUser.IPENDMAXDIAS = (int)(dr["PENDMAXDIAS"]);
            }

            if (dr["PAGOPARCIALIDADES"] != System.DBNull.Value)
            {
                auxUser.IPAGOPARCIALIDADES = (string)(dr["PAGOPARCIALIDADES"]);
            }

            if (dr["SALDOVENCIDOMOVIL"] != System.DBNull.Value)
            {
                auxUser.ISALDOVENCIDOMOVIL = (decimal)(dr["SALDOVENCIDOMOVIL"]);
            }


            if (dr["SALDOMOVIL"] != System.DBNull.Value)
            {
                auxUser.ISALDOMOVIL = (decimal)(dr["SALDOMOVIL"]);
            }

            if (dr["GRUPOUSUARIOID"] != System.DBNull.Value)
            {
                auxUser.IGRUPOUSUARIOID = (long)(dr["GRUPOUSUARIOID"]);
            }

            if (dr["CREDITOFORMAPAGOSATABONOS"] != System.DBNull.Value)
            {
                auxUser.ICREDITOFORMAPAGOSATABONOS = (long)(dr["CREDITOFORMAPAGOSATABONOS"]);
            }

            if (dr["SERVICIOADOMICILIO"] != System.DBNull.Value)
            {
                auxUser.ISERVICIOADOMICILIO = (string)(dr["SERVICIOADOMICILIO"]);
            }

            if (dr["ULTIMAVENTA"] != System.DBNull.Value)
            {
                auxUser.IULTIMAVENTA = (DateTime)(dr["ULTIMAVENTA"]);
            }

            if (dr["GENERARRECIBOELECTRONICO"] != System.DBNull.Value)
            {
                auxUser.IGENERARRECIBOELECTRONICO = (string)(dr["GENERARRECIBOELECTRONICO"]);
            }

            if (dr["LOCALIDAD"] != System.DBNull.Value)
            {
                auxUser.ILOCALIDAD = (string)(dr["LOCALIDAD"]);
            }

            if (dr["REFERENCIADOM"] != System.DBNull.Value)
            {
                auxUser.IREFERENCIADOM = (string)(dr["REFERENCIADOM"]);
            }

            if (dr["HAB_PAGOEFECTIVO"] != System.DBNull.Value)
            {
                auxUser.IHAB_PAGOEFECTIVO = (string)(dr["HAB_PAGOEFECTIVO"]);
            }

            if (dr["CLERKPAGOSERVICIOSID"] != System.DBNull.Value)
            {
                auxUser.ICLERKPAGOSERVICIOSID = (long)(dr["CLERKPAGOSERVICIOSID"]);
            }

            if (dr["CLERKSERVICIOS"] != System.DBNull.Value)
            {
                auxUser.ICLERKSERVICIOS = (long)(dr["CLERKSERVICIOS"]);
            }

            if (dr["BANCOMERDOCTOPENDID"] != System.DBNull.Value)
            {
                auxUser.IBANCOMERDOCTOPENDID = (long)(dr["BANCOMERDOCTOPENDID"]);
            }


            if (dr["SOLICITAORDENCOMPRA"] != System.DBNull.Value)
            {
                auxUser.ISOLICITAORDENCOMPRA = (string)(dr["SOLICITAORDENCOMPRA"]);
            }


            if (dr["CUENTACONTPAQ"] != System.DBNull.Value)
            {
                auxUser.ICUENTACONTPAQ = (string)(dr["CUENTACONTPAQ"]);
            }

            if (dr["ESIMPORTADOR"] != System.DBNull.Value)
            {
                auxUser.IESIMPORTADOR = (string)(dr["ESIMPORTADOR"]);
            }

            try
            {
                if (dr["SEPARARPRODXPLAZO"] != System.DBNull.Value)
                {
                    auxUser.ISEPARARPRODXPLAZO = (string)(dr["SEPARARPRODXPLAZO"]);
                }


                //agregar aqui los demas campos que se agreguen, por lo de los passwords


            }
            catch (Exception ex)
            {

            }

            try
            {

                if (dr["CARGOXVENTACONTARJETA"] != System.DBNull.Value)
                {
                    auxUser.ICARGOXVENTACONTARJETA = (string)(dr["CARGOXVENTACONTARJETA"]);
                }
            }
            catch (Exception ex)
            {

            }



            try
            {


                if (dr["PAGOTARJMENORPRECIOLISTA"] != System.DBNull.Value)
                {
                    auxUser.IPAGOTARJMENORPRECIOLISTA = (string)(dr["PAGOTARJMENORPRECIOLISTA"]);
                }
            }
            catch (Exception ex)
            {

            }



            try
            {

                if (dr["SAT_CLAVE_PAIS"] != System.DBNull.Value)
                {
                    auxUser.ISAT_CLAVE_PAIS = (string)(dr["SAT_CLAVE_PAIS"]);
                }


            }
            catch
            {

            }

            try
            {

                if (dr["PROVEECLIENTEID"] != System.DBNull.Value)
                {
                    auxUser.IPROVEECLIENTEID = (long)(dr["PROVEECLIENTEID"]);
                }
            }
            catch
            {

            }

            try
            {

                if (dr["EXENTOIVA"] != System.DBNull.Value)
                {
                    auxUser.IEXENTOIVA = (string)(dr["EXENTOIVA"]);
                }

            }
            catch
            {

            }


            try
            {

                if (dr["TICKETLARGOCOTIZACION"] != System.DBNull.Value)
                {
                    auxUser.ITICKETLARGOCOTIZACION = (string)(dr["TICKETLARGOCOTIZACION"]);
                }


            }
            catch
            {

            }


            try
            {


                if (dr["CODIGOAUTORIZACION"] != System.DBNull.Value)
                {
                    auxUser.ICODIGOAUTORIZACION = (string)(dr["CODIGOAUTORIZACION"]);
                }

            }
            catch
            {

            }


            try
            {
                if (dr["CLIEFORMASPAGODEF"] != System.DBNull.Value)
                {
                    auxUser.ICLIEFORMASPAGODEF = (string)(dr["CLIEFORMASPAGODEF"]);
                }

            }
            catch
            {

            }



            try
            {
                if (dr["POR_COME"] != System.DBNull.Value)
                {
                    auxUser.IPOR_COME = (decimal)(dr["POR_COME"]);
                }
            }
            catch{}


            try
            {
                if (dr["DIAS_EXTR"] != System.DBNull.Value)
                {
                    auxUser.IDIAS_EXTR = (int)(dr["DIAS_EXTR"]);
                }
            }
            catch { }


            try
            {
                if (dr["ADESCPES"] != System.DBNull.Value)
                {
                    auxUser.IADESCPES = (decimal)(dr["ADESCPES"]);
                }
            }
            catch { }


            try
            {

                if (dr["MAYOREOXPRODUCTO"] != System.DBNull.Value)
                {
                    auxUser.IMAYOREOXPRODUCTO = (string)(dr["MAYOREOXPRODUCTO"]);
                }

            }
            catch
            {

            }

            try
            {

                if (dr["GENERACOMPROBTRASL"] != System.DBNull.Value)
                {
                    auxUser.IGENERACOMPROBTRASL = (string)(dr["GENERACOMPROBTRASL"]);
                }

                if (dr["GENERACARTAPORTE"] != System.DBNull.Value)
                {
                    auxUser.IGENERACARTAPORTE = (string)(dr["GENERACARTAPORTE"]);
                }
            }
            catch { }


            try
            {
                if (dr["SAT_COLONIAID"] != System.DBNull.Value)
                {
                    auxUser.ISAT_COLONIAID = (long)(dr["SAT_COLONIAID"]);
                }

                if (dr["SAT_LOCALIDADID"] != System.DBNull.Value)
                {
                    auxUser.ISAT_LOCALIDADID = (long)(dr["SAT_LOCALIDADID"]);
                }

                if (dr["SAT_MUNICIPIOID"] != System.DBNull.Value)
                {
                    auxUser.ISAT_MUNICIPIOID = (long)(dr["SAT_MUNICIPIOID"]);
                }

                if (dr["DISTANCIA"] != System.DBNull.Value)
                {
                    auxUser.IDISTANCIA = (decimal)(dr["DISTANCIA"]);
                }
            }
            catch { }

            try
            {
                if (dr["ENTREGA_SAT_COLONIAID"] != System.DBNull.Value)
                {
                    auxUser.IENTREGA_SAT_COLONIAID = (long)(dr["ENTREGA_SAT_COLONIAID"]);
                }

                if (dr["ENTREGA_SAT_LOCALIDADID"] != System.DBNull.Value)
                {
                    auxUser.IENTREGA_SAT_LOCALIDADID = (long)(dr["ENTREGA_SAT_LOCALIDADID"]);
                }

                if (dr["ENTREGA_SAT_MUNICIPIOID"] != System.DBNull.Value)
                {
                    auxUser.IENTREGA_SAT_MUNICIPIOID = (long)(dr["ENTREGA_SAT_MUNICIPIOID"]);
                }

                if (dr["ENTREGA_DISTANCIA"] != System.DBNull.Value)
                {
                    auxUser.IENTREGA_DISTANCIA = (decimal)(dr["ENTREGA_DISTANCIA"]);
                }

                if (dr["ENTREGAREFERENCIADOM"] != System.DBNull.Value)
                {
                    auxUser.IENTREGAREFERENCIADOM = (string)(dr["ENTREGAREFERENCIADOM"]);
                }


                if (dr["FIRMAIMAGEN"] != System.DBNull.Value)
                {
                    auxUser.IFIRMAIMAGEN = (string)(dr["FIRMAIMAGEN"]);
                }

                if (dr["LATITUD"] != System.DBNull.Value)
                {
                    auxUser.ILATITUD = (double)(dr["LATITUD"]);
                }

                if (dr["LONGITUD"] != System.DBNull.Value)
                {
                    auxUser.ILONGITUD = (double)(dr["LONGITUD"]);
                }
            }
            catch { }


            return auxUser;


        }


    }
}
