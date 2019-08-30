using System;
using System.Collections.Generic;
using System.Text;

namespace LyaStudio.Models
{

        public class Studio
        {
            public string studioTipo { get; set; }
            public double preco { get; set; }
            public int id { get; set; }
            public string precoFormatado
            {
                get
                {
                    return string.Format("R${0}", preco);
                }
            }

        }
    
}
