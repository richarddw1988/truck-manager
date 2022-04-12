using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckManager.Application.ViewModel
{
    public class ModeloViewModel : ViewModelBase
    {
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}
