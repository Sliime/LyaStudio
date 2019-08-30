using System;
using System.Collections.Generic;
using System.Text;

namespace LyaStudio.Models
{
    public class Agendamento
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public DateTime dataAgendamento = DateTime.Today;
        public DateTime DataAgendamento
        {
            get
            {
                return dataAgendamento;
            }
            set
            {

                dataAgendamento = value;

            }
        }
        public TimeSpan HoraAgendamento { get; set; }







    }
}
