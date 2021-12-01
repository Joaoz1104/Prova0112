using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao1.Model
{
    class Ficha
    {
        public int Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string NomeInstrutor { get; set; }

        public override string ToString()
        {
            return NomeInstrutor;
        }
    }
}
