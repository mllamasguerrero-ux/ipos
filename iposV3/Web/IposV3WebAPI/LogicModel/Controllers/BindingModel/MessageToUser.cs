using MvvmFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingModels
{
    public class MessageToUser : Validatable
    {
        public MessageToUser()
        {
            title = "";
            message = "";
            tipo = "Information";
            isOpen = true;
            openProgress = 0;
            staysOpen = true;

        }

        public MessageToUser(string title, string message, string tipo, bool isOpen)
        {

            this.title = title;
            this.message = message;
            this.tipo = tipo;
            this.isOpen = isOpen;
            this.openProgress = 0;
            this.staysOpen = true;
        }

        private string title;
        private string message;
        private string tipo;
        private bool isOpen ;
        private int openProgress ;
        private bool staysOpen;


        public string Title { get => title; set { title = value; OnPropertyChanged(); } }
        public string Message { get => message; set { message = value; OnPropertyChanged(); } }
        public string Tipo { get => tipo; set { tipo = value; OnPropertyChanged(); } }
        public bool IsOpen { get => isOpen; set { isOpen = value; OnPropertyChanged(); } }

        public int OpenProgress { get => openProgress; set { openProgress = value; OnPropertyChanged(); } }

        public bool StaysOpen { get => staysOpen; set { staysOpen = value; OnPropertyChanged(); } }
    }

    public enum MessageType { success, warning, information, error }

    public class MessageToUserSimple
    {


        public string Title { get; set; }
        public string Message { get; set; }
        public string Tipo { get; set; }

        public MessageToUserSimple(string title, string message, string tipo)
        {
            Title = title;
            Message = message;
            Tipo = tipo;
        }
    }
}
