using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckManager.Domain.Entity
{
    public class Modelo : EntityBase
    {
        public string Nome { get; set; } = string.Empty;

        public bool Ativo { get; set; } 
    }
}
