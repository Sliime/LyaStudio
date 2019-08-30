using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyaStudio.Models;
using LyaStudio.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LyaStudio.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoView : ContentPage
	{

        public AgendamentoViewModel view;


        public AgendamentoView (Studio studio)
		{
            InitializeComponent();

            this.view = new AgendamentoViewModel(studio);
            this.BindingContext = this.view;
			
		}



        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async(msg)  =>
            {
                var alerta= await DisplayAlert
                ("Salvar Agendamento", "Deseja mesmo enviar seu agendamento?", "Sim", "Não");

              if(alerta)
                {
                    this.view.SalvaAgendamento();
                }
              
            });

            MessagingCenter.Subscribe<Agendamento>(this, "Sucess", (msg) =>
            {
                DisplayAlert("Agendamento", "Agendamento enviado com sucesso", "Ok");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento", (msg) =>
            {
                DisplayAlert("Horario ocupado ou servidor fora do ar", "Olá, talvez seu horario já esteja ocupado ou o servidor esta com problemas","Ok");
            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "Sucess");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}