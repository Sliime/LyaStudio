using LyaStudio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LyaStudio.ViewModels
{
    public class ListagemViewModel
    {
        const string URL_GET_STUDIOS = "https://navestudio20190828104253.azurewebsites.net/Api";

        Studio studioSelecionado;
        public Studio StudioSelecionado {
            get { return studioSelecionado; }
            set { studioSelecionado = value;
                if (value != null) 
                 MessagingCenter.Send(studioSelecionado, "StudioSelecionado");
            } }

        
        public ObservableCollection<Studio> Studios { get; set; }

    



        public ListagemViewModel()
        {
            this.Studios = new ObservableCollection<Studio>();


        }

        public async Task GetStudios()
        {
            HttpClient Cliente = new HttpClient();

            var result = await Cliente.GetStringAsync(URL_GET_STUDIOS);

           var StudioJason = JsonConvert.DeserializeObject<EstudioJson[]>(result);

            foreach(var ESTUDIO in StudioJason)
            {
                this.Studios.Add(new Studio { studioTipo = ESTUDIO.nome, preco = ESTUDIO.preco, id = ESTUDIO.id });
            }
        }
    }

    public class EstudioJson
    {
        public string codigo { get; set; }
        public string nome { get; set; }
        public double preco { get; set; }
        public  int id { get; set; }
    }


}
