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
		public AgendamentoView (Studio studio)
		{
            this.Title = studio.studioTipo;


			InitializeComponent ();
		}


    }
}