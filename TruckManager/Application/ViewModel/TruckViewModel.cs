using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckManager.Application.ViewModel
{
    public class TruckViewModel : ViewModelBase
    {
        public bool Selecionado { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int? IdModelo { get; set; } 
        public string Modelo { get; set; } = string.Empty;
        public int? AnoFabricacao { get; set; }
        public int? AnoModelo { get; set; }
    }
}
