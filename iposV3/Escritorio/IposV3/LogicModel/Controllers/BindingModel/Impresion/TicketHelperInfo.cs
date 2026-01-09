using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingModels
{
    public class TicketHelperInfo
    {
        public string? Template { get; set; }
        public object? TemplateValues { get; set; }
        public string? Printer { get; set; }
        public bool AbrirCajon { get; set; }
        public int Letra { get; set; }
        public Dictionary<string, string>? Condiciones { get; set; }

       
    }
}
