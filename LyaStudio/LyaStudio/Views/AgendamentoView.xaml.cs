using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LyaStudio.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoView : ContentPage
	{
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public DateTime dataAgendamento = DateTime.Today;

        public DateTime DataAgendamento {
            get
            {
                return dataAgendamento;
            }
            set {

                dataAgendamento = value;

                }
            }





        public TimeSpan HoraAgendamento { get; set; }


        public AgendamentoView (Studio studio)
		{
            this.Title = studio.studioTipo;

            this.BindingContext = this;
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento", 
         string.Format(@"  
         Nome: {0}
         Email: {1}
         Data: {2}
         Hora:{3}", Nome, Email, Celular, DataAgendamento.ToString("dd/MM/yyyy")), "Ok" );
        }
    }
}