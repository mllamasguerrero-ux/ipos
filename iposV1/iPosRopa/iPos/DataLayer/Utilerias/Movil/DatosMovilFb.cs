using DataLayer.Movil.businessData.MOVILANDROID;
using iPosBusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Utilerias.Movil
{
    public class DatosMovilFb
    {
        private string comentario;
        public string Comentario { get => comentario; set => comentario = value; }

        public bool ExportarDatosAFb(
            List<CPERSONABE> clientes,
            long doctoId,
            string manejaKits,
            long cobranzaId,
            string claveVendedor,
            long tipoVendedor)
        {
            if (!ExportarProdFb(doctoId))
                return false;

            if (!ExportarClipFb(clientes, tipoVendedor))
                return false;
            
            if(cobranzaId > 0)
                if (!ExportarCrepFb(cobranzaId, claveVendedor))
                    return false;

            if (!ExportarBankFb())
                return false;
            if (!String.IsNullOrEmpty(manejaKits) && manejaKits.Equals("S"))
                if (!ExportarKitsFb())
                    return false;

            if (!ExportarEdosFb())
                return false;

            return true;
        }

        private bool ExportarProdFb(long doctoId)
        {
            try
            {
                CPRODDROIDD prodDao = new CPRODDROIDD();
                if (!prodDao.LlenarTabla(doctoId))
                    throw new Exception(prodDao.IComentario);

                return true;
            }
            catch (Exception e)
            {
                comentario = e.Message;
                return false;
            }
        }

        private bool ExportarClipFb(List<CPERSONABE> clientes, long tipoVendedor)
        {
            try
            {
                CMCLIPDROIDD clipDao = new CMCLIPDROIDD();
                if (!clipDao.LlenarTabla(clientes, tipoVendedor))
                    throw new Exception(clipDao.IComentario);

                return true;
            }
            catch (Exception e)
            {
                comentario = e.Message;
                return false;
            }
        }

        private bool ExportarBankFb()
        {
            try
            {
                CMBANKDROIDD bankDao = new CMBANKDROIDD();
                if (!bankDao.LlenarTabla())
                    throw new Exception(bankDao.IComentario);

                return true;
            }
            catch (Exception e)
            {
                comentario = e.Message;
                return false;
            }
        }

        private bool ExportarEdosFb()
        {
            try
            {
                CMEDOSDROIDD edosDao = new CMEDOSDROIDD();
                if (!edosDao.LlenarTabla())
                    throw new Exception(edosDao.IComentario);

                return true;
            }
            catch (Exception e)
            {
                comentario = e.Message;
                return false;
            }
        }

        private bool ExportarKitsFb()
        {
            try
            {
                CMKITSDROIDD kitsDao = new CMKITSDROIDD();
                if (!kitsDao.LlenarTabla())
                    throw new Exception(kitsDao.IComentario);

                return true;
            }
            catch (Exception e)
            {
                comentario = e.Message;
                return false;
            }
        }

        private bool ExportarCrepFb(long crepId, string claveVendedor)
        {
            try
            {
                CMCREPDROIDD cobranzaDao = new CMCREPDROIDD();

                cobranzaDao.LlenarTabla(crepId, claveVendedor);
                return true;
            }
            catch (Exception e)
            {
                comentario = e.Message;
                return false;
            }
        }
    }
}
