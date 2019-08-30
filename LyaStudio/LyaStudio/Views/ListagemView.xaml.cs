using LyaStudio.Models;
using LyaStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LyaStudio.Views
{
   
    public partial class ListagemView : ContentPage
    {
        ListagemViewModel view;
        public ListagemView()
        {
           
           InitializeComponent();
            this.view = new ListagemViewModel();
            this.BindingContext = this.view;
            
        }

        bool teste;
        protected async override void OnAppearing()
        {
            
            base.OnAppearing();
            MessagingCenter.Subscribe<Studio>(this, "StudioSelecionado", (msg) => {

                Navigation.PushAsync(new DetalheView(msg));
            } );
            if (teste == false)
            {
                await this.view.GetStudios();
                teste = true;
            }
            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Studio>(this, "StudioSelecionado");

        }
        
    }
}
