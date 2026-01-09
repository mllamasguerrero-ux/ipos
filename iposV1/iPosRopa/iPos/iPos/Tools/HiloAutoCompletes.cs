using iPosBusinessEntity;
using iPosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

namespace iPos
{
    public class HiloAutoCompletes
    {

        bool m_bSolicitudDeAbortar = false;

        Thread p1;
        private System.Windows.Threading.Dispatcher dispatcher;

        public HiloAutoCompletes()
        {
            this.dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            p1 = new Thread(new ThreadStart(ProcesaAutoCompletes));
        }

        ~HiloAutoCompletes()  // destructor
        {
            // cleanup statements...

        }

        public void IniciarHiloAutoCompletes()
        {
            p1.Start();
        }

        //[SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void DetenerHiloAutoCompletes()
        {
            m_bSolicitudDeAbortar = true;

            //p1.Interrupt();
            if (!p1.Join(1000))
            { // or an agreed resonable time
                p1.Abort();
            }
        }

        public void ProcesaAutoCompletes()
        {
            if(iPos.CurrentUserID.CurrentParameters.IAUTOCOMPLETECONEXISENVENTA == null ||  !iPos.CurrentUserID.CurrentParameters.IAUTOCOMPLETECONEXISENVENTA.Equals("S"))
            return;
            
            while (!m_bSolicitudDeAbortar)
            {
                try
                {
                    CPRODUCTOD daoProducto = new CPRODUCTOD();
                    DataTable listaCambios = null;

                      DateTime ultimoCambioExistencia  = daoProducto.SeleccionarUltimoCambioExistencia(null);

                      if (ultimoCambioExistencia > iPos.CurrentUserID.fechaLastLlenadoAutocompleteConExis && iPos.CurrentUserID.fechaLastLlenadoAutocompleteConExis > DateTime.MinValue)
                        {

                            listaCambios = daoProducto.getProductoNombresConExisChanged(false, iPos.CurrentUserID.fechaLastLlenadoAutocompleteConExis);
                

                           if(listaCambios != null && listaCambios.Rows.Count > 0)
                           {
                              this.dispatcher.Invoke(new Action(() =>
                               {

                                  
                                   foreach(DataRow row in listaCambios.Rows)
                                   {

                                       string claveProducto = row["clave"].ToString().Trim();
                                       string descripcionProducto = row["descripcion1"].ToString().Trim();
                                       string existenciastr = row["existenciastr"].ToString().Trim();
                                       string adicional = row["adicional"].ToString().Trim();
                                       string inventariable = row["inventariable"].ToString().Trim();
                                       string negativos = row["negativos"].ToString().Trim();
                                       decimal existencia = decimal.Parse(row["existencia"].ToString().Trim());

                                      // autoSourceCollection.Add(row[0].ToString().Trim() + " Exist: " + row[3].ToString().Trim() + " " + " <((" + row[1].ToString().Trim() + "))>" + " " + row[2].ToString()); //assuming required data is in first column


                                      string strKeyCurrent = " <((" + claveProducto + "))>" + " ";

                                       bool bEncontrado = false;

                                       List<int> indicesARemover = new List<int>();

                                       for(int i = 0; iPos.CurrentUserID.listadoAutoCompleteProdConExis != null && i < iPos.CurrentUserID.listadoAutoCompleteProdConExis.Count; i++)
                                       {
                                           string strAutoComplete = iPos.CurrentUserID.listadoAutoCompleteProdConExis[i];
                                           
                                           if(strAutoComplete.Contains(strKeyCurrent))
                                           {
                                               if (existencia > 0 || inventariable != "S" || negativos == "S")
                                               {

                                                   strAutoComplete = row[0].ToString().Trim() + " Exist: " + row[3].ToString().Trim() + " " + " <((" + row[1].ToString().Trim() + "))>" + " " + row[2].ToString();
                                                   iPos.CurrentUserID.listadoAutoCompleteProdConExis[i] = strAutoComplete;
                                                   bEncontrado = true;
                                               }
                                               else
                                               {
                                                   indicesARemover.Add(i);
                                               }

                                               break;
                                           }
                                       }

                                       foreach(int i in indicesARemover)
                                       {
                                           iPos.CurrentUserID.listadoAutoCompleteProdConExis.RemoveAt(i);
                                       }

                                       if (!bEncontrado && (existencia > 0 || inventariable != "S" || negativos == "S"))
                                       {
                                           string strAutoComplete = row[0].ToString().Trim() + " Exist: " + row[3].ToString().Trim() + " " + " <((" + row[1].ToString().Trim() + "))>" + " " + row[2].ToString();
                                           if (iPos.CurrentUserID.listadoAutoCompleteProdConExis != null)
                                                iPos.CurrentUserID.listadoAutoCompleteProdConExis.Add(strAutoComplete);
                                       }



                                   }

                                   iPos.CurrentUserID.fechaLastLlenadoAutocompleteConExis = ultimoCambioExistencia;


                              }));
                          }
                      }

                    

                }
                catch
                {

                }

                //Dormir 10 segundos para pruebas..enproduccionminimoseran 30
                Thread.Sleep(30 * 1000);
            }

        }




        string obtenerExistenciaStr(CPRODUCTOBE prod)
        {
                if(prod.IINVENTARIABLE != "S")
                {
                     return "";
                }
                else if(prod.IUNIDAD == "KG")
                {
                    return  prod.IEXISTENCIA.ToString("N3") +  (prod.IEXISTENCIA  >= 1 ? " KG" : " GM");
                }
                else if(prod.IUNIDAD != "PZA" && prod.IUNIDAD != "KG" )
                {
                    return prod.IEXISTENCIA.ToString("N2");

                }
                else if(prod.IPZACAJA == 0 || prod.IPZACAJA == 1)
                {
                    
                    
                    return prod.IEXISTENCIA.ToString("N2") + " PZAS";
                }
                else
                {
                    return Math.Floor(prod.IEXISTENCIA / prod.IPZACAJA).ToString("N0") + " cajas " +  (prod.IEXISTENCIA % prod.IPZACAJA).ToString("N0") + " piezas";
                }
                        

        }
    }
}
