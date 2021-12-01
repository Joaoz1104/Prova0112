using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao1.Model
{
    class Atividade
    {
        public int Id { get; set; }
        public string Serie { get; set; }
        public string Descricao { get; set; }
        public int Repeticao { get; set; }
        public double Peso { get; set; }

        public int FichaId { get; set; }
        public Ficha ficha { get; set; }

        public override string ToString()
        {
            return Serie;
        }
    }
}
