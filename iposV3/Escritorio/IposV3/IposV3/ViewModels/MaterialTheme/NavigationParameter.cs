using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.ViewModels
{
    public class NavigationParameter
    {
        public NavigationParameter(object? content, bool keepHistory, bool goBack)
        {
            Content = content;
            KeepHistory = keepHistory;
            GoBack = goBack;
        }
        public object? Content { get; set; }
        public bool KeepHistory { get; set; }
        public bool GoBack { get; set; }
    }
}
