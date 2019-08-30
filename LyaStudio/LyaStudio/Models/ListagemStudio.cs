using System;
using System.Collections.Generic;
using System.Text;

namespace LyaStudio.Models
{
    public class ListagemStudio
    {
        
        public ListagemStudio()
        {
            this.Studios = new List<Studio>
            {
                new Studio { studioTipo = "Gravação", preco = 100.00 },
                new Studio { studioTipo="Ensaio", preco = 50.00},
                new Studio { studioTipo="qqqq", preco = 50.00}

            };


        }

        public List<Studio> Studios { get; }
    }
}
