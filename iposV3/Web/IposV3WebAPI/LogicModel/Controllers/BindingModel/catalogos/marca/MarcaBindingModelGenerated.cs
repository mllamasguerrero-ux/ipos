
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MvvmFramework;
using System.Xml.Serialization;
using IposV3.Model;

namespace BindingModels
{
    [XmlRoot]
    public class MarcaBindingModelGenerated : Validatable, IBaseBindingModel
    {

        //protected Marca? item;

        public MarcaBindingModelGenerated()
        {
            //item = new Marca();
        }
        
        #if PROYECTO_WEB
        public MarcaBindingModelGenerated(Marca item)
        {
            FillFromEntity(item);
        }
        #endif
        

        //public Marca? Item { get => item; set => item = value; }



        private BoolCS? activo ;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCS Activo { get => activo ?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, activo)) { activo = value; OnPropertyChanged(); } } }


        private string? clave;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public string Clave { get => clave ?? ""; set { if (RaiseAcceptPendingChange(value, clave)) { clave = value; OnPropertyChanged(); } } }


        private string? nombre;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public string Nombre { get => nombre ?? ""; set { if ( RaiseAcceptPendingChange(value, nombre)) { nombre = value; OnPropertyChanged(); } } }


        private BoolCN? descontinuado;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public BoolCN Descontinuado { get => descontinuado ?? BoolCN.N; set { if ( RaiseAcceptPendingChange(value, descontinuado)) { descontinuado = value; OnPropertyChanged(); } } }



        private long? empresaId;
        [XmlAttribute]
        public long? EmpresaId { get => empresaId; set { if ( RaiseAcceptPendingChange(value, empresaId)) { empresaId = value ?? 0; OnPropertyChanged(); } } }



        public long? sucursalId;
        [XmlAttribute]
        public long? SucursalId { get => sucursalId; set { if (RaiseAcceptPendingChange(value, sucursalId)) { sucursalId = value ?? 0; OnPropertyChanged(); } } }



        private long? id;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public long? Id { get => id; set { if ( RaiseAcceptPendingChange(value, id)) { id = value ?? 0; OnPropertyChanged(); } } }


        private DateTimeOffset? creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => creado; set { if (RaiseAcceptPendingChange(value, creado)) { creado = value ?? DateTime.Now; OnPropertyChanged(); } } }


        private long? creadoPorId;
        [XmlAttribute]
        public long? CreadoPorId { get => creadoPorId; set { if ( RaiseAcceptPendingChange(value, creadoPorId)) { creadoPorId = value; OnPropertyChanged(); } } }



        private DateTimeOffset? modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => modificado; set { if (RaiseAcceptPendingChange(value, modificado)) { modificado = value ?? DateTime.Now; OnPropertyChanged(); } } }


        private long? modificadoPorId;
        [XmlAttribute]
        public long? ModificadoPorId { get => modificadoPorId; set { if (RaiseAcceptPendingChange(value, modificadoPorId)) { modificadoPorId = value; OnPropertyChanged(); } } }



        public static string GetBaseQuery()
        {
            return $@"SELECT * FROM ""Marca"" Where ""EmpresaId"" = @1 and ""SucursalId"" = @2 ";
        }


        public static string GetFieldsForGeneralSearch()
        {
            return @"""Clave""|""Nombre""";
        }
        
        #if PROYECTO_WEB
        
        public void FillEntityValues(ref Marca item)
        {
            item.Activo = this.Activo;
            item.SucursalId = this.SucursalId ?? 0;
            item.EmpresaId = this.EmpresaId ?? 0;
            item.Creado = this.Creado ?? DateTimeOffset.Now;
            item.CreadoPorId = this.CreadoPorId;
            item.Modificado = this.Modificado ?? DateTimeOffset.Now;
            item.ModificadoPorId = this.ModificadoPorId;
            item.Clave = this.Clave;
            item.Nombre = this.Nombre;
            item.Descontinuado = this.Descontinuado;
            item.Id = this.Id ?? 0;
        }

        public void FillFromEntity(Marca item)
        {

            Activo = item.Activo;
            SucursalId = item.SucursalId;
            EmpresaId = item.EmpresaId;
            Creado = item.Creado;
            CreadoPorId = item.CreadoPorId;
            Modificado = item.Modificado;
            ModificadoPorId = item.ModificadoPorId;
            Clave = item.Clave;
            Nombre = item.Nombre;
            Descontinuado = item.Descontinuado;
            Id = item.Id;
        }
        #endif



    }

    public class MarcaParamGenerated : BaseParam
    {

        public MarcaParamGenerated() : base()
        {

        }

        public MarcaParamGenerated(BaseParam baseParam) : this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {

        }
        public MarcaParamGenerated(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

            this.EmpresaId = 0;

            this.SucursalId = 0;

            this.Id = 0;


        }



        public MarcaParamGenerated(long? empresaid, long? sucursalid
                    , long? EmpresaId
                    , long? SucursalId
                    , long? Id
                  ) : base(empresaid, sucursalid)
        {

            this.EmpresaId = EmpresaId;

            this.SucursalId = SucursalId;

            this.Id = Id;

        }



        public long? EmpresaId { get; set; }

        public long? SucursalId { get; set; }

        public long? Id { get; set; }




    }


}

