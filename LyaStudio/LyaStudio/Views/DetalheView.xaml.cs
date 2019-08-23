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
	public partial class DetalheView : ContentPage
	{

        public Studio StudioTipoNome { get; set; }

        public string textoDetalhe { get { return ($"Você irá utilizar o estúdio para {StudioTipoNome.studioTipo}, que irá custar {StudioTipoNome.precoFormatado} "); } }
        

        public DetalheView (Studio servicoNome)
		{
           // this.Title = servicoNome.studioTipo;
            StudioTipoNome = servicoNome;
            BindingContext = this;
			InitializeComponent ();
		}

    
        private void BotaoProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(StudioTipoNome));
        }
    }
}