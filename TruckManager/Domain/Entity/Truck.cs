using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckManager.Domain.Entity
{
    public class Truck : EntityBase
    {
        public string Nome { get; set; } = string.Empty;
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public int IdModelo { get; set; }
        public virtual Modelo Modelo { get; set; }

        public bool IsAnoFabricacaoIgualAnoAtual()
        {
            int anoAtual = DateTime.Now.Year;

            if (AnoFabricacao == anoAtual)
            {
                return true;
            }
            return false;
        }

        public bool IsAnoModeloIgualAnoSubsequente()
        {
            int anoSubsequente = DateTime.Now.AddYears(1).Year;

            if (AnoModelo == anoSubsequente)
            {
                return true;
            }
            return false;
        }

        public bool IsAnoModeloIgualAnoAtual()
        {
            int anoAtual = DateTime.Now.Year;

            if (AnoModelo == anoAtual)
            {
                return true;
            }
            return false;
        }
    }
}
