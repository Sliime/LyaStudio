using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LyaStudio.Views
{
    public class Studio
    {
        public string studioTipo { get; set; }
        public  double preco { get; set; }
        public string precoFormatado { get{
                return string.Format("R${0}", preco);
            } }

    }
    public partial class ListagemView : ContentPage
    {

        public List<Studio> Studios { get; set; }

        public ListagemView()
        {
           
            InitializeComponent();

            this.Studios = new List<Studio>
            {
                new Studio { studioTipo = "Gravação", preco = 100.00 },
                new Studio { studioTipo="Ensaio", preco = 50.00}

            };



           BindingContext = this;
        }

        async void ListViewStudio_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var studio = (Studio)e.Item;

           await Navigation.PushAsync(new DetalheView(studio));

        }
    }
}
