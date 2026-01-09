using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSGetProducta4App.DAO.businessEntity
{
    public class InvMovilDocto
    {
        private int id;
        private DateTime fecha;
        private string usuario;
        private string dispositivo;
        private string sucursalClave;
        private string estatus;

        public int Id { get => id; set => id = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Dispositivo { get => dispositivo; set => dispositivo = value; }
        public string SucursalClave { get => sucursalClave; set => sucursalClave = value; }
        public string Estatus { get => estatus; set => estatus = value; }
    }
}