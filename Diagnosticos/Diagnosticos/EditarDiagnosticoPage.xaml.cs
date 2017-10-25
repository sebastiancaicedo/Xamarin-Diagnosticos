using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Diagnosticos
{
    public struct InfoDiagnostico
    {
        public int Indice { get; set; }
        public string Diagnostico { get; set; }

        public InfoDiagnostico(int indice, string diagnostico)
        {
            Indice = indice;
            Diagnostico = diagnostico;
        }
    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarDiagnosticoPage : ContentPage
	{
        public event EventHandler<InfoDiagnostico> Finalizar;

        private InfoDiagnostico infoDiagnostico;

		public EditarDiagnosticoPage (InfoDiagnostico infoDiagnostico)
		{
            this.infoDiagnostico = infoDiagnostico;
            Title = "Editar Diagnostico";
			InitializeComponent ();
            BindingContext = infoDiagnostico.Diagnostico;
		}

        public void Aceptar(object sender, EventArgs e)
        {
            string nuevoDiagnostico = entryDiagnostico.Text;
            if (!String.IsNullOrEmpty(nuevoDiagnostico))
            {
                infoDiagnostico.Diagnostico = nuevoDiagnostico;
                Finalizar(this, infoDiagnostico);
                Navigation.PopAsync();
            }
        }
	}
}