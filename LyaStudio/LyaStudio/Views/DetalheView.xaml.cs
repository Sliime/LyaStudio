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
	public partial class DetalheView : ContentPage
	{
        public Studio StudioTipoNome { get; set; }

        public DetalheView (Studio servicoNome)
		{
            // this.Title = servicoNome.studioTipo;
            InitializeComponent();
            StudioTipoNome = servicoNome;
            BindingContext = new DetalheViewModel(servicoNome);
		}


        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Studio>(this, "proximo", (msg) =>
            {
                Navigation.PushAsync(new AgendamentoView(msg));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Studio>(this, "proximo");
            MessagingCenter.Unsubscribe<Studio>(this, "StudioSelecionado");
        }

    }
}