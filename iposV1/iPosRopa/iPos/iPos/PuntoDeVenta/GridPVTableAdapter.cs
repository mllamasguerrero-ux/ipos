using System.Data.SqlClient;
namespace iPos.PuntoDeVenta.DSPuntoDeVentaAuxTableAdapters
{
    public partial class GRIDPVTableAdapter
    {
        public int SelectCommandTimeout
        {
            get
            {
                return this.CommandCollection[0].CommandTimeout;
            }
            set
            {
                this.CommandCollection[0].CommandTimeout = value;
                /*for (int i = 0; i < this._commandCollection.Length; i++)
                {
                    if ((this._commandCollection[i] != null))
                    {
                        ((FirebirdSql.Data.FirebirdClient.FbCommand)
                         (this._commandCollection[i])).CommandTimeout = value;
                    }
                }*/
            }
        }
    }
}