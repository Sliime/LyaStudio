using LyaStudio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LyaStudio.ViewModels
{
   public class DetalheViewModel
    {
        public Studio StudioTipoNome { get; set; }

        public string textoDetalhe { get { return ($"Você irá utilizar o estúdio para {StudioTipoNome.studioTipo}, que irá custar {StudioTipoNome.precoFormatado} "); } }

        public DetalheViewModel(Studio studio)
        {
            StudioTipoNome = studio;
            ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send(studio, "proximo");
            });
        }

        public ICommand ProximoCommand { get; set; }
    }
}
