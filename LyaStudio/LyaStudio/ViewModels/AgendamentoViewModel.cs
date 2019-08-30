using LyaStudio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LyaStudio.ViewModels
{
    public class AgendamentoViewModel
    {
        public Studio Studio { get; set; }

        const string URLPOST = "https://navestudio20190828104253.azurewebsites.net/Api";

        Agendamento Agendamento = new Agendamento();
        public string Nome { get { return Agendamento.Nome; } set { Agendamento.Nome = value; } }
        public string Email { get { return Agendamento.Email; } set { Agendamento.Email = value; } }
        public string Celular { get { return Agendamento.Celular; } set { Agendamento.Celular = value; } }

        public DateTime DataAgendamento
        {
            get
            {
                return Agendamento.dataAgendamento;
            }
            set
            {

                Agendamento.dataAgendamento = value;

            }
        }

        public TimeSpan HoraAgendamento { get; set; }

        public TimeSpan HoraAgendamentoSaida { get; set; }


        public AgendamentoViewModel(Studio studio)
        {
            Studio = studio;
            AgendarCommand = new Command(()=> 
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "Agendamento");

            });

        }

        public async void SalvaAgendamento()
        {
            HttpClient Cliente = new HttpClient();

            var datahoraEntrada = new DateTime(DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds);
            var datahoraSaida = new DateTime(DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                HoraAgendamentoSaida.Hours, HoraAgendamentoSaida.Minutes, HoraAgendamentoSaida.Seconds);

            var json = JsonConvert.SerializeObject(new
            {
                Nome = Nome,
                Email = Email,
                NumeroCelular = Celular,
                HoraEntrada = datahoraEntrada,
                HoraSaida = datahoraSaida,
                ProdutoId = Studio.id
            }
                ) ;

            var conteudo = new StringContent(json,Encoding.UTF8, "application/json");


           var resposta= await Cliente.PostAsync(URLPOST, conteudo );

            if (resposta.IsSuccessStatusCode)
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "Sucess");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            }
        }

        public ICommand AgendarCommand { get; set; }

    }
}
