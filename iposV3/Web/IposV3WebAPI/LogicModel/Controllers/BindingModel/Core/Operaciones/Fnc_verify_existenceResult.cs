
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
    public class Fnc_verify_existenceResult
    {


    public Fnc_verify_existenceResult() { }

    




    public BoolCS? Hayexistencia { get; set; }  

    public string? Usermessage { get; set; }  

    public string? Devmessage { get; set; }  

    public decimal? Existencia { get; set; }  

    public decimal? Existenciaparaarmarkit { get; set; }  

    public decimal? Existenciatotal { get; set; }  

    public decimal? Enprocesodesalida { get; set; }  

    public long? Result { get; set; }  


  }
}

